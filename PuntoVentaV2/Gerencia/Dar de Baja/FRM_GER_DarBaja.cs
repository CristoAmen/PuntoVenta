using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaV2.Gerencia.Dar_de_Baja
{
    public partial class FRM_GER_DarBaja : Form
    {
        public FRM_GER_DarBaja()
        {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            FRM_GER_DarBajaUsuario frmEmp = new FRM_GER_DarBajaUsuario();
            frmEmp.Visible = true;
            this.Visible = false;
        }

        private void bntEmpleado_Click(object sender, EventArgs e)
        {
            FRM_GER_DarBajaEmpleado frmEmp = new FRM_GER_DarBajaEmpleado();
            frmEmp.Visible = true;
            this.Visible = false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FRM_GER_Empleados frmEmp = new FRM_GER_Empleados();
            frmEmp.Visible = true;
            this.Visible = false;
        }
    }
}
