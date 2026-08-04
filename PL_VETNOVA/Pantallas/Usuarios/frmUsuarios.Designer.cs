namespace PL_VETNOVA.Pantallas.Usuarios
{
    partial class frmUsuarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevaCita = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblInfoUsuario = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlHeaderBorde = new System.Windows.Forms.Panel();
            this.pnlFormCita = new System.Windows.Forms.Panel();
            this.btnCancelarCita = new System.Windows.Forms.Button();
            this.btnGuardarCita = new System.Windows.Forms.Button();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboVeterinario = new System.Windows.Forms.ComboBox();
            this.lblVeterinario = new System.Windows.Forms.Label();
            this.cboMascota = new System.Windows.Forms.ComboBox();
            this.lblMascota = new System.Windows.Forms.Label();
            this.cboPropietario = new System.Windows.Forms.ComboBox();
            this.lblPropietario = new System.Windows.Forms.Label();
            this.lblFormTitulo = new System.Windows.Forms.Label();
            this.colIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContrasena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlFormCita.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCitas
            // 
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.AllowUserToDeleteRows = false;
            this.dgvCitas.BackgroundColor = System.Drawing.Color.White;
            this.dgvCitas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCitas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdUsuario,
            this.colIdRol,
            this.colRol,
            this.colNombreUsuario,
            this.colEmail,
            this.colContrasena,
            this.colEstado});
            this.dgvCitas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.dgvCitas.Location = new System.Drawing.Point(20, 110);
            this.dgvCitas.MultiSelect = false;
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersVisible = false;
            this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.Size = new System.Drawing.Size(770, 230);
            this.dgvCitas.TabIndex = 12;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(690, 68);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnModificar.Location = new System.Drawing.Point(560, 68);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(120, 30);
            this.btnModificar.TabIndex = 10;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnNuevaCita
            // 
            this.btnNuevaCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnNuevaCita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaCita.FlatAppearance.BorderSize = 0;
            this.btnNuevaCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaCita.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevaCita.ForeColor = System.Drawing.Color.White;
            this.btnNuevaCita.Location = new System.Drawing.Point(440, 68);
            this.btnNuevaCita.Name = "btnNuevaCita";
            this.btnNuevaCita.Size = new System.Drawing.Size(110, 30);
            this.btnNuevaCita.TabIndex = 9;
            this.btnNuevaCita.Text = "+ Nuevo";
            this.btnNuevaCita.UseVisualStyleBackColor = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(20, 70);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(300, 24);
            this.txtBuscar.TabIndex = 8;
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
            this.pnlHeader.Size = new System.Drawing.Size(830, 50);
            this.pnlHeader.TabIndex = 7;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.Location = new System.Drawing.Point(720, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(90, 30);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // lblInfoUsuario
            // 
            this.lblInfoUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfoUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfoUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblInfoUsuario.Location = new System.Drawing.Point(400, 16);
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
            this.lblTitulo.Size = new System.Drawing.Size(89, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Usuarios";
            // 
            // pnlHeaderBorde
            // 
            this.pnlHeaderBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.pnlHeaderBorde.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderBorde.Location = new System.Drawing.Point(0, 49);
            this.pnlHeaderBorde.Name = "pnlHeaderBorde";
            this.pnlHeaderBorde.Size = new System.Drawing.Size(830, 1);
            this.pnlHeaderBorde.TabIndex = 2;
            // 
            // pnlFormCita
            // 
            this.pnlFormCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.pnlFormCita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormCita.Controls.Add(this.btnCancelarCita);
            this.pnlFormCita.Controls.Add(this.btnGuardarCita);
            this.pnlFormCita.Controls.Add(this.txtMotivo);
            this.pnlFormCita.Controls.Add(this.lblMotivo);
            this.pnlFormCita.Controls.Add(this.dtpHora);
            this.pnlFormCita.Controls.Add(this.lblHora);
            this.pnlFormCita.Controls.Add(this.dtpFecha);
            this.pnlFormCita.Controls.Add(this.lblFecha);
            this.pnlFormCita.Controls.Add(this.cboEstado);
            this.pnlFormCita.Controls.Add(this.lblEstado);
            this.pnlFormCita.Controls.Add(this.cboVeterinario);
            this.pnlFormCita.Controls.Add(this.lblVeterinario);
            this.pnlFormCita.Controls.Add(this.cboMascota);
            this.pnlFormCita.Controls.Add(this.lblMascota);
            this.pnlFormCita.Controls.Add(this.cboPropietario);
            this.pnlFormCita.Controls.Add(this.lblPropietario);
            this.pnlFormCita.Controls.Add(this.lblFormTitulo);
            this.pnlFormCita.Location = new System.Drawing.Point(20, 360);
            this.pnlFormCita.Name = "pnlFormCita";
            this.pnlFormCita.Size = new System.Drawing.Size(770, 340);
            this.pnlFormCita.TabIndex = 13;
            this.pnlFormCita.Visible = false;
            // 
            // btnCancelarCita
            // 
            this.btnCancelarCita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarCita.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelarCita.Location = new System.Drawing.Point(160, 284);
            this.btnCancelarCita.Name = "btnCancelarCita";
            this.btnCancelarCita.Size = new System.Drawing.Size(130, 34);
            this.btnCancelarCita.TabIndex = 16;
            this.btnCancelarCita.Text = "Cancelar";
            this.btnCancelarCita.UseVisualStyleBackColor = true;
            // 
            // btnGuardarCita
            // 
            this.btnGuardarCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnGuardarCita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarCita.FlatAppearance.BorderSize = 0;
            this.btnGuardarCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCita.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarCita.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCita.Location = new System.Drawing.Point(14, 284);
            this.btnGuardarCita.Name = "btnGuardarCita";
            this.btnGuardarCita.Size = new System.Drawing.Size(130, 34);
            this.btnGuardarCita.TabIndex = 15;
            this.btnGuardarCita.Text = "Guardar";
            this.btnGuardarCita.UseVisualStyleBackColor = false;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMotivo.Location = new System.Drawing.Point(14, 228);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(736, 44);
            this.txtMotivo.TabIndex = 14;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblMotivo.Location = new System.Drawing.Point(14, 212);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(45, 15);
            this.lblMotivo.TabIndex = 13;
            this.lblMotivo.Text = "Motivo";
            // 
            // dtpHora
            // 
            this.dtpHora.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(200, 172);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(170, 24);
            this.dtpHora.TabIndex = 12;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblHora.Location = new System.Drawing.Point(200, 156);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(33, 15);
            this.lblHora.TabIndex = 11;
            this.lblHora.Text = "Hora";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(14, 172);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(170, 24);
            this.dtpFecha.TabIndex = 10;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblFecha.Location = new System.Drawing.Point(14, 156);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(38, 15);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Fecha";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(390, 116);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(360, 25);
            this.cboEstado.TabIndex = 8;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblEstado.Location = new System.Drawing.Point(390, 100);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(42, 15);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Estado";
            // 
            // cboVeterinario
            // 
            this.cboVeterinario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVeterinario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboVeterinario.FormattingEnabled = true;
            this.cboVeterinario.Location = new System.Drawing.Point(14, 116);
            this.cboVeterinario.Name = "cboVeterinario";
            this.cboVeterinario.Size = new System.Drawing.Size(360, 25);
            this.cboVeterinario.TabIndex = 6;
            // 
            // lblVeterinario
            // 
            this.lblVeterinario.AutoSize = true;
            this.lblVeterinario.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblVeterinario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblVeterinario.Location = new System.Drawing.Point(14, 100);
            this.lblVeterinario.Name = "lblVeterinario";
            this.lblVeterinario.Size = new System.Drawing.Size(63, 15);
            this.lblVeterinario.TabIndex = 5;
            this.lblVeterinario.Text = "Veterinario";
            // 
            // cboMascota
            // 
            this.cboMascota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboMascota.FormattingEnabled = true;
            this.cboMascota.Location = new System.Drawing.Point(390, 60);
            this.cboMascota.Name = "cboMascota";
            this.cboMascota.Size = new System.Drawing.Size(360, 25);
            this.cboMascota.TabIndex = 4;
            // 
            // lblMascota
            // 
            this.lblMascota.AutoSize = true;
            this.lblMascota.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMascota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblMascota.Location = new System.Drawing.Point(390, 44);
            this.lblMascota.Name = "lblMascota";
            this.lblMascota.Size = new System.Drawing.Size(52, 15);
            this.lblMascota.TabIndex = 3;
            this.lblMascota.Text = "Mascota";
            // 
            // cboPropietario
            // 
            this.cboPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPropietario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboPropietario.FormattingEnabled = true;
            this.cboPropietario.Location = new System.Drawing.Point(14, 60);
            this.cboPropietario.Name = "cboPropietario";
            this.cboPropietario.Size = new System.Drawing.Size(360, 25);
            this.cboPropietario.TabIndex = 2;
            // 
            // lblPropietario
            // 
            this.lblPropietario.AutoSize = true;
            this.lblPropietario.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPropietario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblPropietario.Location = new System.Drawing.Point(14, 44);
            this.lblPropietario.Name = "lblPropietario";
            this.lblPropietario.Size = new System.Drawing.Size(65, 15);
            this.lblPropietario.TabIndex = 1;
            this.lblPropietario.Text = "Propietario";
            // 
            // lblFormTitulo
            // 
            this.lblFormTitulo.AutoSize = true;
            this.lblFormTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblFormTitulo.Name = "lblFormTitulo";
            this.lblFormTitulo.Size = new System.Drawing.Size(106, 19);
            this.lblFormTitulo.TabIndex = 0;
            this.lblFormTitulo.Text = "Nuevo usuario";
            // 
            // colIdUsuario
            // 
            this.colIdUsuario.HeaderText = "Id_Usuario";
            this.colIdUsuario.Name = "colIdUsuario";
            this.colIdUsuario.ReadOnly = true;
            this.colIdUsuario.Visible = false;
            // 
            // colIdRol
            // 
            this.colIdRol.HeaderText = "Id_Rol";
            this.colIdRol.Name = "colIdRol";
            this.colIdRol.ReadOnly = true;
            this.colIdRol.Visible = false;
            // 
            // colRol
            // 
            this.colRol.HeaderText = "Rol";
            this.colRol.Name = "colRol";
            this.colRol.ReadOnly = true;
            this.colRol.Width = 130;
            // 
            // colNombreUsuario
            // 
            this.colNombreUsuario.HeaderText = "Nombre de Usuario";
            this.colNombreUsuario.Name = "colNombreUsuario";
            this.colNombreUsuario.ReadOnly = true;
            this.colNombreUsuario.Width = 250;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 250;
            // 
            // colContrasena
            // 
            this.colContrasena.HeaderText = "Contraseña";
            this.colContrasena.Name = "colContrasena";
            this.colContrasena.ReadOnly = true;
            this.colContrasena.Visible = false;
            this.colContrasena.Width = 70;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 139;
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(830, 720);
            this.Controls.Add(this.dgvCitas);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevaCita);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFormCita);
            this.Name = "frmUsuarios";
            this.Text = "VetNova - Usuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFormCita.ResumeLayout(false);
            this.pnlFormCita.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevaCita;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblInfoUsuario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlHeaderBorde;
        private System.Windows.Forms.Panel pnlFormCita;
        private System.Windows.Forms.Button btnCancelarCita;
        private System.Windows.Forms.Button btnGuardarCita;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboVeterinario;
        private System.Windows.Forms.Label lblVeterinario;
        private System.Windows.Forms.ComboBox cboMascota;
        private System.Windows.Forms.Label lblMascota;
        private System.Windows.Forms.ComboBox cboPropietario;
        private System.Windows.Forms.Label lblPropietario;
        private System.Windows.Forms.Label lblFormTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContrasena;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}