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
    public partial class FRM_GER_Reportes : Form
    {
        public FRM_GER_Reportes()
        {
            InitializeComponent();
        }

        private void FRM_GER_Reportes_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            dbTickets database = new dbTickets();
            DataTable datos = new DataTable();
            datos = database.ConsultarTodos();
            dgvReportes.DataSource = datos;
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FRM_GER_Menu frmEmp = new FRM_GER_Menu();
            frmEmp.Visible = true;
            this.Visible = false;
        }
    }
}
