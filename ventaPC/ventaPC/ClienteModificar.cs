using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventaPC
{
    public partial class ClienteModificar : Form
    {
        public ClienteModificar()
        {
            InitializeComponent();
        }

        private void btnBackCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            this.Close();
        }

        private void dataGridViewMod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textIDMod.Text = dataGridViewMod.CurrentRow.Cells[0].Value.ToString();
                textNombreMod.Text = dataGridViewMod.CurrentRow.Cells[1].Value.ToString();
                textCorreoMod.Text = dataGridViewMod.CurrentRow.Cells[2].Value.ToString();
                textRFCMod.Text = dataGridViewMod.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dataGridViewMod.DataSource = llenarGrid();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textIDMod.Text = "";
            textNombreMod.Text = "";
            textCorreoMod.Text = "";
            textRFCMod.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "update cliente set nombreCompleto = @nombreCompleto, correo = @correo, rfc = @rfc where idCliente = @idCliente";
            SqlCommand cmd = new SqlCommand(actualizar, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@idCliente", textIDMod.Text);
            cmd.Parameters.AddWithValue("@nombreCompleto", textNombreMod.Text);
            cmd.Parameters.AddWithValue("@correo", textCorreoMod.Text);
            cmd.Parameters.AddWithValue("@rfc", textRFCMod.Text);
            cmd.ExecuteNonQuery();
            dataGridViewMod.DataSource = llenarGrid();
        }

        public DataTable llenarGrid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from cliente";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
