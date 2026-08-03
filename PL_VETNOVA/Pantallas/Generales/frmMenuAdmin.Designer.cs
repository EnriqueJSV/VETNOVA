namespace PL_VETNOVA.Pantallas.Generales
{
    partial class frmMenuAdmin
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
            this.lblInfoUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInfoUsuario
            // 
            this.lblInfoUsuario.AutoSize = true;
            this.lblInfoUsuario.Location = new System.Drawing.Point(189, 137);
            this.lblInfoUsuario.Name = "lblInfoUsuario";
            this.lblInfoUsuario.Size = new System.Drawing.Size(0, 20);
            this.lblInfoUsuario.TabIndex = 0;
            // 
            // frmMenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInfoUsuario);
            this.Name = "frmMenuAdmin";
            this.Text = "frmMenuPrincipal";
            this.Load += new System.EventHandler(this.frmMenuAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfoUsuario;
    }
}