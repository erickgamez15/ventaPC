using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ventaPC
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ClienteAgregar clienteAgr = new ClienteAgregar();
            clienteAgr.Show();
            this.Hide();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ClienteConsultar clienteCon = new ClienteConsultar();
            clienteCon.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ClienteModificar clienteMod = new ClienteModificar();
            clienteMod.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClienteEliminar clienteEli = new ClienteEliminar();
            clienteEli.Show();
            this.Hide();
        }
    }
}
