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

        public cls_Roles_DAL obj_Roles_DAL = new cls_Roles_DAL();
        public cls_Roles_BLL obj_Roles_BLL = new cls_Roles_BLL();

        #endregion

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();
            cargaUsuarios();
            cargarComboRoles();

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

        private void cargaUsuarios()
        {
            try
            {

                obj_Usuarios_BLL.ListarUsuarios(ref obj_Usuarios_DAL);

                if (obj_Usuarios_DAL.dtDatos != null)
                {
                    if (obj_Usuarios_DAL.dtDatos.Rows.Count != 0)
                    {
                        dgvUsuarios.DataSource = null;
                        dgvUsuarios.DataSource = obj_Usuarios_DAL.dtDatos;
                        filtrarUsuarios(ref obj_Usuarios_DAL);
                    }
                    else
                    {
                        dgvUsuarios.DataSource = null;
                        MessageBox.Show("No se encontraron datos en la base de datos.",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    dgvUsuarios.DataSource = null;
                    MessageBox.Show("Se presento un error al intentar cargar la lista de datos. Error: " + obj_Usuarios_DAL.sMsjError,
                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento un error al intentar cargar la lista de datos. Error: " + ex.ToString(),
                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void filtrarUsuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            if (obj_Usuarios_DAL.dtDatos == null)
                return;

            obj_Usuarios_DAL.sFiltro = txtBuscar.Text.Trim().Replace("'", "''");

            DataView vista = obj_Usuarios_DAL.dtDatos.DefaultView;

            if (string.IsNullOrEmpty(obj_Usuarios_DAL.sFiltro))
            {
                vista.RowFilter = "";
            }
            else
            {
                vista.RowFilter =
                    $"Rol LIKE '%{obj_Usuarios_DAL.sFiltro}%' OR " +
                    $"Nombre_Usuario LIKE '%{obj_Usuarios_DAL.sFiltro}%' OR " +
                    $"Email LIKE '%{obj_Usuarios_DAL.sFiltro}%' OR " +
                    $"Estado LIKE '%{obj_Usuarios_DAL.sFiltro}%'";
            }

            dgvUsuarios.DataSource = vista;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarUsuarios(ref obj_Usuarios_DAL);
        }

        private void cargarComboRoles()
        {
            try
            {

                obj_Roles_BLL.ListarRoles(ref obj_Roles_DAL);

                if (obj_Roles_DAL.dtDatos != null)
                {
                    if (obj_Roles_DAL.dtDatos.Rows.Count != 0)
                    {
                        cboRoles.ValueMember = "Id_Rol";
                        cboRoles.DisplayMember = "Rol";

                        cboRoles.DataSource = obj_Roles_DAL.dtDatos;

                        cboRoles.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros de tipos de identificacion disponibles",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Se presento un error al intentar cargar la lista de tipos de identificacion " +
                        "disponibles", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento un error al intentar cargar la lista de tipos de identificacion " +
                            "disponibles. Error: " + ex.ToString(), "Informacion del sistema",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            pnlFormUsuario.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlFormUsuario.Visible = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
