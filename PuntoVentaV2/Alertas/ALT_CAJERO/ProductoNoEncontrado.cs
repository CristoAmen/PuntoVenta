using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaV2.Alertas
{
    public partial class ProductoNoEncontrado : Form
    {
        public ProductoNoEncontrado()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
                
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lblText_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
