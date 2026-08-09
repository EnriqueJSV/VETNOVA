using BLL_VETNOVA.Entidades;
using DAL_VETNOVA.Entidades;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace PL_VETNOVA.Pantallas.Mascotas
{
    public partial class frmMascotas : Form
    {
        #region Variables Globales o de Entidades

        public cls_Usuarios_DAL obj_Usuario_Global_DAL;
        public cls_Usuarios_BLL obj_Usuario_Global_BLL = new cls_Usuarios_BLL();

        public cls_Mascotas_DAL obj_Mascotas_Global_DAL = new cls_Mascotas_DAL();
        public cls_Mascotas_BLL obj_Mascotas_Global_BLL = new cls_Mascotas_BLL();

        public cls_Propietarios_DAL obj_Propietarios_Global_DAL = new cls_Propietarios_DAL();
        public cls_Propietarios_BLL obj_Propietarios_Global_BLL = new cls_Propietarios_BLL();

        public cls_Especies_DAL obj_Especies_Global_DAL = new cls_Especies_DAL();
        public cls_Especies_BLL obj_Especies_Global_BLL = new cls_Especies_BLL();

        public cls_Razas_DAL obj_Razas_Global_DAL = new cls_Razas_DAL();
        public cls_Razas_BLL obj_Razas_Global_BLL = new cls_Razas_BLL();

        private DataTable dtMascotas;
        private DataView vistaMascotas; // vista filtrable en memoria, mismo patron que frmCitas/frmCatalogos

        private DataTable dtRazasCompleto; // TODAS las razas (de todas las especies), para resolver nombres y para filtrar cboRazaMascota

        // Si es null, pnlFormMascota esta en modo "Nueva mascota" (INSERT).
        // Si tiene valor, esta en modo "Editar mascota" (UPDATE) sobre ese Id_Mascota.
        private int? idMascotaEnEdicion = null;

        #endregion

        public frmMascotas()
        {
            InitializeComponent();

            dgvMascotas.AutoGenerateColumns = false;
        }

        #region Eventos Form

        private void frmMascotas_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();

            cboSexoMascota.SelectedIndex = -1;
            cboEstadoMascota.SelectedIndex = -1;

            CargarCombos();
            CargarMascotas();
        }

        private void frmMascotas_FormClosing(object sender, FormClosingEventArgs e)
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

        #region Combos (Propietario, Especie, Raza)

        private void CargarCombos()
        {
            // Propietarios (mismo patron NombreCompleto que ya usa frmCitas),
            // ordenados alfabeticamente con DefaultView.Sort.
            obj_Propietarios_Global_BLL.ListarPropietarios(ref obj_Propietarios_Global_DAL);
            if (obj_Propietarios_Global_DAL.sMsjError == string.Empty && obj_Propietarios_Global_DAL.dtDatos != null)
            {
                DataTable dtProp = obj_Propietarios_Global_DAL.dtDatos;
                if (!dtProp.Columns.Contains("NombreCompleto"))
                {
                    dtProp.Columns.Add("NombreCompleto", typeof(string));
                }
                foreach (DataRow fila in dtProp.Rows)
                {
                    fila["NombreCompleto"] = fila["Nombre"].ToString() + " " + fila["Apellido1"].ToString();
                }

                dtProp.DefaultView.RowFilter = "Estado = 'A'";
                dtProp.DefaultView.Sort = "NombreCompleto ASC";

                cboPropietarioMascota.DataSource = dtProp.DefaultView;
                cboPropietarioMascota.DisplayMember = "NombreCompleto";
                cboPropietarioMascota.ValueMember = "Id_Propietario";
                cboPropietarioMascota.SelectedIndex = -1;
            }

            // Especies (para el combo cascada)
            obj_Especies_Global_BLL.ListarEspecies(ref obj_Especies_Global_DAL);
            if (obj_Especies_Global_DAL.sMsjError == string.Empty && obj_Especies_Global_DAL.dtDatos != null)
            {
                obj_Especies_Global_DAL.dtDatos.DefaultView.RowFilter = "Estado = 'A'";

                cboEspecieMascota.DataSource = obj_Especies_Global_DAL.dtDatos;
                cboEspecieMascota.DisplayMember = "Especie";
                cboEspecieMascota.ValueMember = "Id_Especie";
                cboEspecieMascota.SelectedIndex = -1;
            }

            // TODAS las razas (de todas las especies), para filtrar por especie
            // en memoria y tambien para resolver el nombre de raza en el grid.
            obj_Razas_Global_BLL.ListarRazas(ref obj_Razas_Global_DAL);
            if (obj_Razas_Global_DAL.sMsjError == string.Empty && obj_Razas_Global_DAL.dtDatos != null)
            {
                dtRazasCompleto = obj_Razas_Global_DAL.dtDatos;
                dtRazasCompleto.DefaultView.RowFilter = "Estado = 'A'";
            }
        }

        private void cboEspecieMascota_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboRazaMascota.DataSource = null;
            cboRazaMascota.Items.Clear();

            if (cboEspecieMascota.SelectedValue == null || dtRazasCompleto == null)
            {
                return;
            }

            int idEspecieSeleccionada = Convert.ToInt32(cboEspecieMascota.SelectedValue);

            DataView vista = new DataView(dtRazasCompleto);

            // Filtrar por especie y solo razas activas
            vista.RowFilter = "Id_Especie = " + idEspecieSeleccionada + " AND Estado = 'A'";
            vista.Sort = "Raza ASC";

            cboRazaMascota.DataSource = vista;
            cboRazaMascota.DisplayMember = "Raza";
            cboRazaMascota.ValueMember = "Id_Raza";
            cboRazaMascota.SelectedIndex = -1;
        }

        #endregion

        #region CRUD Mascotas

        private void CargarMascotas()
        {
            obj_Mascotas_Global_BLL.ListarMascotas(ref obj_Mascotas_Global_DAL);

            if (!string.IsNullOrEmpty(obj_Mascotas_Global_DAL.sMsjError))
            {
                MessageBox.Show("Error al cargar mascotas: " + obj_Mascotas_Global_DAL.sMsjError,
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dtMascotas = obj_Mascotas_Global_DAL.dtDatos;

            // SP_LISTAR_MASCOTAS solo trae Id_Propietario / Id_Raza (numeros).
            // Resolvemos los nombres aca en memoria contra lo que ya tenemos
            // cargado en los combos, igual que hicimos con Especie en Razas.
            if (!dtMascotas.Columns.Contains("PropietarioNombre"))
            {
                dtMascotas.Columns.Add("PropietarioNombre", typeof(string));
            }
            if (!dtMascotas.Columns.Contains("RazaNombre"))
            {
                dtMascotas.Columns.Add("RazaNombre", typeof(string));
            }

            // cboPropietarioMascota.DataSource ahora es un DataView (por el
            // ordenamiento alfabetico en CargarCombos), no un DataTable
            // directo, asi que hay que sacar el DataTable de abajo con .Table.
            DataTable dtPropLookup = (cboPropietarioMascota.DataSource as DataView)?.Table;

            foreach (DataRow filaMascota in dtMascotas.Rows)
            {
                if (dtPropLookup != null)
                {
                    DataRow[] filasProp = dtPropLookup.Select("Id_Propietario = " + filaMascota["Id_Propietario"]);
                    filaMascota["PropietarioNombre"] = filasProp.Length > 0 ? filasProp[0]["NombreCompleto"].ToString() : string.Empty;
                }

                if (dtRazasCompleto != null)
                {
                    DataRow[] filasRaza = dtRazasCompleto.Select("Id_Raza = " + filaMascota["Id_Raza"]);
                    filaMascota["RazaNombre"] = filasRaza.Length > 0 ? filasRaza[0]["Raza"].ToString() : string.Empty;
                }
            }

            vistaMascotas = new DataView(dtMascotas);
            dgvMascotas.DataSource = vistaMascotas;

            FiltrarMascotas(); // reaplica lo que haya en txtBuscarMascota sobre los datos frescos
        }

        private void FiltrarMascotas()
        {
            if (vistaMascotas == null)
            {
                return;
            }

            string sFiltro = txtBuscarMascota.Text.Trim().Replace("'", "''"); // escapa comillas simples para no romper el RowFilter

            vistaMascotas.RowFilter = string.IsNullOrEmpty(sFiltro)
                ? string.Empty
                : "Nombre LIKE '%" + sFiltro + "%' OR PropietarioNombre LIKE '%" + sFiltro + "%'";
        }

        private void txtBuscarMascota_TextChanged(object sender, EventArgs e)
        {
            FiltrarMascotas();
        }

        private void btnNuevaMascota_Click(object sender, EventArgs e)
        {
            idMascotaEnEdicion = null;
            lblFormTituloMascota.Text = "Nueva mascota";
            btnGuardarMascota.Text = "Guardar";

            LimpiarFormularioMascota();
            pnlFormMascota.Visible = !pnlFormMascota.Visible;
        }

        private void btnCancelarMascota_Click(object sender, EventArgs e)
        {
            idMascotaEnEdicion = null;
            lblFormTituloMascota.Text = "Nueva mascota";
            btnGuardarMascota.Text = "Guardar";

            pnlFormMascota.Visible = false;
            LimpiarFormularioMascota();
        }

        private void btnGuardarMascota_Click(object sender, EventArgs e)
        {
            if (cboPropietarioMascota.SelectedValue == null ||
                cboEspecieMascota.SelectedValue == null ||
                cboRazaMascota.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtNombreMascota.Text) ||
                cboSexoMascota.SelectedIndex == -1 ||
                cboEstadoMascota.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtColorMascota.Text))
            {
                MessageBox.Show("Completa todos los campos antes de guardar.", "Mascotas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sEstado = cboEstadoMascota.SelectedItem.ToString() == "Activo" ? "A" : "I";

            obj_Mascotas_Global_DAL.iId_Propietario = Convert.ToInt32(cboPropietarioMascota.SelectedValue);
            obj_Mascotas_Global_DAL.iId_Raza = Convert.ToInt32(cboRazaMascota.SelectedValue);
            obj_Mascotas_Global_DAL.sNombre = txtNombreMascota.Text.Trim();
            obj_Mascotas_Global_DAL.sSexo = cboSexoMascota.SelectedItem.ToString();
            obj_Mascotas_Global_DAL.dtFecha_Nacimiento = dtpFechaNacimientoMascota.Value;
            obj_Mascotas_Global_DAL.dePeso = nudPesoMascota.Value;
            obj_Mascotas_Global_DAL.sColor = txtColorMascota.Text.Trim();
            obj_Mascotas_Global_DAL.sEstado = sEstado;
            obj_Mascotas_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

            if (idMascotaEnEdicion.HasValue)
            {
                obj_Mascotas_Global_DAL.iId_Mascota = idMascotaEnEdicion.Value;
                obj_Mascotas_Global_BLL.ActualizarMascota(ref obj_Mascotas_Global_DAL);

                if (obj_Mascotas_Global_DAL.sValorScalar == "-2")
                {
                    MessageBox.Show("La mascota ya no existe (puede que la hayan eliminado). Se va a refrescar la lista.", "Editar mascota",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(obj_Mascotas_Global_DAL.sMsjError) && obj_Mascotas_Global_DAL.sValorScalar != "0")
                {
                    MessageBox.Show("La mascota se actualizó correctamente.", "Editar mascota",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar actualizar la mascota: " + obj_Mascotas_Global_DAL.sMsjError, "Editar mascota",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                obj_Mascotas_Global_BLL.InsertarMascota(ref obj_Mascotas_Global_DAL);

                if (string.IsNullOrEmpty(obj_Mascotas_Global_DAL.sMsjError) && obj_Mascotas_Global_DAL.sValorScalar != "0")
                {
                    MessageBox.Show("La mascota se guardó correctamente.", "Nueva mascota",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar guardar la mascota: " + obj_Mascotas_Global_DAL.sMsjError, "Nueva mascota",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            idMascotaEnEdicion = null;
            lblFormTituloMascota.Text = "Nueva mascota";
            btnGuardarMascota.Text = "Guardar";
            pnlFormMascota.Visible = false;
            LimpiarFormularioMascota();
            CargarMascotas();
        }

        private void btnModificarMascota_Click(object sender, EventArgs e)
        {
            if (!(dgvMascotas.CurrentRow?.DataBoundItem is DataRowView fila))
            {
                MessageBox.Show("Selecciona una mascota de la lista.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            idMascotaEnEdicion = Convert.ToInt32(fila["Id_Mascota"]);

            cboPropietarioMascota.SelectedValue = Convert.ToInt32(fila["Id_Propietario"]);

            // Para que cboRazaMascota se filtre correctamente, primero hay que
            // seleccionar la especie a la que pertenece la raza de esta mascota
            // (eso dispara cboEspecieMascota_SelectedIndexChanged, que llena
            // cboRazaMascota); recien ahi seleccionamos la raza puntual.
            int idRazaActual = Convert.ToInt32(fila["Id_Raza"]);
            if (dtRazasCompleto != null)
            {
                DataRow[] filaRaza = dtRazasCompleto.Select("Id_Raza = " + idRazaActual);
                if (filaRaza.Length > 0)
                {
                    cboEspecieMascota.SelectedValue = Convert.ToInt32(filaRaza[0]["Id_Especie"]);
                }
            }
            cboRazaMascota.SelectedValue = idRazaActual;

            txtNombreMascota.Text = fila["Nombre"].ToString();
            cboSexoMascota.SelectedItem = fila["Sexo"].ToString();
            dtpFechaNacimientoMascota.Value = Convert.ToDateTime(fila["Fecha_Nacimiento"]);

            // Antes: Convert.ToDecimal(fila["Peso"]) directo -> tronaba con
            // FormatException cuando el valor venia con decimales (ej. "7.5")
            // porque la cultura activa no coincidia con el separador decimal.
            // Se fuerza CultureInfo.InvariantCulture para el parseo. Peso ya
            // se maneja como decimal en todo el flujo (dePeso en el DAL), asi
            // que aca se preserva la precision sin redondear.
            nudPesoMascota.Value = Convert.ToDecimal(fila["Peso"], CultureInfo.InvariantCulture);

            txtColorMascota.Text = fila["Color"].ToString();
            cboEstadoMascota.SelectedItem = fila["Estado"].ToString() == "A" ? "Activo" : "Inactivo";

            lblFormTituloMascota.Text = "Editar mascota";
            btnGuardarMascota.Text = "Guardar cambios";
            pnlFormMascota.Visible = true;
        }

        private void btnEliminarMascota_Click(object sender, EventArgs e)
        {
            if (!(dgvMascotas.CurrentRow?.DataBoundItem is DataRowView fila))
            {
                MessageBox.Show("Selecciona una mascota de la lista.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sNombre = fila["Nombre"].ToString();

            DialogResult dr = MessageBox.Show($"¿Eliminar la mascota \"{sNombre}\"?",
                "VetNova", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }

            obj_Mascotas_Global_DAL.iId_Mascota = Convert.ToInt32(fila["Id_Mascota"]);
            obj_Mascotas_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

            obj_Mascotas_Global_BLL.EliminarMascota(ref obj_Mascotas_Global_DAL);

            if (obj_Mascotas_Global_DAL.sValorScalar == "-1")
            {
                MessageBox.Show("No se puede eliminar: esta mascota tiene citas asociadas.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (obj_Mascotas_Global_DAL.sValorScalar == "-2")
            {
                MessageBox.Show("El registro ya no existe, probablemente lo eliminaron en otra sesion.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CargarMascotas();
                return;
            }

            if (string.IsNullOrEmpty(obj_Mascotas_Global_DAL.sMsjError) && obj_Mascotas_Global_DAL.sValorScalar != "0")
            {
                MessageBox.Show("La mascota se eliminó correctamente.",
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMascotas();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar eliminar la mascota: " + obj_Mascotas_Global_DAL.sMsjError,
                    "VetNova", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormularioMascota()
        {
            cboPropietarioMascota.SelectedIndex = -1;
            cboEspecieMascota.SelectedIndex = -1;
            cboRazaMascota.DataSource = null;
            cboRazaMascota.Items.Clear();
            txtNombreMascota.Clear();
            cboSexoMascota.SelectedIndex = -1;
            dtpFechaNacimientoMascota.Value = DateTime.Now;
            nudPesoMascota.Value = 0;
            txtColorMascota.Clear();
            cboEstadoMascota.SelectedIndex = -1;
            cboEstadoMascota.SelectedItem = "Activo";
        }

        #endregion
    }
}