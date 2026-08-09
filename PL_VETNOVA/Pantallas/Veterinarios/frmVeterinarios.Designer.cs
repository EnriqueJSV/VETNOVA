namespace PL_VETNOVA.Pantallas.Veterinarios
{
    partial class frmVeterinarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVeterinarios));
            this.dgvVeterinarios = new System.Windows.Forms.DataGridView();
            this.colId_Veterinario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_Tipo_Identificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId_Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblInfoUsuario = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlHeaderBorde = new System.Windows.Forms.Panel();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.cboTipos_Identificacion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApellido2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellido1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblVeterinario = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cboEspecialidades = new System.Windows.Forms.ComboBox();
            this.lblPropietario = new System.Windows.Forms.Label();
            this.lblFormTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeterinarios)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVeterinarios
            // 
            this.dgvVeterinarios.AllowUserToAddRows = false;
            this.dgvVeterinarios.AllowUserToDeleteRows = false;
            this.dgvVeterinarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvVeterinarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVeterinarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVeterinarios.ColumnHeadersHeight = 34;
            this.dgvVeterinarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVeterinarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId_Veterinario,
            this.colId_Tipo_Identificacion,
            this.colIdentificacion,
            this.colNombre,
            this.colApellido,
            this.colApellido2,
            this.colId_Especialidad,
            this.colTelefono,
            this.colEmail,
            this.colEstado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVeterinarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVeterinarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.dgvVeterinarios.Location = new System.Drawing.Point(30, 169);
            this.dgvVeterinarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvVeterinarios.MultiSelect = false;
            this.dgvVeterinarios.Name = "dgvVeterinarios";
            this.dgvVeterinarios.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVeterinarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVeterinarios.RowHeadersVisible = false;
            this.dgvVeterinarios.RowHeadersWidth = 62;
            this.dgvVeterinarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVeterinarios.Size = new System.Drawing.Size(1155, 354);
            this.dgvVeterinarios.TabIndex = 19;
            // 
            // colId_Veterinario
            // 
            this.colId_Veterinario.DataPropertyName = "Id_Veterinario";
            this.colId_Veterinario.HeaderText = "Id_Veterinario";
            this.colId_Veterinario.MinimumWidth = 8;
            this.colId_Veterinario.Name = "colId_Veterinario";
            this.colId_Veterinario.ReadOnly = true;
            this.colId_Veterinario.Visible = false;
            this.colId_Veterinario.Width = 150;
            // 
            // colId_Tipo_Identificacion
            // 
            this.colId_Tipo_Identificacion.DataPropertyName = "Id_Tipo_Identificacion";
            this.colId_Tipo_Identificacion.HeaderText = "Id_Tipo_Identificacion";
            this.colId_Tipo_Identificacion.MinimumWidth = 8;
            this.colId_Tipo_Identificacion.Name = "colId_Tipo_Identificacion";
            this.colId_Tipo_Identificacion.ReadOnly = true;
            this.colId_Tipo_Identificacion.Visible = false;
            this.colId_Tipo_Identificacion.Width = 150;
            // 
            // colIdentificacion
            // 
            this.colIdentificacion.DataPropertyName = "Identificacion";
            this.colIdentificacion.HeaderText = "Identificación";
            this.colIdentificacion.MinimumWidth = 8;
            this.colIdentificacion.Name = "colIdentificacion";
            this.colIdentificacion.ReadOnly = true;
            this.colIdentificacion.Width = 150;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 8;
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 110;
            // 
            // colApellido
            // 
            this.colApellido.DataPropertyName = "Apellido1";
            this.colApellido.HeaderText = "Apellido";
            this.colApellido.MinimumWidth = 8;
            this.colApellido.Name = "colApellido";
            this.colApellido.ReadOnly = true;
            this.colApellido.Width = 110;
            // 
            // colApellido2
            // 
            this.colApellido2.DataPropertyName = "Apellido2";
            this.colApellido2.HeaderText = "Apellido2";
            this.colApellido2.MinimumWidth = 8;
            this.colApellido2.Name = "colApellido2";
            this.colApellido2.ReadOnly = true;
            this.colApellido2.Visible = false;
            this.colApellido2.Width = 150;
            // 
            // colId_Especialidad
            // 
            this.colId_Especialidad.DataPropertyName = "Id_Especialidad";
            this.colId_Especialidad.HeaderText = "Especialidad";
            this.colId_Especialidad.MinimumWidth = 8;
            this.colId_Especialidad.Name = "colId_Especialidad";
            this.colId_Especialidad.ReadOnly = true;
            this.colId_Especialidad.Width = 150;
            // 
            // colTelefono
            // 
            this.colTelefono.DataPropertyName = "Telefono";
            this.colTelefono.HeaderText = "Teléfono";
            this.colTelefono.MinimumWidth = 8;
            this.colTelefono.Name = "colTelefono";
            this.colTelefono.ReadOnly = true;
            this.colTelefono.Width = 150;
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 8;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 130;
            // 
            // colEstado
            // 
            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 8;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 115;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(1035, 105);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 46);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnModificar.Location = new System.Drawing.Point(840, 105);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(180, 46);
            this.btnModificar.TabIndex = 17;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(660, 105);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(165, 46);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "+ Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(30, 108);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(448, 33);
            this.txtBuscar.TabIndex = 15;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
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
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1245, 77);
            this.pnlHeader.TabIndex = 14;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.Location = new System.Drawing.Point(1080, 15);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(135, 46);
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
            this.lblInfoUsuario.Location = new System.Drawing.Point(600, 25);
            this.lblInfoUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoUsuario.Name = "lblInfoUsuario";
            this.lblInfoUsuario.Size = new System.Drawing.Size(465, 31);
            this.lblInfoUsuario.TabIndex = 1;
            this.lblInfoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(30, 15);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(174, 38);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Veterinarios";
            // 
            // pnlHeaderBorde
            // 
            this.pnlHeaderBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.pnlHeaderBorde.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderBorde.Location = new System.Drawing.Point(0, 75);
            this.pnlHeaderBorde.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeaderBorde.Name = "pnlHeaderBorde";
            this.pnlHeaderBorde.Size = new System.Drawing.Size(1245, 2);
            this.pnlHeaderBorde.TabIndex = 2;
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(225)))), ((int)(((byte)(203)))));
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForm.Controls.Add(this.cboTipos_Identificacion);
            this.pnlForm.Controls.Add(this.label5);
            this.pnlForm.Controls.Add(this.txtTelefono);
            this.pnlForm.Controls.Add(this.label1);
            this.pnlForm.Controls.Add(this.txtApellido2);
            this.pnlForm.Controls.Add(this.label4);
            this.pnlForm.Controls.Add(this.txtApellido1);
            this.pnlForm.Controls.Add(this.label3);
            this.pnlForm.Controls.Add(this.txtIdentificacion);
            this.pnlForm.Controls.Add(this.label2);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.txtNombre);
            this.pnlForm.Controls.Add(this.btnCancelar);
            this.pnlForm.Controls.Add(this.btnGuardar);
            this.pnlForm.Controls.Add(this.cboEstado);
            this.pnlForm.Controls.Add(this.lblEstado);
            this.pnlForm.Controls.Add(this.lblVeterinario);
            this.pnlForm.Controls.Add(this.lblNombre);
            this.pnlForm.Controls.Add(this.cboEspecialidades);
            this.pnlForm.Controls.Add(this.lblPropietario);
            this.pnlForm.Controls.Add(this.lblFormTitulo);
            this.pnlForm.Location = new System.Drawing.Point(30, 554);
            this.pnlForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1154, 522);
            this.pnlForm.TabIndex = 20;
            this.pnlForm.Visible = false;
            // 
            // cboTipos_Identificacion
            // 
            this.cboTipos_Identificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipos_Identificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboTipos_Identificacion.FormattingEnabled = true;
            this.cboTipos_Identificacion.Location = new System.Drawing.Point(21, 86);
            this.cboTipos_Identificacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboTipos_Identificacion.Name = "cboTipos_Identificacion";
            this.cboTipos_Identificacion.Size = new System.Drawing.Size(538, 33);
            this.cboTipos_Identificacion.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.label5.Location = new System.Drawing.Point(21, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 23);
            this.label5.TabIndex = 30;
            this.label5.Text = "Tipo de Identificación";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelefono.Location = new System.Drawing.Point(21, 326);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTelefono.Multiline = true;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(538, 36);
            this.txtTelefono.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.label1.Location = new System.Drawing.Point(21, 298);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Teléfono";
            // 
            // txtApellido2
            // 
            this.txtApellido2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtApellido2.Location = new System.Drawing.Point(21, 248);
            this.txtApellido2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtApellido2.Multiline = true;
            this.txtApellido2.Name = "txtApellido2";
            this.txtApellido2.Size = new System.Drawing.Size(538, 36);
            this.txtApellido2.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.label4.Location = new System.Drawing.Point(22, 220);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 26;
            this.label4.Text = "Apellido 2";
            // 
            // txtApellido1
            // 
            this.txtApellido1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtApellido1.Location = new System.Drawing.Point(594, 163);
            this.txtApellido1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtApellido1.Multiline = true;
            this.txtApellido1.Name = "txtApellido1";
            this.txtApellido1.Size = new System.Drawing.Size(538, 36);
            this.txtApellido1.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.label3.Location = new System.Drawing.Point(596, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "Apellido 1";
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtIdentificacion.Location = new System.Drawing.Point(594, 86);
            this.txtIdentificacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIdentificacion.Multiline = true;
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(538, 36);
            this.txtIdentificacion.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.label2.Location = new System.Drawing.Point(594, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "Identificación";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.Location = new System.Drawing.Point(594, 326);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(538, 36);
            this.txtEmail.TabIndex = 21;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombre.Location = new System.Drawing.Point(21, 163);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombre.Multiline = true;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(538, 36);
            this.txtNombre.TabIndex = 19;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.Location = new System.Drawing.Point(240, 437);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(195, 52);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(21, 437);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(195, 52);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cboEstado.Location = new System.Drawing.Point(594, 409);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(538, 33);
            this.cboEstado.TabIndex = 8;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblEstado.Location = new System.Drawing.Point(590, 382);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(61, 23);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Estado";
            // 
            // lblVeterinario
            // 
            this.lblVeterinario.AutoSize = true;
            this.lblVeterinario.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblVeterinario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblVeterinario.Location = new System.Drawing.Point(594, 302);
            this.lblVeterinario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVeterinario.Name = "lblVeterinario";
            this.lblVeterinario.Size = new System.Drawing.Size(51, 23);
            this.lblVeterinario.TabIndex = 5;
            this.lblVeterinario.Text = "Email";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblNombre.Location = new System.Drawing.Point(21, 135);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(73, 23);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
            // 
            // cboEspecialidades
            // 
            this.cboEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEspecialidades.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEspecialidades.FormattingEnabled = true;
            this.cboEspecialidades.Location = new System.Drawing.Point(594, 248);
            this.cboEspecialidades.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboEspecialidades.Name = "cboEspecialidades";
            this.cboEspecialidades.Size = new System.Drawing.Size(538, 33);
            this.cboEspecialidades.TabIndex = 2;
            // 
            // lblPropietario
            // 
            this.lblPropietario.AutoSize = true;
            this.lblPropietario.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPropietario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblPropietario.Location = new System.Drawing.Point(594, 223);
            this.lblPropietario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPropietario.Name = "lblPropietario";
            this.lblPropietario.Size = new System.Drawing.Size(103, 23);
            this.lblPropietario.TabIndex = 1;
            this.lblPropietario.Text = "Especialidad";
            // 
            // lblFormTitulo
            // 
            this.lblFormTitulo.AutoSize = true;
            this.lblFormTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormTitulo.Location = new System.Drawing.Point(21, 15);
            this.lblFormTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormTitulo.Name = "lblFormTitulo";
            this.lblFormTitulo.Size = new System.Drawing.Size(185, 28);
            this.lblFormTitulo.TabIndex = 0;
            this.lblFormTitulo.Text = "Nuevo Veterinario";
            // 
            // frmVeterinarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1245, 1108);
            this.Controls.Add(this.dgvVeterinarios);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmVeterinarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VetNova - Veterinarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVeterinarios_FormClosing);
            this.Load += new System.EventHandler(this.frmVeterinarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeterinarios)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVeterinarios;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblInfoUsuario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlHeaderBorde;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblVeterinario;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cboEspecialidades;
        private System.Windows.Forms.Label lblPropietario;
        private System.Windows.Forms.Label lblFormTitulo;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellido2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellido1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipos_Identificacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_Veterinario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_Tipo_Identificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId_Especialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}