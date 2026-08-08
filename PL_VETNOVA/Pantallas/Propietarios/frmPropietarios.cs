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

namespace PL_VETNOVA.Pantallas.Propietarios
{
    public partial class frmPropietarios : Form
    {

        #region Variables Globales o Entidades

        public cls_Usuarios_DAL obj_Usuario_Global_DAL;
        public cls_Usuarios_BLL obj_Usuario_Global_BLL = new cls_Usuarios_BLL();

        public cls_Propietarios_DAL obj_Propietarios_DAL = new cls_Propietarios_DAL();
        public cls_Propietarios_BLL obj_Propietarios_BLL = new cls_Propietarios_BLL();

        public cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL = new cls_Tipos_Identificacion_DAL();
        public cls_Tipos_Identificacion_BLL obj_Tipos_Identificacion_BLL = new cls_Tipos_Identificacion_BLL();

        #endregion

        public frmPropietarios()
        {
            InitializeComponent();
        }

        #region Eventos de Formularios

        private void frmPropietarios_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();
            cargaPropietarios();
            cargarComboTiposIdentificacion();
        }

        private void frmPropietarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
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

        private void cargaPropietarios()
        {
            try
            {

                obj_Propietarios_BLL.ListarPropietarios(ref obj_Propietarios_DAL);

                if (obj_Propietarios_DAL.dtDatos != null)
                {
                    if (obj_Propietarios_DAL.dtDatos.Rows.Count != 0)
                    {
                        dgvPropietarios.DataSource = null;
                        dgvPropietarios.DataSource = obj_Propietarios_DAL.dtDatos;
                        configurarGridPropietarios();
                        filtrarPropietarios(ref obj_Propietarios_DAL);
                    }
                    else
                    {
                        dgvPropietarios.DataSource = null;
                        MessageBox.Show("No se encontraron datos en la base de datos.",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    dgvPropietarios.DataSource = null;
                    MessageBox.Show("Se presento un error al intentar cargar la lista de datos. Error: " + obj_Propietarios_DAL.sMsjError,
                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento un error al intentar cargar la lista de datos. Error: " + ex.ToString(),
                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void configurarGridPropietarios()
        {
            // Ocultar columnas
            dgvPropietarios.Columns[0].Visible = false; // Ocultar columna Id_Propietario
            dgvPropietarios.Columns[1].Visible = false; // Ocultar columna Id_Tipo_Identificacion
            dgvPropietarios.Columns[5].Visible = false; // Ocultar columna Apellido2

            // Cambiar encabezados
            dgvPropietarios.Columns[2].HeaderText = "Identificación";
            dgvPropietarios.Columns[3].HeaderText = "Nombre";
            dgvPropietarios.Columns[4].HeaderText = "Apellido";
            dgvPropietarios.Columns[6].HeaderText = "Teléfono";
            dgvPropietarios.Columns[7].HeaderText = "Email";
            dgvPropietarios.Columns[8].HeaderText = "Dirección";
            dgvPropietarios.Columns[9].HeaderText = "Estado";

            // Ajustar ancho automáticamente
            dgvPropietarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void filtrarPropietarios(ref cls_Propietarios_DAL obj_Propietarios_DAL)
        {
            if (obj_Propietarios_DAL.dtDatos == null)
                return;

            obj_Propietarios_DAL.sFiltro = txtBuscar.Text.Trim().Replace("'", "''");

            DataView vista = obj_Propietarios_DAL.dtDatos.DefaultView;

            if (string.IsNullOrEmpty(obj_Propietarios_DAL.sFiltro))
            {
                vista.RowFilter = "";
            }
            else
            {
                vista.RowFilter =
                    $"Identificacion LIKE '%{obj_Propietarios_DAL.sFiltro}%' OR " +
                    $"Nombre LIKE '%{obj_Propietarios_DAL.sFiltro}%' OR " +
                    $"Apellido1 LIKE '%{obj_Propietarios_DAL.sFiltro}%' OR " +
                    $"Apellido2 LIKE '%{obj_Propietarios_DAL.sFiltro}%' OR " +
                    $"Telefono LIKE '%{obj_Propietarios_DAL.sFiltro}%' OR " +
                    $"Email LIKE '%{obj_Propietarios_DAL.sFiltro}%' OR " +
                    $"Direccion LIKE '%{obj_Propietarios_DAL.sFiltro}%' OR " +
                    $"Estado LIKE '%{obj_Propietarios_DAL.sFiltro}%'";
            }

            dgvPropietarios.DataSource = vista;
            configurarGridPropietarios();
        }

        private void cargarComboTiposIdentificacion()
        {
            try
            {

                obj_Tipos_Identificacion_BLL.ListarTiposIdentificacion(ref obj_Tipos_Identificacion_DAL);

                if (obj_Tipos_Identificacion_DAL.dtDatos != null)
                {
                    if (obj_Tipos_Identificacion_DAL.dtDatos.Rows.Count != 0)
                    {
                        cboTipos_Identificacion.ValueMember = "Id_Tipo_Identificacion";
                        cboTipos_Identificacion.DisplayMember = "Tipo_Identificacion";

                        cboTipos_Identificacion.DataSource = obj_Tipos_Identificacion_DAL.dtDatos;

                        cboTipos_Identificacion.SelectedIndex = 0;
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarPropietarios(ref obj_Propietarios_DAL);
        }


        #endregion

        #region Eventos de botones

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblFormTitulo.Text = "Nuevo Propietario";
            cboTipos_Identificacion.SelectedIndex = 0;
            txtIdentificacion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            obj_Propietarios_DAL.sAxn = "I";
            pnlForm.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
            cboTipos_Identificacion.SelectedIndex = 0;
            txtIdentificacion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            cboEstado.SelectedIndex = 0;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                pnlForm.Visible = true;
                lblFormTitulo.Text = "Editar Propietario";

                /* EVALUAR SI LA TABLA CARGADA EN DGV TIENE FILAS */
                if (dgvPropietarios.Rows.Count != 0)
                {
                    /* EVALUAR SI HAY UN REGISTRO SELECCIONADO */
                    if (dgvPropietarios.SelectedRows[0] != null)
                    {
                        /* Establecer propiedades para editar el registro */
                        obj_Propietarios_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;
                        obj_Propietarios_DAL.iId_Propietario = Convert.ToInt32(dgvPropietarios.SelectedRows[0].Cells[0].Value.ToString());
                        obj_Propietarios_DAL.iId_Tipo_Identificacion = Convert.ToInt32(dgvPropietarios.SelectedRows[0].Cells[1].Value.ToString());
                        obj_Propietarios_DAL.sIdentificacion = dgvPropietarios.SelectedRows[0].Cells[2].Value.ToString();
                        obj_Propietarios_DAL.sNombre = dgvPropietarios.SelectedRows[0].Cells[3].Value.ToString();
                        obj_Propietarios_DAL.sApellido1 = dgvPropietarios.SelectedRows[0].Cells[4].Value.ToString();
                        obj_Propietarios_DAL.sApellido2 = dgvPropietarios.SelectedRows[0].Cells[5].Value.ToString();
                        obj_Propietarios_DAL.sTelefono = dgvPropietarios.SelectedRows[0].Cells[6].Value.ToString();
                        obj_Propietarios_DAL.sEmail = dgvPropietarios.SelectedRows[0].Cells[7].Value.ToString();
                        obj_Propietarios_DAL.sDireccion = dgvPropietarios.SelectedRows[0].Cells[8].Value.ToString();
                        obj_Propietarios_DAL.sEstado = dgvPropietarios.SelectedRows[0].Cells[9].Value.ToString();

                        obj_Propietarios_DAL.sAxn = "A"; // I = Insertar, A = Actualizar, E = Eliminar, L = Inicio Sesion, X = Cerrar Sesion

                        cboTipos_Identificacion.SelectedValue = obj_Propietarios_DAL.iId_Tipo_Identificacion;
                        txtIdentificacion.Text = obj_Propietarios_DAL.sIdentificacion;
                        txtNombre.Text = obj_Propietarios_DAL.sNombre;
                        txtApellido1.Text = obj_Propietarios_DAL.sApellido1;
                        txtApellido2.Text = obj_Propietarios_DAL.sApellido2;
                        txtTelefono.Text = obj_Propietarios_DAL.sTelefono;
                        txtEmail.Text = obj_Propietarios_DAL.sEmail;
                        txtDireccion.Text = obj_Propietarios_DAL.sDireccion;
                        cboEstado.SelectedValue = obj_Propietarios_DAL.sEstado == "A" ? "Activo" : "Inactivo";

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
                if (dgvPropietarios.Rows.Count != 0)
                {
                    /* EVALUAR SI HAY UN REGISTRO SELECCIONADO */
                    if (dgvPropietarios.SelectedRows[0] != null)
                    {
                        if (MessageBox.Show("Desea eliminar el registro [ " +
                            dgvPropietarios.SelectedRows[0].Cells[2].Value.ToString() + " - " +
                            dgvPropietarios.SelectedRows[0].Cells[3].Value.ToString() + " - " +
                            dgvPropietarios.SelectedRows[0].Cells[4].Value.ToString() + " ] ? ",
                            "Confirmacion de proceso",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            /* Establecer propiedades para eliminar el registro */
                            obj_Propietarios_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;
                            obj_Propietarios_DAL.iId_Propietario = Convert.ToInt32(dgvPropietarios.SelectedRows[0].Cells[0].Value.ToString());

                            /* LLAMAR A BLL DEL PROCESO ELIMINAR REGISTROS */
                            obj_Propietarios_BLL.EliminarPropietarios(ref obj_Propietarios_DAL);

                            /* EVALUAR VALOR SCALAR DEL RESULTADO DE EJECUCION */
                            if (obj_Propietarios_DAL.sValorScalar != "-1" &&
                                obj_Propietarios_DAL.sValorScalar != "0")
                            {
                                MessageBox.Show("La informacion del registro ha sido eliminada de forma correcta",
                                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                cargaPropietarios();
                            }
                            else if (obj_Propietarios_DAL.sValorScalar == "-1")
                            {
                                MessageBox.Show("Existen registros asociados al elemento que desea eliminar. Verifique!!",
                                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show("Se presento un error al intentar eliminar el registro. Error: " + obj_Propietarios_DAL.sMsjError,
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

                pnlForm.Visible = false; // Ocultar el panel del formulario

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento un error al intentar eliminar el registro. Error: " + ex.ToString(),
                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (cboTipos_Identificacion.SelectedIndex == -1 ||
                   string.IsNullOrEmpty(txtIdentificacion.Text) ||
                   string.IsNullOrEmpty(txtNombre.Text) ||
                   string.IsNullOrEmpty(txtApellido1.Text) ||
                   string.IsNullOrEmpty(txtApellido2.Text) ||
                   string.IsNullOrEmpty(txtTelefono.Text) ||
                   string.IsNullOrEmpty(txtEmail.Text) ||
                   string.IsNullOrEmpty(txtDireccion.Text) ||
                   cboEstado.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe completar todos los campos del formulario antes de guardar.",
                        "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                /* Capturar info del formulario y guardarla en el obj*/
                obj_Propietarios_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal; // Para auditoria

                // Solo obtener el Id si es una modificación
                if (obj_Propietarios_DAL.sAxn == "A")
                {
                    obj_Propietarios_DAL.iId_Propietario = Convert.ToInt32(dgvPropietarios.SelectedRows[0].Cells[0].Value);
                }

                obj_Propietarios_DAL.iId_Tipo_Identificacion = Convert.ToInt32(cboTipos_Identificacion.SelectedValue);
                obj_Propietarios_DAL.sIdentificacion = txtIdentificacion.Text;
                obj_Propietarios_DAL.sNombre = txtNombre.Text;
                obj_Propietarios_DAL.sApellido1 = txtApellido1.Text;
                obj_Propietarios_DAL.sApellido2 = txtApellido2.Text;
                obj_Propietarios_DAL.sTelefono = txtTelefono.Text;
                obj_Propietarios_DAL.sEmail = txtEmail.Text;
                obj_Propietarios_DAL.sDireccion = txtDireccion.Text;
                obj_Propietarios_DAL.sEstado = cboEstado.Text == "Activo" ? "A" : "I";


                /* DETERMINAR SI ES NUEVO O SI YA EXISTE*/
                if (obj_Propietarios_DAL.sAxn == "I")
                {
                    obj_Propietarios_BLL.NuevoPropietario(ref obj_Propietarios_DAL);

                    /*EVALUAR VALOR SCALAR*/
                    if (obj_Propietarios_DAL.sValorScalar != "-1" &&
                        obj_Propietarios_DAL.sValorScalar != "0")
                    {
                        MessageBox.Show("La informacion del registro ha sido guardada de forma correcta",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (obj_Propietarios_DAL.sValorScalar == "-1")
                    {
                        MessageBox.Show("Ya existe un registro con la misma informacion. Verifique!!",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Se presento un error al intentar guardar el registro. Error: " + obj_Propietarios_DAL.sMsjError,
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    obj_Propietarios_BLL.ModificarPropietario(ref obj_Propietarios_DAL);

                    /*EVALUAR VALOR SCALAR*/
                    if (obj_Propietarios_DAL.sValorScalar != "-1" &&
                        obj_Propietarios_DAL.sValorScalar != "0")
                    {
                        MessageBox.Show("La informacion del registro ha sido actualizada de forma correcta",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (obj_Propietarios_DAL.sValorScalar == "-1")
                    {
                        MessageBox.Show("Ya existe un registro con la misma informacion. Verifique!!",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Se presento un error al intentar actualizar el registro. Error: " + obj_Propietarios_DAL.sMsjError,
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                cargaPropietarios(); // Refrescar la informacion del formulario
                pnlForm.Visible = false; // Ocultar el panel del formulario 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento un error al intentar guardar la informacion del registro. Error: " + ex.ToString(),
                                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion


    }
}
