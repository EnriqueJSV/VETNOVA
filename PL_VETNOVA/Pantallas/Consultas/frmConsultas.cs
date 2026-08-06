using BLL_VETNOVA.Entidades;
using DAL_VETNOVA.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_VETNOVA.Pantallas.Consultas
{
    public partial class frmConsultas : Form
    {

        #region Variables Globales o de Entidades

        public cls_Usuarios_DAL obj_Usuario_Global_DAL;
        public cls_Usuarios_BLL obj_Usuario_Global_BLL = new cls_Usuarios_BLL();

        // Reutilizamos cls_Citas_BLL.ListarCitas y cls_Mascotas_BLL.ListarMascotas
        // (las mismas que usa frmCitas) para armar los combos, sin SPs nuevos.
        public cls_Citas_DAL obj_Citas_Global_DAL = new cls_Citas_DAL();
        public cls_Citas_BLL obj_Citas_Global_BLL = new cls_Citas_BLL();

        public cls_Mascotas_DAL obj_Mascotas_Global_DAL = new cls_Mascotas_DAL();
        public cls_Mascotas_BLL obj_Mascotas_Global_BLL = new cls_Mascotas_BLL();

        public cls_Consultas_DAL obj_Consultas_Global_DAL = new cls_Consultas_DAL();
        public cls_Consultas_BLL obj_Consultas_Global_BLL = new cls_Consultas_BLL();

        private DataView vistaCitasPendientes; // citas Pendiente/Confirmada de la mascota elegida, filtradas en memoria
        private DataTable dtConsultasCompleto; // todas las consultas, para armar el historial en memoria

        #endregion

        public frmConsultas()
        {
            InitializeComponent();

            // Mismo motivo que en frmCitas/frmConsultasAuditoria: evita que
            // WinForms autogenere columnas de mas cuando se bindee el grid de
            // historial.
            dgvHistorial.AutoGenerateColumns = false;
        }

        private void frmConsultas_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();
            cargaMascotas();
            cargaCitasCompleto();
            cargaConsultasCompleto();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }

        // Al elegir la mascota: filtra cboCita en memoria (solo las Pendiente/
        // Confirmada de ESA mascota) y carga el historial de una vez, sin
        // esperar a que se elija una cita.
        private void cboMascota_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCita.SelectedIndex = -1;
            txtDiagnostico.Clear();
            txtTratamiento.Clear();
            txtObservaciones.Clear();

            if (cboMascota.SelectedValue == null || vistaCitasPendientes == null)
            {
                if (vistaCitasPendientes != null)
                {
                    vistaCitasPendientes.RowFilter = "1=0";
                }
                dgvHistorial.DataSource = null;
                return;
            }

            string nombreMascota = cboMascota.Text;
            string nombreEscapado = nombreMascota.Replace("'", "''");

            vistaCitasPendientes.RowFilter =
                "(Estado = 'Pendiente' OR Estado = 'Confirmada') AND Mascota = '" + nombreEscapado + "'";

            cargaHistorialConsultas(nombreMascota);
        }

        private void btnGuardarConsulta_Click(object sender, EventArgs e)
        {
            if (cboCita.SelectedValue == null || string.IsNullOrWhiteSpace(txtDiagnostico.Text) ||
                string.IsNullOrWhiteSpace(txtTratamiento.Text))
            {
                MessageBox.Show("Selecciona una cita y completa al menos Diagnóstico y Tratamiento antes de guardar.", "Consultas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                obj_Consultas_Global_DAL.iId_Cita = Convert.ToInt32(cboCita.SelectedValue);
                obj_Consultas_Global_DAL.sDiagnostico = txtDiagnostico.Text.Trim();
                obj_Consultas_Global_DAL.sTratamiento = txtTratamiento.Text.Trim();
                obj_Consultas_Global_DAL.sObservaciones = txtObservaciones.Text.Trim();
                obj_Consultas_Global_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;

                obj_Consultas_Global_BLL.InsertaConsulta(ref obj_Consultas_Global_DAL);

                if (obj_Consultas_Global_DAL.sValorScalar == "-1")
                {
                    MessageBox.Show("Esta cita ya tiene una consulta registrada.", "Consultas",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (obj_Consultas_Global_DAL.sMsjError == string.Empty && obj_Consultas_Global_DAL.sValorScalar != "0")
                {
                    MessageBox.Show("La consulta se guardó correctamente.", "Consultas",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string nombreMascotaActual = cboMascota.Text;

                    txtDiagnostico.Clear();
                    txtTratamiento.Clear();
                    txtObservaciones.Clear();

                    cargaCitasCompleto();     // refresca estados (la cita quedo "Atendida")
                    cargaConsultasCompleto(); // trae la consulta recien insertada, ya con Fecha/Mascota enlazadas

                    // Se mantiene la mascota elegida y se reaplica su filtro +
                    // historial, ya con los datos frescos.
                    if (!string.IsNullOrEmpty(nombreMascotaActual))
                    {
                        string nombreEscapado = nombreMascotaActual.Replace("'", "''");
                        vistaCitasPendientes.RowFilter =
                            "(Estado = 'Pendiente' OR Estado = 'Confirmada') AND Mascota = '" + nombreEscapado + "'";
                        cargaHistorialConsultas(nombreMascotaActual);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar guardar la consulta: " + obj_Consultas_Global_DAL.sMsjError, "Consultas",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar guardar la consulta. Error: " + ex.ToString(), "Consultas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Cargadores de datos

        private void cargaDatosUsuarioGlobal()
        {
            try
            {
                obj_Usuario_Global_BLL.CargaDatosUsuario(ref obj_Usuario_Global_DAL);

                if (obj_Usuario_Global_DAL.sMsjError == string.Empty)
                {
                    if (obj_Usuario_Global_DAL.dtDatos.Rows.Count > 0)
                    {
                        // Mismos indices que usa frmCitas / frmConsultasAuditoria:
                        // [2]=Email, [4]=Id_Rol, [5]=Rol.
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

        // Ordenado alfabeticamente con DataView.Sort, sin buscador.
        private void cargaMascotas()
        {
            try
            {
                obj_Mascotas_Global_BLL.ListarMascotas(ref obj_Mascotas_Global_DAL);

                if (obj_Mascotas_Global_DAL.sMsjError == string.Empty && obj_Mascotas_Global_DAL.dtDatos != null)
                {
                    DataView vistaMascotas = new DataView(obj_Mascotas_Global_DAL.dtDatos);
                    vistaMascotas.Sort = "Nombre ASC";

                    cboMascota.DataSource = vistaMascotas;
                    cboMascota.DisplayMember = "Nombre";
                    cboMascota.ValueMember = "Id_Mascota";
                    cboMascota.SelectedIndex = -1;
                }
                else
                {
                    cboMascota.DataSource = null;
                    MessageBox.Show("Ocurrió un error al intentar cargar las mascotas: " + obj_Mascotas_Global_DAL.sMsjError, "Consultas",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar cargar las mascotas. Error: " + ex.ToString(), "Consultas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Trae TODAS las citas (mismo SP_LISTAR_CITAS de frmCitas). El combo
        // cboCita arranca vacio (RowFilter = "1=0") hasta que se elija una
        // mascota en cboMascota_SelectedIndexChanged.
        private void cargaCitasCompleto()
        {
            try
            {
                obj_Citas_Global_BLL.ListarCitas(ref obj_Citas_Global_DAL);

                if (obj_Citas_Global_DAL.sMsjError == string.Empty)
                {
                    DataTable dtCitas = obj_Citas_Global_DAL.dtDatos;

                    if (!dtCitas.Columns.Contains("Resumen"))
                    {
                        dtCitas.Columns.Add("Resumen", typeof(string));
                    }
                    foreach (DataRow fila in dtCitas.Rows)
                    {
                        fila["Resumen"] = fila["Fecha"] + " - " + fila["Hora"] + " - " + fila["Motivo"];
                    }

                    vistaCitasPendientes = new DataView(dtCitas);
                    vistaCitasPendientes.RowFilter = "1=0"; // vacio hasta elegir mascota

                    cboCita.DataSource = vistaCitasPendientes;
                    cboCita.DisplayMember = "Resumen";
                    cboCita.ValueMember = "Id_Cita";
                    cboCita.SelectedIndex = -1;
                }
                else
                {
                    cboCita.DataSource = null;
                    MessageBox.Show("Ocurrió un error al intentar cargar las citas: " + obj_Citas_Global_DAL.sMsjError, "Consultas",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar cargar las citas. Error: " + ex.ToString(), "Consultas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Trae TODAS las consultas (SP_LISTAR_CONSULTAS) una sola vez, y las
        // enriquece con Fecha y Mascota (sacadas de obj_Citas_Global_DAL.dtDatos)
        // UNA SOLA VEZ aca. Asi, cargaHistorialConsultas() ya no necesita cruzar
        // nada: solo filtra este DataTable con un DataView normal.
        private void cargaConsultasCompleto()
        {
            try
            {
                obj_Consultas_Global_BLL.ListarConsultas(ref obj_Consultas_Global_DAL);

                if (obj_Consultas_Global_DAL.sMsjError == string.Empty)
                {
                    dtConsultasCompleto = obj_Consultas_Global_DAL.dtDatos;

                    if (!dtConsultasCompleto.Columns.Contains("Fecha"))
                    {
                        dtConsultasCompleto.Columns.Add("Fecha", typeof(string));
                    }
                    if (!dtConsultasCompleto.Columns.Contains("Mascota"))
                    {
                        dtConsultasCompleto.Columns.Add("Mascota", typeof(string));
                    }

                    if (obj_Citas_Global_DAL.dtDatos != null)
                    {
                        foreach (DataRow filaConsulta in dtConsultasCompleto.Rows)
                        {
                            int idCita = Convert.ToInt32(filaConsulta["Id_Cita"]);

                            DataRow[] citaCoincidente = obj_Citas_Global_DAL.dtDatos.Select("Id_Cita = " + idCita);
                            if (citaCoincidente.Length > 0)
                            {
                                filaConsulta["Fecha"] = citaCoincidente[0]["Fecha"];
                                filaConsulta["Mascota"] = citaCoincidente[0]["Mascota"];
                            }
                        }
                    }
                }
                else
                {
                    dtConsultasCompleto = null;
                    MessageBox.Show("Ocurrió un error al intentar cargar el historial de consultas: " + obj_Consultas_Global_DAL.sMsjError, "Consultas",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar cargar el historial de consultas. Error: " + ex.ToString(), "Consultas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ya con Fecha y Mascota puestas en dtConsultasCompleto, esto es
        // simplemente un DataView filtrado y ordenado. Nada de diccionarios ni
        // recorridos manuales por cada mascota que se elige.
        private void cargaHistorialConsultas(string nombreMascota)
        {
            if (dtConsultasCompleto == null)
            {
                dgvHistorial.DataSource = null;
                return;
            }

            string nombreEscapado = nombreMascota.Replace("'", "''");

            DataView vistaHistorial = new DataView(dtConsultasCompleto);
            vistaHistorial.RowFilter = "Mascota = '" + nombreEscapado + "'";
            vistaHistorial.Sort = "Fecha DESC";

            dgvHistorial.DataSource = vistaHistorial;
        }

        #endregion
    }
}