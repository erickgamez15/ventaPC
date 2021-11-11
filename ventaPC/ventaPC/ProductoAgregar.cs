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
    public partial class ProductoAgregar : Form
    {
        public ProductoAgregar()
        {
            InitializeComponent();
        }

        private void btnBackProducto_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textNombre.Text = "";
            textCodigo.Text = "";
            textStock.Text = "";
            textPrecioC.Text = "";
            textPrecioV.Text = "";
            textDescripcion.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "insert into producto(codigo, nombreProducto, descripcion, stock, precioCompra, precioVenta) values(@codigo, @nombreProducto, @descripcion, @stock, @precioCompra, @precioVenta)";
            SqlCommand cmd = new SqlCommand(insertar, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@codigo", textCodigo.Text);
            cmd.Parameters.AddWithValue("@nombreProducto", textNombre.Text);
            cmd.Parameters.AddWithValue("@descripcion", textDescripcion.Text);
            cmd.Parameters.AddWithValue("@stock", textStock.Text);
            cmd.Parameters.AddWithValue("@precioCompra", textPrecioC.Text);
            cmd.Parameters.AddWithValue("@precioVenta", textPrecioV.Text);
            cmd.ExecuteNonQuery();
            dataGridView1.DataSource = llenarGrid();
        }

        private DataTable llenarGrid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from producto";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
