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
using System.Configuration;

namespace PL_VETNOVA.Pantallas.Generales
{
    public partial class frmInicioSesion : Form
    {
        #region Variables Globales o de Entidades
        cls_Usuarios_DAL obj_Usuarios_DAL = new cls_Usuarios_DAL();
        cls_Usuarios_BLL obj_Usuarios_BLL = new cls_Usuarios_BLL();
        #endregion

        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                obj_Usuarios_DAL.sMsjError = string.Empty;
                obj_Usuarios_DAL.sNombre_Usuario = txtUsuario.Text;
                obj_Usuarios_DAL.sContrasena = txtContrasena.Text;

                obj_Usuarios_BLL.IniciarSesion(ref obj_Usuarios_DAL);

                if (obj_Usuarios_DAL.sMsjError == string.Empty)
                {
                    if (obj_Usuarios_DAL.sValorScalar != "0" && obj_Usuarios_DAL.sValorScalar != "-1")
                    {
                        obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(obj_Usuarios_DAL.sValorScalar);
                        obj_Usuarios_DAL.iId_UsuarioGlobal = Convert.ToInt32(obj_Usuarios_DAL.sValorScalar);

                        MessageBox.Show("Bienvenido al sistema", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (obj_Usuarios_DAL.iId_Rol == 1)
                        {
                            Pantallas.Generales.frmMenuAdmin obj_Formuario = new Pantallas.Generales.frmMenuAdmin();
                            this.Hide();
                            obj_Formuario.obj_Usuario_Global_DAL = obj_Usuarios_DAL;
                            obj_Formuario.Show(this);
                        }
                        else if (obj_Usuarios_DAL.iId_Rol == 2)
                        {
                            Pantallas.Generales.frmMenuVeterinario obj_Formuario = new Pantallas.Generales.frmMenuVeterinario();
                            this.Hide();
                            obj_Formuario.obj_Usuario_Global_DAL = obj_Usuarios_DAL;
                            obj_Formuario.Show(this);
                        }
                        else if (obj_Usuarios_DAL.iId_Rol == 3)
                        {
                            Pantallas.Generales.frmMenuRecepcionista obj_Formuario = new Pantallas.Generales.frmMenuRecepcionista();
                            this.Hide();
                            obj_Formuario.obj_Usuario_Global_DAL = obj_Usuarios_DAL;
                            obj_Formuario.Show(this);
                        }

                    }
                    else if (obj_Usuarios_DAL.sValorScalar == "-1")
                    {
                        MessageBox.Show("Las credenciales de acceso al sistema son incorrectas", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al intentar iniciar sesión en el sistema.", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar iniciar sesión en el sistema.", "Inicio de Sesión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar iniciar sesión en el sistema. Código Error: " +
                    ex.ToString(), "Inicio de Sesión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            lblMensaje.Text = string.Empty;
            txtUsuario.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
