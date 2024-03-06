using PuntoVentaV2.Gerencia;
using PuntoVentaV2.Gerencia.Dar_de_Baja;
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
    public partial class FRM_GER_Empleados : Form
    {
        public FRM_GER_Empleados()
        {
            InitializeComponent();
        }
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            FRM_GER_AgregarEmpleado frmEmp = new FRM_GER_AgregarEmpleado();
            frmEmp.Visible = true;
            this.Visible = false;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FRM_GER_AgregarUsuario frmEmp = new FRM_GER_AgregarUsuario();
            frmEmp.Visible = true;
            this.Visible = false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FRM_GER_Menu frmEmp = new FRM_GER_Menu();
            frmEmp.Visible = true;
            this.Visible = false;
        }
        private void btnReePass_Click(object sender, EventArgs e)
        {
            FRM_GER_RestablecerPass frmEmp = new FRM_GER_RestablecerPass();
            frmEmp.Visible = true;
            this.Visible = false;
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            FRM_GER_DarBaja frmEmp = new FRM_GER_DarBaja();
            frmEmp.Visible = true;
            this.Visible = false;
        }
        private void btnListaEmp_Click(object sender, EventArgs e)
        {
            FER_GER_ListaEmpleados frmEmp = new FER_GER_ListaEmpleados();
            frmEmp.Visible = true;
            this.Visible = false;
        }

        private void FRM_GER_Empleados_Load(object sender, EventArgs e)
        {

        }
    }
}
