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

namespace PuntoVentaV2.Gerencia
{
    public partial class FRM_GER_RestablecerPass : Form
    {
        public FRM_GER_RestablecerPass()
        {
            InitializeComponent();
        }

        private void btnReestablecer_Click(object sender, EventArgs e)
        {
            dbUsuario database = new dbUsuario();
            ClassUsuario obj = new ClassUsuario();
            if (txtNewPass.Text == txtRePass.Text)
            {
                obj.Password = txtNewPass.Text;
                
                if(cmbUsuario.Text!="")
                {
                    obj.Id = int.Parse(cmbUsuario.SelectedValue.ToString());

                    DataTable datos = new DataTable();
                    datos = database.ConsultarCodigo(obj);
                    if (txtNewPass.Text != "" && txtRePass.Text != "")
                    {
                        database.Actualizar(obj);
                        // MessageBox.Show("Se realizo el cambio con exito", "Sistema");

                        //Saldra un mensaje
                        ALT_CambioExitoso CambioExitoso = new ALT_CambioExitoso();
                        CambioExitoso.Show();

                        limpiar();
                    }
                    else
                    {
                        //MessageBox.Show("Falto capturar informacion", "Sistema");

                        ALT_FaltaCapturar faltaCapturar = new ALT_FaltaCapturar();
                        faltaCapturar.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccion no valida","Sistema");
                }
            }
            else
            {
                // MessageBox.Show("La contraseña no coincide");

                ALT_ContrasenaNoCoincide contrasenaNoCoincide = new ALT_ContrasenaNoCoincide();
                contrasenaNoCoincide.Show();

            }
        }
        private void FRM_GER_RestablecerPass_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FRM_GER_Empleados frmEmp = new FRM_GER_Empleados();
            frmEmp.Visible = true;
            this.Visible = false;
        }
        private void cargarCombo()
        {
            cmbUsuario.Text = "Selecciona una opcion";
            dbUsuario db = new dbUsuario();

            cmbUsuario.DataSource = db.ConsultarU("usuario");
            cmbUsuario.DisplayMember = "idUsuario";
            cmbUsuario.ValueMember = "idUsuario";
        }
        private void limpiar()
        {
            txtNewPass.Text = null;
            txtRePass.Text = null;
            //cmbUsuario.Text = null;
        }
    }
}
