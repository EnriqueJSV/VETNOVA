namespace PL_VETNOVA.Pantallas.Generales
{
    partial class frmMenuRecepcionista
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codigo generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlCerrarSesion = new System.Windows.Forms.Panel();
            this.lblNavCerrarSesion = new System.Windows.Forms.Label();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.pnlNavActiveMarker = new System.Windows.Forms.Panel();
            this.lblNavMascotas = new System.Windows.Forms.Label();
            this.lblNavPropietarios = new System.Windows.Forms.Label();
            this.lblNavConsultas = new System.Windows.Forms.Label();
            this.lblNavCitas = new System.Windows.Forms.Label();
            this.lblNavDashboard = new System.Windows.Forms.Label();
            this.pnlSidebarHeader = new System.Windows.Forms.Panel();
            this.lblSidebarTagline = new System.Windows.Forms.Label();
            this.lblSidebarTitulo = new System.Windows.Forms.Label();
            this.picLogoSidebar = new System.Windows.Forms.PictureBox();
            this.pnlContentWrapper = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvCitasHoy = new System.Windows.Forms.DataGridView();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVeterinario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblProximasCitas = new System.Windows.Forms.Label();
            this.pnlCardPropietarios = new System.Windows.Forms.Panel();
            this.lblCardPropietariosValor = new System.Windows.Forms.Label();
            this.lblCardPropietariosTitulo = new System.Windows.Forms.Label();
            this.pnlCardMascotas = new System.Windows.Forms.Panel();
            this.lblCardMascotasValor = new System.Windows.Forms.Label();
            this.lblCardMascotasTitulo = new System.Windows.Forms.Label();
            this.pnlCardCitas = new System.Windows.Forms.Panel();
            this.lblCardCitasValor = new System.Windows.Forms.Label();
            this.lblCardCitasTitulo = new System.Windows.Forms.Label();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblInfoUsuario = new System.Windows.Forms.Label();
            this.lblTituloPantalla = new System.Windows.Forms.Label();
            this.pnlTopBarBorde = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlCerrarSesion.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.pnlSidebarHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoSidebar)).BeginInit();
            this.pnlContentWrapper.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitasHoy)).BeginInit();
            this.pnlCardPropietarios.SuspendLayout();
            this.pnlCardMascotas.SuspendLayout();
            this.pnlCardCitas.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlSidebar
            //
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.pnlSidebar.Controls.Add(this.pnlCerrarSesion);
            this.pnlSidebar.Controls.Add(this.pnlNav);
            this.pnlSidebar.Controls.Add(this.pnlSidebarHeader);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 650);
            this.pnlSidebar.TabIndex = 0;
            //
            // pnlCerrarSesion
            //
            this.pnlCerrarSesion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCerrarSesion.Controls.Add(this.lblNavCerrarSesion);
            this.pnlCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCerrarSesion.Location = new System.Drawing.Point(0, 606);
            this.pnlCerrarSesion.Name = "pnlCerrarSesion";
            this.pnlCerrarSesion.Size = new System.Drawing.Size(220, 44);
            this.pnlCerrarSesion.TabIndex = 2;
            //
            // lblNavCerrarSesion
            //
            this.lblNavCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNavCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblNavCerrarSesion.Location = new System.Drawing.Point(18, 10);
            this.lblNavCerrarSesion.Name = "lblNavCerrarSesion";
            this.lblNavCerrarSesion.Size = new System.Drawing.Size(180, 24);
            this.lblNavCerrarSesion.TabIndex = 0;
            this.lblNavCerrarSesion.Text = "Cerrar sesion";
            this.lblNavCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNavCerrarSesion.Click += new System.EventHandler(this.lblNavCerrarSesion_Click);
            //
            // pnlNav
            //
            this.pnlNav.Controls.Add(this.pnlNavActiveMarker);
            this.pnlNav.Controls.Add(this.lblNavMascotas);
            this.pnlNav.Controls.Add(this.lblNavPropietarios);
            this.pnlNav.Controls.Add(this.lblNavConsultas);
            this.pnlNav.Controls.Add(this.lblNavCitas);
            this.pnlNav.Controls.Add(this.lblNavDashboard);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNav.Location = new System.Drawing.Point(0, 70);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(220, 536);
            this.pnlNav.TabIndex = 1;
            //
            // pnlNavActiveMarker
            //
            this.pnlNavActiveMarker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.pnlNavActiveMarker.Location = new System.Drawing.Point(0, 8);
            this.pnlNavActiveMarker.Name = "pnlNavActiveMarker";
            this.pnlNavActiveMarker.Size = new System.Drawing.Size(3, 32);
            this.pnlNavActiveMarker.TabIndex = 5;
            //
            // lblNavMascotas
            //
            this.lblNavMascotas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavMascotas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNavMascotas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblNavMascotas.Location = new System.Drawing.Point(18, 152);
            this.lblNavMascotas.Name = "lblNavMascotas";
            this.lblNavMascotas.Size = new System.Drawing.Size(180, 32);
            this.lblNavMascotas.TabIndex = 4;
            this.lblNavMascotas.Text = "Mascotas";
            this.lblNavMascotas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblNavPropietarios
            //
            this.lblNavPropietarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavPropietarios.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNavPropietarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblNavPropietarios.Location = new System.Drawing.Point(18, 116);
            this.lblNavPropietarios.Name = "lblNavPropietarios";
            this.lblNavPropietarios.Size = new System.Drawing.Size(180, 32);
            this.lblNavPropietarios.TabIndex = 3;
            this.lblNavPropietarios.Text = "Propietarios";
            this.lblNavPropietarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblNavConsultas
            //
            this.lblNavConsultas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavConsultas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNavConsultas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblNavConsultas.Location = new System.Drawing.Point(18, 80);
            this.lblNavConsultas.Name = "lblNavConsultas";
            this.lblNavConsultas.Size = new System.Drawing.Size(180, 32);
            this.lblNavConsultas.TabIndex = 2;
            this.lblNavConsultas.Text = "Consultas";
            this.lblNavConsultas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblNavCitas
            //
            this.lblNavCitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavCitas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNavCitas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblNavCitas.Location = new System.Drawing.Point(18, 44);
            this.lblNavCitas.Name = "lblNavCitas";
            this.lblNavCitas.Size = new System.Drawing.Size(180, 32);
            this.lblNavCitas.TabIndex = 1;
            this.lblNavCitas.Text = "Citas";
            this.lblNavCitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNavCitas.Click += new System.EventHandler(this.lblNavCitas_Click);
            //
            // lblNavDashboard
            //
            this.lblNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNavDashboard.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblNavDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(28)))));
            this.lblNavDashboard.Location = new System.Drawing.Point(18, 8);
            this.lblNavDashboard.Name = "lblNavDashboard";
            this.lblNavDashboard.Size = new System.Drawing.Size(180, 32);
            this.lblNavDashboard.TabIndex = 0;
            this.lblNavDashboard.Text = "Panel principal";
            this.lblNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlSidebarHeader
            //
            this.pnlSidebarHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(52)))), ((int)(((byte)(44)))));
            this.pnlSidebarHeader.Controls.Add(this.lblSidebarTagline);
            this.pnlSidebarHeader.Controls.Add(this.lblSidebarTitulo);
            this.pnlSidebarHeader.Controls.Add(this.picLogoSidebar);
            this.pnlSidebarHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSidebarHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebarHeader.Name = "pnlSidebarHeader";
            this.pnlSidebarHeader.Size = new System.Drawing.Size(220, 70);
            this.pnlSidebarHeader.TabIndex = 0;
            //
            // lblSidebarTagline
            //
            this.lblSidebarTagline.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblSidebarTagline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(225)))), ((int)(((byte)(203)))));
            this.lblSidebarTagline.Location = new System.Drawing.Point(46, 34);
            this.lblSidebarTagline.Name = "lblSidebarTagline";
            this.lblSidebarTagline.Size = new System.Drawing.Size(160, 16);
            this.lblSidebarTagline.TabIndex = 2;
            this.lblSidebarTagline.Text = "simple y trazable";
            //
            // lblSidebarTitulo
            //
            this.lblSidebarTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitulo.ForeColor = System.Drawing.Color.White;
            this.lblSidebarTitulo.Location = new System.Drawing.Point(44, 12);
            this.lblSidebarTitulo.Name = "lblSidebarTitulo";
            this.lblSidebarTitulo.Size = new System.Drawing.Size(160, 22);
            this.lblSidebarTitulo.TabIndex = 1;
            this.lblSidebarTitulo.Text = "VetNova";
            //
            // picLogoSidebar
            //
            this.picLogoSidebar.BackColor = System.Drawing.Color.Transparent;
            this.picLogoSidebar.Location = new System.Drawing.Point(14, 14);
            this.picLogoSidebar.Name = "picLogoSidebar";
            this.picLogoSidebar.Size = new System.Drawing.Size(24, 24);
            this.picLogoSidebar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogoSidebar.TabIndex = 0;
            this.picLogoSidebar.TabStop = false;
            //
            // pnlContentWrapper
            //
            this.pnlContentWrapper.Controls.Add(this.pnlContent);
            this.pnlContentWrapper.Controls.Add(this.pnlTopBar);
            this.pnlContentWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentWrapper.Location = new System.Drawing.Point(220, 0);
            this.pnlContentWrapper.Name = "pnlContentWrapper";
            this.pnlContentWrapper.Size = new System.Drawing.Size(830, 650);
            this.pnlContentWrapper.TabIndex = 1;
            //
            // pnlContent
            //
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.dgvCitasHoy);
            this.pnlContent.Controls.Add(this.lblProximasCitas);
            this.pnlContent.Controls.Add(this.pnlCardPropietarios);
            this.pnlContent.Controls.Add(this.pnlCardMascotas);
            this.pnlContent.Controls.Add(this.pnlCardCitas);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 50);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(830, 600);
            this.pnlContent.TabIndex = 1;
            //
            // dgvCitasHoy
            //
            this.dgvCitasHoy.AllowUserToAddRows = false;
            this.dgvCitasHoy.AllowUserToDeleteRows = false;
            this.dgvCitasHoy.BackgroundColor = System.Drawing.Color.White;
            this.dgvCitasHoy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCitasHoy.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.dgvCitasHoy.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvCitasHoy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCitasHoy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHora,
            this.colMascota,
            this.colVeterinario,
            this.colEstado});
            this.dgvCitasHoy.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.dgvCitasHoy.Location = new System.Drawing.Point(20, 200);
            this.dgvCitasHoy.Name = "dgvCitasHoy";
            this.dgvCitasHoy.ReadOnly = true;
            this.dgvCitasHoy.RowHeadersVisible = false;
            this.dgvCitasHoy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitasHoy.Size = new System.Drawing.Size(770, 260);
            this.dgvCitasHoy.TabIndex = 4;
            //
            // colHora
            //
            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "colHora";
            this.colHora.ReadOnly = true;
            this.colHora.Width = 80;
            //
            // colMascota
            //
            this.colMascota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMascota.HeaderText = "Mascota";
            this.colMascota.Name = "colMascota";
            this.colMascota.ReadOnly = true;
            //
            // colVeterinario
            //
            this.colVeterinario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVeterinario.HeaderText = "Veterinario";
            this.colVeterinario.Name = "colVeterinario";
            this.colVeterinario.ReadOnly = true;
            //
            // colEstado
            //
            this.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            //
            // lblProximasCitas
            //
            this.lblProximasCitas.AutoSize = true;
            this.lblProximasCitas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProximasCitas.Location = new System.Drawing.Point(20, 170);
            this.lblProximasCitas.Name = "lblProximasCitas";
            this.lblProximasCitas.Size = new System.Drawing.Size(144, 19);
            this.lblProximasCitas.TabIndex = 3;
            this.lblProximasCitas.Text = "Citas de hoy";
            //
            // pnlCardPropietarios
            //
            this.pnlCardPropietarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.pnlCardPropietarios.Controls.Add(this.lblCardPropietariosValor);
            this.pnlCardPropietarios.Controls.Add(this.lblCardPropietariosTitulo);
            this.pnlCardPropietarios.Location = new System.Drawing.Point(405, 20);
            this.pnlCardPropietarios.Name = "pnlCardPropietarios";
            this.pnlCardPropietarios.Size = new System.Drawing.Size(190, 80);
            this.pnlCardPropietarios.TabIndex = 2;
            //
            // lblCardPropietariosValor
            //
            this.lblCardPropietariosValor.AutoSize = true;
            this.lblCardPropietariosValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardPropietariosValor.Location = new System.Drawing.Point(14, 34);
            this.lblCardPropietariosValor.Name = "lblCardPropietariosValor";
            this.lblCardPropietariosValor.Size = new System.Drawing.Size(21, 30);
            this.lblCardPropietariosValor.TabIndex = 1;
            this.lblCardPropietariosValor.Text = "0";
            //
            // lblCardPropietariosTitulo
            //
            this.lblCardPropietariosTitulo.AutoSize = true;
            this.lblCardPropietariosTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCardPropietariosTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblCardPropietariosTitulo.Location = new System.Drawing.Point(14, 12);
            this.lblCardPropietariosTitulo.Name = "lblCardPropietariosTitulo";
            this.lblCardPropietariosTitulo.Size = new System.Drawing.Size(96, 15);
            this.lblCardPropietariosTitulo.TabIndex = 0;
            this.lblCardPropietariosTitulo.Text = "Propietarios activos";
            //
            // pnlCardMascotas
            //
            this.pnlCardMascotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.pnlCardMascotas.Controls.Add(this.lblCardMascotasValor);
            this.pnlCardMascotas.Controls.Add(this.lblCardMascotasTitulo);
            this.pnlCardMascotas.Location = new System.Drawing.Point(210, 20);
            this.pnlCardMascotas.Name = "pnlCardMascotas";
            this.pnlCardMascotas.Size = new System.Drawing.Size(190, 80);
            this.pnlCardMascotas.TabIndex = 1;
            //
            // lblCardMascotasValor
            //
            this.lblCardMascotasValor.AutoSize = true;
            this.lblCardMascotasValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardMascotasValor.Location = new System.Drawing.Point(14, 34);
            this.lblCardMascotasValor.Name = "lblCardMascotasValor";
            this.lblCardMascotasValor.Size = new System.Drawing.Size(21, 30);
            this.lblCardMascotasValor.TabIndex = 1;
            this.lblCardMascotasValor.Text = "0";
            //
            // lblCardMascotasTitulo
            //
            this.lblCardMascotasTitulo.AutoSize = true;
            this.lblCardMascotasTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCardMascotasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblCardMascotasTitulo.Location = new System.Drawing.Point(14, 12);
            this.lblCardMascotasTitulo.Name = "lblCardMascotasTitulo";
            this.lblCardMascotasTitulo.Size = new System.Drawing.Size(122, 15);
            this.lblCardMascotasTitulo.TabIndex = 0;
            this.lblCardMascotasTitulo.Text = "Mascotas registradas";
            //
            // pnlCardCitas
            //
            this.pnlCardCitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.pnlCardCitas.Controls.Add(this.lblCardCitasValor);
            this.pnlCardCitas.Controls.Add(this.lblCardCitasTitulo);
            this.pnlCardCitas.Location = new System.Drawing.Point(20, 20);
            this.pnlCardCitas.Name = "pnlCardCitas";
            this.pnlCardCitas.Size = new System.Drawing.Size(180, 80);
            this.pnlCardCitas.TabIndex = 0;
            //
            // lblCardCitasValor
            //
            this.lblCardCitasValor.AutoSize = true;
            this.lblCardCitasValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCardCitasValor.Location = new System.Drawing.Point(14, 34);
            this.lblCardCitasValor.Name = "lblCardCitasValor";
            this.lblCardCitasValor.Size = new System.Drawing.Size(21, 30);
            this.lblCardCitasValor.TabIndex = 1;
            this.lblCardCitasValor.Text = "0";
            //
            // lblCardCitasTitulo
            //
            this.lblCardCitasTitulo.AutoSize = true;
            this.lblCardCitasTitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCardCitasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblCardCitasTitulo.Location = new System.Drawing.Point(14, 12);
            this.lblCardCitasTitulo.Name = "lblCardCitasTitulo";
            this.lblCardCitasTitulo.Size = new System.Drawing.Size(58, 15);
            this.lblCardCitasTitulo.TabIndex = 0;
            this.lblCardCitasTitulo.Text = "Citas hoy";
            //
            // pnlTopBar
            //
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.lblInfoUsuario);
            this.pnlTopBar.Controls.Add(this.lblTituloPantalla);
            this.pnlTopBar.Controls.Add(this.pnlTopBarBorde);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(830, 50);
            this.pnlTopBar.TabIndex = 0;
            //
            // lblInfoUsuario
            //
            this.lblInfoUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblInfoUsuario.Location = new System.Drawing.Point(510, 16);
            this.lblInfoUsuario.Name = "lblInfoUsuario";
            this.lblInfoUsuario.Size = new System.Drawing.Size(300, 20);
            this.lblInfoUsuario.TabIndex = 1;
            this.lblInfoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblTituloPantalla
            //
            this.lblTituloPantalla.AutoSize = true;
            this.lblTituloPantalla.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTituloPantalla.Location = new System.Drawing.Point(20, 14);
            this.lblTituloPantalla.Name = "lblTituloPantalla";
            this.lblTituloPantalla.Size = new System.Drawing.Size(107, 20);
            this.lblTituloPantalla.TabIndex = 0;
            this.lblTituloPantalla.Text = "Panel principal";
            //
            // pnlTopBarBorde
            //
            this.pnlTopBarBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.pnlTopBarBorde.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTopBarBorde.Location = new System.Drawing.Point(0, 49);
            this.pnlTopBarBorde.Name = "pnlTopBarBorde";
            this.pnlTopBarBorde.Size = new System.Drawing.Size(830, 1);
            this.pnlTopBarBorde.TabIndex = 2;
            //
            // frmMenuRecepcionista
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.pnlContentWrapper);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "frmMenuRecepcionista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VetNova - Panel principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmMenuRecepcionista_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlCerrarSesion.ResumeLayout(false);
            this.pnlNav.ResumeLayout(false);
            this.pnlSidebarHeader.ResumeLayout(false);
            this.pnlSidebarHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoSidebar)).EndInit();
            this.pnlContentWrapper.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitasHoy)).EndInit();
            this.pnlCardPropietarios.ResumeLayout(false);
            this.pnlCardPropietarios.PerformLayout();
            this.pnlCardMascotas.ResumeLayout(false);
            this.pnlCardMascotas.PerformLayout();
            this.pnlCardCitas.ResumeLayout(false);
            this.pnlCardCitas.PerformLayout();
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlCerrarSesion;
        private System.Windows.Forms.Label lblNavCerrarSesion;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Panel pnlNavActiveMarker;
        private System.Windows.Forms.Label lblNavMascotas;
        private System.Windows.Forms.Label lblNavPropietarios;
        private System.Windows.Forms.Label lblNavConsultas;
        private System.Windows.Forms.Label lblNavCitas;
        private System.Windows.Forms.Label lblNavDashboard;
        private System.Windows.Forms.Panel pnlSidebarHeader;
        private System.Windows.Forms.Label lblSidebarTagline;
        private System.Windows.Forms.Label lblSidebarTitulo;
        private System.Windows.Forms.PictureBox picLogoSidebar;
        private System.Windows.Forms.Panel pnlContentWrapper;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvCitasHoy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVeterinario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Label lblProximasCitas;
        private System.Windows.Forms.Panel pnlCardPropietarios;
        private System.Windows.Forms.Label lblCardPropietariosValor;
        private System.Windows.Forms.Label lblCardPropietariosTitulo;
        private System.Windows.Forms.Panel pnlCardMascotas;
        private System.Windows.Forms.Label lblCardMascotasValor;
        private System.Windows.Forms.Label lblCardMascotasTitulo;
        private System.Windows.Forms.Panel pnlCardCitas;
        private System.Windows.Forms.Label lblCardCitasValor;
        private System.Windows.Forms.Label lblCardCitasTitulo;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblInfoUsuario;
        private System.Windows.Forms.Label lblTituloPantalla;
        private System.Windows.Forms.Panel pnlTopBarBorde;
    }
}
