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
    public partial class ClienteAgregar : Form
    {
        public ClienteAgregar()
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
            textNombre.Text = "";
            textCorreo.Text = "";
            textRFC.Text = "";
        }

        private void ClienteAgregar_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "insert into cliente(nombreCompleto, correo, rfc) values(@nombreCompleto,@correo, @rfc)";
            SqlCommand cmd = new SqlCommand(insertar, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@nombreCompleto", textNombre.Text);
            cmd.Parameters.AddWithValue("@correo", textCorreo.Text);
            cmd.Parameters.AddWithValue("@rfc", textRFC.Text);
            cmd.ExecuteNonQuery();
            dataGridView1.DataSource = llenarGrid();
        }

        private DataTable llenarGrid()
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
