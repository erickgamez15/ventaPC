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
    public partial class ClienteEliminar : Form
    {
        public ClienteEliminar()
        {
            InitializeComponent();
        }

        private void btnBackCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textID.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "delete from cliente where idCliente = @idCliente";
            SqlCommand cmd = new SqlCommand(eliminar, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@idCliente", textID.Text);
            cmd.ExecuteNonQuery();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenarGrid();
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
