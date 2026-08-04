using BLL_VETNOVA.Entidades;
using DAL_VETNOVA.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_VETNOVA.Pantallas.Usuarios
{
    public partial class frmUsuarios : Form
    {

        #region Variables Globales o de entidades

        public cls_Usuarios_DAL obj_Usuario_Global_DAL;
        public cls_Usuarios_BLL obj_Usuario_Global_BLL = new cls_Usuarios_BLL();

        public cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
        public cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();

        #endregion

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();
            //cargaUsuarios();

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
                        lblInfoUsuario.Text = "Usuario: " + obj_Usuario_Global_DAL.sNombre_Usuario + "  | Rol: " + obj_Usuario_Global_DAL.sNombreRol;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos del usuario en la base de datos.", "Informacion de usuario",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Pantallas.Generales.frmInicioSesion obj_Formulario = new Pantallas.Generales.frmInicioSesion();
                        this.Hide();
                        obj_Formulario.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al intentar cargar la informacion del usuario. Error: " + obj_Usuario_Global_DAL.sMsjError, "Informacion de usuario",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al intentar cargar la informacion del usuario. Error: " + ex.ToString(), "Informacion de usuario",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
        private void cargaUsuarios()
        {
            try
            {
                obj_Usuarios_BLL.ListarUsuarios(ref obj_Usuarios_DAL);

                if (obj_Usuarios_DAL.sMsjError == string.Empty)
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
        */
    }
}
