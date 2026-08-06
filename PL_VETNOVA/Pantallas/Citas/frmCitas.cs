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
        public frmCitas()
        {
            InitializeComponent();

            // Se fuerza acá en código porque el grid se bindea directo al DataTable
            // (dgvCitas.DataSource = obj_Citas_Global_DAL.dtDatos en cargaCitas()).
            // Sin esto, cada vez que se recarga el grid, WinForms vuelve a
            // autogenerar columnas de más ademas de las 8 que ya definimos a mano.
            dgvCitas.AutoGenerateColumns = false;
        }

        #region Variables Globales o de Entidades

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

        #region Eventos Forms
        private void frmCitas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }


        private void frmCitas_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();

            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new object[] { "Pendiente", "Confirmada", "Atendida", "Cancelada" });

            cargaCitas();
            cargaCombos();
        }

        #endregion

        #region Eventos Botones
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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
                obj_Citas_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

                if (idCitaEnEdicion.HasValue)
                {
                    // Igual que Guardar (INSERT): un solo mensaje de éxito, un solo
                    // mensaje de error. El único caso especial es -2 (alguien mas
                    // ya elimino esta cita mientras la estabamos editando).
                    obj_Citas_Global_DAL.iId_Cita = idCitaEnEdicion.Value;

                    obj_Citas_Global_BLL.ActualizaCita(ref obj_Citas_Global_DAL);

                    if (obj_Citas_Global_DAL.sValorScalar == "-2")
                    {
                        MessageBox.Show("La cita ya no existe (puede que la hayan eliminado). Se va a refrescar la lista.", "Editar cita",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (obj_Citas_Global_DAL.sMsjError == string.Empty && obj_Citas_Global_DAL.sValorScalar != "0")
                    {
                        MessageBox.Show("La cita se actualizó correctamente.", "Editar cita",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al intentar actualizar la cita: " + obj_Citas_Global_DAL.sMsjError, "Editar cita",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona primero una cita de la tabla.", "Modificar cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView filaSeleccionada = dgvCitas.SelectedRows[0].DataBoundItem as DataRowView;
            if (filaSeleccionada == null)
            {
                MessageBox.Show("No se pudo leer la información de la fila seleccionada.", "Modificar cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            idCitaEnEdicion = Convert.ToInt32(filaSeleccionada["Id_Cita"]);

            string nombrePropietario = filaSeleccionada["Propietario"].ToString();
            string nombreMascota = filaSeleccionada["Mascota"].ToString();
            string nombreVeterinario = filaSeleccionada["Veterinario"].ToString();

            // No usamos IDs ocultos: buscamos el propietario y el veterinario por
            // el mismo texto (Nombre + Apellido1) que ya se ve en la tabla. Esto
            // dispara cboPropietario_SelectedIndexChanged, que filtra cboMascota;
            // recien ahi buscamos la mascota por su Nombre dentro de esa lista ya
            // filtrada (evita confundir mascotas con el mismo nombre de OTRO dueño).
            SeleccionarEnComboPorTexto(cboPropietario, "NombreCompleto", nombrePropietario);
            SeleccionarMascotaPorNombre(nombreMascota);
            SeleccionarEnComboPorTexto(cboVeterinario, "NombreCompleto", nombreVeterinario);

            cboEstado.SelectedItem = filaSeleccionada["Estado"].ToString();
            dtpFecha.Value = DateTime.ParseExact(filaSeleccionada["Fecha"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dtpHora.Value = DateTime.ParseExact(filaSeleccionada["Hora"].ToString(), "HH:mm", CultureInfo.InvariantCulture);
            txtMotivo.Text = filaSeleccionada["Motivo"].ToString();

            lblFormTitulo.Text = "Editar cita";
            btnGuardarCita.Text = "Guardar cambios";
            pnlFormCita.Visible = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona primero una cita de la tabla.", "Eliminar cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView filaSeleccionada = dgvCitas.SelectedRows[0].DataBoundItem as DataRowView;
            if (filaSeleccionada == null)
            {
                MessageBox.Show("No se pudo leer la información de la fila seleccionada.", "Eliminar cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idCita = Convert.ToInt32(filaSeleccionada["Id_Cita"]);

            string resumen = filaSeleccionada["Mascota"] + " con " + filaSeleccionada["Veterinario"] +
                "\n" + filaSeleccionada["Fecha"] + " a las " + filaSeleccionada["Hora"] +
                "\nMotivo: " + filaSeleccionada["Motivo"];

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar esta cita?\n\n" + resumen,
                "Eliminar cita", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            obj_Citas_Global_DAL.iId_Cita = idCita;
            obj_Citas_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

            obj_Citas_Global_BLL.EliminaCita(ref obj_Citas_Global_DAL);

            // Mismo espiritu que Guardar/Actualizar: un mensaje de éxito, un
            // mensaje de error, y dos casos especiales propios de Eliminar
            // (-1 tiene dependientes, -2 ya no existe).
            if (obj_Citas_Global_DAL.sValorScalar == "-1")
            {
                MessageBox.Show("Esta cita tiene una consulta registrada asociada, no se puede eliminar.", "Eliminar cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (obj_Citas_Global_DAL.sValorScalar == "-2")
            {
                MessageBox.Show("La cita ya no existe (puede que ya la hayan eliminado). Se va a refrescar la lista.", "Eliminar cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cargaCitas();
            }
            else if (obj_Citas_Global_DAL.sMsjError == string.Empty && obj_Citas_Global_DAL.sValorScalar != "0")
            {
                MessageBox.Show("La cita se eliminó correctamente.", "Eliminar cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargaCitas();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar eliminar la cita: " + obj_Citas_Global_DAL.sMsjError, "Eliminar cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos de Manipulacion de datos // Cargar-Filtrar-Limpiar
        private void cargaDatosUsuarioGlobal()
        {
            try
            {
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
                obj_Citas_Global_BLL.ListarFiltrarCitas(txtBuscar.Text.Trim(), ref obj_Citas_Global_DAL);

                if (obj_Citas_Global_DAL.sMsjError == string.Empty)
                {
                    dgvCitas.DataSource = obj_Citas_Global_DAL.dtDatos;
                }
                else
                {
                    dgvCitas.DataSource = null;
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargaCitas();
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

        #endregion
    }
}