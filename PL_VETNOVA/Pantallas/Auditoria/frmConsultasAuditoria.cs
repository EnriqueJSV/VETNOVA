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

namespace PL_VETNOVA.Pantallas.Auditoria
{
    public partial class frmConsultasAuditoria : Form
    {

        #region Variables Globales o de Entidades

        // Se le pasa desde el menu que abre esta ventana (solo Admin tiene
        // acceso), igual que en frmCitas, para mostrar el usuario/rol y para
        // futuras validaciones.
        public cls_Usuarios_DAL obj_Usuario_Global_DAL;
        public cls_Usuarios_BLL obj_Usuario_Global_BLL = new cls_Usuarios_BLL();

        public cls_Auditoria_DAL obj_Auditoria_DAL = new cls_Auditoria_DAL();
        public cls_Auditoria_BLL obj_Auditoria_BLL = new cls_Auditoria_BLL();

        #endregion

        public frmConsultasAuditoria()
        {
            InitializeComponent();

            // Mismo motivo que en frmCitas: al bindear el grid directo a un
            // DataTable mas adelante, esto evita que WinForms autogenere
            // columnas de mas ademas de las 4 que ya definimos a mano.
            dgvAuditoria.AutoGenerateColumns = false;
        }

        private void frmConsultasAuditoria_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();
            cargaAuditoria();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultasAuditoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
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
                        // Mismos indices que usa frmCitas / frmMenuAdmin: [2]=Email,
                        // [4]=Id_Rol, [5]=Rol.
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

        private void cargaAuditoria()
        {
            try
            {
                obj_Auditoria_BLL.ListarAuditoria(ref obj_Auditoria_DAL);

                if (obj_Auditoria_DAL.sMsjError == string.Empty)
                {
                    dgvAuditoria.DataSource = obj_Auditoria_DAL.dtDatos;
                }
                else
                {
                    dgvAuditoria.DataSource = null;
                    MessageBox.Show("Ocurrió un error al intentar cargar la auditoría: " + obj_Auditoria_DAL.sMsjError, "Auditoría",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar cargar la auditoría. Error: " + ex.ToString(), "Auditoría",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void filtrarAuditoria()
        {
            if (obj_Auditoria_DAL.dtDatos == null)
                return;

            // Crea un nuevo DataTable con la misma estructura (columnas) que el original,
            // pero sin registros. Aquí se almacenarán únicamente los registros filtrados.
            DataTable resultado = obj_Auditoria_DAL.dtDatos.Clone();


            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1); // 23:59:59

            obj_Auditoria_DAL.sFiltro = txtBuscar.Text.Trim().Replace("'", "''");

            // Recorre cada fila del DataTable original de auditoría.
            foreach (DataRow fila in obj_Auditoria_DAL.dtDatos.Rows)
            {
                // Convierte el valor de la columna FechaHora (que viene como texto desde el SP)
                // a un objeto DateTime utilizando el formato "dd/MM/yyyy HH:mm".
                DateTime fecha = DateTime.ParseExact(
                    fila["FechaHora"].ToString(),
                    "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture);

                // Evalúa si el registro cumple con el filtro de usuario.
                // Si el cuadro de búsqueda está vacío, se aceptan todos los usuarios.
                // En caso contrario, compara el nombre del usuario de la fila con el texto buscado.
                bool cumpleUsuario =
                    string.IsNullOrEmpty(obj_Auditoria_DAL.sFiltro) ||
                    fila["Usuario"].ToString().IndexOf(obj_Auditoria_DAL.sFiltro, StringComparison.OrdinalIgnoreCase) >= 0;

                // Evalúa si la fecha del registro está dentro del rango seleccionado entre "desde" y "hasta".
                bool cumpleFecha = fecha >= desde && fecha <= hasta;

                // Si el registro cumple tanto el filtro de usuario como el rango de fechas,
                // se agrega al DataTable filtrado.
                if (cumpleUsuario && cumpleFecha)
                {
                    resultado.ImportRow(fila);
                }
            }

            // Asigna el DataTable filtrado como origen de datos del DataGridView,
            // mostrando únicamente los registros que cumplieron los filtros.
            dgvAuditoria.DataSource = resultado;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarAuditoria();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            filtrarAuditoria();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            filtrarAuditoria();
        }

        #endregion


    }
}