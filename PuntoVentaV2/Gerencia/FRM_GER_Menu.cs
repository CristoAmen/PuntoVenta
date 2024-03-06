using PuntoVentaV2.Gerencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaV2
{
    public partial class FRM_GER_Menu : Form
    {
        public FRM_GER_Menu()
        {
            InitializeComponent();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login frmEmp = new Login();
            frmEmp.Visible = true;
            this.Visible = false;
        }
        private void btnAddProd_Click(object sender, EventArgs e)
        {
            FRM_GER_AddProductos frmEmp = new FRM_GER_AddProductos();
            frmEmp.Visible = true;
            this.Visible = false;
        }

        private void btnEmpleados_Click_1(object sender, EventArgs e)
        {
            FRM_GER_Empleados frmEmp = new FRM_GER_Empleados();
            frmEmp.Visible = true;
            this.Visible = false;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FRM_GER_Reportes frmEmp = new FRM_GER_Reportes();
            frmEmp.Visible = true;
            this.Visible = false;
        }
    }
}
