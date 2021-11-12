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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            VentasAgregar ventaAgr = new VentasAgregar();
            ventaAgr.Show();
            this.Hide();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            VentasConsultar ventaCon = new VentasConsultar();
            ventaCon.Show();
            this.Hide();
        }
    }
}
