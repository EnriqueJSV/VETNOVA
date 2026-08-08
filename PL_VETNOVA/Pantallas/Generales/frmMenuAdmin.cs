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

namespace PL_VETNOVA.Pantallas.Generales
{
    public partial class frmMenuAdmin : Form
    {

        #region Variables Globales o de Entidades
        public cls_Usuarios_DAL obj_Usuario_Global_DAL;
        public cls_Usuarios_BLL obj_Usuario_Global_BLL = new cls_Usuarios_BLL();

        public cls_Citas_DAL obj_Citas_Global_DAL = new cls_Citas_DAL();
        public cls_Citas_BLL obj_Citas_Global_BLL = new cls_Citas_BLL();
        public cls_Mascotas_DAL obj_Mascotas_Global_DAL = new cls_Mascotas_DAL();
        public cls_Mascotas_BLL obj_Mascotas_Global_BLL = new cls_Mascotas_BLL();
        public cls_Propietarios_DAL obj_Propietarios_Global_DAL = new cls_Propietarios_DAL();
        public cls_Propietarios_BLL obj_Propietarios_Global_BLL = new cls_Propietarios_BLL();
        public cls_Veterinarios_DAL obj_Veterinarios_Global_DAL = new cls_Veterinarios_DAL();
        public cls_Veterinarios_BLL obj_Veterinarios_Global_BLL = new cls_Veterinarios_BLL();
        #endregion

        public frmMenuAdmin()
        {
            InitializeComponent();
        }

        private void frmMenuAdmin_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();
            cargaConteoCitas();
            cargaCitasHoy();
            cargaConteoMascotas();
            cargaConteoPropietarios();
            cargaConteoVeterinarios();
        }

        #region Cargadores De Datos
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

                        lblInfoUsuario.Text = "Usuario: " + obj_Usuario_Global_DAL.sNombre_Usuario + " | Rol: " + obj_Usuario_Global_DAL.sNombreRol;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos del usuario.", "Información de Usuario",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        Pantallas.Generales.frmInicioSesion obj_Formulario = new Pantallas.Generales.frmInicioSesion();
                        this.Hide();
                        obj_Formulario.ShowDialog();
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

