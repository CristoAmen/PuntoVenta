using PuntoVentaV2.Alertas;
using PuntoVentaV2.Alertas.ALT_GERENTE;
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
    public partial class FRM_GER_DarBajaUsuario : Form
    {
        public FRM_GER_DarBajaUsuario()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbUsuario database = new dbUsuario();
            ClassUsuario obj = new ClassUsuario();

            if (cmbUsuario.Text == "")
            {
                //MessageBox.Show("Seleccion no valida", "Sistema");

                //Saldra un mensaje
                ALT_SeleccionNoValida seleccionNoValida = new ALT_SeleccionNoValida();
                seleccionNoValida.Show();

            }
            else
            {
                obj.Id = int.Parse(cmbUsuario.SelectedValue.ToString());

                tCombo.Start();
                DataTable datos = new DataTable();
                database.EliminarU(obj);

                // MessageBox.Show("Se elimino con exito", "Sistema");

                //Saldra un mensaje
                ALT_SeEliminoConExito seEliminoConExito = new ALT_SeEliminoConExito();
                seEliminoConExito.Show();

                tCombo.Stop();
            }
        }



        private void FRM_GER_DarBajaUsuario_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }
        private void cargarCombo()
        {
            cmbUsuario.Text = "Selecciona una opcion";
            dbUsuario db = new dbUsuario();

            cmbUsuario.DataSource = db.ConsultarU("usuario");
            cmbUsuario.DisplayMember = "idUsuario";
            cmbUsuario.ValueMember = "idUsuario";
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FRM_GER_DarBaja frmEmp = new FRM_GER_DarBaja();
            frmEmp.Visible = true;
            this.Visible = false;
        }

        private void tCombo_Tick(object sender, EventArgs e)
        {
            cargarCombo();
        }
    }
}
