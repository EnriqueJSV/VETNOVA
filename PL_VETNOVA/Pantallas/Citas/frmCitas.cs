using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL_VETNOVA.Pantallas.Citas
{
    public partial class frmCitas : Form
    {
        // Se le pasan desde frmMenuAdmin antes de abrir esta ventana, para que
        // sepa quien esta guardando (auditoria) y que le enseñe en el header.
        public int IdUsuarioGlobal { get; set; }
        public string InfoUsuario { get; set; }

        public frmCitas()
        {
            InitializeComponent();
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            lblInfoUsuario.Text = InfoUsuario;

            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new object[] { "Pendiente", "Confirmada", "Atendida", "Cancelada" });

            // TODO: cargar dgvCitas: EXEC SP_LISTAR_CITAS
            // TODO: cargar cboPropietario: EXEC SP_LISTAR_PROPIETARIOS
            // TODO: cargar cboVeterinario: EXEC SP_LISTAR_VETERINARIOS
            // cboMascota se llena cuando se elige un propietario (ver mas abajo)
        }

        private void btnNuevaCita_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            pnlFormCita.Visible = !pnlFormCita.Visible;
        }

        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            pnlFormCita.Visible = false;
            LimpiarFormulario();
        }

        private void btnGuardarCita_Click(object sender, EventArgs e)
        {
            if (cboPropietario.SelectedIndex == -1 || cboMascota.SelectedIndex == -1 ||
                cboVeterinario.SelectedIndex == -1 || cboEstado.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                MessageBox.Show("Completa todos los campos antes de guardar.", "Nueva cita",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: llamar a cls_Citas_BLL con SP_INSERTA_CITAS, usando:
            //   @Id_Mascota = (Id detras de cboMascota.SelectedItem)
            //   @Id_Veterinario = (Id detras de cboVeterinario.SelectedItem)
            //   @Fecha = dtpFecha.Value
            //   @Hora = dtpHora.Value.ToString("HH:mm")
            //   @Motivo = txtMotivo.Text
            //   @Estado_Cita = cboEstado.SelectedItem.ToString()
            //   @IdUsuarioGlobal = this.IdUsuarioGlobal
            MessageBox.Show("Aqui se va a guardar la cita una vez conectemos la logica con la base de datos.",
                "Nueva cita", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cboPropietario_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: cuando cboPropietario tenga datos reales (Value = Id_Propietario),
            // filtrar aqui las mascotas de ese propietario y llenar cboMascota,
            // por ejemplo con un SP_FILTRAR_MASCOTAS_POR_PROPIETARIO (o similar).
        }

        private void dgvCitas_SelectionChanged(object sender, EventArgs e)
        {
            // TODO: cuando se agregue edicion/eliminacion, aqui se puede leer la
            // fila seleccionada de dgvCitas y precargar pnlFormCita para editarla.
        }

        private void LimpiarFormulario()
        {
            cboPropietario.SelectedIndex = -1;
            cboMascota.SelectedIndex = -1;
            cboVeterinario.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            dtpHora.Value = DateTime.Now;
            txtMotivo.Clear();
        }
    }
}
