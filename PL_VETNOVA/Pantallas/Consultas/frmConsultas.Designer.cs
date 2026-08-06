namespace PL_VETNOVA.Pantallas.Consultas
{
    partial class frmConsultas
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.lblInfoUsuario = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlHeaderBorde = new System.Windows.Forms.Panel();
            this.lblMascota = new System.Windows.Forms.Label();
            this.cboMascota = new System.Windows.Forms.ComboBox();
            this.lblCita = new System.Windows.Forms.Label();
            this.cboCita = new System.Windows.Forms.ComboBox();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.lblTratamiento = new System.Windows.Forms.Label();
            this.txtTratamiento = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnGuardarConsulta = new System.Windows.Forms.Button();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiagnostico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTratamiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(800, 50);
            this.pnlHeader.TabIndex = 0;
            //
            // btnCerrar
            //
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCerrar.Location = new System.Drawing.Point(690, 10);
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
            this.lblInfoUsuario.Location = new System.Drawing.Point(370, 16);
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
            this.lblTitulo.Size = new System.Drawing.Size(122, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Consultas";
            //
            // pnlHeaderBorde
            //
            this.pnlHeaderBorde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.pnlHeaderBorde.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderBorde.Location = new System.Drawing.Point(0, 49);
            this.pnlHeaderBorde.Name = "pnlHeaderBorde";
            this.pnlHeaderBorde.Size = new System.Drawing.Size(800, 1);
            this.pnlHeaderBorde.TabIndex = 2;
            //
            // lblMascota
            //
            this.lblMascota.AutoSize = true;
            this.lblMascota.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMascota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblMascota.Location = new System.Drawing.Point(20, 62);
            this.lblMascota.Name = "lblMascota";
            this.lblMascota.Size = new System.Drawing.Size(53, 14);
            this.lblMascota.TabIndex = 1;
            this.lblMascota.Text = "Mascota";
            //
            // cboMascota
            //
            // Reutiliza cls_Mascotas_BLL.ListarMascotas (misma que frmCitas), sin
            // SP nuevo. Ordenado alfabeticamente con DataView.Sort. Al elegir
            // una mascota se filtra cboCita en memoria y se carga el historial
            // de una vez (ver cboMascota_SelectedIndexChanged).
            this.cboMascota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMascota.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboMascota.FormattingEnabled = true;
            this.cboMascota.Location = new System.Drawing.Point(20, 78);
            this.cboMascota.Name = "cboMascota";
            this.cboMascota.Size = new System.Drawing.Size(760, 25);
            this.cboMascota.TabIndex = 2;
            this.cboMascota.SelectedIndexChanged += new System.EventHandler(this.cboMascota_SelectedIndexChanged);
            //
            // lblCita
            //
            this.lblCita.AutoSize = true;
            this.lblCita.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCita.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblCita.Location = new System.Drawing.Point(20, 117);
            this.lblCita.Name = "lblCita";
            this.lblCita.Size = new System.Drawing.Size(28, 14);
            this.lblCita.TabIndex = 3;
            this.lblCita.Text = "Cita";
            //
            // cboCita
            //
            this.cboCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCita.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCita.FormattingEnabled = true;
            this.cboCita.Location = new System.Drawing.Point(20, 133);
            this.cboCita.Name = "cboCita";
            this.cboCita.Size = new System.Drawing.Size(760, 25);
            this.cboCita.TabIndex = 4;
            //
            // lblDiagnostico
            //
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDiagnostico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblDiagnostico.Location = new System.Drawing.Point(20, 172);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(74, 14);
            this.lblDiagnostico.TabIndex = 5;
            this.lblDiagnostico.Text = "Diagnóstico";
            //
            // txtDiagnostico
            //
            this.txtDiagnostico.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiagnostico.Location = new System.Drawing.Point(20, 188);
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnostico.Size = new System.Drawing.Size(760, 80);
            this.txtDiagnostico.TabIndex = 6;
            //
            // lblTratamiento
            //
            this.lblTratamiento.AutoSize = true;
            this.lblTratamiento.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTratamiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblTratamiento.Location = new System.Drawing.Point(20, 282);
            this.lblTratamiento.Name = "lblTratamiento";
            this.lblTratamiento.Size = new System.Drawing.Size(72, 14);
            this.lblTratamiento.TabIndex = 7;
            this.lblTratamiento.Text = "Tratamiento";
            //
            // txtTratamiento
            //
            this.txtTratamiento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTratamiento.Location = new System.Drawing.Point(20, 298);
            this.txtTratamiento.Multiline = true;
            this.txtTratamiento.Name = "txtTratamiento";
            this.txtTratamiento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTratamiento.Size = new System.Drawing.Size(760, 80);
            this.txtTratamiento.TabIndex = 8;
            //
            // lblObservaciones
            //
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(94)))), ((int)(((byte)(90)))));
            this.lblObservaciones.Location = new System.Drawing.Point(20, 392);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(89, 14);
            this.lblObservaciones.TabIndex = 9;
            this.lblObservaciones.Text = "Observaciones";
            //
            // txtObservaciones
            //
            this.txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtObservaciones.Location = new System.Drawing.Point(20, 408);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(760, 80);
            this.txtObservaciones.TabIndex = 10;
            //
            // btnGuardarConsulta
            //
            this.btnGuardarConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnGuardarConsulta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarConsulta.FlatAppearance.BorderSize = 0;
            this.btnGuardarConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarConsulta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardarConsulta.ForeColor = System.Drawing.Color.White;
            this.btnGuardarConsulta.Location = new System.Drawing.Point(20, 502);
            this.btnGuardarConsulta.Name = "btnGuardarConsulta";
            this.btnGuardarConsulta.Size = new System.Drawing.Size(170, 34);
            this.btnGuardarConsulta.TabIndex = 11;
            this.btnGuardarConsulta.Text = "Guardar consulta";
            this.btnGuardarConsulta.UseVisualStyleBackColor = false;
            this.btnGuardarConsulta.Click += new System.EventHandler(this.btnGuardarConsulta_Click);
            //
            // lblHistorial
            //
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistorial.Location = new System.Drawing.Point(20, 557);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(268, 19);
            this.lblHistorial.TabIndex = 12;
            this.lblHistorial.Text = "Historial de consultas de esta mascota";
            //
            // dgvHistorial
            //
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(248)))));
            this.dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colDiagnostico,
            this.colTratamiento});
            this.dgvHistorial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(222)))));
            this.dgvHistorial.Location = new System.Drawing.Point(20, 587);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(760, 260);
            this.dgvHistorial.TabIndex = 13;
            //
            // colFecha
            //
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 100;
            //
            // colDiagnostico
            //
            this.colDiagnostico.HeaderText = "Diagnóstico";
            this.colDiagnostico.Name = "colDiagnostico";
            this.colDiagnostico.DataPropertyName = "Diagnostico";
            this.colDiagnostico.ReadOnly = true;
            this.colDiagnostico.Width = 260;
            //
            // colTratamiento
            //
            this.colTratamiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTratamiento.HeaderText = "Tratamiento";
            this.colTratamiento.Name = "colTratamiento";
            this.colTratamiento.DataPropertyName = "Tratamiento";
            this.colTratamiento.ReadOnly = true;
            //
            // frmConsultas
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 870);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.btnGuardarConsulta);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.txtTratamiento);
            this.Controls.Add(this.lblTratamiento);
            this.Controls.Add(this.txtDiagnostico);
            this.Controls.Add(this.lblDiagnostico);
            this.Controls.Add(this.cboCita);
            this.Controls.Add(this.lblCita);
            this.Controls.Add(this.cboMascota);
            this.Controls.Add(this.lblMascota);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(700, 720);
            this.Name = "frmConsultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VetNova - Consultas";
            this.Load += new System.EventHandler(this.frmConsultas_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConsultas_FormClosing);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label lblInfoUsuario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlHeaderBorde;
        private System.Windows.Forms.Label lblMascota;
        private System.Windows.Forms.ComboBox cboMascota;
        private System.Windows.Forms.Label lblCita;
        private System.Windows.Forms.ComboBox cboCita;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label lblTratamiento;
        private System.Windows.Forms.TextBox txtTratamiento;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnGuardarConsulta;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiagnostico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTratamiento;
    }
}