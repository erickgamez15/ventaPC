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
    public partial class Producto : Form
    {
        public Producto()
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
            ProductoAgregar productoAgr = new ProductoAgregar();
            productoAgr.Show();
            this.Hide();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ProductoConsultar productoCon = new ProductoConsultar();
            productoCon.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductoModificar productoMod = new ProductoModificar();
            productoMod.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProductoEliminar productoEli = new ProductoEliminar();
            productoEli.Show();
            this.Hide();
        }
    }
}
