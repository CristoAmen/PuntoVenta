using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaV2.Cajero
{
    public partial class CAJ_TarjetaAprobada : Form
    {
        CAJ_Interfaz v = new CAJ_Interfaz();
        public CAJ_TarjetaAprobada()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            v.Show();
            this.Close();
        }

        private void CAJ_TarjetaAprobada_Load(object sender, EventArgs e)
        {

        }
    }
}
