using System.IO;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nosevv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void labelDireccion_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            dgvEmpleados.Columns.Add("id", "ID");
            dgvEmpleados.Columns.Add("nombre", "NOMBRE");
            dgvEmpleados.Columns.Add("apellidos", "APELLIDOS");
            dgvEmpleados.Columns.Add("direccion", "DIRECCION");
            dgvEmpleados.Columns.Add("email", "EMAIL");
            dgvEmpleados.Columns.Add("numero", "NUMERO");
            dgvEmpleados.Columns.Add("salario", "SALARIO");
            dgvEmpleados.Columns.Add("cargo", "CARGO");
            dgvEmpleados.Columns.Add("genero", "GENERO");
            dgvEmpleados.Columns.Add("fecha", "FECHA INGRESO");

           
            comboBoxCargo.Items.AddRange(new string[]
            {
                "Administrador",
                "Empleado"
            });

           
            comboBoxGenero.Items.AddRange(new string[]
            {
                "Masculino",
                "Femenino"
            });
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
       
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtNumero.Text) ||
                string.IsNullOrWhiteSpace(txtSalario.Text))
            {
                MessageBox.Show("No deje ningún campo vacío.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

           
            if (comboBoxCargo.SelectedIndex == -1 ||
                comboBoxGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione Cargo y Género.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

           
            if (!int.TryParse(txtId.Text, out int id) ||
                !int.TryParse(txtNumero.Text, out int numero) ||
                !int.TryParse(txtSalario.Text, out int salario))
            {
                MessageBox.Show("ID, Número y Salario deben ser numéricos.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

          
            dgvEmpleados.Rows.Add(
                id,
                txtNombre.Text,
                txtApellidos.Text,
                txtDireccion.Text,
                txtEmail.Text,
                numero,
                salario,
                comboBoxCargo.Text,
                comboBoxGenero.Text,
                dateTimePickerFecha.Value.ToShortDateString()
            );

           
            DialogResult r = MessageBox.Show(
                "¿Desea guardar los datos en un archivo TXT?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (r != DialogResult.Yes)
                return;

           
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivos de texto (*.txt)|*.txt";
            sfd.Title = "Guardar archivo";
            sfd.FileName = "Empleados.txt";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName))
            {
                foreach (DataGridViewRow fila in dgvEmpleados.Rows)
                {
                    if (!fila.IsNewRow)
                    {
                        sw.WriteLine(
                            fila.Cells[0].Value + " | " +
                            fila.Cells[1].Value + " | " +
                            fila.Cells[2].Value + " | " +
                            fila.Cells[3].Value + " | " +
                            fila.Cells[4].Value + " | " +
                            fila.Cells[5].Value + " | " +
                            fila.Cells[6].Value + " | " +
                            fila.Cells[7].Value + " | " +
                            fila.Cells[8].Value + " | " +
                            fila.Cells[9].Value
                        );
                    }
                }
            }

            MessageBox.Show("Archivo guardado correctamente 💾",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Process.Start(new ProcessStartInfo
            {
                FileName = sfd.FileName,
                UseShellExecute = true
            });
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtDireccion.Clear();
            txtEmail.Clear();
            txtNumero.Clear();
            txtSalario.Clear();

            comboBoxCargo.SelectedIndex = -1;
            comboBoxGenero.SelectedIndex = -1;

            dateTimePickerFecha.Value = DateTime.Now;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "¿Desea salir de la aplicación?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
                Application.Exit();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Empleado guardado correctamente.",
    "Éxito",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information);

        }


    }
}

