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
    public partial class VentasAgregar : Form
    {
        public VentasAgregar()
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
            textIDArticulo.Clear();
            textIDCliente.Clear();
            textCantidad.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion.Conectar();
                string insertar = "insert into venta(idProducto, idCliente, cantidad) values(@idProducto, @idCliente, @cantidad)";
                SqlCommand cmd = new SqlCommand(insertar, Conexion.Conectar());
                cmd.Parameters.AddWithValue("@idProducto", textIDArticulo.Text);
                cmd.Parameters.AddWithValue("@idCliente", textIDCliente.Text);
                cmd.Parameters.AddWithValue("@cantidad", textCantidad.Text);
                cmd.ExecuteNonQuery();
                dataGridView1.DataSource = llenarGrid();
                string actualizarStock = "UPDATE producto set stock = stock - venta.cantidad from producto inner join venta on venta.idProducto = producto.idProducto";
                SqlCommand cmdA = new SqlCommand(actualizarStock, Conexion.Conectar());
                cmdA.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable llenarGrid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from venta";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
