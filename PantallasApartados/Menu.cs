using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PantallasApartados
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            var cliente = new frmApartadosClientes();
            cliente.MdiParent = this.MdiParent;

            cliente.Show();
        }

        private void btnBodega_Click(object sender, EventArgs e)
        {
            var bodega = new frmApartadosBodega();
            bodega.MdiParent = this.MdiParent;

            bodega.Show();

        }
    }
}
