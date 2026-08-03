using BLL_VETNOVA.Entidades;
using DAL_VETNOVA.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_VETNOVA.Pantallas.Citas
{
    public partial class frmCitas : Form
    {

        #region Variables Globales o de Entidades

        private DataTable dtCitasCompleto;

        // Se le pasa desde el menu que abre esta ventana (Admin, Veterinario o
        // Recepcionista), para que frmCitas sepa quien esta guardando (auditoria)
        // y pueda consultar por su cuenta el nombre/rol reales a mostrar.
        public int IdUsuarioGlobal { get; set; }

        public cls_Usuarios_DAL obj_Usuario_Global_DAL;
        public cls_Usuarios_BLL obj_Usuario_Global_BLL = new cls_Usuarios_BLL();
        public cls_Citas_DAL obj_Citas_Global_DAL = new cls_Citas_DAL();
        public cls_Citas_BLL obj_Citas_Global_BLL = new cls_Citas_BLL();

        public cls_Propietarios_DAL obj_Propietarios_Global_DAL = new cls_Propietarios_DAL();
        public cls_Propietarios_BLL obj_Propietarios_Global_BLL = new cls_Propietarios_BLL();

        public cls_Veterinarios_DAL obj_Veterinarios_Global_DAL = new cls_Veterinarios_DAL();
        public cls_Veterinarios_BLL obj_Veterinarios_Global_BLL = new cls_Veterinarios_BLL();

        public cls_Mascotas_DAL obj_Mascotas_Global_DAL = new cls_Mascotas_DAL();
        public cls_Mascotas_BLL obj_Mascotas_Global_BLL = new cls_Mascotas_BLL();

        private DataTable dtMascotasCompleto; // todas las mascotas, para filtrar por propietario en memoria

        // Si es null, pnlFormCita esta en modo "Nueva cita" (INSERT).
        // Si tiene valor, esta en modo "Editar cita" (UPDATE) sobre ese Id_Cita.
        private int? idCitaEnEdicion = null;
        #endregion

        public frmCitas()
        {
            InitializeComponent();
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();

            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new object[] { "Pendiente", "Confirmada", "Atendida", "Cancelada" });

            cargaCitas();
            cargaCombos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmCitas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }

        #region Nueva cita / formulario

        private void btnNuevaCita_Click(object sender, EventArgs e)
        {
            idCitaEnEdicion = null;
            lblFormTitulo.Text = "Nueva cita";
            btnGuardarCita.Text = "Guardar";

            LimpiarFormulario();
            pnlFormCita.Visible = !pnlFormCita.Visible;
        }

        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            idCitaEnEdicion = null;
            lblFormTitulo.Text = "Nueva cita";
            btnGuardarCita.Text = "Guardar";

            pnlFormCita.Visible = false;
            LimpiarFormulario();
        }

        private void btnGuardarCita_Click(object sender, EventArgs e)
        {
            if (cboPropietario.SelectedIndex == -1 || cboMascota.SelectedIndex == -1 ||
                cboVeterinario.SelectedIndex == -1 || cboEstado.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Completa todos los campos antes de guardar.", "Nueva cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                obj_Citas_Global_DAL.iId_Mascota = Convert.ToInt32(cboMascota.SelectedValue);
                obj_Citas_Global_DAL.iId_Veterinario = Convert.ToInt32(cboVeterinario.SelectedValue);
                obj_Citas_Global_DAL.dtFecha = dtpFecha.Value;
                obj_Citas_Global_DAL.dtHora = dtpHora.Value;
                obj_Citas_Global_DAL.sMotivo = txtMotivo.Text.Trim();
                obj_Citas_Global_DAL.sEstado_Cita = cboEstado.SelectedItem.ToString();
                obj_Citas_Global_DAL.iId_UsuarioGlobal = this.IdUsuarioGlobal;

                if (idCitaEnEdicion.HasValue)
                {
                    // TODO: cls_Citas_BLL.ActualizaCita(ref obj_Citas_Global_DAL), usando
                    // obj_Citas_Global_DAL.iId_Cita = idCitaEnEdicion.Value; y un futuro
                    // SP_ACTUALIZA_CITAS (mismo espiritu que SP_ACTUALIZA_X del resto del
                    // sistema: valida que la cita exista antes de actualizar, devuelve -2
                    // si no existe, y solo entonces escribe en Auditoria).
                    MessageBox.Show("Aqui se va a actualizar la cita Id_Cita = " + idCitaEnEdicion.Value +
                        " una vez conectemos la logica con la base de datos.", "Editar cita",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    obj_Citas_Global_BLL.InsertaCita(ref obj_Citas_Global_DAL);

                    if (obj_Citas_Global_DAL.sMsjError == string.Empty)
                    {
                        MessageBox.Show("La cita se guardó correctamente.", "Nueva cita",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al intentar guardar la cita: " + obj_Citas_Global_DAL.sMsjError, "Nueva cita",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                idCitaEnEdicion = null;
                lblFormTitulo.Text = "Nueva cita";
                btnGuardarCita.Text = "Guardar";
                pnlFormCita.Visible = false;
                LimpiarFormulario();
                cargaCitas(); // refresca la tabla para que se vea el cambio
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar guardar la cita. Error: " + ex.ToString(), "Nueva cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPropietario_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMascota.DataSource = null;
            cboMascota.Items.Clear();

            if (cboPropietario.SelectedValue == null || dtMascotasCompleto == null)
            {
                return;
            }

            int idPropietarioSeleccionado = Convert.ToInt32(cboPropietario.SelectedValue);

            DataView vista = new DataView(dtMascotasCompleto);
            vista.RowFilter = "Id_Propietario = " + idPropietarioSeleccionado;

            cboMascota.DataSource = vista;
            cboMascota.DisplayMember = "Nombre";
            cboMascota.ValueMember = "Id_Mascota";
            cboMascota.SelectedIndex = -1;
        }

        private void LimpiarFormulario()
        {
            cboPropietario.SelectedIndex = -1;
            cboMascota.SelectedIndex = -1;
            cboVeterinario.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            dtpHora.Value = DateTime.Now;
            txtMotivo.Clear();
        }

        #endregion

        #region Modificar / Eliminar (workflow: primero seleccionar una fila)

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona primero una cita de la tabla.", "Modificar cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvCitas.SelectedRows[0];

            idCitaEnEdicion = Convert.ToInt32(fila.Cells["colIdCita"].Value);

            string nombrePropietario = fila.Cells["colPropietario"].Value.ToString();
            string nombreMascota = fila.Cells["colMascota"].Value.ToString();
            string nombreVeterinario = fila.Cells["colVeterinario"].Value.ToString();

            // No usamos IDs ocultos: buscamos el propietario y el veterinario por
            // el mismo texto (Nombre + Apellido1) que ya se ve en la tabla. Esto
            // dispara cboPropietario_SelectedIndexChanged, que filtra cboMascota;
            // recien ahi buscamos la mascota por su Nombre dentro de esa lista ya
            // filtrada (evita confundir mascotas con el mismo nombre de OTRO dueño).
            SeleccionarEnComboPorTexto(cboPropietario, "NombreCompleto", nombrePropietario);
            SeleccionarMascotaPorNombre(nombreMascota);
            SeleccionarEnComboPorTexto(cboVeterinario, "NombreCompleto", nombreVeterinario);

            cboEstado.SelectedItem = fila.Cells["colEstado"].Value.ToString();
            dtpFecha.Value = DateTime.ParseExact(fila.Cells["colFecha"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dtpHora.Value = DateTime.ParseExact(fila.Cells["colHora"].Value.ToString(), "HH:mm", CultureInfo.InvariantCulture);
            txtMotivo.Text = fila.Cells["colMotivo"].Value.ToString();

            lblFormTitulo.Text = "Editar cita";
            btnGuardarCita.Text = "Guardar cambios";
            pnlFormCita.Visible = true;
        }

        // Busca, dentro de un combo cargado con un DataTable (cboPropietario,
        // cboVeterinario), la fila cuyo texto visible coincida exactamente, y
        // selecciona esa fila por su ValueMember (Id_Propietario / Id_Veterinario).
        private void SeleccionarEnComboPorTexto(ComboBox combo, string nombreColumnaTexto, string valorBuscado)
        {
            DataTable tabla = combo.DataSource as DataTable;
            if (tabla == null)
            {
                return;
            }

            foreach (DataRow fila in tabla.Rows)
            {
                if (fila[nombreColumnaTexto].ToString() == valorBuscado)
                {
                    combo.SelectedValue = fila[combo.ValueMember];
                    return;
                }
            }
        }

        // cboMascota es distinto: su DataSource es un DataView YA FILTRADO por el
        // propietario elegido (ver cboPropietario_SelectedIndexChanged), asi que
        // buscamos por Nombre solo dentro de ese subconjunto, no en todas las
        // mascotas del sistema.
        private void SeleccionarMascotaPorNombre(string nombreMascotaBuscada)
        {
            DataView vista = cboMascota.DataSource as DataView;
            if (vista == null)
            {
                return;
            }

            foreach (DataRowView filaVista in vista)
            {
                if (filaVista["Nombre"].ToString() == nombreMascotaBuscada)
                {
                    cboMascota.SelectedValue = filaVista["Id_Mascota"];
                    return;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona primero una cita de la tabla.", "Eliminar cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dgvCitas.SelectedRows[0];
            int idCita = Convert.ToInt32(fila.Cells["colIdCita"].Value);

            string resumen = fila.Cells["colMascota"].Value + " con " + fila.Cells["colVeterinario"].Value +
                "\n" + fila.Cells["colFecha"].Value + " a las " + fila.Cells["colHora"].Value +
                "\nMotivo: " + fila.Cells["colMotivo"].Value;

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar esta cita?\n\n" + resumen,
                "Eliminar cita", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            // TODO: cls_Citas_BLL.EliminaCita(ref obj_Citas_Global_DAL), usando
            // obj_Citas_Global_DAL.iId_Cita = idCita;
            // obj_Citas_Global_DAL.iId_UsuarioGlobal = this.IdUsuarioGlobal;
            // contra un futuro SP_ELIMINA_CITAS(@Id_Cita, @IdUsuarioGlobal), mismo
            // patron que los demas SP_ELIMINA_X (-2 si no existe, -1 si tiene
            // dependientes como una Consulta ya registrada, Id > 0 si se elimino).
            // Cuando este conectado, terminar con cargaCitas(); para refrescar.
            MessageBox.Show("Eliminar cita Id_Cita = " + idCita + " (pendiente de conectar)",
                "Eliminar cita", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        private void FiltrarCitas()
        {
            if (dtCitasCompleto == null)
            {
                return;
            }

            string filtro = txtBuscar.Text.Trim().ToLower();

            dgvCitas.Rows.Clear();

            foreach (DataRow fila in dtCitasCompleto.Rows)
            {
                bool coincide = filtro == string.Empty
                    || fila["Mascota"].ToString().ToLower().Contains(filtro)
                    || fila["Propietario"].ToString().ToLower().Contains(filtro)
                    || fila["Veterinario"].ToString().ToLower().Contains(filtro)
                    || fila["Motivo"].ToString().ToLower().Contains(filtro)
                    || fila["Estado"].ToString().ToLower().Contains(filtro);

                if (coincide)
                {
                    // El orden calza EXACTO con el orden de columnas del grid:
                    // Id_Cita (oculta) + las 7 visibles.
                    dgvCitas.Rows.Add(
                        fila["Id_Cita"].ToString(),
                        fila["Mascota"].ToString(),
                        fila["Propietario"].ToString(),
                        fila["Veterinario"].ToString(),
                        fila["Fecha"].ToString(),
                        fila["Hora"].ToString(),
                        fila["Motivo"].ToString(),
                        fila["Estado"].ToString()
                    );
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarCitas();
        }


        #region Cargadores de datos
        private void cargaDatosUsuarioGlobal()
        {
            try
            {
                obj_Usuario_Global_DAL = new cls_Usuarios_DAL();
                obj_Usuario_Global_DAL.iId_UsuarioGlobal = this.IdUsuarioGlobal;

                obj_Usuario_Global_BLL.CargaDatosUsuario(ref obj_Usuario_Global_DAL);

                if (obj_Usuario_Global_DAL.sMsjError == string.Empty)
                {
                    if (obj_Usuario_Global_DAL.dtDatos.Rows.Count > 0)
                    {
                        // Mismos indices que usa frmMenuAdmin: [2]=Email (usado como
                        // "nombre" a mostrar), [4]=Id_Rol, [5]=Rol (nombre del rol).
                        // Ajusta estos indices si tu SP_INFO_Usuarios trae otro orden.
                        obj_Usuario_Global_DAL.sNombre_Usuario = obj_Usuario_Global_DAL.dtDatos.Rows[0][2].ToString();
                        obj_Usuario_Global_DAL.iId_Rol = Convert.ToInt32(obj_Usuario_Global_DAL.dtDatos.Rows[0][4]);
                        obj_Usuario_Global_DAL.sNombreRol = obj_Usuario_Global_DAL.dtDatos.Rows[0][5].ToString();

                        lblInfoUsuario.Text = "Usuario: " + obj_Usuario_Global_DAL.sNombre_Usuario + " | Rol: " + obj_Usuario_Global_DAL.sNombreRol;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos del usuario.", "Información de Usuario",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
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


        private void cargaCombos()
        {
            // Propietarios
            obj_Propietarios_Global_BLL.ListarPropietarios(ref obj_Propietarios_Global_DAL);
            if (obj_Propietarios_Global_DAL.sMsjError == string.Empty && obj_Propietarios_Global_DAL.dtDatos != null)
            {
                DataTable dtProp = obj_Propietarios_Global_DAL.dtDatos;
                dtProp.Columns.Add("NombreCompleto", typeof(string));
                foreach (DataRow fila in dtProp.Rows)
                {
                    fila["NombreCompleto"] = fila["Nombre"].ToString() + " " + fila["Apellido1"].ToString();
                }

                cboPropietario.DataSource = dtProp;
                cboPropietario.DisplayMember = "NombreCompleto";
                cboPropietario.ValueMember = "Id_Propietario";
                cboPropietario.SelectedIndex = -1;
            }

            // Veterinarios
            obj_Veterinarios_Global_BLL.ListarVeterinarios(ref obj_Veterinarios_Global_DAL);
            if (obj_Veterinarios_Global_DAL.sMsjError == string.Empty && obj_Veterinarios_Global_DAL.dtDatos != null)
            {
                DataTable dtVet = obj_Veterinarios_Global_DAL.dtDatos;
                dtVet.Columns.Add("NombreCompleto", typeof(string));
                foreach (DataRow fila in dtVet.Rows)
                {
                    fila["NombreCompleto"] = fila["Nombre"].ToString() + " " + fila["Apellido1"].ToString();
                }

                cboVeterinario.DataSource = dtVet;
                cboVeterinario.DisplayMember = "NombreCompleto";
                cboVeterinario.ValueMember = "Id_Veterinario";
                cboVeterinario.SelectedIndex = -1;
            }

            // Mascotas: se guardan TODAS en memoria; cboMascota se llena luego,
            // filtrado, cuando el usuario elija un propietario (o al Modificar)
            obj_Mascotas_Global_BLL.ListarMascotas(ref obj_Mascotas_Global_DAL);
            if (obj_Mascotas_Global_DAL.sMsjError == string.Empty && obj_Mascotas_Global_DAL.dtDatos != null)
            {
                dtMascotasCompleto = obj_Mascotas_Global_DAL.dtDatos;
            }
        }

        private void cargaCitas()
        {
            try
            {
                obj_Citas_Global_BLL.ListarCitas(ref obj_Citas_Global_DAL);

                if (obj_Citas_Global_DAL.sMsjError == string.Empty)
                {
                    dtCitasCompleto = obj_Citas_Global_DAL.dtDatos;
                    FiltrarCitas(); // pinta la tabla completa la primera vez (sin filtro)
                }
                else
                {
                    dgvCitas.Rows.Clear();
                    MessageBox.Show("Ocurrió un error al intentar cargar las citas: " + obj_Citas_Global_DAL.sMsjError, "Citas",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar cargar las citas. Error: " + ex.ToString(), "Citas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
