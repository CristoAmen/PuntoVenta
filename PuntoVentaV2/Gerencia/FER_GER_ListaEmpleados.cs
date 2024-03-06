using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaV2.Gerencia
{
    public partial class FER_GER_ListaEmpleados : Form
    {
        public FER_GER_ListaEmpleados()
        {
            InitializeComponent();
        }

        private void FER_GER_ListaEmpleados_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            dbEmpleado database = new dbEmpleado();
            DataTable datos = new DataTable();
            datos = database.ConsultarTodos();
            dgvEmpleados.DataSource = datos;

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FRM_GER_Empleados frmEmp = new FRM_GER_Empleados();
            frmEmp.Visible = true;
            this.Visible = false;
        }
    }
}
