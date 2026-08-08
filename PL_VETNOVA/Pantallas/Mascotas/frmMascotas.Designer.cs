namespace PL_VETNOVA.Pantallas.Mascotas
{
    partial class frmMascotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMascotas));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblInfoUsuario = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlHeaderBorde = new System.Windows.Forms.Panel();
            this.txtBuscarMascota = new System.Windows.Forms.TextBox();
            this.btnNuevaMascota = new System.Windows.Forms.Button();
            this.btnModificarMascota = new System.Windows.Forms.Button();
            this.btnEliminarMascota = new System.Windows.Forms.Button();
            this.dgvMascotas = new System.Windows.Forms.DataGridView();
            this.colIdMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPropietarioMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRazaMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSexoMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaNacimientoMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPesoMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColorMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstadoMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFormMascota = new System.Windows.Forms.Panel();
            this.btnCancelarMascota = new System.Windows.Forms.Button();
            this.btnGuardarMascota = new System.Windows.Forms.Button();
            this.lblColorMascota = new System.Windows.Forms.Label();
            this.txtColorMascota = new System.Windows.Forms.TextBox();
            this.lblPesoMascota = new System.Windows.Forms.Label();
            this.nudPesoMascota = new System.Windows.Forms.NumericUpDown();
            this.lblEstadoMascotaForm = new System.Windows.Forms.Label();
            this.cboEstadoMascota = new System.Windows.Forms.ComboBox();
            this.lblFechaNacimientoMascotaForm = new System.Windows.Forms.Label();
            this.dtpFechaNacimientoMascota = new System.Windows.Forms.DateTimePicker();
            this.lblSexoMascota = new System.Windows.Forms.Label();
            this.cboSexoMascota = new System.Windows.Forms.ComboBox();
            this.lblNombreMascota = new System.Windows.Forms.Label();
            this.txtNombreMascota = new System.Windows.Forms.TextBox();
            this.lblRazaMascota = new System.Windows.Forms.Label();
            this.cboRazaMascota = new System.Windows.Forms.ComboBox();
            this.lblEspecieMascota = new System.Windows.Forms.Label();
            this.cboEspecieMascota = new System.Windows.Forms.ComboBox();
            this.lblPropietarioMascota = new System.Windows.Forms.Label();
            this.cboPropietarioMascota = new System.Windows.Forms.ComboBox();
            this.lblFormTituloMascota = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).BeginInit();
            this.pnlFormMascota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoMascota)).BeginInit();
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
            this.lblTitulo.Size = new System.Drawing.Size(139, 38);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mascotas";
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
            // txtBuscarMascota
            // 
            this.txtBuscarMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscarMascota.Location = new System.Drawing.Point(20, 70);
            this.txtBuscarMascota.Name = "txtBuscarMascota";
            this.txtBuscarMascota.Size = new System.Drawing.Size(400, 33);
            this.txtBuscarMascota.TabIndex = 1;
            this.txtBuscarMascota.TextChanged += new System.EventHandler(this.txtBuscarMascota_TextChanged);
            // 
            // btnNuevaMascota
            // 
            this.btnNuevaMascota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnNuevaMascota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaMascota.FlatAppearance.BorderSize = 0;
            this.btnNuevaMascota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevaMascota.ForeColor = System.Drawing.Color.White;
            this.btnNuevaMascota.Location = new System.Drawing.Point(560, 68);
            this.btnNuevaMascota.Name = "btnNuevaMascota";
            this.btnNuevaMascota.Size = new System.Drawing.Size(110, 30);
            this.btnNuevaMascota.TabIndex = 2;
            this.btnNuevaMascota.Text = "+ Nueva";
            this.btnNuevaMascota.UseVisualStyleBackColor = false;
            this.btnNuevaMascota.Click += new System.EventHandler(this.btnNuevaMascota_Click);
            // 
            // btnModificarMascota
            // 
            this.btnModificarMascota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnModificarMascota.Location = new System.Drawing.Point(680, 68);
            this.btnModificarMascota.Name = "btnModificarMascota";
            this.btnModificarMascota.Size = new System.Drawing.Size(120, 30);
            this.btnModificarMascota.TabIndex = 3;
            this.btnModificarMascota.Text = "Modificar";
            this.btnModificarMascota.UseVisualStyleBackColor = true;
            this.btnModificarMascota.Click += new System.EventHandler(this.btnModificarMascota_Click);
            // 
            // btnEliminarMascota
            // 
            this.btnEliminarMascota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnEliminarMascota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarMascota.FlatAppearance.BorderSize = 0;
            this.btnEliminarMascota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminarMascota.ForeColor = System.Drawing.Color.White;
            this.btnEliminarMascota.Location = new System.Drawing.Point(810, 68);
            this.btnEliminarMascota.Name = "btnEliminarMascota";
            this.btnEliminarMascota.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarMascota.TabIndex = 4;
            this.btnEliminarMascota.Text = "Eliminar";
            this.btnEliminarMascota.UseVisualStyleBackColor = false;
            this.btnEliminarMascota.Click += new System.EventHandler(this.btnEliminarMascota_Click);
            // 
            // dgvMascotas
            // 
            this.dgvMascotas.AllowUserToAddRows = false;
            this.dgvMascotas.AllowUserToDeleteRows = false;
            this.dgvMascotas.BackgroundColor = System.Drawing.Color.White;
            this.dgvMascotas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMascotas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMascotas.ColumnHeadersHeight = 34;
            this.dgvMascotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMascotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdMascota,
            this.colNombreMascota,
            this.colPropietarioMascota,
            this.colRazaMascota,
            this.colSexoMascota,
            this.colFechaNacimientoMascota,
            this.colPesoMascota,
            this.colColorMascota,
            this.colEstadoMascota});
            this.dgvMascotas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.dgvMascotas.Location = new System.Drawing.Point(20, 110);
            this.dgvMascotas.MultiSelect = false;
            this.dgvMascotas.Name = "dgvMascotas";
            this.dgvMascotas.ReadOnly = true;
            this.dgvMascotas.RowHeadersVisible = false;
            this.dgvMascotas.RowHeadersWidth = 62;
            this.dgvMascotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMascotas.Size = new System.Drawing.Size(910, 260);
            this.dgvMascotas.TabIndex = 5;
            // 
            // colIdMascota
            // 
            this.colIdMascota.DataPropertyName = "Id_Mascota";
            this.colIdMascota.HeaderText = "Id";
            this.colIdMascota.MinimumWidth = 8;
            this.colIdMascota.Name = "colIdMascota";
            this.colIdMascota.ReadOnly = true;
            this.colIdMascota.Width = 60;
            // 
            // colNombreMascota
            // 
            this.colNombreMascota.DataPropertyName = "Nombre";
            this.colNombreMascota.HeaderText = "Nombre";
            this.colNombreMascota.MinimumWidth = 8;
            this.colNombreMascota.Name = "colNombreMascota";
            this.colNombreMascota.ReadOnly = true;
            this.colNombreMascota.Width = 120;
            // 
            // colPropietarioMascota
            // 
            this.colPropietarioMascota.DataPropertyName = "PropietarioNombre";
            this.colPropietarioMascota.HeaderText = "Propietario";
            this.colPropietarioMascota.MinimumWidth = 8;
            this.colPropietarioMascota.Name = "colPropietarioMascota";
            this.colPropietarioMascota.ReadOnly = true;
            this.colPropietarioMascota.Width = 150;
            // 
            // colRazaMascota
            // 
            this.colRazaMascota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRazaMascota.DataPropertyName = "RazaNombre";
            this.colRazaMascota.HeaderText = "Raza";
            this.colRazaMascota.MinimumWidth = 8;
            this.colRazaMascota.Name = "colRazaMascota";
            this.colRazaMascota.ReadOnly = true;
            // 
            // colSexoMascota
            // 
            this.colSexoMascota.DataPropertyName = "Sexo";
            this.colSexoMascota.HeaderText = "Sexo";
            this.colSexoMascota.MinimumWidth = 8;
            this.colSexoMascota.Name = "colSexoMascota";
            this.colSexoMascota.ReadOnly = true;
            this.colSexoMascota.Width = 80;
            // 
            // colFechaNacimientoMascota
            // 
            this.colFechaNacimientoMascota.DataPropertyName = "Fecha_Nacimiento";
            this.colFechaNacimientoMascota.HeaderText = "Nacimiento";
            this.colFechaNacimientoMascota.MinimumWidth = 8;
            this.colFechaNacimientoMascota.Name = "colFechaNacimientoMascota";
            this.colFechaNacimientoMascota.ReadOnly = true;
            // 
            // colPesoMascota
            // 
            this.colPesoMascota.DataPropertyName = "Peso";
            this.colPesoMascota.HeaderText = "Peso (kg)";
            this.colPesoMascota.MinimumWidth = 8;
            this.colPesoMascota.Name = "colPesoMascota";
            this.colPesoMascota.ReadOnly = true;
            this.colPesoMascota.Width = 80;
            // 
            // colColorMascota
            // 
            this.colColorMascota.DataPropertyName = "Color";
            this.colColorMascota.HeaderText = "Color";
            this.colColorMascota.MinimumWidth = 8;
            this.colColorMascota.Name = "colColorMascota";
            this.colColorMascota.ReadOnly = true;
            this.colColorMascota.Width = 90;
            // 
            // colEstadoMascota
            // 
            this.colEstadoMascota.DataPropertyName = "Estado";
            this.colEstadoMascota.HeaderText = "Estado";
            this.colEstadoMascota.MinimumWidth = 8;
            this.colEstadoMascota.Name = "colEstadoMascota";
            this.colEstadoMascota.ReadOnly = true;
            this.colEstadoMascota.Width = 80;
            // 
            // pnlFormMascota
            // 
            this.pnlFormMascota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.pnlFormMascota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormMascota.Controls.Add(this.btnCancelarMascota);
            this.pnlFormMascota.Controls.Add(this.btnGuardarMascota);
            this.pnlFormMascota.Controls.Add(this.lblColorMascota);
            this.pnlFormMascota.Controls.Add(this.txtColorMascota);
            this.pnlFormMascota.Controls.Add(this.lblPesoMascota);
            this.pnlFormMascota.Controls.Add(this.nudPesoMascota);
            this.pnlFormMascota.Controls.Add(this.lblEstadoMascotaForm);
            this.pnlFormMascota.Controls.Add(this.cboEstadoMascota);
            this.pnlFormMascota.Controls.Add(this.lblFechaNacimientoMascotaForm);
            this.pnlFormMascota.Controls.Add(this.dtpFechaNacimientoMascota);
            this.pnlFormMascota.Controls.Add(this.lblSexoMascota);
            this.pnlFormMascota.Controls.Add(this.cboSexoMascota);
            this.pnlFormMascota.Controls.Add(this.lblNombreMascota);
            this.pnlFormMascota.Controls.Add(this.txtNombreMascota);
            this.pnlFormMascota.Controls.Add(this.lblRazaMascota);
            this.pnlFormMascota.Controls.Add(this.cboRazaMascota);
            this.pnlFormMascota.Controls.Add(this.lblEspecieMascota);
            this.pnlFormMascota.Controls.Add(this.cboEspecieMascota);
            this.pnlFormMascota.Controls.Add(this.lblPropietarioMascota);
            this.pnlFormMascota.Controls.Add(this.cboPropietarioMascota);
            this.pnlFormMascota.Controls.Add(this.lblFormTituloMascota);
            this.pnlFormMascota.Location = new System.Drawing.Point(20, 390);
            this.pnlFormMascota.Name = "pnlFormMascota";
            this.pnlFormMascota.Size = new System.Drawing.Size(910, 360);
            this.pnlFormMascota.TabIndex = 6;
            this.pnlFormMascota.Visible = false;
            // 
            // btnCancelarMascota
            // 
            this.btnCancelarMascota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelarMascota.Location = new System.Drawing.Point(160, 300);
            this.btnCancelarMascota.Name = "btnCancelarMascota";
            this.btnCancelarMascota.Size = new System.Drawing.Size(130, 34);
            this.btnCancelarMascota.TabIndex = 20;
            this.btnCancelarMascota.Text = "Cancelar";
            this.btnCancelarMascota.UseVisualStyleBackColor = true;
            this.btnCancelarMascota.Click += new System.EventHandler(this.btnCancelarMascota_Click);
            // 
            // btnGuardarMascota
            // 
            this.btnGuardarMascota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnGuardarMascota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarMascota.FlatAppearance.BorderSize = 0;
            this.btnGuardarMascota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarMascota.ForeColor = System.Drawing.Color.White;
            this.btnGuardarMascota.Location = new System.Drawing.Point(14, 300);
            this.btnGuardarMascota.Name = "btnGuardarMascota";
            this.btnGuardarMascota.Size = new System.Drawing.Size(130, 34);
            this.btnGuardarMascota.TabIndex = 19;
            this.btnGuardarMascota.Text = "Guardar";
            this.btnGuardarMascota.UseVisualStyleBackColor = false;
            this.btnGuardarMascota.Click += new System.EventHandler(this.btnGuardarMascota_Click);
            // 
            // lblColorMascota
            // 
            this.lblColorMascota.AutoSize = true;
            this.lblColorMascota.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblColorMascota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblColorMascota.Location = new System.Drawing.Point(450, 212);
            this.lblColorMascota.Name = "lblColorMascota";
            this.lblColorMascota.Size = new System.Drawing.Size(51, 23);
            this.lblColorMascota.TabIndex = 17;
            this.lblColorMascota.Text = "Color";
            // 
            // txtColorMascota
            // 
            this.txtColorMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtColorMascota.Location = new System.Drawing.Point(450, 228);
            this.txtColorMascota.Name = "txtColorMascota";
            this.txtColorMascota.Size = new System.Drawing.Size(420, 33);
            this.txtColorMascota.TabIndex = 18;
            // 
            // lblPesoMascota
            // 
            this.lblPesoMascota.AutoSize = true;
            this.lblPesoMascota.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPesoMascota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblPesoMascota.Location = new System.Drawing.Point(14, 212);
            this.lblPesoMascota.Name = "lblPesoMascota";
            this.lblPesoMascota.Size = new System.Drawing.Size(78, 23);
            this.lblPesoMascota.TabIndex = 15;
            this.lblPesoMascota.Text = "Peso (kg)";
            // 
            // nudPesoMascota
            // 
            this.nudPesoMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudPesoMascota.Location = new System.Drawing.Point(14, 228);
            this.nudPesoMascota.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudPesoMascota.Name = "nudPesoMascota";
            this.nudPesoMascota.Size = new System.Drawing.Size(420, 33);
            this.nudPesoMascota.TabIndex = 16;
            // 
            // lblEstadoMascotaForm
            // 
            this.lblEstadoMascotaForm.AutoSize = true;
            this.lblEstadoMascotaForm.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstadoMascotaForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblEstadoMascotaForm.Location = new System.Drawing.Point(606, 156);
            this.lblEstadoMascotaForm.Name = "lblEstadoMascotaForm";
            this.lblEstadoMascotaForm.Size = new System.Drawing.Size(61, 23);
            this.lblEstadoMascotaForm.TabIndex = 13;
            this.lblEstadoMascotaForm.Text = "Estado";
            // 
            // cboEstadoMascota
            // 
            this.cboEstadoMascota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstadoMascota.FormattingEnabled = true;
            this.cboEstadoMascota.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cboEstadoMascota.Location = new System.Drawing.Point(606, 172);
            this.cboEstadoMascota.Name = "cboEstadoMascota";
            this.cboEstadoMascota.Size = new System.Drawing.Size(264, 33);
            this.cboEstadoMascota.TabIndex = 14;
            // 
            // lblFechaNacimientoMascotaForm
            // 
            this.lblFechaNacimientoMascotaForm.AutoSize = true;
            this.lblFechaNacimientoMascotaForm.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFechaNacimientoMascotaForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblFechaNacimientoMascotaForm.Location = new System.Drawing.Point(310, 156);
            this.lblFechaNacimientoMascotaForm.Name = "lblFechaNacimientoMascotaForm";
            this.lblFechaNacimientoMascotaForm.Size = new System.Drawing.Size(144, 23);
            this.lblFechaNacimientoMascotaForm.TabIndex = 11;
            this.lblFechaNacimientoMascotaForm.Text = "Fecha nacimiento";
            // 
            // dtpFechaNacimientoMascota
            // 
            this.dtpFechaNacimientoMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaNacimientoMascota.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimientoMascota.Location = new System.Drawing.Point(310, 172);
            this.dtpFechaNacimientoMascota.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpFechaNacimientoMascota.Name = "dtpFechaNacimientoMascota";
            this.dtpFechaNacimientoMascota.Size = new System.Drawing.Size(270, 33);
            this.dtpFechaNacimientoMascota.TabIndex = 12;
            // 
            // lblSexoMascota
            // 
            this.lblSexoMascota.AutoSize = true;
            this.lblSexoMascota.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSexoMascota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblSexoMascota.Location = new System.Drawing.Point(14, 156);
            this.lblSexoMascota.Name = "lblSexoMascota";
            this.lblSexoMascota.Size = new System.Drawing.Size(46, 23);
            this.lblSexoMascota.TabIndex = 9;
            this.lblSexoMascota.Text = "Sexo";
            // 
            // cboSexoMascota
            // 
            this.cboSexoMascota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSexoMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboSexoMascota.FormattingEnabled = true;
            this.cboSexoMascota.Items.AddRange(new object[] {
            "Macho",
            "Hembra"});
            this.cboSexoMascota.Location = new System.Drawing.Point(14, 172);
            this.cboSexoMascota.Name = "cboSexoMascota";
            this.cboSexoMascota.Size = new System.Drawing.Size(270, 33);
            this.cboSexoMascota.TabIndex = 10;
            // 
            // lblNombreMascota
            // 
            this.lblNombreMascota.AutoSize = true;
            this.lblNombreMascota.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNombreMascota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblNombreMascota.Location = new System.Drawing.Point(450, 100);
            this.lblNombreMascota.Name = "lblNombreMascota";
            this.lblNombreMascota.Size = new System.Drawing.Size(73, 23);
            this.lblNombreMascota.TabIndex = 7;
            this.lblNombreMascota.Text = "Nombre";
            // 
            // txtNombreMascota
            // 
            this.txtNombreMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreMascota.Location = new System.Drawing.Point(450, 116);
            this.txtNombreMascota.Name = "txtNombreMascota";
            this.txtNombreMascota.Size = new System.Drawing.Size(420, 33);
            this.txtNombreMascota.TabIndex = 8;
            // 
            // lblRazaMascota
            // 
            this.lblRazaMascota.AutoSize = true;
            this.lblRazaMascota.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRazaMascota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblRazaMascota.Location = new System.Drawing.Point(14, 100);
            this.lblRazaMascota.Name = "lblRazaMascota";
            this.lblRazaMascota.Size = new System.Drawing.Size(46, 23);
            this.lblRazaMascota.TabIndex = 5;
            this.lblRazaMascota.Text = "Raza";
            // 
            // cboRazaMascota
            // 
            this.cboRazaMascota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRazaMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboRazaMascota.FormattingEnabled = true;
            this.cboRazaMascota.Location = new System.Drawing.Point(14, 116);
            this.cboRazaMascota.Name = "cboRazaMascota";
            this.cboRazaMascota.Size = new System.Drawing.Size(420, 33);
            this.cboRazaMascota.TabIndex = 6;
            // 
            // lblEspecieMascota
            // 
            this.lblEspecieMascota.AutoSize = true;
            this.lblEspecieMascota.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEspecieMascota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblEspecieMascota.Location = new System.Drawing.Point(450, 44);
            this.lblEspecieMascota.Name = "lblEspecieMascota";
            this.lblEspecieMascota.Size = new System.Drawing.Size(66, 23);
            this.lblEspecieMascota.TabIndex = 3;
            this.lblEspecieMascota.Text = "Especie";
            // 
            // cboEspecieMascota
            // 
            this.cboEspecieMascota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEspecieMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEspecieMascota.FormattingEnabled = true;
            this.cboEspecieMascota.Location = new System.Drawing.Point(450, 60);
            this.cboEspecieMascota.Name = "cboEspecieMascota";
            this.cboEspecieMascota.Size = new System.Drawing.Size(420, 33);
            this.cboEspecieMascota.TabIndex = 4;
            this.cboEspecieMascota.SelectedIndexChanged += new System.EventHandler(this.cboEspecieMascota_SelectedIndexChanged);
            // 
            // lblPropietarioMascota
            // 
            this.lblPropietarioMascota.AutoSize = true;
            this.lblPropietarioMascota.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPropietarioMascota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblPropietarioMascota.Location = new System.Drawing.Point(14, 44);
            this.lblPropietarioMascota.Name = "lblPropietarioMascota";
            this.lblPropietarioMascota.Size = new System.Drawing.Size(94, 23);
            this.lblPropietarioMascota.TabIndex = 1;
            this.lblPropietarioMascota.Text = "Propietario";
            // 
            // cboPropietarioMascota
            // 
            this.cboPropietarioMascota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPropietarioMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboPropietarioMascota.FormattingEnabled = true;
            this.cboPropietarioMascota.Location = new System.Drawing.Point(14, 60);
            this.cboPropietarioMascota.Name = "cboPropietarioMascota";
            this.cboPropietarioMascota.Size = new System.Drawing.Size(420, 33);
            this.cboPropietarioMascota.TabIndex = 2;
            // 
            // lblFormTituloMascota
            // 
            this.lblFormTituloMascota.AutoSize = true;
            this.lblFormTituloMascota.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormTituloMascota.Location = new System.Drawing.Point(14, 10);
            this.lblFormTituloMascota.Name = "lblFormTituloMascota";
            this.lblFormTituloMascota.Size = new System.Drawing.Size(158, 28);
            this.lblFormTituloMascota.TabIndex = 0;
            this.lblFormTituloMascota.Text = "Nueva mascota";
            // 
            // frmMascotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 780);
            this.Controls.Add(this.pnlFormMascota);
            this.Controls.Add(this.dgvMascotas);
            this.Controls.Add(this.btnEliminarMascota);
            this.Controls.Add(this.btnModificarMascota);
            this.Controls.Add(this.btnNuevaMascota);
            this.Controls.Add(this.txtBuscarMascota);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 650);
            this.Name = "frmMascotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VetNova - Mascotas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMascotas_FormClosing);
            this.Load += new System.EventHandler(this.frmMascotas_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).EndInit();
            this.pnlFormMascota.ResumeLayout(false);
            this.pnlFormMascota.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoMascota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblInfoUsuario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlHeaderBorde;

        private System.Windows.Forms.TextBox txtBuscarMascota;
        private System.Windows.Forms.Button btnNuevaMascota;
        private System.Windows.Forms.Button btnModificarMascota;
        private System.Windows.Forms.Button btnEliminarMascota;

        private System.Windows.Forms.DataGridView dgvMascotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPropietarioMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRazaMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSexoMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaNacimientoMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPesoMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColorMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstadoMascota;

        private System.Windows.Forms.Panel pnlFormMascota;
        private System.Windows.Forms.Label lblFormTituloMascota;
        private System.Windows.Forms.Label lblPropietarioMascota;
        private System.Windows.Forms.ComboBox cboPropietarioMascota;
        private System.Windows.Forms.Label lblEspecieMascota;
        private System.Windows.Forms.ComboBox cboEspecieMascota;
        private System.Windows.Forms.Label lblRazaMascota;
        private System.Windows.Forms.ComboBox cboRazaMascota;
        private System.Windows.Forms.Label lblNombreMascota;
        private System.Windows.Forms.TextBox txtNombreMascota;
        private System.Windows.Forms.Label lblSexoMascota;
        private System.Windows.Forms.ComboBox cboSexoMascota;
        private System.Windows.Forms.Label lblFechaNacimientoMascotaForm;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimientoMascota;
        private System.Windows.Forms.Label lblEstadoMascotaForm;
        private System.Windows.Forms.ComboBox cboEstadoMascota;
        private System.Windows.Forms.Label lblPesoMascota;
        private System.Windows.Forms.NumericUpDown nudPesoMascota;
        private System.Windows.Forms.Label lblColorMascota;
        private System.Windows.Forms.TextBox txtColorMascota;
        private System.Windows.Forms.Button btnGuardarMascota;
        private System.Windows.Forms.Button btnCancelarMascota;
    }
}