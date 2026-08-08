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

        #region Eventos de formulario

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();
            cargaUsuarios();
            cargarComboRoles();
        }

        private void frmUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }

        #endregion

        #region Eventos de botones

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            lblFormTitulo.Text = "Nuevo Usuario";
            cboRoles.SelectedIndex = 0;
            txtNomUsuario.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContrasena.Text = string.Empty;
            obj_Usuarios_DAL.sAxn = "I";
            pnlFormUsuario.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlFormUsuario.Visible = false;
            cboRoles.SelectedIndex = 0;
            txtNomUsuario.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContrasena.Text = string.Empty;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                pnlFormUsuario.Visible = true;
                lblFormTitulo.Text = "Editar Usuario";

                /* EVALUAR SI LA TABLA CARGADA EN DGV TIENE FILAS */
                if (dgvUsuarios.Rows.Count != 0)
                {
                    /* EVALUAR SI HAY UN REGISTRO SELECCIONADO */
                    if (dgvUsuarios.SelectedRows[0] != null)
                    {
                        /* Establecer propiedades para editar el registro */
                        obj_Usuarios_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;
                        obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());
                        obj_Usuarios_DAL.iId_Rol = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[1].Value.ToString());
                        obj_Usuarios_DAL.sNombreRol = dgvUsuarios.SelectedRows[0].Cells[2].Value.ToString();
                        obj_Usuarios_DAL.sNombre_Usuario = dgvUsuarios.SelectedRows[0].Cells[3].Value.ToString();
                        obj_Usuarios_DAL.sEmail = dgvUsuarios.SelectedRows[0].Cells[4].Value.ToString();
                        obj_Usuarios_DAL.sContrasena = dgvUsuarios.SelectedRows[0].Cells[5].Value.ToString();
                        obj_Usuarios_DAL.sEstado = dgvUsuarios.SelectedRows[0].Cells[6].Value.ToString();

                        obj_Usuarios_DAL.sAxn = "A"; // I = Insertar, A = Actualizar, E = Eliminar, L = Inicio Sesion, X = Cerrar Sesion

                        cboRoles.SelectedValue = obj_Usuarios_DAL.iId_Rol;
                        txtNomUsuario.Text = obj_Usuarios_DAL.sNombre_Usuario;
                        txtEmail.Text = obj_Usuarios_DAL.sEmail;
                        txtContrasena.Text = obj_Usuarios_DAL.sContrasena;

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un registro de la lista para editar.",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No hay registros en la lista para editar.",
                        "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento un error al intentar editar el registro. Error: " + ex.ToString(),
                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                /* EVALUAR SI LA TABLA CARGADA EN DGV TIENE FILAS */
                if (dgvUsuarios.Rows.Count != 0)
                {
                    /* EVALUAR SI HAY UN REGISTRO SELECCIONADO */
                    if (dgvUsuarios.SelectedRows[0] != null)
                    {
                        if (MessageBox.Show("Desea eliminar el registro [ " +
                            dgvUsuarios.SelectedRows[0].Cells[2].Value.ToString() + " - " +
                            dgvUsuarios.SelectedRows[0].Cells[3].Value.ToString() + " - " +
                            dgvUsuarios.SelectedRows[0].Cells[4].Value.ToString() + " ] ? ",
                            "Confirmacion de proceso",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            /* Establecer propiedades para eliminar el registro */
                            obj_Usuarios_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;
                            obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString());

                            /* LLAMAR A BLL DEL PROCESO ELIMINAR REGISTROS */
                            obj_Usuarios_BLL.EliminarUsuarios(ref obj_Usuarios_DAL);

                            /* EVALUAR VALOR SCALAR DEL RESULTADO DE EJECUCION */
                            if (obj_Usuarios_DAL.sValorScalar != "-1" &&
                                obj_Usuarios_DAL.sValorScalar != "0")
                            {
                                MessageBox.Show("La informacion del registro ha sido eliminada de forma correcta",
                                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                cargaUsuarios();
                            }
                            else if (obj_Usuarios_DAL.sValorScalar == "-1")
                            {
                                MessageBox.Show("Existen registros asociados al elemento que desea eliminar. Verifique!!",
                                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show("Se presento un error al intentar eliminar el registro. Error: " + obj_Usuarios_DAL.sMsjError,
                                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un registro de la lista para eliminar.",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No hay registros en la lista para eliminar.",
                        "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                pnlFormUsuario.Visible = false; // Ocultar el panel del formulario

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento un error al intentar eliminar el registro. Error: " + ex.ToString(),
                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarUsuarios_Click(object sender, EventArgs e)
        {
            try
            {

                if (cboRoles.SelectedIndex == -1 ||
                   string.IsNullOrEmpty(txtNomUsuario.Text) ||
                   string.IsNullOrEmpty(txtEmail.Text) ||
                   string.IsNullOrEmpty(txtContrasena.Text) ||
                   cboEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe completar todos los campos del formulario antes de guardar.",
                        "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                /* Capturar info del formulario y guardarla en el obj*/
                obj_Usuarios_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal; // Para auditoria

                // Solo obtener el Id si es una modificación
                if (obj_Usuarios_DAL.sAxn == "A")
                {
                    obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[0].Value);
                }

                obj_Usuarios_DAL.iId_Rol = Convert.ToInt32(cboRoles.SelectedValue);
                obj_Usuarios_DAL.sNombreRol = cboRoles.Text;
                obj_Usuarios_DAL.sNombre_Usuario = txtNomUsuario.Text;
                obj_Usuarios_DAL.sEmail = txtEmail.Text;
                obj_Usuarios_DAL.sContrasena = txtContrasena.Text;
                obj_Usuarios_DAL.sEstado = cboEstado.Text == "Activo" ? "A" : "I";


                /* DETERMINAR SI ES NUEVO O SI YA EXISTE*/
                if (obj_Usuarios_DAL.sAxn == "I")
                {
                    obj_Usuarios_BLL.NuevoUsuario(ref obj_Usuarios_DAL);

                    /*EVALUAR VALOR SCALAR*/
                    if (obj_Usuarios_DAL.sValorScalar != "-1" &&
                        obj_Usuarios_DAL.sValorScalar != "0")
                    {
                        MessageBox.Show("La informacion del registro ha sido guardada de forma correcta",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (obj_Usuarios_DAL.sValorScalar == "-1")
                    {
                        MessageBox.Show("Ya existe un registro con la misma informacion. Verifique!!",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Se presento un error al intentar guardar el registro. Error: " + obj_Usuarios_DAL.sMsjError,
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    obj_Usuarios_BLL.ModificarUsuario(ref obj_Usuarios_DAL);

                    /*EVALUAR VALOR SCALAR*/
                    if (obj_Usuarios_DAL.sValorScalar != "-1" &&
                        obj_Usuarios_DAL.sValorScalar != "0")
                    {
                        MessageBox.Show("La informacion del registro ha sido actualizada de forma correcta",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (obj_Usuarios_DAL.sValorScalar == "-1")
                    {
                        MessageBox.Show("Ya existe un registro con la misma informacion. Verifique!!",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Se presento un error al intentar actualizar el registro. Error: " + obj_Usuarios_DAL.sMsjError,
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                cargaUsuarios(); // Refrescar la informacion del formulario
                pnlFormUsuario.Visible = false; // Ocultar el panel del formulario

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento un error al intentar guardar la informacion del registro. Error: " + ex.ToString(),
                                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion

        #region Carga y Filtrado de Datos

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
                        configurarGridUsuarios();
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

        private void configurarGridUsuarios()
        {
            // Ocultar columnas
            dgvUsuarios.Columns[0].Visible = false; // Ocultar columna Id_Usuario
            dgvUsuarios.Columns[1].Visible = false; // Ocultar columna Id_Rol
            dgvUsuarios.Columns[5].Visible = false; // Ocultar columna Contrasena

            // Cambiar encabezados
            dgvUsuarios.Columns[2].HeaderText = "Rol";
            dgvUsuarios.Columns[3].HeaderText = "Nombre de Usuario";
            dgvUsuarios.Columns[4].HeaderText = "Email";
            dgvUsuarios.Columns[6].HeaderText = "Estado";

            // Ajustar ancho automáticamente
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            configurarGridUsuarios();
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

        #endregion

    }
}
