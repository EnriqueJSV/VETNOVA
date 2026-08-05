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

        public cls_Auditoria_DAL obj_Auditoria_Global_DAL = new cls_Auditoria_DAL();
        public cls_Auditoria_BLL obj_Auditoria_Global_BLL = new cls_Auditoria_BLL();

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
                obj_Auditoria_Global_BLL.ListarAuditoria(ref obj_Auditoria_Global_DAL);

                if (obj_Auditoria_Global_DAL.sMsjError == string.Empty)
                {
                    dgvAuditoria.DataSource = obj_Auditoria_Global_DAL.dtDatos;
                }
                else
                {
                    dgvAuditoria.DataSource = null;
                    MessageBox.Show("Ocurrió un error al intentar cargar la auditoría: " + obj_Auditoria_Global_DAL.sMsjError, "Auditoría",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar cargar la auditoría. Error: " + ex.ToString(), "Auditoría",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}