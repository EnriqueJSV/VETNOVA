using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PL_VETNOVA.Pantallas.Generales
{
    public partial class frmInicioSesion : Form
    {
        // Id del usuario que inicio sesion correctamente. Se usa como
        // @IdUsuarioGlobal en el resto de la aplicacion para la auditoria.
        public int IdUsuarioAutenticado { get; private set; } = 0;

        public frmInicioSesion()
        {
            InitializeComponent();

            this.AcceptButton = btnIngresar;
            txtContrasena.KeyDown += TxtContrasena_KeyDown;

            CargarLogo();
        }

        private void CargarLogo()
        {
            try
            {
                string ruta = Path.Combine(Application.StartupPath, "Recursos", "paw_icon.png");
                if (File.Exists(ruta))
                {
                    picLogo.Image = Image.FromFile(ruta);
                }
            }
            catch
            {
                // Si no encuentra el icono, el formulario sigue funcionando sin el
            }
        }

        private void TxtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnIngresar_Click(sender, e);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;

            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                lblMensaje.Text = "Ingresa tu usuario y contrasena.";
                return;
            }

            btnIngresar.Enabled = false;

            try
            {
                // TODO: reemplazar este bloque por la llamada real a la capa BLL.
                // Ejemplo, una vez tengan la clase de negocio de Usuarios:
                //
                //     int idUsuario = new UsuariosBLL().IniciarSesion(usuario, contrasena);
                //
                // SP_INICIAR_SESION devuelve el Id_Usuario si las credenciales son
                // correctas, o -1 si no lo son (revisar el procedimiento almacenado
                // para el detalle exacto del contrato).
                //
                // IMPORTANTE: el combo "cboRolSimulado" es SOLO para poder navegar
                // las pantallas mientras la BLL no esta lista. En el sistema real
                // el rol NO se elige aqui: viene de Usuarios.Id_Rol una vez que
                // el login es exitoso. Hay que quitar cboRolSimulado (y su label)
                // antes de la entrega final.
                int idUsuario = 0; // placeholder mientras se conecta la BLL

                if (idUsuario > 0)
                {
                    IdUsuarioAutenticado = idUsuario;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblMensaje.Text = "Usuario o contrasena incorrectos.";
                    txtContrasena.Clear();
                    txtContrasena.Focus();
                }
            }
            catch (Exception)
            {
                lblMensaje.Text = "No se pudo conectar con el sistema. Intenta de nuevo.";
            }
            finally
            {
                btnIngresar.Enabled = true;
            }
        }
    }
}
