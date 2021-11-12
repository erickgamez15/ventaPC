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
    public partial class ProductoModificar : Form
    {
        public ProductoModificar()
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
            textIDProducto.Text = "";
            textNombre.Text = "";
            textCodigo.Text = "";
            textStock.Text = "";
            textPrecioC.Text = "";
            textPrecioV.Text = "";
            textDescripcion.Text = "";
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            dataGridViewMod.DataSource = llenarGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "update producto set codigo = @codigo, nombreProducto = @nombreProducto,  descripcion = @descripcion, stock = @stock, precioCompra = @precioCompra,  precioVenta = @precioVenta where idProducto = @idProducto";
            SqlCommand cmd = new SqlCommand(actualizar, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@idProducto", textIDProducto.Text);
            cmd.Parameters.AddWithValue("@codigo", textCodigo.Text);
            cmd.Parameters.AddWithValue("@nombreProducto", textNombre.Text);
            cmd.Parameters.AddWithValue("@descripcion", textDescripcion.Text);
            cmd.Parameters.AddWithValue("@stock", textStock.Text);
            cmd.Parameters.AddWithValue("@precioCompra", textPrecioC.Text);
            cmd.Parameters.AddWithValue("@precioVenta", textPrecioV.Text);
            cmd.ExecuteNonQuery();
            dataGridViewMod.DataSource = llenarGrid();
        }

        private void dataGridViewMod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textIDProducto.Text = dataGridViewMod.CurrentRow.Cells[0].Value.ToString();
                textCodigo.Text = dataGridViewMod.CurrentRow.Cells[1].Value.ToString();
                textNombre.Text = dataGridViewMod.CurrentRow.Cells[2].Value.ToString();
                textDescripcion.Text = dataGridViewMod.CurrentRow.Cells[3].Value.ToString();
                textStock.Text = dataGridViewMod.CurrentRow.Cells[4].Value.ToString();
                textPrecioC.Text = dataGridViewMod.CurrentRow.Cells[5].Value.ToString();
                textPrecioV.Text = dataGridViewMod.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable llenarGrid()
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
