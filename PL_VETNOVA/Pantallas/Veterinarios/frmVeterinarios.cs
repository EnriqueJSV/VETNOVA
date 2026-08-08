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

namespace PL_VETNOVA.Pantallas.Veterinarios
{
    public partial class frmVeterinarios : Form
    {
        #region Variables Globales o de entidades

        public cls_Usuarios_DAL obj_Usuario_Global_DAL;
        public cls_Usuarios_BLL obj_Usuario_Global_BLL = new cls_Usuarios_BLL();

        public cls_Veterinarios_DAL obj_Veterinarios_DAL = new cls_Veterinarios_DAL();
        public cls_Veterinarios_BLL obj_Veterinarios_BLL = new cls_Veterinarios_BLL();

        public cls_Especialidades_DAL obj_Especialidades_DAL = new cls_Especialidades_DAL();
        public cls_Especialidades_BLL obj_Especialidades_BLL = new cls_Especialidades_BLL();

        public cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL = new cls_Tipos_Identificacion_DAL();
        public cls_Tipos_Identificacion_BLL obj_Tipos_Identificacion_BLL = new cls_Tipos_Identificacion_BLL();

        #endregion


        public frmVeterinarios()
        {
            InitializeComponent();
        }

        #region Eventos de Formulario

        private void frmVeterinarios_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();
            cargaVeterinarios();
            cargarComboEspecialidades();
            cargarComboTiposIdentificacion();
        }

