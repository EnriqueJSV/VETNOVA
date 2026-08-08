using DAL_VETNOVA.Entidades;
using BLL_VETNOVA.Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace PL_VETNOVA.Pantallas.Catalogos
{
    public partial class frmCatalogos : Form
    {
        #region Variables Globales o de Entidades

        public cls_Usuarios_DAL obj_Usuario_Global_DAL;
        public cls_Usuarios_BLL obj_Usuario_Global_BLL = new cls_Usuarios_BLL();

        public cls_Especies_DAL obj_Especies_Global_DAL = new cls_Especies_DAL();
        public cls_Especies_BLL obj_Especies_Global_BLL = new cls_Especies_BLL();

        public cls_Razas_DAL obj_Razas_Global_DAL = new cls_Razas_DAL();
        public cls_Razas_BLL obj_Razas_Global_BLL = new cls_Razas_BLL();

        public cls_Especialidades_DAL obj_Especialidades_Global_DAL = new cls_Especialidades_DAL();
        public cls_Especialidades_BLL obj_Especialidades_Global_BLL = new cls_Especialidades_BLL();

        public cls_Tipos_Identificacion_DAL obj_TiposIdentificacion_Global_DAL = new cls_Tipos_Identificacion_DAL();
        public cls_Tipos_Identificacion_BLL obj_TiposIdentificacion_Global_BLL = new cls_Tipos_Identificacion_BLL();

        // DataTables en memoria para poder filtrar con DataView.RowFilter
        // (busqueda por texto y, en Razas, el cascadeo por especie) sin pegarle
        // otra vez a la base de datos.
        private DataTable dtEspecies;
        private DataTable dtRazas;
        private DataTable dtEspecialidades;
        private DataTable dtTiposIdentificacion;

        // Vistas filtrables sobre cada DataTable, mismo patron que vistaCitas
        // en frmCitas: se crean al cargar y se les aplica RowFilter en memoria.
        private DataView vistaEspecies;
        private DataView vistaRazas;
        private DataView vistaEspecialidades;
        private DataView vistaTiposIdentificacion;

        // Si es null, el panel de alta/edicion respectivo esta en modo "Nuevo" (INSERT).
        // Si tiene valor, esta en modo "Editar" (UPDATE) sobre ese Id.
        private int? idEspecieEnEdicion = null;
        private int? idRazaEnEdicion = null;
        private int? idEspecialidadEnEdicion = null;
        private int? idTipoIdentificacionEnEdicion = null;

        #endregion

        public frmCatalogos()
        {
            InitializeComponent();

            // Se fuerza aca en codigo porque los grids se bindean directo a un
            // DataView (dgvX.DataSource = vistaX en CargarX()). Sin esto, cada
            // vez que se recarga el grid, WinForms vuelve a autogenerar columnas
            // de mas ademas de las que ya definimos a mano en el Designer.
            dgvEspecies.AutoGenerateColumns = false;
            dgvRazas.AutoGenerateColumns = false;
            dgvEspecialidades.AutoGenerateColumns = false;
            dgvTiposIdentificacion.AutoGenerateColumns = false;
        }

        #region Eventos Form

        private void frmCatalogos_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();

            CargarEspecies();
            CargarEspecieRazaCombo();
            CargarRazas();
            CargarEspecialidades();
            CargarTiposIdentificacion();
        }

        private void frmCatalogos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Refresca el combo de especies de Razas cada vez que el usuario entra
        // a esa pestaña, para que si acaba de agregar una especie nueva en el
        // tab de Especies, ya aparezca aqui sin tener que reabrir el formulario.
        private void tabCatalogos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCatalogos.SelectedTab == tabRazas)
            {
                CargarEspecieRazaCombo();
            }
        }

        // Igual que en frmCitas: obj_Usuario_Global_DAL ya viene con
        // iId_Usuario asignado desde frmMenuAdmin; aca completamos el resto
        // de sus datos (nombre, rol) para pintar lblInfoUsuario.
        private void cargaDatosUsuarioGlobal()
        {
            try
            {
                obj_Usuario_Global_BLL.CargaDatosUsuario(ref obj_Usuario_Global_DAL);

                if (obj_Usuario_Global_DAL.sMsjError == string.Empty)
                {
                    if (obj_Usuario_Global_DAL.dtDatos.Rows.Count > 0)
                    {
                        obj_Usuario_Global_DAL.sNombre_Usuario = obj_Usuario_Global_DAL.dtDatos.Rows[0][2].ToString();
                        obj_Usuario_Global_DAL.iId_Rol = Convert.ToInt32(obj_Usuario_Global_DAL.dtDatos.Rows[0][4]);
                        obj_Usuario_Global_DAL.sNombreRol = obj_Usuario_Global_DAL.dtDatos.Rows[0][5].ToString();

                        lblInfoUsuario.Text = "Usuario: " + obj_Usuario_Global_DAL.sNombre_Usuario + " | Rol: " + obj_Usuario_Global_DAL.sNombreRol;
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar cargar la información del usuario: " + obj_Usuario_Global_DAL.sMsjError, "Información de Usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar cargar la información del usuario. Error: " + ex.ToString(), "Información de Usuario",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Especies TAB

        private void CargarEspecies()
        {
            obj_Especies_Global_BLL.ListarEspecies(ref obj_Especies_Global_DAL);

            if (!string.IsNullOrEmpty(obj_Especies_Global_DAL.sMsjError))
            {
                MessageBox.Show("Error al cargar especies: " + obj_Especies_Global_DAL.sMsjError,
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dtEspecies = obj_Especies_Global_DAL.dtDatos;
            vistaEspecies = new DataView(dtEspecies);
            dgvEspecies.DataSource = vistaEspecies;

            FiltrarEspecies(); // reaplica lo que haya en txtBuscarEspecie sobre los datos frescos
        }

        private void FiltrarEspecies()
        {
            if (vistaEspecies == null)
            {
                return;
            }

            string sFiltro = txtBuscarEspecie.Text.Trim().Replace("'", "''"); // escapa comillas simples para no romper el RowFilter

            vistaEspecies.RowFilter = string.IsNullOrEmpty(sFiltro)
                ? string.Empty
                : "Especie LIKE '%" + sFiltro + "%'";
        }

        private void txtBuscarEspecie_TextChanged(object sender, EventArgs e)
        {
            FiltrarEspecies();
        }

        private void btnNuevaEspecie_Click(object sender, EventArgs e)
        {
            idEspecieEnEdicion = null;
            lblFormTituloEspecie.Text = "Nueva especie";
            btnGuardarEspecie.Text = "Guardar";

            LimpiarFormularioEspecie();
            pnlFormEspecie.Visible = !pnlFormEspecie.Visible;
        }

        private void btnCancelarEspecie_Click(object sender, EventArgs e)
        {
            idEspecieEnEdicion = null;
            lblFormTituloEspecie.Text = "Nueva especie";
            btnGuardarEspecie.Text = "Guardar";

            pnlFormEspecie.Visible = false;
            LimpiarFormularioEspecie();
        }

        private void btnGuardarEspecie_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreEspecie.Text) || cboEstadoEspecie.SelectedIndex == -1)
            {
                MessageBox.Show("Completa el nombre y el estado antes de guardar.", "Especies",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // El combo muestra "Activo"/"Inactivo" pero la BD guarda "A"/"I".
            string sEstado = cboEstadoEspecie.SelectedItem.ToString() == "Activo" ? "A" : "I";

            obj_Especies_Global_DAL.sEspecie = txtNombreEspecie.Text.Trim();
            obj_Especies_Global_DAL.sEstado = sEstado;
            obj_Especies_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

            if (idEspecieEnEdicion.HasValue)
            {
                obj_Especies_Global_DAL.iId_Especie = idEspecieEnEdicion.Value;
                obj_Especies_Global_BLL.ActualizarEspecie(ref obj_Especies_Global_DAL);

                if (obj_Especies_Global_DAL.sValorScalar == "-2")
                {
                    MessageBox.Show("La especie ya no existe (puede que la hayan eliminado). Se va a refrescar la lista.", "Editar especie",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (obj_Especies_Global_DAL.sValorScalar == "-1")
                {
                    MessageBox.Show("Ya existe otra especie con ese nombre.", "Editar especie",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (string.IsNullOrEmpty(obj_Especies_Global_DAL.sMsjError))
                {
                    MessageBox.Show("La especie se actualizó correctamente.", "Editar especie",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar actualizar la especie: " + obj_Especies_Global_DAL.sMsjError, "Editar especie",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                obj_Especies_Global_BLL.InsertarEspecie(ref obj_Especies_Global_DAL);

                if (obj_Especies_Global_DAL.sValorScalar == "-1")
                {
                    MessageBox.Show("Ya existe una especie con ese nombre.", "Nueva especie",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (string.IsNullOrEmpty(obj_Especies_Global_DAL.sMsjError))
                {
                    MessageBox.Show("La especie se guardó correctamente.", "Nueva especie",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar guardar la especie: " + obj_Especies_Global_DAL.sMsjError, "Nueva especie",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            idEspecieEnEdicion = null;
            lblFormTituloEspecie.Text = "Nueva especie";
            btnGuardarEspecie.Text = "Guardar";
            pnlFormEspecie.Visible = false;
            LimpiarFormularioEspecie();
            CargarEspecies();

            // Si acabamos de agregar/editar una especie, el combo de Razas
            // (que probablemente ya esta cargado desde el Load) debe reflejar
            // el cambio de inmediato, sin esperar a que el usuario cambie de tab.
            CargarEspecieRazaCombo();
        }

        private void btnModificarEspecie_Click(object sender, EventArgs e)
        {
            if (!(dgvEspecies.CurrentRow?.DataBoundItem is DataRowView fila))
            {
                MessageBox.Show("Selecciona una especie de la lista.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            idEspecieEnEdicion = Convert.ToInt32(fila["Id_Especie"]);

            txtNombreEspecie.Text = fila["Especie"].ToString();
            cboEstadoEspecie.SelectedItem = fila["Estado"].ToString() == "A" ? "Activo" : "Inactivo";

            lblFormTituloEspecie.Text = "Editar especie";
            btnGuardarEspecie.Text = "Guardar cambios";
            pnlFormEspecie.Visible = true;
        }

        private void btnEliminarEspecie_Click(object sender, EventArgs e)
        {
            if (!(dgvEspecies.CurrentRow?.DataBoundItem is DataRowView fila))
            {
                MessageBox.Show("Selecciona una especie de la lista.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sNombre = fila["Especie"].ToString();

            DialogResult dr = MessageBox.Show($"¿Eliminar la especie \"{sNombre}\"?",
                "VetNova", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            obj_Especies_Global_DAL.iId_Especie = Convert.ToInt32(fila["Id_Especie"]);
            obj_Especies_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

            obj_Especies_Global_BLL.EliminarEspecie(ref obj_Especies_Global_DAL);

            if (!string.IsNullOrEmpty(obj_Especies_Global_DAL.sMsjError))
            {
                MessageBox.Show("Error al eliminar: " + obj_Especies_Global_DAL.sMsjError,
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (obj_Especies_Global_DAL.sValorScalar == "-1")
            {
                MessageBox.Show("No se puede eliminar: tiene razas asociadas.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (obj_Especies_Global_DAL.sValorScalar == "-2")
            {
                MessageBox.Show("El registro ya no existe, probablemente lo eliminaron en otra sesion.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            CargarEspecies();
            CargarEspecieRazaCombo();
        }

        private void LimpiarFormularioEspecie()
        {
            txtNombreEspecie.Clear();
            cboEstadoEspecie.SelectedIndex = -1;
            cboEstadoEspecie.SelectedItem = "Activo";
        }

        #endregion

        #region Razas TAB

        // Carga TODAS las especies en cboEspecieRaza. Se llama en el Load, cada
        // vez que el usuario entra a la pestaña Razas (ver tabCatalogos_SelectedIndexChanged)
        // y despues de insertar/editar una especie en el tab de Especies, para
        // que el combo nunca quede desactualizado.
        private void CargarEspecieRazaCombo()
        {
            obj_Especies_Global_BLL.ListarEspecies(ref obj_Especies_Global_DAL);

            if (!string.IsNullOrEmpty(obj_Especies_Global_DAL.sMsjError))
            {
                MessageBox.Show("Error al cargar especies para Razas: " + obj_Especies_Global_DAL.sMsjError,
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Recordamos la especie seleccionada para no perder el filtro actual
            // si el usuario ya estaba viendo razas de una especie en particular.
            object valorPrevio = cboEspecieRaza.SelectedValue;

            cboEspecieRaza.DataSource = obj_Especies_Global_DAL.dtDatos;
            cboEspecieRaza.DisplayMember = "Especie";
            cboEspecieRaza.ValueMember = "Id_Especie";

            if (valorPrevio != null)
            {
                cboEspecieRaza.SelectedValue = valorPrevio;
            }
        }

        private void CargarRazas()
        {
            obj_Razas_Global_BLL.ListarRazas(ref obj_Razas_Global_DAL);

            if (!string.IsNullOrEmpty(obj_Razas_Global_DAL.sMsjError))
            {
                MessageBox.Show("Error al cargar razas: " + obj_Razas_Global_DAL.sMsjError,
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dtRazas = obj_Razas_Global_DAL.dtDatos;

            // SP_LISTAR_RAZAS solo trae Id_Especie (el numero), no el nombre.
            // Lo resolvemos aca en memoria contra las especies que ya estan
            // cargadas en cboEspecieRaza (mismo espiritu que frmCitas armando
            // "NombreCompleto" para Propietarios), para no tener que tocar el SP.
            if (!dtRazas.Columns.Contains("Especie"))
            {
                dtRazas.Columns.Add("Especie", typeof(string));
            }

            DataTable dtEspeciesLookup = cboEspecieRaza.DataSource as DataTable;
            if (dtEspeciesLookup != null)
            {
                foreach (DataRow filaRaza in dtRazas.Rows)
                {
                    int idEspecieRaza = Convert.ToInt32(filaRaza["Id_Especie"]);
                    DataRow[] filasEspecie = dtEspeciesLookup.Select("Id_Especie = " + idEspecieRaza);
                    filaRaza["Especie"] = filasEspecie.Length > 0 ? filasEspecie[0]["Especie"].ToString() : string.Empty;
                }
            }

            vistaRazas = new DataView(dtRazas);
            dgvRazas.DataSource = vistaRazas;

            FiltrarRazas(); // reaplica el filtro de especie + texto sobre los datos frescos
        }

        // Combina el filtro de especie (cboEspecieRaza) con el de texto
        // (txtBuscarRaza) en un solo RowFilter, con AND. Mismo espiritu que
        // FiltrarEspecies, pero con dos condiciones en vez de una.
        private void FiltrarRazas()
        {
            if (vistaRazas == null)
            {
                return;
            }

            string sFiltroTexto = txtBuscarRaza.Text.Trim().Replace("'", "''");

            string sClauseEspecie = cboEspecieRaza.SelectedValue != null
                ? "Id_Especie = " + Convert.ToInt32(cboEspecieRaza.SelectedValue)
                : string.Empty;

            string sClauseTexto = string.IsNullOrEmpty(sFiltroTexto)
                ? string.Empty
                : "Raza LIKE '%" + sFiltroTexto + "%'";

            if (!string.IsNullOrEmpty(sClauseEspecie) && !string.IsNullOrEmpty(sClauseTexto))
            {
                vistaRazas.RowFilter = sClauseEspecie + " AND " + sClauseTexto;
            }
            else if (!string.IsNullOrEmpty(sClauseEspecie))
            {
                vistaRazas.RowFilter = sClauseEspecie;
            }
            else if (!string.IsNullOrEmpty(sClauseTexto))
            {
                vistaRazas.RowFilter = sClauseTexto;
            }
            else
            {
                vistaRazas.RowFilter = string.Empty;
            }
        }

        private void cboEspecieRaza_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarRazas();
        }

        private void txtBuscarRaza_TextChanged(object sender, EventArgs e)
        {
            FiltrarRazas();
        }

        private void btnNuevaRaza_Click(object sender, EventArgs e)
        {
            if (cboEspecieRaza.SelectedValue == null)
            {
                MessageBox.Show("Selecciona primero una especie.", "Razas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            idRazaEnEdicion = null;
            lblFormTituloRaza.Text = "Nueva raza";
            btnGuardarRaza.Text = "Guardar";

            LimpiarFormularioRaza();
            pnlFormRaza.Visible = !pnlFormRaza.Visible;
        }

        private void btnCancelarRaza_Click(object sender, EventArgs e)
        {
            idRazaEnEdicion = null;
            lblFormTituloRaza.Text = "Nueva raza";
            btnGuardarRaza.Text = "Guardar";

            pnlFormRaza.Visible = false;
            LimpiarFormularioRaza();
        }

        private void btnGuardarRaza_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreRaza.Text) || cboEstadoRaza.SelectedIndex == -1)
            {
                MessageBox.Show("Completa el nombre y el estado antes de guardar.", "Razas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboEspecieRaza.SelectedValue == null)
            {
                MessageBox.Show("Selecciona primero una especie.", "Razas",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // El combo muestra "Activo"/"Inactivo" pero la BD guarda "A"/"I".
            string sEstado = cboEstadoRaza.SelectedItem.ToString() == "Activo" ? "A" : "I";

            obj_Razas_Global_DAL.sRaza = txtNombreRaza.Text.Trim();
            obj_Razas_Global_DAL.iId_Especie = Convert.ToInt32(cboEspecieRaza.SelectedValue);
            obj_Razas_Global_DAL.sEstado = sEstado;
            obj_Razas_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

            if (idRazaEnEdicion.HasValue)
            {
                obj_Razas_Global_DAL.iId_Raza = idRazaEnEdicion.Value;
                obj_Razas_Global_BLL.ActualizarRaza(ref obj_Razas_Global_DAL);

                if (obj_Razas_Global_DAL.sValorScalar == "-2")
                {
                    MessageBox.Show("La raza ya no existe (puede que la hayan eliminado). Se va a refrescar la lista.", "Editar raza",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (obj_Razas_Global_DAL.sValorScalar == "-1")
                {
                    MessageBox.Show("Ya existe otra raza con ese nombre para esta especie.", "Editar raza",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (string.IsNullOrEmpty(obj_Razas_Global_DAL.sMsjError))
                {
                    MessageBox.Show("La raza se actualizó correctamente.", "Editar raza",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar actualizar la raza: " + obj_Razas_Global_DAL.sMsjError, "Editar raza",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                obj_Razas_Global_BLL.InsertarRaza(ref obj_Razas_Global_DAL);

                if (obj_Razas_Global_DAL.sValorScalar == "-1")
                {
                    MessageBox.Show("Ya existe una raza con ese nombre para esta especie.", "Nueva raza",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (string.IsNullOrEmpty(obj_Razas_Global_DAL.sMsjError))
                {
                    MessageBox.Show("La raza se guardó correctamente.", "Nueva raza",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar guardar la raza: " + obj_Razas_Global_DAL.sMsjError, "Nueva raza",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            idRazaEnEdicion = null;
            lblFormTituloRaza.Text = "Nueva raza";
            btnGuardarRaza.Text = "Guardar";
            pnlFormRaza.Visible = false;
            LimpiarFormularioRaza();
            CargarRazas();
        }

        private void btnModificarRaza_Click(object sender, EventArgs e)
        {
            if (!(dgvRazas.CurrentRow?.DataBoundItem is DataRowView fila))
            {
                MessageBox.Show("Selecciona una raza de la lista.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            idRazaEnEdicion = Convert.ToInt32(fila["Id_Raza"]);

            txtNombreRaza.Text = fila["Raza"].ToString();
            cboEstadoRaza.SelectedItem = fila["Estado"].ToString() == "A" ? "Activo" : "Inactivo";

            lblFormTituloRaza.Text = "Editar raza";
            btnGuardarRaza.Text = "Guardar cambios";
            pnlFormRaza.Visible = true;
        }

        private void btnEliminarRaza_Click(object sender, EventArgs e)
        {
            if (!(dgvRazas.CurrentRow?.DataBoundItem is DataRowView fila))
            {
                MessageBox.Show("Selecciona una raza de la lista.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sNombre = fila["Raza"].ToString();

            DialogResult dr = MessageBox.Show($"¿Eliminar la raza \"{sNombre}\"?",
                "VetNova", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            obj_Razas_Global_DAL.iId_Raza = Convert.ToInt32(fila["Id_Raza"]);
            obj_Razas_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

            obj_Razas_Global_BLL.EliminarRaza(ref obj_Razas_Global_DAL);

            if (!string.IsNullOrEmpty(obj_Razas_Global_DAL.sMsjError))
            {
                MessageBox.Show("Error al eliminar: " + obj_Razas_Global_DAL.sMsjError,
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (obj_Razas_Global_DAL.sValorScalar == "-1")
            {
                MessageBox.Show("No se puede eliminar: tiene mascotas asociadas.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (obj_Razas_Global_DAL.sValorScalar == "-2")
            {
                MessageBox.Show("El registro ya no existe, probablemente lo eliminaron en otra sesion.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            CargarRazas();
        }

        private void LimpiarFormularioRaza()
        {
            txtNombreRaza.Clear();
            cboEstadoRaza.SelectedIndex = -1;
            cboEstadoRaza.SelectedItem = "Activo";
        }

        #endregion

        #region Especialidades Veterinarios TAB

        private void CargarEspecialidades()
        {
            obj_Especialidades_Global_BLL.ListarEspecialidades(ref obj_Especialidades_Global_DAL);

            if (!string.IsNullOrEmpty(obj_Especialidades_Global_DAL.sMsjError))
            {
                MessageBox.Show("Error al cargar especialidades: " + obj_Especialidades_Global_DAL.sMsjError,
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dtEspecialidades = obj_Especialidades_Global_DAL.dtDatos;
            vistaEspecialidades = new DataView(dtEspecialidades);
            dgvEspecialidades.DataSource = vistaEspecialidades;

            FiltrarEspecialidades(); // reaplica lo que haya en txtBuscarEspecialidad sobre los datos frescos
        }

        private void FiltrarEspecialidades()
        {
            if (vistaEspecialidades == null)
            {
                return;
            }

            string sFiltro = txtBuscarEspecialidad.Text.Trim().Replace("'", "''"); // escapa comillas simples para no romper el RowFilter

            vistaEspecialidades.RowFilter = string.IsNullOrEmpty(sFiltro)
                ? string.Empty
                : "Especialidad LIKE '%" + sFiltro + "%'";
        }

        private void txtBuscarEspecialidad_TextChanged(object sender, EventArgs e)
        {
            FiltrarEspecialidades();
        }

        private void btnNuevaEspecialidad_Click(object sender, EventArgs e)
        {
            idEspecialidadEnEdicion = null;
            lblFormTituloEspecialidad.Text = "Nueva especialidad";
            btnGuardarEspecialidad.Text = "Guardar";

            LimpiarFormularioEspecialidad();
            pnlFormEspecialidad.Visible = !pnlFormEspecialidad.Visible;
        }

        private void btnCancelarEspecialidad_Click(object sender, EventArgs e)
        {
            idEspecialidadEnEdicion = null;
            lblFormTituloEspecialidad.Text = "Nueva especialidad";
            btnGuardarEspecialidad.Text = "Guardar";

            pnlFormEspecialidad.Visible = false;
            LimpiarFormularioEspecialidad();
        }

        private void btnGuardarEspecialidad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreEspecialidad.Text) || cboEstadoEspecialidadForm.SelectedIndex == -1)
            {
                MessageBox.Show("Completa el nombre y el estado antes de guardar.", "Especialidades",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // El combo muestra "Activo"/"Inactivo" pero la BD guarda "A"/"I".
            string sEstado = cboEstadoEspecialidadForm.SelectedItem.ToString() == "Activo" ? "A" : "I";

            obj_Especialidades_Global_DAL.sEspecialidad = txtNombreEspecialidad.Text.Trim();
            obj_Especialidades_Global_DAL.sEstado = sEstado;
            obj_Especialidades_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

            if (idEspecialidadEnEdicion.HasValue)
            {
                obj_Especialidades_Global_DAL.iId_Especialidad = idEspecialidadEnEdicion.Value;
                obj_Especialidades_Global_BLL.ActualizarEspecialidad(ref obj_Especialidades_Global_DAL);

                if (obj_Especialidades_Global_DAL.sValorScalar == "-2")
                {
                    MessageBox.Show("La especialidad ya no existe (puede que la hayan eliminado). Se va a refrescar la lista.", "Editar especialidad",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (obj_Especialidades_Global_DAL.sValorScalar == "-1")
                {
                    MessageBox.Show("Ya existe otra especialidad con ese nombre.", "Editar especialidad",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (string.IsNullOrEmpty(obj_Especialidades_Global_DAL.sMsjError))
                {
                    MessageBox.Show("La especialidad se actualizó correctamente.", "Editar especialidad",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar actualizar la especialidad: " + obj_Especialidades_Global_DAL.sMsjError, "Editar especialidad",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                obj_Especialidades_Global_BLL.InsertarEspecialidad(ref obj_Especialidades_Global_DAL);

                if (obj_Especialidades_Global_DAL.sValorScalar == "-1")
                {
                    MessageBox.Show("Ya existe una especialidad con ese nombre.", "Nueva especialidad",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (string.IsNullOrEmpty(obj_Especialidades_Global_DAL.sMsjError))
                {
                    MessageBox.Show("La especialidad se guardó correctamente.", "Nueva especialidad",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar guardar la especialidad: " + obj_Especialidades_Global_DAL.sMsjError, "Nueva especialidad",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            idEspecialidadEnEdicion = null;
            lblFormTituloEspecialidad.Text = "Nueva especialidad";
            btnGuardarEspecialidad.Text = "Guardar";
            pnlFormEspecialidad.Visible = false;
            LimpiarFormularioEspecialidad();
            CargarEspecialidades();
        }

        private void btnModificarEspecialidad_Click(object sender, EventArgs e)
        {
            if (!(dgvEspecialidades.CurrentRow?.DataBoundItem is DataRowView fila))
            {
                MessageBox.Show("Selecciona una especialidad de la lista.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            idEspecialidadEnEdicion = Convert.ToInt32(fila["Id_Especialidad"]);

            txtNombreEspecialidad.Text = fila["Especialidad"].ToString();
            cboEstadoEspecialidadForm.SelectedItem = fila["Estado"].ToString() == "A" ? "Activo" : "Inactivo";

            lblFormTituloEspecialidad.Text = "Editar especialidad";
            btnGuardarEspecialidad.Text = "Guardar cambios";
            pnlFormEspecialidad.Visible = true;
        }

        private void btnEliminarEspecialidad_Click(object sender, EventArgs e)
        {
            if (!(dgvEspecialidades.CurrentRow?.DataBoundItem is DataRowView fila))
            {
                MessageBox.Show("Selecciona una especialidad de la lista.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sNombre = fila["Especialidad"].ToString();

            DialogResult dr = MessageBox.Show($"¿Eliminar la especialidad \"{sNombre}\"?",
                "VetNova", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            obj_Especialidades_Global_DAL.iId_Especialidad = Convert.ToInt32(fila["Id_Especialidad"]);
            obj_Especialidades_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

            obj_Especialidades_Global_BLL.EliminarEspecialidad(ref obj_Especialidades_Global_DAL);

            if (!string.IsNullOrEmpty(obj_Especialidades_Global_DAL.sMsjError))
            {
                MessageBox.Show("Error al eliminar: " + obj_Especialidades_Global_DAL.sMsjError,
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (obj_Especialidades_Global_DAL.sValorScalar == "-1")
            {
                MessageBox.Show("No se puede eliminar: tiene veterinarios asociados.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (obj_Especialidades_Global_DAL.sValorScalar == "-2")
            {
                MessageBox.Show("El registro ya no existe, probablemente lo eliminaron en otra sesion.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            CargarEspecialidades();
        }

        private void LimpiarFormularioEspecialidad()
        {
            txtNombreEspecialidad.Clear();
            cboEstadoEspecialidadForm.SelectedIndex = -1;
            cboEstadoEspecialidadForm.SelectedItem = "Activo";
        }

        #endregion

        #region Tipos Identificacion TAB

        private void CargarTiposIdentificacion()
        {
            obj_TiposIdentificacion_Global_BLL.ListarTiposIdentificacion(ref obj_TiposIdentificacion_Global_DAL);

            if (!string.IsNullOrEmpty(obj_TiposIdentificacion_Global_DAL.sMsjError))
            {
                MessageBox.Show("Error al cargar tipos de identificación: " + obj_TiposIdentificacion_Global_DAL.sMsjError,
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dtTiposIdentificacion = obj_TiposIdentificacion_Global_DAL.dtDatos;
            vistaTiposIdentificacion = new DataView(dtTiposIdentificacion);
            dgvTiposIdentificacion.DataSource = vistaTiposIdentificacion;

            FiltrarTiposIdentificacion(); // reaplica lo que haya en txtBuscarTipoIdentificacion sobre los datos frescos
        }

        private void FiltrarTiposIdentificacion()
        {
            if (vistaTiposIdentificacion == null)
            {
                return;
            }

            string sFiltro = txtBuscarTipoIdentificacion.Text.Trim().Replace("'", "''"); // escapa comillas simples para no romper el RowFilter

            vistaTiposIdentificacion.RowFilter = string.IsNullOrEmpty(sFiltro)
                ? string.Empty
                : "Tipo_Identificacion LIKE '%" + sFiltro + "%'";
        }

        private void txtBuscarTipoIdentificacion_TextChanged(object sender, EventArgs e)
        {
            FiltrarTiposIdentificacion();
        }

        private void btnNuevoTipoIdentificacion_Click(object sender, EventArgs e)
        {
            idTipoIdentificacionEnEdicion = null;
            lblFormTituloTipoIdentificacion.Text = "Nuevo tipo de identificacion";
            btnGuardarTipoIdentificacion.Text = "Guardar";

            LimpiarFormularioTipoIdentificacion();
            pnlFormTipoIdentificacion.Visible = !pnlFormTipoIdentificacion.Visible;
        }

        private void btnCancelarTipoIdentificacion_Click(object sender, EventArgs e)
        {
            idTipoIdentificacionEnEdicion = null;
            lblFormTituloTipoIdentificacion.Text = "Nuevo tipo de identificacion";
            btnGuardarTipoIdentificacion.Text = "Guardar";

            pnlFormTipoIdentificacion.Visible = false;
            LimpiarFormularioTipoIdentificacion();
        }

        private void btnGuardarTipoIdentificacion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreTipoIdentificacion.Text) || cboEstadoTipoIdentificacionForm.SelectedIndex == -1)
            {
                MessageBox.Show("Completa el nombre y el estado antes de guardar.", "Tipos de identificacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // El combo muestra "Activo"/"Inactivo" pero la BD guarda "A"/"I".
            string sEstado = cboEstadoTipoIdentificacionForm.SelectedItem.ToString() == "Activo" ? "A" : "I";

            obj_TiposIdentificacion_Global_DAL.sTipo_Identificacion = txtNombreTipoIdentificacion.Text.Trim();
            obj_TiposIdentificacion_Global_DAL.sEstado = sEstado;
            obj_TiposIdentificacion_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

            if (idTipoIdentificacionEnEdicion.HasValue)
            {
                obj_TiposIdentificacion_Global_DAL.iId_Tipo_Identificacion = idTipoIdentificacionEnEdicion.Value;
                obj_TiposIdentificacion_Global_BLL.ActualizarTipoIdentificacion(ref obj_TiposIdentificacion_Global_DAL);

                if (obj_TiposIdentificacion_Global_DAL.sValorScalar == "-2")
                {
                    MessageBox.Show("El tipo de identificación ya no existe (puede que lo hayan eliminado). Se va a refrescar la lista.", "Editar tipo de identificacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (obj_TiposIdentificacion_Global_DAL.sValorScalar == "-1")
                {
                    MessageBox.Show("Ya existe otro tipo de identificación con ese nombre.", "Editar tipo de identificacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (string.IsNullOrEmpty(obj_TiposIdentificacion_Global_DAL.sMsjError))
                {
                    MessageBox.Show("El tipo de identificación se actualizó correctamente.", "Editar tipo de identificacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar actualizar el tipo de identificación: " + obj_TiposIdentificacion_Global_DAL.sMsjError, "Editar tipo de identificacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                obj_TiposIdentificacion_Global_BLL.InsertarTipoIdentificacion(ref obj_TiposIdentificacion_Global_DAL);

                if (obj_TiposIdentificacion_Global_DAL.sValorScalar == "-1")
                {
                    MessageBox.Show("Ya existe un tipo de identificación con ese nombre.", "Nuevo tipo de identificacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (string.IsNullOrEmpty(obj_TiposIdentificacion_Global_DAL.sMsjError))
                {
                    MessageBox.Show("El tipo de identificación se guardó correctamente.", "Nuevo tipo de identificacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar guardar el tipo de identificación: " + obj_TiposIdentificacion_Global_DAL.sMsjError, "Nuevo tipo de identificacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            idTipoIdentificacionEnEdicion = null;
            lblFormTituloTipoIdentificacion.Text = "Nuevo tipo de identificacion";
            btnGuardarTipoIdentificacion.Text = "Guardar";
            pnlFormTipoIdentificacion.Visible = false;
            LimpiarFormularioTipoIdentificacion();
            CargarTiposIdentificacion();
        }

        private void btnModificarTipoIdentificacion_Click(object sender, EventArgs e)
        {
            if (!(dgvTiposIdentificacion.CurrentRow?.DataBoundItem is DataRowView fila))
            {
                MessageBox.Show("Selecciona un tipo de identificación de la lista.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            idTipoIdentificacionEnEdicion = Convert.ToInt32(fila["Id_Tipo_Identificacion"]);

            txtNombreTipoIdentificacion.Text = fila["Tipo_Identificacion"].ToString();
            cboEstadoTipoIdentificacionForm.SelectedItem = fila["Estado"].ToString() == "A" ? "Activo" : "Inactivo";

            lblFormTituloTipoIdentificacion.Text = "Editar tipo de identificacion";
            btnGuardarTipoIdentificacion.Text = "Guardar cambios";
            pnlFormTipoIdentificacion.Visible = true;
        }

        private void btnEliminarTipoIdentificacion_Click(object sender, EventArgs e)
        {
            if (!(dgvTiposIdentificacion.CurrentRow?.DataBoundItem is DataRowView fila))
            {
                MessageBox.Show("Selecciona un tipo de identificación de la lista.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sNombre = fila["Tipo_Identificacion"].ToString();

            DialogResult dr = MessageBox.Show($"¿Eliminar el tipo de identificación \"{sNombre}\"?",
                "VetNova", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            obj_TiposIdentificacion_Global_DAL.iId_Tipo_Identificacion = Convert.ToInt32(fila["Id_Tipo_Identificacion"]);
            obj_TiposIdentificacion_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

            obj_TiposIdentificacion_Global_BLL.EliminarTipoIdentificacion(ref obj_TiposIdentificacion_Global_DAL);

            if (!string.IsNullOrEmpty(obj_TiposIdentificacion_Global_DAL.sMsjError))
            {
                MessageBox.Show("Error al eliminar: " + obj_TiposIdentificacion_Global_DAL.sMsjError,
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (obj_TiposIdentificacion_Global_DAL.sValorScalar == "-1")
            {
                MessageBox.Show("No se puede eliminar: tiene propietarios o veterinarios asociados.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (obj_TiposIdentificacion_Global_DAL.sValorScalar == "-2")
            {
                MessageBox.Show("El registro ya no existe, probablemente lo eliminaron en otra sesion.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            CargarTiposIdentificacion();
        }

        private void LimpiarFormularioTipoIdentificacion()
        {
            txtNombreTipoIdentificacion.Clear();
            cboEstadoTipoIdentificacionForm.SelectedIndex = -1;
            cboEstadoTipoIdentificacionForm.SelectedItem = "Activo";
        }

        #endregion
    }
}