using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaV2.Alertas.ALT_GERENTE
{
    public partial class ALT_ContrasenaNoCoincide : Form
    {
        public ALT_ContrasenaNoCoincide()
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
    }
}
