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
    }
}