        private void cargaConteoCitas()
        {
            try
            {
                obj_Citas_Global_BLL.ContarCitasHoy(ref obj_Citas_Global_DAL);

                if (obj_Citas_Global_DAL.sMsjError == string.Empty)
                {
                    // -1 es el codigo de error que devuelve el propio SP en su CATCH
                    if (obj_Citas_Global_DAL.sValorScalar != "-1")
                    {
                        lblCardCitasValor.Text = obj_Citas_Global_DAL.sValorScalar;
                    }
                    else
                    {
                        lblCardCitasValor.Text = "0";
                    }
                }
                else
                {
                    lblCardCitasValor.Text = "-";
                    MessageBox.Show("Ocurrió un error al intentar contar las citas de hoy: " + obj_Citas_Global_DAL.sMsjError, "Panel principal",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblCardCitasValor.Text = "-";
                MessageBox.Show("Ocurrió un error al intentar contar las citas de hoy. Error: " + ex.ToString(), "Panel principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargaCitasHoy()
        {
            try
            {
                obj_Citas_Global_BLL.ListarCitasHoy(ref obj_Citas_Global_DAL);

                dgvCitasHoy.Rows.Clear();

                if (obj_Citas_Global_DAL.sMsjError == string.Empty)
                {
                    if (obj_Citas_Global_DAL.dtDatos != null && obj_Citas_Global_DAL.dtDatos.Rows.Count > 0)
                    {
                        foreach (DataRow fila in obj_Citas_Global_DAL.dtDatos.Rows)
                        {
                            dgvCitasHoy.Rows.Add(
                                fila["Hora"].ToString(),
                                fila["Mascota"].ToString(),
                                fila["Veterinario"].ToString(),
                                fila["Estado"].ToString()
                            );
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar cargar las citas de hoy: " + obj_Citas_Global_DAL.sMsjError, "Panel principal",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar cargar las citas de hoy. Error: " + ex.ToString(), "Panel principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargaConteoMascotas()
        {
            try
            {
                obj_Mascotas_Global_BLL.ContarMascotas(ref obj_Mascotas_Global_DAL);

                if (obj_Mascotas_Global_DAL.sMsjError == string.Empty)
                {
                    if (obj_Mascotas_Global_DAL.sValorScalar != "-1")
                    {
                        lblCardMascotasValor.Text = obj_Mascotas_Global_DAL.sValorScalar;
                    }
                    else
                    {
                        lblCardMascotasValor.Text = "0";
                    }
                }
                else
                {
                    lblCardMascotasValor.Text = "-";
                    MessageBox.Show("Ocurrió un error al intentar contar las mascotas: " + obj_Mascotas_Global_DAL.sMsjError, "Panel principal",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblCardMascotasValor.Text = "-";
                MessageBox.Show("Ocurrió un error al intentar contar las mascotas. Error: " + ex.ToString(), "Panel principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargaConteoPropietarios()
        {
            try
            {
                obj_Propietarios_Global_BLL.ContarPropietarios(ref obj_Propietarios_Global_DAL);

                if (obj_Propietarios_Global_DAL.sMsjError == string.Empty)
                {
                    if (obj_Propietarios_Global_DAL.sValorScalar != "-1")
                    {
                        lblCardPropietariosValor.Text = obj_Propietarios_Global_DAL.sValorScalar;
                    }
                    else
                    {
                        lblCardPropietariosValor.Text = "0";
                    }
                }
                else
                {
                    lblCardPropietariosValor.Text = "-";
                    MessageBox.Show("Ocurrió un error al intentar contar los propietarios: " + obj_Propietarios_Global_DAL.sMsjError, "Panel principal",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblCardPropietariosValor.Text = "-";
                MessageBox.Show("Ocurrió un error al intentar contar los propietarios. Error: " + ex.ToString(), "Panel principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargaConteoVeterinarios()
        {
            try
            {
                obj_Veterinarios_Global_BLL.ContarVeterinarios(ref obj_Veterinarios_Global_DAL);

                if (obj_Veterinarios_Global_DAL.sMsjError == string.Empty)
                {
                    if (obj_Veterinarios_Global_DAL.sValorScalar != "-1")
                    {
                        lblCardVeterinariosValor.Text = obj_Veterinarios_Global_DAL.sValorScalar;
                    }
                    else
                    {
                        lblCardVeterinariosValor.Text = "0";
                    }
                }
                else
                {
                    lblCardVeterinariosValor.Text = "-";
                    MessageBox.Show("Ocurrió un error al intentar contar los veterinarios: " + obj_Veterinarios_Global_DAL.sMsjError, "Panel principal",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblCardVeterinariosValor.Text = "-";
                MessageBox.Show("Ocurrió un error al intentar contar los veterinarios. Error: " + ex.ToString(), "Panel principal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void lblNavCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Deseas cerrar la sesión actual?", "Cerrar sesión",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                obj_Usuario_Global_BLL.CerrarSesion(ref obj_Usuario_Global_DAL);
                var loginOriginal = (Pantallas.Generales.frmInicioSesion)this.Owner;
                loginOriginal.LimpiarCampos();
                loginOriginal.Show();
                this.Close();
            }
        }

        private void lblNavCitas_Click(object sender, EventArgs e)
        {
            Pantallas.Citas.frmCitas obj_Formulario = new Pantallas.Citas.frmCitas();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL;

            this.Hide();
            obj_Formulario.ShowDialog(this);

            // Al volver de Citas, refrescamos el panel principal por si se
            // agregó/modificó/eliminó algo mientras estuvimos en esa pantalla.
            cargaConteoCitas();
            cargaCitasHoy();
            cargaConteoMascotas();
            cargaConteoPropietarios();
            cargaConteoVeterinarios();
        }

        private void lblNavAuditoria_Click(object sender, EventArgs e)
        {
            Pantallas.Auditoria.frmConsultasAuditoria obj_Formulario = new Pantallas.Auditoria.frmConsultasAuditoria();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL;

            this.Hide();
            obj_Formulario.ShowDialog(this);

            // Al volver de Citas, refrescamos el panel principal por si se
            // agregó/modificó/eliminó algo mientras estuvimos en esa pantalla.
            cargaConteoCitas();
            cargaCitasHoy();
            cargaConteoMascotas();
            cargaConteoPropietarios();
            cargaConteoVeterinarios();
        }

        private void lblNavUsuarios_Click(object sender, EventArgs e)
        {
            Pantallas.Usuarios.frmUsuarios obj_Formulario = new Pantallas.Usuarios.frmUsuarios();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL;

            this.Hide();
            obj_Formulario.ShowDialog(this);
            // Al volver de Citas, refrescamos el panel principal por si se
            // agregó/modificó/eliminó algo mientras estuvimos en esa pantalla.
            cargaConteoCitas();
            cargaCitasHoy();
            cargaConteoMascotas();
            cargaConteoPropietarios();
            cargaConteoVeterinarios();
        }

        private void lblNavConsultas_Click(object sender, EventArgs e)
        {
            Pantallas.Consultas.frmConsultas obj_Formulario = new Pantallas.Consultas.frmConsultas();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL; 

            this.Hide();
            obj_Formulario.ShowDialog(this);
            // Al volver de Citas, refrescamos el panel principal por si se
            // agregó/modificó/eliminó algo mientras estuvimos en esa pantalla.
            cargaConteoCitas();
            cargaCitasHoy();
            cargaConteoMascotas();
            cargaConteoPropietarios();
            cargaConteoVeterinarios();
        }

        private void lblNavVeterinarios_Click(object sender, EventArgs e)
        {
            Pantallas.Veterinarios.frmVeterinarios obj_Formulario = new Pantallas.Veterinarios.frmVeterinarios();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL;

            this.Hide();
            obj_Formulario.ShowDialog(this);
            // Al volver de Citas, refrescamos el panel principal por si se
            // agregó/modificó/eliminó algo mientras estuvimos en esa pantalla.
            cargaConteoCitas();
            cargaCitasHoy();
            cargaConteoMascotas();
            cargaConteoPropietarios();
            cargaConteoVeterinarios();
        }

        private void lblNavCatalogos_Click(object sender, EventArgs e)
        {
            Pantallas.Catalogos.frmCatalogos obj_Formulario = new Pantallas.Catalogos.frmCatalogos();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL; // ajusta el nombre exacto de tu propiedad si es distinto

            this.Hide();
            obj_Formulario.ShowDialog(this);
            // Al volver de Citas, refrescamos el panel principal por si se
            // agregó/modificó/eliminó algo mientras estuvimos en esa pantalla.
            cargaConteoCitas();
            cargaCitasHoy();
            cargaConteoMascotas();
            cargaConteoPropietarios();
            cargaConteoVeterinarios();
        }
    }
}
