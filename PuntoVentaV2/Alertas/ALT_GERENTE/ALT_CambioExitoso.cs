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
    public partial class ALT_CambioExitoso : Form
    {
        public ALT_CambioExitoso()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        }

        private void ALT_CambioExitoso_Load(object sender, EventArgs e)
        {

        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
