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
    public partial class VentasConsultar : Form
    {
        public VentasConsultar()
        {
            InitializeComponent();
        }

        private void btnBackVenta_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            venta.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textID.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenarGrid();
        }

        public DataTable llenarGrid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select idVenta, p.idProducto, nombreProducto, c.idCliente, nombreCompleto, rfc, cantidad, (cantidad*p.precioVenta) as 'Total a pagar' from venta v inner join producto p on p.idProducto = v.idProducto inner join cliente c on c.idCliente = v.idCliente where idVenta = @idVenta";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@idVenta", textID.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenarGrid1();
        }

        public DataTable llenarGrid1()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from venta";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