        private void frmVeterinarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }

        #endregion

        #region Eventos de botones

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblFormTitulo.Text = "Nuevo Veterinario";
            txtIdentificacion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            cboEspecialidades.SelectedIndex = 0;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            obj_Veterinarios_DAL.sAxn = "I";
            pnlForm.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
            txtIdentificacion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            cboEspecialidades.SelectedIndex = 0;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                pnlForm.Visible = true;
                lblFormTitulo.Text = "Editar Veterinario";

                /* EVALUAR SI LA TABLA CARGADA EN DGV TIENE FILAS */
                if (dgvVeterinarios.Rows.Count != 0)
                {
                    /* EVALUAR SI HAY UN REGISTRO SELECCIONADO */
                    if (dgvVeterinarios.SelectedRows[0] != null)
                    {
                        /* Establecer propiedades para editar el registro */
                        obj_Veterinarios_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;
                        obj_Veterinarios_DAL.iId_Veterinario = Convert.ToInt32(dgvVeterinarios.SelectedRows[0].Cells[0].Value.ToString());
                        obj_Veterinarios_DAL.iId_Tipo_Identificacion = Convert.ToInt32(dgvVeterinarios.SelectedRows[0].Cells[1].Value.ToString());
                        obj_Veterinarios_DAL.sIdentificacion = dgvVeterinarios.SelectedRows[0].Cells[2].Value.ToString();
                        obj_Veterinarios_DAL.sNombre = dgvVeterinarios.SelectedRows[0].Cells[3].Value.ToString();
                        obj_Veterinarios_DAL.sApellido1 = dgvVeterinarios.SelectedRows[0].Cells[4].Value.ToString();
                        obj_Veterinarios_DAL.sApellido2 = dgvVeterinarios.SelectedRows[0].Cells[5].Value.ToString();
                        obj_Veterinarios_DAL.iId_Especialidad = Convert.ToInt32(dgvVeterinarios.SelectedRows[0].Cells[6].Value.ToString());
                        obj_Veterinarios_DAL.sTelefono = dgvVeterinarios.SelectedRows[0].Cells[8].Value.ToString();
                        obj_Veterinarios_DAL.sEmail = dgvVeterinarios.SelectedRows[0].Cells[9].Value.ToString();
                        obj_Veterinarios_DAL.sEstado = dgvVeterinarios.SelectedRows[0].Cells[10].Value.ToString();

                        obj_Veterinarios_DAL.sAxn = "A"; // I = Insertar, A = Actualizar, E = Eliminar, L = Inicio Sesion, X = Cerrar Sesion

                        cboTipos_Identificacion.SelectedValue = obj_Veterinarios_DAL.iId_Tipo_Identificacion;
                        txtIdentificacion.Text = obj_Veterinarios_DAL.sIdentificacion;
                        txtNombre.Text = obj_Veterinarios_DAL.sNombre;
                        txtApellido1.Text = obj_Veterinarios_DAL.sApellido1;
                        txtApellido2.Text = obj_Veterinarios_DAL.sApellido2;
                        cboEspecialidades.SelectedValue = obj_Veterinarios_DAL.iId_Especialidad;
                        txtTelefono.Text = obj_Veterinarios_DAL.sTelefono;
                        txtEmail.Text = obj_Veterinarios_DAL.sEmail;
                        cboEstado.SelectedValue = obj_Veterinarios_DAL.sEstado == "A" ? "Activo" : "Inactivo";

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
                if (dgvVeterinarios.Rows.Count != 0)
                {
                    /* EVALUAR SI HAY UN REGISTRO SELECCIONADO */
                    if (dgvVeterinarios.SelectedRows[0] != null)
                    {
                        if (MessageBox.Show("Desea eliminar el registro [ " +
                            dgvVeterinarios.SelectedRows[0].Cells[2].Value.ToString() + " - " +
                            dgvVeterinarios.SelectedRows[0].Cells[3].Value.ToString() + " - " +
                            dgvVeterinarios.SelectedRows[0].Cells[4].Value.ToString() + " ] ? ",
                            "Confirmacion de proceso",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            /* Establecer propiedades para eliminar el registro */
                            obj_Veterinarios_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal;
                            obj_Veterinarios_DAL.iId_Veterinario = Convert.ToInt32(dgvVeterinarios.SelectedRows[0].Cells[0].Value.ToString());

                            /* LLAMAR A BLL DEL PROCESO ELIMINAR REGISTROS */
                            obj_Veterinarios_BLL.EliminarVeterinarios(ref obj_Veterinarios_DAL);

                            /* EVALUAR VALOR SCALAR DEL RESULTADO DE EJECUCION */
                            if (obj_Veterinarios_DAL.sValorScalar != "-1" &&
                                obj_Veterinarios_DAL.sValorScalar != "0")
                            {
                                MessageBox.Show("La informacion del registro ha sido eliminada de forma correcta",
                                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                cargaVeterinarios();
                            }
                            else if (obj_Veterinarios_DAL.sValorScalar == "-1")
                            {
                                MessageBox.Show("Existen registros asociados al elemento que desea eliminar. Verifique!!",
                                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show("Se presento un error al intentar eliminar el registro. Error: " + obj_Veterinarios_DAL.sMsjError,
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

                if(string.IsNullOrEmpty(txtIdentificacion.Text) ||
                   string.IsNullOrEmpty(txtNombre.Text) ||
                   string.IsNullOrEmpty(txtApellido1.Text) ||
                   string.IsNullOrEmpty(txtApellido2.Text) ||
                   cboEspecialidades.SelectedIndex == -1 ||
                   string.IsNullOrEmpty(txtTelefono.Text) ||
                   string.IsNullOrEmpty(txtEmail.Text) ||
                   cboEstado.SelectedIndex == -1) 
                {
                    MessageBox.Show("Debe completar todos los campos del formulario antes de guardar.",
                        "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                /* Capturar info del formulario y guardarla en el obj*/
                obj_Veterinarios_DAL.iId_UsuarioGlobal = obj_Usuario_Global_DAL.iId_UsuarioGlobal; // Para auditoria

                // Solo obtener el Id si es una modificación
                if (obj_Veterinarios_DAL.sAxn == "A")
                {
                    obj_Veterinarios_DAL.iId_Veterinario = Convert.ToInt32(dgvVeterinarios.SelectedRows[0].Cells[0].Value);
                }

                obj_Veterinarios_DAL.iId_Tipo_Identificacion = Convert.ToInt32(cboTipos_Identificacion.SelectedValue);
                obj_Veterinarios_DAL.sIdentificacion = txtIdentificacion.Text;
                obj_Veterinarios_DAL.sNombre = txtNombre.Text;
                obj_Veterinarios_DAL.sApellido1 = txtApellido1.Text;
                obj_Veterinarios_DAL.sApellido2 = txtApellido2.Text;
                obj_Veterinarios_DAL.iId_Especialidad = Convert.ToInt32(cboEspecialidades.SelectedValue);
                obj_Veterinarios_DAL.sTelefono = txtTelefono.Text;
                obj_Veterinarios_DAL.sEmail = txtEmail.Text;
                obj_Veterinarios_DAL.sEstado = cboEstado.Text == "Activo" ? "A" : "I";


                /* DETERMINAR SI ES NUEVO O SI YA EXISTE*/
                if (obj_Veterinarios_DAL.sAxn == "I")
                {
                    obj_Veterinarios_BLL.NuevoVeterinario(ref obj_Veterinarios_DAL);

                    /*EVALUAR VALOR SCALAR*/
                    if (obj_Veterinarios_DAL.sValorScalar != "-1" &&
                        obj_Veterinarios_DAL.sValorScalar != "0")
                    {
                        MessageBox.Show("La informacion del registro ha sido guardada de forma correcta",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (obj_Veterinarios_DAL.sValorScalar == "-1")
                    {
                        MessageBox.Show("Ya existe un registro con la misma informacion. Verifique!!",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Se presento un error al intentar guardar el registro. Error: " + obj_Veterinarios_DAL.sMsjError,
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    obj_Veterinarios_BLL.ModificarVeterinario(ref obj_Veterinarios_DAL);

                    /*EVALUAR VALOR SCALAR*/
                    if (obj_Veterinarios_DAL.sValorScalar != "-1" &&
                        obj_Veterinarios_DAL.sValorScalar != "0")
                    {
                        MessageBox.Show("La informacion del registro ha sido actualizada de forma correcta",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (obj_Veterinarios_DAL.sValorScalar == "-1")
                    {
                        MessageBox.Show("Ya existe un registro con la misma informacion. Verifique!!",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Se presento un error al intentar actualizar el registro. Error: " + obj_Veterinarios_DAL.sMsjError,
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                cargaVeterinarios(); // Refrescar la informacion del formulario
                pnlForm.Visible = false; // Ocultar el panel del formulario 

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

        private void cargaVeterinarios()
        {
            try
            {

                obj_Veterinarios_BLL.ListarVeterinarios(ref obj_Veterinarios_DAL);

                if (obj_Veterinarios_DAL.dtDatos != null)
                {
                    if (obj_Veterinarios_DAL.dtDatos.Rows.Count != 0)
                    {
                        dgvVeterinarios.DataSource = null;
                        dgvVeterinarios.DataSource = obj_Veterinarios_DAL.dtDatos;
                        configurarGridVeterinarios();
                        filtrarVeterinarios(ref obj_Veterinarios_DAL);
                    }
                    else
                    {
                        dgvVeterinarios.DataSource = null;
                        MessageBox.Show("No se encontraron datos en la base de datos.",
                            "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    dgvVeterinarios.DataSource = null;
                    MessageBox.Show("Se presento un error al intentar cargar la lista de datos. Error: " + obj_Veterinarios_DAL.sMsjError,
                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento un error al intentar cargar la lista de datos. Error: " + ex.ToString(),
                    "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void configurarGridVeterinarios()
        {
            // Ocultar columnas
            dgvVeterinarios.Columns[0].Visible = false; // Ocultar columna Id_Veterinario
            dgvVeterinarios.Columns[1].Visible = false; // Ocultar columna Id_Tipo_Identificacion
            dgvVeterinarios.Columns[5].Visible = false; // Ocultar columna Apellido2
            dgvVeterinarios.Columns[6].Visible = false; // Ocultar columna Id_Especialidad

            // Cambiar encabezados
            dgvVeterinarios.Columns[2].HeaderText = "Identificación";
            dgvVeterinarios.Columns[3].HeaderText = "Nombre";
            dgvVeterinarios.Columns[4].HeaderText = "Apellido";
            dgvVeterinarios.Columns[7].HeaderText = "Especialidad";
            dgvVeterinarios.Columns[8].HeaderText = "Teléfono";
            dgvVeterinarios.Columns[9].HeaderText = "Email";
            dgvVeterinarios.Columns[10].HeaderText = "Estado";

            // Ajustar ancho automáticamente
            dgvVeterinarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void filtrarVeterinarios(ref cls_Veterinarios_DAL obj_Veterinarios_DAL)
        {
            if (obj_Veterinarios_DAL.dtDatos == null)
                return;

            obj_Veterinarios_DAL.sFiltro = txtBuscar.Text.Trim().Replace("'", "''");

            DataView vista = obj_Veterinarios_DAL.dtDatos.DefaultView;

            if (string.IsNullOrEmpty(obj_Veterinarios_DAL.sFiltro))
            {
                vista.RowFilter = "";
            }
            else
            {
                vista.RowFilter =
                    $"Identificacion LIKE '%{obj_Veterinarios_DAL.sFiltro}%' OR " +
                    $"Nombre LIKE '%{obj_Veterinarios_DAL.sFiltro}%' OR " +
                    $"Apellido1 LIKE '%{obj_Veterinarios_DAL.sFiltro}%' OR " +
                    $"Apellido2 LIKE '%{obj_Veterinarios_DAL.sFiltro}%' OR " +
                    $"Especialidad LIKE '%{obj_Veterinarios_DAL.sFiltro}%' OR " +
                    $"Telefono LIKE '%{obj_Veterinarios_DAL.sFiltro}%' OR " +
                    $"Email LIKE '%{obj_Veterinarios_DAL.sFiltro}%' OR " +
                    $"Estado LIKE '%{obj_Veterinarios_DAL.sFiltro}%'";
            }

            dgvVeterinarios.DataSource = vista;
            configurarGridVeterinarios();
        }

        private void cargarComboEspecialidades()
        {
            try
            {

                obj_Especialidades_BLL.ListarEspecialidades(ref obj_Especialidades_DAL);

                if (obj_Especialidades_DAL.dtDatos != null)
                {
                    if (obj_Especialidades_DAL.dtDatos.Rows.Count != 0)
                    {
                        cboEspecialidades.ValueMember = "Id_Especialidad";
                        cboEspecialidades.DisplayMember = "Especialidad";

                        cboEspecialidades.DataSource = obj_Especialidades_DAL.dtDatos;

                        cboEspecialidades.SelectedIndex = 0;
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
            filtrarVeterinarios(ref obj_Veterinarios_DAL);
        }

        #endregion








    }
}
