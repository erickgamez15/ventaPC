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
    public partial class ProductoConsultar : Form
    {
        public ProductoConsultar()
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
            textID.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenarGrid();
        }

        public DataTable llenarGrid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from producto where idProducto = @idProducto";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@idProducto", textID.Text);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
