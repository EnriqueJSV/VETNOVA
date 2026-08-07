namespace PL_VETNOVA.Pantallas.Catalogos
{
    partial class frmCatalogos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblInfoUsuario = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlHeaderBorde = new System.Windows.Forms.Panel();

            this.tabCatalogos = new System.Windows.Forms.TabControl();

            // ---- Tab Especies ----
            this.tabEspecies = new System.Windows.Forms.TabPage();
            this.txtBuscarEspecie = new System.Windows.Forms.TextBox();
            this.btnNuevaEspecie = new System.Windows.Forms.Button();
            this.btnModificarEspecie = new System.Windows.Forms.Button();
            this.btnEliminarEspecie = new System.Windows.Forms.Button();
            this.dgvEspecies = new System.Windows.Forms.DataGridView();
            this.colIdEspecie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreEspecie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoEspecie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFormEspecie = new System.Windows.Forms.Panel();
            this.btnCancelarEspecie = new System.Windows.Forms.Button();
            this.btnGuardarEspecie = new System.Windows.Forms.Button();
            this.cboEstadoEspecie = new System.Windows.Forms.ComboBox();
            this.lblEstadoEspecie = new System.Windows.Forms.Label();
            this.txtNombreEspecie = new System.Windows.Forms.TextBox();
            this.lblNombreEspecie = new System.Windows.Forms.Label();
            this.lblFormTituloEspecie = new System.Windows.Forms.Label();

            // ---- Tab Razas ----
            this.tabRazas = new System.Windows.Forms.TabPage();
            this.lblEspecieRaza = new System.Windows.Forms.Label();
            this.cboEspecieRaza = new System.Windows.Forms.ComboBox();
            this.txtBuscarRaza = new System.Windows.Forms.TextBox();
            this.btnNuevaRaza = new System.Windows.Forms.Button();
            this.btnModificarRaza = new System.Windows.Forms.Button();
            this.btnEliminarRaza = new System.Windows.Forms.Button();
            this.dgvRazas = new System.Windows.Forms.DataGridView();
            this.colIdRaza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreRaza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEspecieRaza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoRaza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFormRaza = new System.Windows.Forms.Panel();
            this.btnCancelarRaza = new System.Windows.Forms.Button();
            this.btnGuardarRaza = new System.Windows.Forms.Button();
            this.cboEstadoRaza = new System.Windows.Forms.ComboBox();
            this.lblEstadoRazaForm = new System.Windows.Forms.Label();
            this.txtNombreRaza = new System.Windows.Forms.TextBox();
            this.lblNombreRaza = new System.Windows.Forms.Label();
            this.lblFormTituloRaza = new System.Windows.Forms.Label();

            // ---- Tab Especialidades ----
            this.tabEspecialidades = new System.Windows.Forms.TabPage();
            this.txtBuscarEspecialidad = new System.Windows.Forms.TextBox();
            this.btnNuevaEspecialidad = new System.Windows.Forms.Button();
            this.btnModificarEspecialidad = new System.Windows.Forms.Button();
            this.btnEliminarEspecialidad = new System.Windows.Forms.Button();
            this.dgvEspecialidades = new System.Windows.Forms.DataGridView();
            this.colIdEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFormEspecialidad = new System.Windows.Forms.Panel();
            this.btnCancelarEspecialidad = new System.Windows.Forms.Button();
            this.btnGuardarEspecialidad = new System.Windows.Forms.Button();
            this.cboEstadoEspecialidadForm = new System.Windows.Forms.ComboBox();
            this.lblEstadoEspecialidadForm = new System.Windows.Forms.Label();
            this.txtNombreEspecialidad = new System.Windows.Forms.TextBox();
            this.lblNombreEspecialidad = new System.Windows.Forms.Label();
            this.lblFormTituloEspecialidad = new System.Windows.Forms.Label();

            // ---- Tab Tipos de identificacion ----
            this.tabTiposIdentificacion = new System.Windows.Forms.TabPage();
            this.txtBuscarTipoIdentificacion = new System.Windows.Forms.TextBox();
            this.btnNuevoTipoIdentificacion = new System.Windows.Forms.Button();
            this.btnModificarTipoIdentificacion = new System.Windows.Forms.Button();
            this.btnEliminarTipoIdentificacion = new System.Windows.Forms.Button();
            this.dgvTiposIdentificacion = new System.Windows.Forms.DataGridView();
            this.colIdTipoIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreTipoIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoTipoIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFormTipoIdentificacion = new System.Windows.Forms.Panel();
            this.btnCancelarTipoIdentificacion = new System.Windows.Forms.Button();
            this.btnGuardarTipoIdentificacion = new System.Windows.Forms.Button();
            this.cboEstadoTipoIdentificacionForm = new System.Windows.Forms.ComboBox();
            this.lblEstadoTipoIdentificacionForm = new System.Windows.Forms.Label();
            this.txtNombreTipoIdentificacion = new System.Windows.Forms.TextBox();
            this.lblNombreTipoIdentificacion = new System.Windows.Forms.Label();
            this.lblFormTituloTipoIdentificacion = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.tabCatalogos.SuspendLayout();
            this.tabEspecies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecies)).BeginInit();
            this.tabRazas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRazas)).BeginInit();
            this.tabEspecialidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
            this.tabTiposIdentificacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposIdentificacion)).BeginInit();
            this.SuspendLayout();

            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnCerrar);
            this.pnlHeader.Controls.Add(this.lblInfoUsuario);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.pnlHeaderBorde);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(950, 50);
            this.pnlHeader.TabIndex = 0;
            //
            // btnCerrar
            //
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.Location = new System.Drawing.Point(840, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 30);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            //
            // lblInfoUsuario
            //
            this.lblInfoUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblInfoUsuario.Location = new System.Drawing.Point(520, 16);
            this.lblInfoUsuario.Name = "lblInfoUsuario";
            this.lblInfoUsuario.Size = new System.Drawing.Size(310, 20);
            this.lblInfoUsuario.TabIndex = 1;
            this.lblInfoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(160, 38);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Catalogos";
            //
            // pnlHeaderBorde
            //
            this.pnlHeaderBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.pnlHeaderBorde.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderBorde.Location = new System.Drawing.Point(0, 49);
            this.pnlHeaderBorde.Name = "pnlHeaderBorde";
            this.pnlHeaderBorde.Size = new System.Drawing.Size(950, 1);
            this.pnlHeaderBorde.TabIndex = 2;

            //
            // tabCatalogos
            //
            this.tabCatalogos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCatalogos.Controls.Add(this.tabEspecies);
            this.tabCatalogos.Controls.Add(this.tabRazas);
            this.tabCatalogos.Controls.Add(this.tabEspecialidades);
            this.tabCatalogos.Controls.Add(this.tabTiposIdentificacion);
            this.tabCatalogos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabCatalogos.Location = new System.Drawing.Point(20, 62);
            this.tabCatalogos.Name = "tabCatalogos";
            this.tabCatalogos.SelectedIndex = 0;
            this.tabCatalogos.Size = new System.Drawing.Size(910, 700);
            this.tabCatalogos.TabIndex = 1;
            this.tabCatalogos.SelectedIndexChanged += new System.EventHandler(this.tabCatalogos_SelectedIndexChanged);

            //
            // tabEspecies
            //
            this.tabEspecies.BackColor = System.Drawing.Color.White;
            this.tabEspecies.Controls.Add(this.pnlFormEspecie);
            this.tabEspecies.Controls.Add(this.btnEliminarEspecie);
            this.tabEspecies.Controls.Add(this.btnModificarEspecie);
            this.tabEspecies.Controls.Add(this.btnNuevaEspecie);
            this.tabEspecies.Controls.Add(this.txtBuscarEspecie);
            this.tabEspecies.Controls.Add(this.dgvEspecies);
            this.tabEspecies.Location = new System.Drawing.Point(4, 30);
            this.tabEspecies.Name = "tabEspecies";
            this.tabEspecies.Padding = new System.Windows.Forms.Padding(14);
            this.tabEspecies.Size = new System.Drawing.Size(902, 666);
            this.tabEspecies.TabIndex = 0;
            this.tabEspecies.Text = "Especies";
            //
            // txtBuscarEspecie
            //
            this.txtBuscarEspecie.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarEspecie.Location = new System.Drawing.Point(14, 14);
            this.txtBuscarEspecie.Name = "txtBuscarEspecie";
            this.txtBuscarEspecie.Size = new System.Drawing.Size(400, 33);
            this.txtBuscarEspecie.TabIndex = 0;
            this.txtBuscarEspecie.TextChanged += new System.EventHandler(this.txtBuscarEspecie_TextChanged);
            //
            // btnNuevaEspecie
            //
            this.btnNuevaEspecie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnNuevaEspecie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaEspecie.FlatAppearance.BorderSize = 0;
            this.btnNuevaEspecie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaEspecie.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevaEspecie.ForeColor = System.Drawing.Color.White;
            this.btnNuevaEspecie.Location = new System.Drawing.Point(430, 14);
            this.btnNuevaEspecie.Name = "btnNuevaEspecie";
            this.btnNuevaEspecie.Size = new System.Drawing.Size(110, 30);
            this.btnNuevaEspecie.TabIndex = 1;
            this.btnNuevaEspecie.Text = "+ Nueva";
            this.btnNuevaEspecie.UseVisualStyleBackColor = false;
            this.btnNuevaEspecie.Click += new System.EventHandler(this.btnNuevaEspecie_Click);
            //
            // btnModificarEspecie
            //
            this.btnModificarEspecie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarEspecie.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnModificarEspecie.Location = new System.Drawing.Point(550, 14);
            this.btnModificarEspecie.Name = "btnModificarEspecie";
            this.btnModificarEspecie.Size = new System.Drawing.Size(120, 30);
            this.btnModificarEspecie.TabIndex = 2;
            this.btnModificarEspecie.Text = "Modificar";
            this.btnModificarEspecie.UseVisualStyleBackColor = true;
            this.btnModificarEspecie.Click += new System.EventHandler(this.btnModificarEspecie_Click);
            //
            // btnEliminarEspecie
            //
            this.btnEliminarEspecie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnEliminarEspecie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarEspecie.FlatAppearance.BorderSize = 0;
            this.btnEliminarEspecie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarEspecie.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminarEspecie.ForeColor = System.Drawing.Color.White;
            this.btnEliminarEspecie.Location = new System.Drawing.Point(680, 14);
            this.btnEliminarEspecie.Name = "btnEliminarEspecie";
            this.btnEliminarEspecie.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarEspecie.TabIndex = 3;
            this.btnEliminarEspecie.Text = "Eliminar";
            this.btnEliminarEspecie.UseVisualStyleBackColor = false;
            this.btnEliminarEspecie.Click += new System.EventHandler(this.btnEliminarEspecie_Click);
            //
            // dgvEspecies
            //
            this.dgvEspecies.AllowUserToAddRows = false;
            this.dgvEspecies.AllowUserToDeleteRows = false;
            this.dgvEspecies.BackgroundColor = System.Drawing.Color.White;
            this.dgvEspecies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEspecies.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEspecies.ColumnHeadersHeight = 34;
            this.dgvEspecies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEspecies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdEspecie,
            this.colNombreEspecie,
            this.colEstadoEspecie});
            this.dgvEspecies.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.dgvEspecies.Location = new System.Drawing.Point(14, 56);
            this.dgvEspecies.MultiSelect = false;
            this.dgvEspecies.Name = "dgvEspecies";
            this.dgvEspecies.ReadOnly = true;
            this.dgvEspecies.RowHeadersVisible = false;
            this.dgvEspecies.RowHeadersWidth = 62;
            this.dgvEspecies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEspecies.Size = new System.Drawing.Size(870, 380);
            this.dgvEspecies.TabIndex = 4;
            //
            // colIdEspecie
            //
            this.colIdEspecie.DataPropertyName = "Id_Especie";
            this.colIdEspecie.HeaderText = "Id";
            this.colIdEspecie.MinimumWidth = 8;
            this.colIdEspecie.Name = "colIdEspecie";
            this.colIdEspecie.ReadOnly = true;
            this.colIdEspecie.Width = 80;
            //
            // colNombreEspecie
            //
            this.colNombreEspecie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombreEspecie.DataPropertyName = "Especie";
            this.colNombreEspecie.HeaderText = "Nombre";
            this.colNombreEspecie.MinimumWidth = 8;
            this.colNombreEspecie.Name = "colNombreEspecie";
            this.colNombreEspecie.ReadOnly = true;
            //
            // colEstadoEspecie
            //
            this.colEstadoEspecie.DataPropertyName = "Estado";
            this.colEstadoEspecie.HeaderText = "Estado";
            this.colEstadoEspecie.MinimumWidth = 8;
            this.colEstadoEspecie.Name = "colEstadoEspecie";
            this.colEstadoEspecie.ReadOnly = true;
            this.colEstadoEspecie.Width = 110;

            //
            // pnlFormEspecie
            //
            this.pnlFormEspecie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.pnlFormEspecie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormEspecie.Controls.Add(this.btnCancelarEspecie);
            this.pnlFormEspecie.Controls.Add(this.btnGuardarEspecie);
            this.pnlFormEspecie.Controls.Add(this.cboEstadoEspecie);
            this.pnlFormEspecie.Controls.Add(this.lblEstadoEspecie);
            this.pnlFormEspecie.Controls.Add(this.txtNombreEspecie);
            this.pnlFormEspecie.Controls.Add(this.lblNombreEspecie);
            this.pnlFormEspecie.Controls.Add(this.lblFormTituloEspecie);
            this.pnlFormEspecie.Location = new System.Drawing.Point(14, 450);
            this.pnlFormEspecie.Name = "pnlFormEspecie";
            this.pnlFormEspecie.Size = new System.Drawing.Size(870, 166);
            this.pnlFormEspecie.TabIndex = 5;
            this.pnlFormEspecie.Visible = false;
            //
            // lblFormTituloEspecie
            //
            this.lblFormTituloEspecie.AutoSize = true;
            this.lblFormTituloEspecie.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormTituloEspecie.Location = new System.Drawing.Point(14, 10);
            this.lblFormTituloEspecie.Name = "lblFormTituloEspecie";
            this.lblFormTituloEspecie.Size = new System.Drawing.Size(150, 28);
            this.lblFormTituloEspecie.TabIndex = 0;
            this.lblFormTituloEspecie.Text = "Nueva especie";
            //
            // lblNombreEspecie
            //
            this.lblNombreEspecie.AutoSize = true;
            this.lblNombreEspecie.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNombreEspecie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblNombreEspecie.Location = new System.Drawing.Point(14, 44);
            this.lblNombreEspecie.Name = "lblNombreEspecie";
            this.lblNombreEspecie.Size = new System.Drawing.Size(80, 23);
            this.lblNombreEspecie.TabIndex = 1;
            this.lblNombreEspecie.Text = "Nombre";
            //
            // txtNombreEspecie
            //
            this.txtNombreEspecie.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreEspecie.Location = new System.Drawing.Point(14, 60);
            this.txtNombreEspecie.Name = "txtNombreEspecie";
            this.txtNombreEspecie.Size = new System.Drawing.Size(400, 33);
            this.txtNombreEspecie.TabIndex = 2;
            //
            // lblEstadoEspecie
            //
            this.lblEstadoEspecie.AutoSize = true;
            this.lblEstadoEspecie.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstadoEspecie.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblEstadoEspecie.Location = new System.Drawing.Point(450, 44);
            this.lblEstadoEspecie.Name = "lblEstadoEspecie";
            this.lblEstadoEspecie.Size = new System.Drawing.Size(61, 23);
            this.lblEstadoEspecie.TabIndex = 3;
            this.lblEstadoEspecie.Text = "Estado";
            //
            // cboEstadoEspecie
            //
            this.cboEstadoEspecie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoEspecie.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstadoEspecie.FormattingEnabled = true;
            this.cboEstadoEspecie.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cboEstadoEspecie.Location = new System.Drawing.Point(450, 60);
            this.cboEstadoEspecie.Name = "cboEstadoEspecie";
            this.cboEstadoEspecie.Size = new System.Drawing.Size(200, 33);
            this.cboEstadoEspecie.TabIndex = 4;
            //
            // btnGuardarEspecie
            //
            this.btnGuardarEspecie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnGuardarEspecie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarEspecie.FlatAppearance.BorderSize = 0;
            this.btnGuardarEspecie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarEspecie.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarEspecie.ForeColor = System.Drawing.Color.White;
            this.btnGuardarEspecie.Location = new System.Drawing.Point(14, 112);
            this.btnGuardarEspecie.Name = "btnGuardarEspecie";
            this.btnGuardarEspecie.Size = new System.Drawing.Size(130, 34);
            this.btnGuardarEspecie.TabIndex = 5;
            this.btnGuardarEspecie.Text = "Guardar";
            this.btnGuardarEspecie.UseVisualStyleBackColor = false;
            this.btnGuardarEspecie.Click += new System.EventHandler(this.btnGuardarEspecie_Click);
            //
            // btnCancelarEspecie
            //
            this.btnCancelarEspecie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarEspecie.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelarEspecie.Location = new System.Drawing.Point(160, 112);
            this.btnCancelarEspecie.Name = "btnCancelarEspecie";
            this.btnCancelarEspecie.Size = new System.Drawing.Size(130, 34);
            this.btnCancelarEspecie.TabIndex = 6;
            this.btnCancelarEspecie.Text = "Cancelar";
            this.btnCancelarEspecie.UseVisualStyleBackColor = true;
            this.btnCancelarEspecie.Click += new System.EventHandler(this.btnCancelarEspecie_Click);

            //
            // tabRazas
            //
            this.tabRazas.BackColor = System.Drawing.Color.White;
            this.tabRazas.Controls.Add(this.pnlFormRaza);
            this.tabRazas.Controls.Add(this.btnEliminarRaza);
            this.tabRazas.Controls.Add(this.btnModificarRaza);
            this.tabRazas.Controls.Add(this.btnNuevaRaza);
            this.tabRazas.Controls.Add(this.txtBuscarRaza);
            this.tabRazas.Controls.Add(this.cboEspecieRaza);
            this.tabRazas.Controls.Add(this.lblEspecieRaza);
            this.tabRazas.Controls.Add(this.dgvRazas);
            this.tabRazas.Location = new System.Drawing.Point(4, 30);
            this.tabRazas.Name = "tabRazas";
            this.tabRazas.Padding = new System.Windows.Forms.Padding(14);
            this.tabRazas.Size = new System.Drawing.Size(902, 666);
            this.tabRazas.TabIndex = 1;
            this.tabRazas.Text = "Razas";
            //
            // lblEspecieRaza
            //
            this.lblEspecieRaza.AutoSize = true;
            this.lblEspecieRaza.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEspecieRaza.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblEspecieRaza.Location = new System.Drawing.Point(14, 0);
            this.lblEspecieRaza.Name = "lblEspecieRaza";
            this.lblEspecieRaza.Size = new System.Drawing.Size(61, 23);
            this.lblEspecieRaza.TabIndex = 0;
            this.lblEspecieRaza.Text = "Especie";
            //
            // cboEspecieRaza
            //
            this.cboEspecieRaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEspecieRaza.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEspecieRaza.FormattingEnabled = true;
            this.cboEspecieRaza.Location = new System.Drawing.Point(14, 16);
            this.cboEspecieRaza.Name = "cboEspecieRaza";
            this.cboEspecieRaza.Size = new System.Drawing.Size(220, 33);
            this.cboEspecieRaza.TabIndex = 1;
            this.cboEspecieRaza.SelectedIndexChanged += new System.EventHandler(this.cboEspecieRaza_SelectedIndexChanged);
            //
            // txtBuscarRaza
            //
            this.txtBuscarRaza.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarRaza.Location = new System.Drawing.Point(250, 16);
            this.txtBuscarRaza.Name = "txtBuscarRaza";
            this.txtBuscarRaza.Size = new System.Drawing.Size(300, 33);
            this.txtBuscarRaza.TabIndex = 2;
            this.txtBuscarRaza.TextChanged += new System.EventHandler(this.txtBuscarRaza_TextChanged);
            //
            // btnNuevaRaza
            //
            this.btnNuevaRaza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnNuevaRaza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaRaza.FlatAppearance.BorderSize = 0;
            this.btnNuevaRaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaRaza.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevaRaza.ForeColor = System.Drawing.Color.White;
            this.btnNuevaRaza.Location = new System.Drawing.Point(570, 16);
            this.btnNuevaRaza.Name = "btnNuevaRaza";
            this.btnNuevaRaza.Size = new System.Drawing.Size(100, 30);
            this.btnNuevaRaza.TabIndex = 3;
            this.btnNuevaRaza.Text = "+ Nueva";
            this.btnNuevaRaza.UseVisualStyleBackColor = false;
            this.btnNuevaRaza.Click += new System.EventHandler(this.btnNuevaRaza_Click);
            //
            // btnModificarRaza
            //
            this.btnModificarRaza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarRaza.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnModificarRaza.Location = new System.Drawing.Point(680, 16);
            this.btnModificarRaza.Name = "btnModificarRaza";
            this.btnModificarRaza.Size = new System.Drawing.Size(110, 30);
            this.btnModificarRaza.TabIndex = 4;
            this.btnModificarRaza.Text = "Modificar";
            this.btnModificarRaza.UseVisualStyleBackColor = true;
            this.btnModificarRaza.Click += new System.EventHandler(this.btnModificarRaza_Click);
            //
            // btnEliminarRaza
            //
            this.btnEliminarRaza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnEliminarRaza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarRaza.FlatAppearance.BorderSize = 0;
            this.btnEliminarRaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarRaza.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminarRaza.ForeColor = System.Drawing.Color.White;
            this.btnEliminarRaza.Location = new System.Drawing.Point(800, 16);
            this.btnEliminarRaza.Name = "btnEliminarRaza";
            this.btnEliminarRaza.Size = new System.Drawing.Size(84, 30);
            this.btnEliminarRaza.TabIndex = 5;
            this.btnEliminarRaza.Text = "Eliminar";
            this.btnEliminarRaza.UseVisualStyleBackColor = false;
            this.btnEliminarRaza.Click += new System.EventHandler(this.btnEliminarRaza_Click);
            //
            // dgvRazas
            //
            this.dgvRazas.AllowUserToAddRows = false;
            this.dgvRazas.AllowUserToDeleteRows = false;
            this.dgvRazas.BackgroundColor = System.Drawing.Color.White;
            this.dgvRazas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRazas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRazas.ColumnHeadersHeight = 34;
            this.dgvRazas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRazas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdRaza,
            this.colNombreRaza,
            this.colEspecieRaza,
            this.colEstadoRaza});
            this.dgvRazas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.dgvRazas.Location = new System.Drawing.Point(14, 60);
            this.dgvRazas.MultiSelect = false;
            this.dgvRazas.Name = "dgvRazas";
            this.dgvRazas.ReadOnly = true;
            this.dgvRazas.RowHeadersVisible = false;
            this.dgvRazas.RowHeadersWidth = 62;
            this.dgvRazas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRazas.Size = new System.Drawing.Size(870, 376);
            this.dgvRazas.TabIndex = 6;
            //
            // colIdRaza
            //
            this.colIdRaza.DataPropertyName = "Id_Raza";
            this.colIdRaza.HeaderText = "Id";
            this.colIdRaza.MinimumWidth = 8;
            this.colIdRaza.Name = "colIdRaza";
            this.colIdRaza.ReadOnly = true;
            this.colIdRaza.Width = 80;
            //
            // colNombreRaza
            //
            this.colNombreRaza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombreRaza.DataPropertyName = "Raza";
            this.colNombreRaza.HeaderText = "Nombre";
            this.colNombreRaza.MinimumWidth = 8;
            this.colNombreRaza.Name = "colNombreRaza";
            this.colNombreRaza.ReadOnly = true;
            //
            // colEspecieRaza
            //
            this.colEspecieRaza.DataPropertyName = "Especie";
            this.colEspecieRaza.HeaderText = "Especie";
            this.colEspecieRaza.MinimumWidth = 8;
            this.colEspecieRaza.Name = "colEspecieRaza";
            this.colEspecieRaza.ReadOnly = true;
            this.colEspecieRaza.Width = 150;
            //
            // colEstadoRaza
            //
            this.colEstadoRaza.DataPropertyName = "Estado";
            this.colEstadoRaza.HeaderText = "Estado";
            this.colEstadoRaza.MinimumWidth = 8;
            this.colEstadoRaza.Name = "colEstadoRaza";
            this.colEstadoRaza.ReadOnly = true;
            this.colEstadoRaza.Width = 110;

            //
            // pnlFormRaza
            //
            this.pnlFormRaza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.pnlFormRaza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormRaza.Controls.Add(this.btnCancelarRaza);
            this.pnlFormRaza.Controls.Add(this.btnGuardarRaza);
            this.pnlFormRaza.Controls.Add(this.cboEstadoRaza);
            this.pnlFormRaza.Controls.Add(this.lblEstadoRazaForm);
            this.pnlFormRaza.Controls.Add(this.txtNombreRaza);
            this.pnlFormRaza.Controls.Add(this.lblNombreRaza);
            this.pnlFormRaza.Controls.Add(this.lblFormTituloRaza);
            this.pnlFormRaza.Location = new System.Drawing.Point(14, 450);
            this.pnlFormRaza.Name = "pnlFormRaza";
            this.pnlFormRaza.Size = new System.Drawing.Size(870, 166);
            this.pnlFormRaza.TabIndex = 7;
            this.pnlFormRaza.Visible = false;
            //
            // lblFormTituloRaza
            //
            this.lblFormTituloRaza.AutoSize = true;
            this.lblFormTituloRaza.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormTituloRaza.Location = new System.Drawing.Point(14, 10);
            this.lblFormTituloRaza.Name = "lblFormTituloRaza";
            this.lblFormTituloRaza.Size = new System.Drawing.Size(150, 28);
            this.lblFormTituloRaza.TabIndex = 0;
            this.lblFormTituloRaza.Text = "Nueva raza";
            //
            // lblNombreRaza
            //
            this.lblNombreRaza.AutoSize = true;
            this.lblNombreRaza.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNombreRaza.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblNombreRaza.Location = new System.Drawing.Point(14, 44);
            this.lblNombreRaza.Name = "lblNombreRaza";
            this.lblNombreRaza.Size = new System.Drawing.Size(80, 23);
            this.lblNombreRaza.TabIndex = 1;
            this.lblNombreRaza.Text = "Nombre";
            //
            // txtNombreRaza
            //
            this.txtNombreRaza.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreRaza.Location = new System.Drawing.Point(14, 60);
            this.txtNombreRaza.Name = "txtNombreRaza";
            this.txtNombreRaza.Size = new System.Drawing.Size(400, 33);
            this.txtNombreRaza.TabIndex = 2;
            //
            // lblEstadoRazaForm
            //
            this.lblEstadoRazaForm.AutoSize = true;
            this.lblEstadoRazaForm.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstadoRazaForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblEstadoRazaForm.Location = new System.Drawing.Point(450, 44);
            this.lblEstadoRazaForm.Name = "lblEstadoRazaForm";
            this.lblEstadoRazaForm.Size = new System.Drawing.Size(61, 23);
            this.lblEstadoRazaForm.TabIndex = 3;
            this.lblEstadoRazaForm.Text = "Estado";
            //
            // cboEstadoRaza
            //
            this.cboEstadoRaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoRaza.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstadoRaza.FormattingEnabled = true;
            this.cboEstadoRaza.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cboEstadoRaza.Location = new System.Drawing.Point(450, 60);
            this.cboEstadoRaza.Name = "cboEstadoRaza";
            this.cboEstadoRaza.Size = new System.Drawing.Size(200, 33);
            this.cboEstadoRaza.TabIndex = 4;
            //
            // btnGuardarRaza
            //
            this.btnGuardarRaza.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnGuardarRaza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarRaza.FlatAppearance.BorderSize = 0;
            this.btnGuardarRaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarRaza.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarRaza.ForeColor = System.Drawing.Color.White;
            this.btnGuardarRaza.Location = new System.Drawing.Point(14, 112);
            this.btnGuardarRaza.Name = "btnGuardarRaza";
            this.btnGuardarRaza.Size = new System.Drawing.Size(130, 34);
            this.btnGuardarRaza.TabIndex = 5;
            this.btnGuardarRaza.Text = "Guardar";
            this.btnGuardarRaza.UseVisualStyleBackColor = false;
            this.btnGuardarRaza.Click += new System.EventHandler(this.btnGuardarRaza_Click);
            //
            // btnCancelarRaza
            //
            this.btnCancelarRaza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarRaza.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelarRaza.Location = new System.Drawing.Point(160, 112);
            this.btnCancelarRaza.Name = "btnCancelarRaza";
            this.btnCancelarRaza.Size = new System.Drawing.Size(130, 34);
            this.btnCancelarRaza.TabIndex = 6;
            this.btnCancelarRaza.Text = "Cancelar";
            this.btnCancelarRaza.UseVisualStyleBackColor = true;
            this.btnCancelarRaza.Click += new System.EventHandler(this.btnCancelarRaza_Click);

            //
            // tabEspecialidades
            //
            this.tabEspecialidades.BackColor = System.Drawing.Color.White;
            this.tabEspecialidades.Controls.Add(this.pnlFormEspecialidad);
            this.tabEspecialidades.Controls.Add(this.btnEliminarEspecialidad);
            this.tabEspecialidades.Controls.Add(this.btnModificarEspecialidad);
            this.tabEspecialidades.Controls.Add(this.btnNuevaEspecialidad);
            this.tabEspecialidades.Controls.Add(this.txtBuscarEspecialidad);
            this.tabEspecialidades.Controls.Add(this.dgvEspecialidades);
            this.tabEspecialidades.Location = new System.Drawing.Point(4, 30);
            this.tabEspecialidades.Name = "tabEspecialidades";
            this.tabEspecialidades.Padding = new System.Windows.Forms.Padding(14);
            this.tabEspecialidades.Size = new System.Drawing.Size(902, 666);
            this.tabEspecialidades.TabIndex = 2;
            this.tabEspecialidades.Text = "Especialidades";
            //
            // txtBuscarEspecialidad
            //
            this.txtBuscarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarEspecialidad.Location = new System.Drawing.Point(14, 14);
            this.txtBuscarEspecialidad.Name = "txtBuscarEspecialidad";
            this.txtBuscarEspecialidad.Size = new System.Drawing.Size(400, 33);
            this.txtBuscarEspecialidad.TabIndex = 0;
            this.txtBuscarEspecialidad.TextChanged += new System.EventHandler(this.txtBuscarEspecialidad_TextChanged);
            //
            // btnNuevaEspecialidad
            //
            this.btnNuevaEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnNuevaEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnNuevaEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevaEspecialidad.ForeColor = System.Drawing.Color.White;
            this.btnNuevaEspecialidad.Location = new System.Drawing.Point(430, 14);
            this.btnNuevaEspecialidad.Name = "btnNuevaEspecialidad";
            this.btnNuevaEspecialidad.Size = new System.Drawing.Size(110, 30);
            this.btnNuevaEspecialidad.TabIndex = 1;
            this.btnNuevaEspecialidad.Text = "+ Nueva";
            this.btnNuevaEspecialidad.UseVisualStyleBackColor = false;
            this.btnNuevaEspecialidad.Click += new System.EventHandler(this.btnNuevaEspecialidad_Click);
            //
            // btnModificarEspecialidad
            //
            this.btnModificarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnModificarEspecialidad.Location = new System.Drawing.Point(550, 14);
            this.btnModificarEspecialidad.Name = "btnModificarEspecialidad";
            this.btnModificarEspecialidad.Size = new System.Drawing.Size(120, 30);
            this.btnModificarEspecialidad.TabIndex = 2;
            this.btnModificarEspecialidad.Text = "Modificar";
            this.btnModificarEspecialidad.UseVisualStyleBackColor = true;
            this.btnModificarEspecialidad.Click += new System.EventHandler(this.btnModificarEspecialidad_Click);
            //
            // btnEliminarEspecialidad
            //
            this.btnEliminarEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnEliminarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnEliminarEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminarEspecialidad.ForeColor = System.Drawing.Color.White;
            this.btnEliminarEspecialidad.Location = new System.Drawing.Point(680, 14);
            this.btnEliminarEspecialidad.Name = "btnEliminarEspecialidad";
            this.btnEliminarEspecialidad.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarEspecialidad.TabIndex = 3;
            this.btnEliminarEspecialidad.Text = "Eliminar";
            this.btnEliminarEspecialidad.UseVisualStyleBackColor = false;
            this.btnEliminarEspecialidad.Click += new System.EventHandler(this.btnEliminarEspecialidad_Click);
            //
            // dgvEspecialidades
            //
            this.dgvEspecialidades.AllowUserToAddRows = false;
            this.dgvEspecialidades.AllowUserToDeleteRows = false;
            this.dgvEspecialidades.BackgroundColor = System.Drawing.Color.White;
            this.dgvEspecialidades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEspecialidades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEspecialidades.ColumnHeadersHeight = 34;
            this.dgvEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEspecialidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdEspecialidad,
            this.colNombreEspecialidad,
            this.colEstadoEspecialidad});
            this.dgvEspecialidades.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.dgvEspecialidades.Location = new System.Drawing.Point(14, 56);
            this.dgvEspecialidades.MultiSelect = false;
            this.dgvEspecialidades.Name = "dgvEspecialidades";
            this.dgvEspecialidades.ReadOnly = true;
            this.dgvEspecialidades.RowHeadersVisible = false;
            this.dgvEspecialidades.RowHeadersWidth = 62;
            this.dgvEspecialidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEspecialidades.Size = new System.Drawing.Size(870, 380);
            this.dgvEspecialidades.TabIndex = 4;
            //
            // colIdEspecialidad
            //
            this.colIdEspecialidad.DataPropertyName = "Id_Especialidad";
            this.colIdEspecialidad.HeaderText = "Id";
            this.colIdEspecialidad.MinimumWidth = 8;
            this.colIdEspecialidad.Name = "colIdEspecialidad";
            this.colIdEspecialidad.ReadOnly = true;
            this.colIdEspecialidad.Width = 80;
            //
            // colNombreEspecialidad
            //
            this.colNombreEspecialidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombreEspecialidad.DataPropertyName = "Especialidad";
            this.colNombreEspecialidad.HeaderText = "Nombre";
            this.colNombreEspecialidad.MinimumWidth = 8;
            this.colNombreEspecialidad.Name = "colNombreEspecialidad";
            this.colNombreEspecialidad.ReadOnly = true;
            //
            // colEstadoEspecialidad
            //
            this.colEstadoEspecialidad.DataPropertyName = "Estado";
            this.colEstadoEspecialidad.HeaderText = "Estado";
            this.colEstadoEspecialidad.MinimumWidth = 8;
            this.colEstadoEspecialidad.Name = "colEstadoEspecialidad";
            this.colEstadoEspecialidad.ReadOnly = true;
            this.colEstadoEspecialidad.Width = 110;

            //
            // pnlFormEspecialidad
            //
            this.pnlFormEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.pnlFormEspecialidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormEspecialidad.Controls.Add(this.btnCancelarEspecialidad);
            this.pnlFormEspecialidad.Controls.Add(this.btnGuardarEspecialidad);
            this.pnlFormEspecialidad.Controls.Add(this.cboEstadoEspecialidadForm);
            this.pnlFormEspecialidad.Controls.Add(this.lblEstadoEspecialidadForm);
            this.pnlFormEspecialidad.Controls.Add(this.txtNombreEspecialidad);
            this.pnlFormEspecialidad.Controls.Add(this.lblNombreEspecialidad);
            this.pnlFormEspecialidad.Controls.Add(this.lblFormTituloEspecialidad);
            this.pnlFormEspecialidad.Location = new System.Drawing.Point(14, 450);
            this.pnlFormEspecialidad.Name = "pnlFormEspecialidad";
            this.pnlFormEspecialidad.Size = new System.Drawing.Size(870, 166);
            this.pnlFormEspecialidad.TabIndex = 5;
            this.pnlFormEspecialidad.Visible = false;
            //
            // lblFormTituloEspecialidad
            //
            this.lblFormTituloEspecialidad.AutoSize = true;
            this.lblFormTituloEspecialidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormTituloEspecialidad.Location = new System.Drawing.Point(14, 10);
            this.lblFormTituloEspecialidad.Name = "lblFormTituloEspecialidad";
            this.lblFormTituloEspecialidad.Size = new System.Drawing.Size(180, 28);
            this.lblFormTituloEspecialidad.TabIndex = 0;
            this.lblFormTituloEspecialidad.Text = "Nueva especialidad";
            //
            // lblNombreEspecialidad
            //
            this.lblNombreEspecialidad.AutoSize = true;
            this.lblNombreEspecialidad.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNombreEspecialidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblNombreEspecialidad.Location = new System.Drawing.Point(14, 44);
            this.lblNombreEspecialidad.Name = "lblNombreEspecialidad";
            this.lblNombreEspecialidad.Size = new System.Drawing.Size(80, 23);
            this.lblNombreEspecialidad.TabIndex = 1;
            this.lblNombreEspecialidad.Text = "Nombre";
            //
            // txtNombreEspecialidad
            //
            this.txtNombreEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreEspecialidad.Location = new System.Drawing.Point(14, 60);
            this.txtNombreEspecialidad.Name = "txtNombreEspecialidad";
            this.txtNombreEspecialidad.Size = new System.Drawing.Size(400, 33);
            this.txtNombreEspecialidad.TabIndex = 2;
            //
            // lblEstadoEspecialidadForm
            //
            this.lblEstadoEspecialidadForm.AutoSize = true;
            this.lblEstadoEspecialidadForm.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstadoEspecialidadForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblEstadoEspecialidadForm.Location = new System.Drawing.Point(450, 44);
            this.lblEstadoEspecialidadForm.Name = "lblEstadoEspecialidadForm";
            this.lblEstadoEspecialidadForm.Size = new System.Drawing.Size(61, 23);
            this.lblEstadoEspecialidadForm.TabIndex = 3;
            this.lblEstadoEspecialidadForm.Text = "Estado";
            //
            // cboEstadoEspecialidadForm
            //
            this.cboEstadoEspecialidadForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoEspecialidadForm.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstadoEspecialidadForm.FormattingEnabled = true;
            this.cboEstadoEspecialidadForm.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cboEstadoEspecialidadForm.Location = new System.Drawing.Point(450, 60);
            this.cboEstadoEspecialidadForm.Name = "cboEstadoEspecialidadForm";
            this.cboEstadoEspecialidadForm.Size = new System.Drawing.Size(200, 33);
            this.cboEstadoEspecialidadForm.TabIndex = 4;
            //
            // btnGuardarEspecialidad
            //
            this.btnGuardarEspecialidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnGuardarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarEspecialidad.FlatAppearance.BorderSize = 0;
            this.btnGuardarEspecialidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarEspecialidad.ForeColor = System.Drawing.Color.White;
            this.btnGuardarEspecialidad.Location = new System.Drawing.Point(14, 112);
            this.btnGuardarEspecialidad.Name = "btnGuardarEspecialidad";
            this.btnGuardarEspecialidad.Size = new System.Drawing.Size(130, 34);
            this.btnGuardarEspecialidad.TabIndex = 5;
            this.btnGuardarEspecialidad.Text = "Guardar";
            this.btnGuardarEspecialidad.UseVisualStyleBackColor = false;
            this.btnGuardarEspecialidad.Click += new System.EventHandler(this.btnGuardarEspecialidad_Click);
            //
            // btnCancelarEspecialidad
            //
            this.btnCancelarEspecialidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelarEspecialidad.Location = new System.Drawing.Point(160, 112);
            this.btnCancelarEspecialidad.Name = "btnCancelarEspecialidad";
            this.btnCancelarEspecialidad.Size = new System.Drawing.Size(130, 34);
            this.btnCancelarEspecialidad.TabIndex = 6;
            this.btnCancelarEspecialidad.Text = "Cancelar";
            this.btnCancelarEspecialidad.UseVisualStyleBackColor = true;
            this.btnCancelarEspecialidad.Click += new System.EventHandler(this.btnCancelarEspecialidad_Click);

            //
            // tabTiposIdentificacion
            //
            this.tabTiposIdentificacion.BackColor = System.Drawing.Color.White;
            this.tabTiposIdentificacion.Controls.Add(this.pnlFormTipoIdentificacion);
            this.tabTiposIdentificacion.Controls.Add(this.btnEliminarTipoIdentificacion);
            this.tabTiposIdentificacion.Controls.Add(this.btnModificarTipoIdentificacion);
            this.tabTiposIdentificacion.Controls.Add(this.btnNuevoTipoIdentificacion);
            this.tabTiposIdentificacion.Controls.Add(this.txtBuscarTipoIdentificacion);
            this.tabTiposIdentificacion.Controls.Add(this.dgvTiposIdentificacion);
            this.tabTiposIdentificacion.Location = new System.Drawing.Point(4, 30);
            this.tabTiposIdentificacion.Name = "tabTiposIdentificacion";
            this.tabTiposIdentificacion.Padding = new System.Windows.Forms.Padding(14);
            this.tabTiposIdentificacion.Size = new System.Drawing.Size(902, 666);
            this.tabTiposIdentificacion.TabIndex = 3;
            this.tabTiposIdentificacion.Text = "Tipos de identificacion";
            //
            // txtBuscarTipoIdentificacion
            //
            this.txtBuscarTipoIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarTipoIdentificacion.Location = new System.Drawing.Point(14, 14);
            this.txtBuscarTipoIdentificacion.Name = "txtBuscarTipoIdentificacion";
            this.txtBuscarTipoIdentificacion.Size = new System.Drawing.Size(400, 33);
            this.txtBuscarTipoIdentificacion.TabIndex = 0;
            this.txtBuscarTipoIdentificacion.TextChanged += new System.EventHandler(this.txtBuscarTipoIdentificacion_TextChanged);
            //
            // btnNuevoTipoIdentificacion
            //
            this.btnNuevoTipoIdentificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnNuevoTipoIdentificacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoTipoIdentificacion.FlatAppearance.BorderSize = 0;
            this.btnNuevoTipoIdentificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoTipoIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevoTipoIdentificacion.ForeColor = System.Drawing.Color.White;
            this.btnNuevoTipoIdentificacion.Location = new System.Drawing.Point(430, 14);
            this.btnNuevoTipoIdentificacion.Name = "btnNuevoTipoIdentificacion";
            this.btnNuevoTipoIdentificacion.Size = new System.Drawing.Size(110, 30);
            this.btnNuevoTipoIdentificacion.TabIndex = 1;
            this.btnNuevoTipoIdentificacion.Text = "+ Nuevo";
            this.btnNuevoTipoIdentificacion.UseVisualStyleBackColor = false;
            this.btnNuevoTipoIdentificacion.Click += new System.EventHandler(this.btnNuevoTipoIdentificacion_Click);
            //
            // btnModificarTipoIdentificacion
            //
            this.btnModificarTipoIdentificacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarTipoIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnModificarTipoIdentificacion.Location = new System.Drawing.Point(550, 14);
            this.btnModificarTipoIdentificacion.Name = "btnModificarTipoIdentificacion";
            this.btnModificarTipoIdentificacion.Size = new System.Drawing.Size(120, 30);
            this.btnModificarTipoIdentificacion.TabIndex = 2;
            this.btnModificarTipoIdentificacion.Text = "Modificar";
            this.btnModificarTipoIdentificacion.UseVisualStyleBackColor = true;
            this.btnModificarTipoIdentificacion.Click += new System.EventHandler(this.btnModificarTipoIdentificacion_Click);
            //
            // btnEliminarTipoIdentificacion
            //
            this.btnEliminarTipoIdentificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnEliminarTipoIdentificacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarTipoIdentificacion.FlatAppearance.BorderSize = 0;
            this.btnEliminarTipoIdentificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarTipoIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminarTipoIdentificacion.ForeColor = System.Drawing.Color.White;
            this.btnEliminarTipoIdentificacion.Location = new System.Drawing.Point(680, 14);
            this.btnEliminarTipoIdentificacion.Name = "btnEliminarTipoIdentificacion";
            this.btnEliminarTipoIdentificacion.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarTipoIdentificacion.TabIndex = 3;
            this.btnEliminarTipoIdentificacion.Text = "Eliminar";
            this.btnEliminarTipoIdentificacion.UseVisualStyleBackColor = false;
            this.btnEliminarTipoIdentificacion.Click += new System.EventHandler(this.btnEliminarTipoIdentificacion_Click);
            //
            // dgvTiposIdentificacion
            //
            this.dgvTiposIdentificacion.AllowUserToAddRows = false;
            this.dgvTiposIdentificacion.AllowUserToDeleteRows = false;
            this.dgvTiposIdentificacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvTiposIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTiposIdentificacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTiposIdentificacion.ColumnHeadersHeight = 34;
            this.dgvTiposIdentificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTiposIdentificacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdTipoIdentificacion,
            this.colNombreTipoIdentificacion,
            this.colEstadoTipoIdentificacion});
            this.dgvTiposIdentificacion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.dgvTiposIdentificacion.Location = new System.Drawing.Point(14, 56);
            this.dgvTiposIdentificacion.MultiSelect = false;
            this.dgvTiposIdentificacion.Name = "dgvTiposIdentificacion";
            this.dgvTiposIdentificacion.ReadOnly = true;
            this.dgvTiposIdentificacion.RowHeadersVisible = false;
            this.dgvTiposIdentificacion.RowHeadersWidth = 62;
            this.dgvTiposIdentificacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTiposIdentificacion.Size = new System.Drawing.Size(870, 380);
            this.dgvTiposIdentificacion.TabIndex = 4;
            //
            // colIdTipoIdentificacion
            //
            this.colIdTipoIdentificacion.DataPropertyName = "Id_Tipo_Identificacion";
            this.colIdTipoIdentificacion.HeaderText = "Id";
            this.colIdTipoIdentificacion.MinimumWidth = 8;
            this.colIdTipoIdentificacion.Name = "colIdTipoIdentificacion";
            this.colIdTipoIdentificacion.ReadOnly = true;
            this.colIdTipoIdentificacion.Width = 80;
            //
            // colNombreTipoIdentificacion
            //
            this.colNombreTipoIdentificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombreTipoIdentificacion.DataPropertyName = "Tipo_Identificacion";
            this.colNombreTipoIdentificacion.HeaderText = "Nombre";
            this.colNombreTipoIdentificacion.MinimumWidth = 8;
            this.colNombreTipoIdentificacion.Name = "colNombreTipoIdentificacion";
            this.colNombreTipoIdentificacion.ReadOnly = true;
            //
            // colEstadoTipoIdentificacion
            //
            this.colEstadoTipoIdentificacion.DataPropertyName = "Estado";
            this.colEstadoTipoIdentificacion.HeaderText = "Estado";
            this.colEstadoTipoIdentificacion.MinimumWidth = 8;
            this.colEstadoTipoIdentificacion.Name = "colEstadoTipoIdentificacion";
            this.colEstadoTipoIdentificacion.ReadOnly = true;
            this.colEstadoTipoIdentificacion.Width = 110;

            //
            // pnlFormTipoIdentificacion
            //
            this.pnlFormTipoIdentificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.pnlFormTipoIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormTipoIdentificacion.Controls.Add(this.btnCancelarTipoIdentificacion);
            this.pnlFormTipoIdentificacion.Controls.Add(this.btnGuardarTipoIdentificacion);
            this.pnlFormTipoIdentificacion.Controls.Add(this.cboEstadoTipoIdentificacionForm);
            this.pnlFormTipoIdentificacion.Controls.Add(this.lblEstadoTipoIdentificacionForm);
            this.pnlFormTipoIdentificacion.Controls.Add(this.txtNombreTipoIdentificacion);
            this.pnlFormTipoIdentificacion.Controls.Add(this.lblNombreTipoIdentificacion);
            this.pnlFormTipoIdentificacion.Controls.Add(this.lblFormTituloTipoIdentificacion);
            this.pnlFormTipoIdentificacion.Location = new System.Drawing.Point(14, 450);
            this.pnlFormTipoIdentificacion.Name = "pnlFormTipoIdentificacion";
            this.pnlFormTipoIdentificacion.Size = new System.Drawing.Size(870, 166);
            this.pnlFormTipoIdentificacion.TabIndex = 5;
            this.pnlFormTipoIdentificacion.Visible = false;
            //
            // lblFormTituloTipoIdentificacion
            //
            this.lblFormTituloTipoIdentificacion.AutoSize = true;
            this.lblFormTituloTipoIdentificacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormTituloTipoIdentificacion.Location = new System.Drawing.Point(14, 10);
            this.lblFormTituloTipoIdentificacion.Name = "lblFormTituloTipoIdentificacion";
            this.lblFormTituloTipoIdentificacion.Size = new System.Drawing.Size(220, 28);
            this.lblFormTituloTipoIdentificacion.TabIndex = 0;
            this.lblFormTituloTipoIdentificacion.Text = "Nuevo tipo de identificacion";
            //
            // lblNombreTipoIdentificacion
            //
            this.lblNombreTipoIdentificacion.AutoSize = true;
            this.lblNombreTipoIdentificacion.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNombreTipoIdentificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblNombreTipoIdentificacion.Location = new System.Drawing.Point(14, 44);
            this.lblNombreTipoIdentificacion.Name = "lblNombreTipoIdentificacion";
            this.lblNombreTipoIdentificacion.Size = new System.Drawing.Size(80, 23);
            this.lblNombreTipoIdentificacion.TabIndex = 1;
            this.lblNombreTipoIdentificacion.Text = "Nombre";
            //
            // txtNombreTipoIdentificacion
            //
            this.txtNombreTipoIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreTipoIdentificacion.Location = new System.Drawing.Point(14, 60);
            this.txtNombreTipoIdentificacion.Name = "txtNombreTipoIdentificacion";
            this.txtNombreTipoIdentificacion.Size = new System.Drawing.Size(400, 33);
            this.txtNombreTipoIdentificacion.TabIndex = 2;
            //
            // lblEstadoTipoIdentificacionForm
            //
            this.lblEstadoTipoIdentificacionForm.AutoSize = true;
            this.lblEstadoTipoIdentificacionForm.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstadoTipoIdentificacionForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblEstadoTipoIdentificacionForm.Location = new System.Drawing.Point(450, 44);
            this.lblEstadoTipoIdentificacionForm.Name = "lblEstadoTipoIdentificacionForm";
            this.lblEstadoTipoIdentificacionForm.Size = new System.Drawing.Size(61, 23);
            this.lblEstadoTipoIdentificacionForm.TabIndex = 3;
            this.lblEstadoTipoIdentificacionForm.Text = "Estado";
            //
            // cboEstadoTipoIdentificacionForm
            //
            this.cboEstadoTipoIdentificacionForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoTipoIdentificacionForm.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstadoTipoIdentificacionForm.FormattingEnabled = true;
            this.cboEstadoTipoIdentificacionForm.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cboEstadoTipoIdentificacionForm.Location = new System.Drawing.Point(450, 60);
            this.cboEstadoTipoIdentificacionForm.Name = "cboEstadoTipoIdentificacionForm";
            this.cboEstadoTipoIdentificacionForm.Size = new System.Drawing.Size(200, 33);
            this.cboEstadoTipoIdentificacionForm.TabIndex = 4;
            //
            // btnGuardarTipoIdentificacion
            //
            this.btnGuardarTipoIdentificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnGuardarTipoIdentificacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarTipoIdentificacion.FlatAppearance.BorderSize = 0;
            this.btnGuardarTipoIdentificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarTipoIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarTipoIdentificacion.ForeColor = System.Drawing.Color.White;
            this.btnGuardarTipoIdentificacion.Location = new System.Drawing.Point(14, 112);
            this.btnGuardarTipoIdentificacion.Name = "btnGuardarTipoIdentificacion";
            this.btnGuardarTipoIdentificacion.Size = new System.Drawing.Size(130, 34);
            this.btnGuardarTipoIdentificacion.TabIndex = 5;
            this.btnGuardarTipoIdentificacion.Text = "Guardar";
            this.btnGuardarTipoIdentificacion.UseVisualStyleBackColor = false;
            this.btnGuardarTipoIdentificacion.Click += new System.EventHandler(this.btnGuardarTipoIdentificacion_Click);
            //
            // btnCancelarTipoIdentificacion
            //
            this.btnCancelarTipoIdentificacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarTipoIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelarTipoIdentificacion.Location = new System.Drawing.Point(160, 112);
            this.btnCancelarTipoIdentificacion.Name = "btnCancelarTipoIdentificacion";
            this.btnCancelarTipoIdentificacion.Size = new System.Drawing.Size(130, 34);
            this.btnCancelarTipoIdentificacion.TabIndex = 6;
            this.btnCancelarTipoIdentificacion.Text = "Cancelar";
            this.btnCancelarTipoIdentificacion.UseVisualStyleBackColor = true;
            this.btnCancelarTipoIdentificacion.Click += new System.EventHandler(this.btnCancelarTipoIdentificacion_Click);

            //
            // frmCatalogos
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 780);
            this.Controls.Add(this.tabCatalogos);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(850, 650);
            this.Name = "frmCatalogos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VetNova - Catalogos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCatalogos_FormClosing);
            this.Load += new System.EventHandler(this.frmCatalogos_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabCatalogos.ResumeLayout(false);
            this.tabEspecies.ResumeLayout(false);
            this.tabEspecies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecies)).EndInit();
            this.tabRazas.ResumeLayout(false);
            this.tabRazas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRazas)).EndInit();
            this.tabEspecialidades.ResumeLayout(false);
            this.tabEspecialidades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).EndInit();
            this.tabTiposIdentificacion.ResumeLayout(false);
            this.tabTiposIdentificacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiposIdentificacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblInfoUsuario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlHeaderBorde;

        private System.Windows.Forms.TabControl tabCatalogos;

        private System.Windows.Forms.TabPage tabEspecies;
        private System.Windows.Forms.TextBox txtBuscarEspecie;
        private System.Windows.Forms.Button btnNuevaEspecie;
        private System.Windows.Forms.Button btnModificarEspecie;
        private System.Windows.Forms.Button btnEliminarEspecie;
        private System.Windows.Forms.DataGridView dgvEspecies;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEspecie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreEspecie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoEspecie;
        private System.Windows.Forms.Panel pnlFormEspecie;
        private System.Windows.Forms.Label lblFormTituloEspecie;
        private System.Windows.Forms.Label lblNombreEspecie;
        private System.Windows.Forms.TextBox txtNombreEspecie;
        private System.Windows.Forms.Label lblEstadoEspecie;
        private System.Windows.Forms.ComboBox cboEstadoEspecie;
        private System.Windows.Forms.Button btnGuardarEspecie;
        private System.Windows.Forms.Button btnCancelarEspecie;

        private System.Windows.Forms.TabPage tabRazas;
        private System.Windows.Forms.Label lblEspecieRaza;
        private System.Windows.Forms.ComboBox cboEspecieRaza;
        private System.Windows.Forms.TextBox txtBuscarRaza;
        private System.Windows.Forms.Button btnNuevaRaza;
        private System.Windows.Forms.Button btnModificarRaza;
        private System.Windows.Forms.Button btnEliminarRaza;
        private System.Windows.Forms.DataGridView dgvRazas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdRaza;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreRaza;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEspecieRaza;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoRaza;
        private System.Windows.Forms.Panel pnlFormRaza;
        private System.Windows.Forms.Label lblFormTituloRaza;
        private System.Windows.Forms.Label lblNombreRaza;
        private System.Windows.Forms.TextBox txtNombreRaza;
        private System.Windows.Forms.Label lblEstadoRazaForm;
        private System.Windows.Forms.ComboBox cboEstadoRaza;
        private System.Windows.Forms.Button btnGuardarRaza;
        private System.Windows.Forms.Button btnCancelarRaza;

        private System.Windows.Forms.TabPage tabEspecialidades;
        private System.Windows.Forms.TextBox txtBuscarEspecialidad;
        private System.Windows.Forms.Button btnNuevaEspecialidad;
        private System.Windows.Forms.Button btnModificarEspecialidad;
        private System.Windows.Forms.Button btnEliminarEspecialidad;
        private System.Windows.Forms.DataGridView dgvEspecialidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoEspecialidad;
        private System.Windows.Forms.Panel pnlFormEspecialidad;
        private System.Windows.Forms.Label lblFormTituloEspecialidad;
        private System.Windows.Forms.Label lblNombreEspecialidad;
        private System.Windows.Forms.TextBox txtNombreEspecialidad;
        private System.Windows.Forms.Label lblEstadoEspecialidadForm;
        private System.Windows.Forms.ComboBox cboEstadoEspecialidadForm;
        private System.Windows.Forms.Button btnGuardarEspecialidad;
        private System.Windows.Forms.Button btnCancelarEspecialidad;

        private System.Windows.Forms.TabPage tabTiposIdentificacion;
        private System.Windows.Forms.TextBox txtBuscarTipoIdentificacion;
        private System.Windows.Forms.Button btnNuevoTipoIdentificacion;
        private System.Windows.Forms.Button btnModificarTipoIdentificacion;
        private System.Windows.Forms.Button btnEliminarTipoIdentificacion;
        private System.Windows.Forms.DataGridView dgvTiposIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdTipoIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreTipoIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoTipoIdentificacion;
        private System.Windows.Forms.Panel pnlFormTipoIdentificacion;
        private System.Windows.Forms.Label lblFormTituloTipoIdentificacion;
        private System.Windows.Forms.Label lblNombreTipoIdentificacion;
        private System.Windows.Forms.TextBox txtNombreTipoIdentificacion;
        private System.Windows.Forms.Label lblEstadoTipoIdentificacionForm;
        private System.Windows.Forms.ComboBox cboEstadoTipoIdentificacionForm;
        private System.Windows.Forms.Button btnGuardarTipoIdentificacion;
        private System.Windows.Forms.Button btnCancelarTipoIdentificacion;
    }
}