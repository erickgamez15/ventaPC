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
    }
}
