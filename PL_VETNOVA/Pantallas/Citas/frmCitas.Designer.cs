namespace PL_VETNOVA.Pantallas.Citas
{
    partial class frmCitas
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblInfoUsuario = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlHeaderBorde = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnNuevaCita = new System.Windows.Forms.Button();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.colMascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPropietario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVeterinario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.pnlFormCita.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblInfoUsuario);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.pnlHeaderBorde);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(830, 50);
            this.pnlHeader.TabIndex = 0;
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
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(60, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Citas";
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
            // txtBuscar
            //
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(20, 70);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(320, 25);
            this.txtBuscar.TabIndex = 1;
            //
            // btnNuevaCita
            //
            this.btnNuevaCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnNuevaCita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaCita.FlatAppearance.BorderSize = 0;
            this.btnNuevaCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaCita.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevaCita.ForeColor = System.Drawing.Color.White;
            this.btnNuevaCita.Location = new System.Drawing.Point(640, 68);
            this.btnNuevaCita.Name = "btnNuevaCita";
            this.btnNuevaCita.Size = new System.Drawing.Size(150, 30);
            this.btnNuevaCita.TabIndex = 2;
            this.btnNuevaCita.Text = "+ Nueva cita";
            this.btnNuevaCita.UseVisualStyleBackColor = false;
            this.btnNuevaCita.Click += new System.EventHandler(this.btnNuevaCita_Click);
            //
            // dgvCitas
            //
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.AllowUserToDeleteRows = false;
            this.dgvCitas.BackgroundColor = System.Drawing.Color.White;
            this.dgvCitas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCitas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.dgvCitas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMascota,
            this.colPropietario,
            this.colVeterinario,
            this.colFecha,
            this.colHora,
            this.colMotivo,
            this.colEstado});
            this.dgvCitas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.dgvCitas.Location = new System.Drawing.Point(20, 110);
            this.dgvCitas.Name = "dgvCitas";
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersVisible = false;
            this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.Size = new System.Drawing.Size(770, 230);
            this.dgvCitas.TabIndex = 3;
            this.dgvCitas.SelectionChanged += new System.EventHandler(this.dgvCitas_SelectionChanged);
            //
            // colMascota
            //
            this.colMascota.HeaderText = "Mascota";
            this.colMascota.Name = "colMascota";
            this.colMascota.ReadOnly = true;
            this.colMascota.Width = 100;
            //
            // colPropietario
            //
            this.colPropietario.HeaderText = "Propietario";
            this.colPropietario.Name = "colPropietario";
            this.colPropietario.ReadOnly = true;
            this.colPropietario.Width = 130;
            //
            // colVeterinario
            //
            this.colVeterinario.HeaderText = "Veterinario";
            this.colVeterinario.Name = "colVeterinario";
            this.colVeterinario.ReadOnly = true;
            this.colVeterinario.Width = 130;
            //
            // colFecha
            //
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 90;
            //
            // colHora
            //
            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "colHora";
            this.colHora.ReadOnly = true;
            this.colHora.Width = 70;
            //
            // colMotivo
            //
            this.colMotivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.ReadOnly = true;
            //
            // colEstado
            //
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 100;
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
            this.pnlFormCita.Location = new System.Drawing.Point(20, 350);
            this.pnlFormCita.Name = "pnlFormCita";
            this.pnlFormCita.Size = new System.Drawing.Size(770, 300);
            this.pnlFormCita.TabIndex = 4;
            this.pnlFormCita.Visible = false;
            //
            // btnCancelarCita
            //
            this.btnCancelarCita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarCita.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelarCita.Location = new System.Drawing.Point(140, 254);
            this.btnCancelarCita.Name = "btnCancelarCita";
            this.btnCancelarCita.Size = new System.Drawing.Size(110, 32);
            this.btnCancelarCita.TabIndex = 16;
            this.btnCancelarCita.Text = "Cancelar";
            this.btnCancelarCita.UseVisualStyleBackColor = true;
            this.btnCancelarCita.Click += new System.EventHandler(this.btnCancelarCita_Click);
            //
            // btnGuardarCita
            //
            this.btnGuardarCita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnGuardarCita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarCita.FlatAppearance.BorderSize = 0;
            this.btnGuardarCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCita.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarCita.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCita.Location = new System.Drawing.Point(14, 254);
            this.btnGuardarCita.Name = "btnGuardarCita";
            this.btnGuardarCita.Size = new System.Drawing.Size(110, 32);
            this.btnGuardarCita.TabIndex = 15;
            this.btnGuardarCita.Text = "Guardar";
            this.btnGuardarCita.UseVisualStyleBackColor = false;
            this.btnGuardarCita.Click += new System.EventHandler(this.btnGuardarCita_Click);
            //
            // txtMotivo
            //
            this.txtMotivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMotivo.Location = new System.Drawing.Point(14, 210);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(736, 36);
            this.txtMotivo.TabIndex = 14;
            //
            // lblMotivo
            //
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblMotivo.Location = new System.Drawing.Point(14, 194);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(44, 14);
            this.lblMotivo.TabIndex = 13;
            this.lblMotivo.Text = "Motivo";
            //
            // dtpHora
            //
            this.dtpHora.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(200, 160);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(170, 25);
            this.dtpHora.TabIndex = 12;
            //
            // lblHora
            //
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblHora.Location = new System.Drawing.Point(200, 144);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(30, 14);
            this.lblHora.TabIndex = 11;
            this.lblHora.Text = "Hora";
            //
            // dtpFecha
            //
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(14, 160);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(170, 25);
            this.dtpFecha.TabIndex = 10;
            //
            // lblFecha
            //
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblFecha.Location = new System.Drawing.Point(14, 144);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 14);
            this.lblFecha.TabIndex = 9;
            this.lblFecha.Text = "Fecha";
            //
            // cboEstado
            //
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(390, 110);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(360, 25);
            this.cboEstado.TabIndex = 8;
            //
            // lblEstado
            //
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblEstado.Location = new System.Drawing.Point(390, 94);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(41, 14);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Estado";
            //
            // cboVeterinario
            //
            this.cboVeterinario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVeterinario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboVeterinario.FormattingEnabled = true;
            this.cboVeterinario.Location = new System.Drawing.Point(14, 110);
            this.cboVeterinario.Name = "cboVeterinario";
            this.cboVeterinario.Size = new System.Drawing.Size(360, 25);
            this.cboVeterinario.TabIndex = 6;
            //
            // lblVeterinario
            //
            this.lblVeterinario.AutoSize = true;
            this.lblVeterinario.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblVeterinario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblVeterinario.Location = new System.Drawing.Point(14, 94);
            this.lblVeterinario.Name = "lblVeterinario";
            this.lblVeterinario.Size = new System.Drawing.Size(64, 14);
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
            this.lblMascota.Size = new System.Drawing.Size(53, 14);
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
            this.cboPropietario.SelectedIndexChanged += new System.EventHandler(this.cboPropietario_SelectedIndexChanged);
            //
            // lblPropietario
            //
            this.lblPropietario.AutoSize = true;
            this.lblPropietario.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPropietario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblPropietario.Location = new System.Drawing.Point(14, 44);
            this.lblPropietario.Name = "lblPropietario";
            this.lblPropietario.Size = new System.Drawing.Size(63, 14);
            this.lblPropietario.TabIndex = 1;
            this.lblPropietario.Text = "Propietario";
            //
            // lblFormTitulo
            //
            this.lblFormTitulo.AutoSize = true;
            this.lblFormTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormTitulo.Location = new System.Drawing.Point(14, 10);
            this.lblFormTitulo.Name = "lblFormTitulo";
            this.lblFormTitulo.Size = new System.Drawing.Size(78, 19);
            this.lblFormTitulo.TabIndex = 0;
            this.lblFormTitulo.Text = "Nueva cita";
            //
            // frmCitas
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(830, 680);
            this.Controls.Add(this.pnlFormCita);
            this.Controls.Add(this.dgvCitas);
            this.Controls.Add(this.btnNuevaCita);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "frmCitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VetNova - Citas";
            this.Load += new System.EventHandler(this.frmCitas_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.pnlFormCita.ResumeLayout(false);
            this.pnlFormCita.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblInfoUsuario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlHeaderBorde;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnNuevaCita;
        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPropietario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVeterinario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
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
    }
}
