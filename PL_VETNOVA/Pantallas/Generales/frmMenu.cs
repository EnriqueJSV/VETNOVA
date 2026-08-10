using BLL_VETNOVA.Entidades;
using DAL_VETNOVA.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PL_VETNOVA.Pantallas.Generales
{
    public partial class frmMenu : Form
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

        // Segun el rol logueado, algunas cards no aplican (Propietarios y
        // Veterinarios no se muestran para Recepcionista/Veterinario). Estas
        // banderas evitan pedirle a la BD datos que el usuario ni va a ver.
        private bool bMuestraCardPropietarios;
        private bool bMuestraCardVeterinarios;

        private readonly Color colorSidebarHoverFondo = Color.FromArgb(225, 245, 238);
        private readonly Color colorSidebarHoverTexto = Color.FromArgb(8, 80, 65);

        private cls_Grafico_BLL obj_Grafico_BLL = new cls_Grafico_BLL();
        private cls_Grafico_DAL obj_Grafico_DAL = new cls_Grafico_DAL();

        #endregion

        #region Hover del Sidebar

        // Estos dos metodos se enganchan desde el Designer (icono del rayo en
        // el panel de Properties) al MouseEnter/MouseLeave de CADA label de
        // pnlNav y de lblNavCerrarSesion.
        private void lblNav_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.BackColor = colorSidebarHoverFondo;
                lbl.ForeColor = colorSidebarHoverTexto;
                lbl.Font = new Font(lbl.Font, FontStyle.Bold);
            }
        }

        private void lblNav_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.BackColor = Color.Transparent;

                // lblNavDashboard es el unico que arranca en negrita y con un
                // gris mas oscuro por defecto; los demas vuelven al gris
                // normal sin negrita.
                if (lbl == lblNavDashboard)
                {
                    lbl.ForeColor = Color.FromArgb(30, 30, 28);
                    lbl.Font = new Font(lbl.Font, FontStyle.Bold);
                }
                else
                {
                    lbl.ForeColor = Color.FromArgb(95, 94, 90);
                    lbl.Font = new Font(lbl.Font, FontStyle.Regular);
                }
            }
        }

        #endregion
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            cargaDatosUsuarioGlobal();

            ConfigurarAccesoPorRol(obj_Usuario_Global_DAL.iId_Rol);

            cargaConteoCitas();
            cargaCitasHoy();
            cargaConteoMascotas();

            if (bMuestraCardPropietarios)
            {
                cargaConteoPropietarios();
            }

            if (bMuestraCardVeterinarios)
            {
                cargaConteoVeterinarios();
            }

            cargarGraficoCitasXMes();
        }

        #region Acceso por Rol

        // Un solo lugar que decide, segun el Id_Rol, que labels de navegacion
        // y que cards de contadores le corresponden a cada usuario. Reemplaza
        // a los 3 formularios que existian antes (frmMenuAdmin, frmMenuVeterinario,
        // frmMenuRecepcionista), que eran identicos graficamente y solo variaban
        // en que controles mostraban.
        private void ConfigurarAccesoPorRol(int idRol)
        {
            // Orden vertical real de los labels dentro de pnlNav (no incluye
            // CerrarSesion, que vive en pnlCerrarSesion y siempre es visible).
            List<Label> ordenNav = new List<Label>
            {
                lblNavDashboard,
                lblNavCitas,
                lblNavConsultas,
                lblNavPropietarios,
                lblNavMascotas,
                lblNavVeterinarios,
                lblNavCatalogos,
                lblNavUsuarios,
                lblNavAuditoria
            };

            // Orden horizontal real de las 4 cards de contadores.
            List<Panel> ordenCards = new List<Panel>
            {
                pnlCardCitas,
                pnlCardMascotas,
                pnlCardPropietarios,
                pnlCardVeterinarios
            };

            List<Label> navVisibles;
            List<Panel> cardsVisibles;

            switch (idRol)
            {
                case 1: // Administrador: acceso total
                    navVisibles = new List<Label> { lblNavDashboard, lblNavCitas, lblNavConsultas, lblNavPropietarios, lblNavMascotas, lblNavVeterinarios, lblNavCatalogos, lblNavUsuarios, lblNavAuditoria };
                    cardsVisibles = new List<Panel> { pnlCardCitas, pnlCardMascotas, pnlCardPropietarios, pnlCardVeterinarios };
                    break;

                case 3: // Recepcionista
                    navVisibles = new List<Label> { lblNavDashboard, lblNavCitas, lblNavConsultas, lblNavPropietarios, lblNavMascotas };
                    cardsVisibles = new List<Panel> { pnlCardCitas, pnlCardMascotas, pnlCardPropietarios };
                    break;

                case 2: // Veterinario
                    navVisibles = new List<Label> { lblNavDashboard, lblNavConsultas, lblNavMascotas };
                    cardsVisibles = new List<Panel> { pnlCardCitas, pnlCardMascotas };
                    break;

                default:
                    // Rol desconocido: no mostramos nada de navegacion ni cards,
                    // para no asumir permisos por accidente.
                    navVisibles = new List<Label>();
                    cardsVisibles = new List<Panel>();
                    break;
            }

            bMuestraCardPropietarios = cardsVisibles.Contains(pnlCardPropietarios);
            bMuestraCardVeterinarios = cardsVisibles.Contains(pnlCardVeterinarios);

            ReacomodarNav(ordenNav, navVisibles);
            ReacomodarCards(ordenCards, cardsVisibles);
        }

        // Oculta los labels que no le tocan al rol y reacomoda verticalmente
        // los que si quedan visibles, para que no se vea un hueco vacio donde
        // deberia estar, por ejemplo, "Veterinarios".
        private void ReacomodarNav(List<Label> ordenCompleto, List<Label> visibles)
        {
            int y = lblNavDashboard.Location.Y; // punto de partida original (8)
            const int paso = 36; // separacion vertical original entre labels

            foreach (Label lbl in ordenCompleto)
            {
                bool esVisible = visibles.Contains(lbl);
                lbl.Visible = esVisible;

                if (esVisible)
                {
                    lbl.Location = new Point(lbl.Location.X, y);
                    y += paso;
                }
            }
        }

        // Mismo espiritu que ReacomodarNav, pero en horizontal para las cards
        // del dashboard.
        private void ReacomodarCards(List<Panel> ordenCompleto, List<Panel> visibles)
        {
            int x = pnlCardCitas.Location.X; // punto de partida original (20)
            const int gap = 10; // separacion horizontal entre cards

            foreach (Panel pnl in ordenCompleto)
            {
                bool esVisible = visibles.Contains(pnl);
                pnl.Visible = esVisible;

                if (esVisible)
                {
                    pnl.Location = new Point(x, pnl.Location.Y);
                    x += pnl.Width + gap;
                }
            }
        }

        #endregion

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

        #region Eventos de Navegacion

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

            // Al volver, refrescamos el panel principal por si se
            // agregó/modificó/eliminó algo mientras estuvimos en esa pantalla.
            RefrescarPanelPrincipal();
        }

        private void lblNavConsultas_Click(object sender, EventArgs e)
        {
            Pantallas.Consultas.frmConsultas obj_Formulario = new Pantallas.Consultas.frmConsultas();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL;

            this.Hide();
            obj_Formulario.ShowDialog(this);

            RefrescarPanelPrincipal();
        }

        private void lblNavCatalogos_Click(object sender, EventArgs e)
        {
            Pantallas.Catalogos.frmCatalogos obj_Formulario = new Pantallas.Catalogos.frmCatalogos();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL;

            this.Hide();
            obj_Formulario.ShowDialog(this);

            RefrescarPanelPrincipal();
        }

        private void lblNavUsuarios_Click(object sender, EventArgs e)
        {
            Pantallas.Usuarios.frmUsuarios obj_Formulario = new Pantallas.Usuarios.frmUsuarios();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL;

            this.Hide();
            obj_Formulario.ShowDialog(this);

            RefrescarPanelPrincipal();
        }

        private void lblNavAuditoria_Click(object sender, EventArgs e)
        {
            Pantallas.Auditoria.frmConsultasAuditoria obj_Formulario = new Pantallas.Auditoria.frmConsultasAuditoria();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL;

            this.Hide();
            obj_Formulario.ShowDialog(this);

            RefrescarPanelPrincipal();
        }

        private void lblNavPropietarios_Click(object sender, EventArgs e)
        {
            Pantallas.Propietarios.frmPropietarios obj_Formulario = new Pantallas.Propietarios.frmPropietarios();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL;

            this.Hide();
            obj_Formulario.ShowDialog(this);

            RefrescarPanelPrincipal();
        }

        private void lblNavMascotas_Click(object sender, EventArgs e)
        {
            Pantallas.Mascotas.frmMascotas obj_Formulario = new Pantallas.Mascotas.frmMascotas();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL;

            this.Hide();
            obj_Formulario.ShowDialog(this);

            RefrescarPanelPrincipal();
        }

        private void lblNavVeterinarios_Click(object sender, EventArgs e)
        {
            Pantallas.Veterinarios.frmVeterinarios obj_Formulario = new Pantallas.Veterinarios.frmVeterinarios();
            obj_Formulario.obj_Usuario_Global_DAL = obj_Usuario_Global_DAL;

            this.Hide();
            obj_Formulario.ShowDialog(this);

            RefrescarPanelPrincipal();
        }

        // Reune el refresco del dashboard que se repetia despues de cada
        // navegacion, respetando que cards/roles no aplican a todos.
        private void RefrescarPanelPrincipal()
        {
            cargaConteoCitas();
            cargaCitasHoy();
            cargaConteoMascotas();

            if (bMuestraCardPropietarios)
            {
                cargaConteoPropietarios();
            }

            if (bMuestraCardVeterinarios)
            {
                cargaConteoVeterinarios();
            }
        }

        #endregion


        private void cargarGraficoCitasXMes()
        {
            try
            {
                // Obtener la información desde BLL
                obj_Grafico_BLL.ListarCitasXMes(ref obj_Grafico_DAL);

                if (obj_Grafico_DAL.dtDatos == null)
                {
                    MessageBox.Show("No se pudo cargar la información del gráfico.",
                        "Información del sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Limpiar cualquier configuración previa
                citasXmes.Series.Clear();
                citasXmes.ChartAreas.Clear();
                citasXmes.Legends.Clear();
                citasXmes.Titles.Clear();

                // Crear el área del gráfico
                ChartArea area = new ChartArea();
                area.BackColor = Color.White;

                // Personalización de los ejes
                // ---------------- EJE X ----------------
                area.AxisX.Title = "Meses";
                area.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
                area.AxisX.TitleForeColor = Color.FromArgb(60, 60, 60);
                area.AxisX.MajorGrid.Enabled = false;
                area.AxisX.LineColor = Color.FromArgb(180, 180, 180);
                area.AxisX.LabelStyle.ForeColor = Color.FromArgb(74, 74, 74);
                area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);

                // Mostrar todos los meses
                area.AxisX.Interval = 1;
                area.AxisX.LabelStyle.Interval = 1;
                area.AxisX.IsLabelAutoFit = false;

                // ---------------- EJE Y ----------------
                area.AxisY.Title = "Citas";
                area.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
                area.AxisY.TitleForeColor = Color.FromArgb(60, 60, 60);
                area.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
                area.AxisY.LineColor = Color.FromArgb(180, 180, 180);
                area.AxisY.LabelStyle.ForeColor = Color.FromArgb(74, 74, 74);
                area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);

                // Evita la doble numeración
                area.AxisY.Minimum = 0;
                area.AxisY.Interval = 2;
                area.AxisY.LabelStyle.Interval = 2;

                citasXmes.ChartAreas.Add(area);

                // Crear la serie
                Series serie = new Series();
                serie.Name = "Citas";
                serie.ChartType = SeriesChartType.Column;
                serie.Color = Color.FromArgb(11, 107, 97); // Verde VetNova
                serie.IsValueShownAsLabel = true;
                serie.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                // Cargar los datos del DataTable
                foreach (DataRow fila in obj_Grafico_DAL.dtDatos.Rows)
                {
                    serie.Points.AddXY(
                        fila["Mes"].ToString(),
                        Convert.ToInt32(fila["TotalCitas"]));
                }

                citasXmes.Series.Add(serie);

                // Fondo del control
                citasXmes.BackColor = Color.FromArgb(244, 244, 244);

                // Título
                Title titulo = new Title();
                titulo.Text = "Citas por mes";
                titulo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                titulo.ForeColor = Color.FromArgb(40, 40, 40);

                citasXmes.Titles.Add(titulo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presentó un error al cargar el gráfico. Error: " + ex.ToString(),
                    "Información del sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


    }
}