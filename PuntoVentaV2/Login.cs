using PuntoVentaV2.Alertas.CustomMessageBox;
using PuntoVentaV2.Alertas;
using PuntoVentaV2.Cajero;
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
using static PuntoVentaV2.Cajero.CAJ_Interfaz;
using static System.Windows.Forms.LinkLabel;

namespace PuntoVentaV2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }
        public void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtEmpleado.Text;
            string password = txtPass.Text;

            try
            {
                Control ctrl = new Control();
                string respuesta = ctrl.ctrlLogin(usuario, password);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if(lblPuesto.Text=="2")
                    {
                        FRM_GER_Menu frm = new FRM_GER_Menu();
                        frm.Visible = true;
                        this.Visible = false;
                    }
                    else if(lblPuesto.Text=="1")
                    {

                        DatosCompartidos.Empleado = txtEmpleado.Text;

                        CAJ_Interfaz frm = new CAJ_Interfaz();
                        frm.Visible = true;
                        this.Visible = false;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cargarPuesto()
        {
            dbUsuario dbe = new dbUsuario();
            ClassUsuario obj = new ClassUsuario();
            DataTable datos = new DataTable();

            obj.Id = int.Parse(txtEmpleado.Text);
            datos = dbe.ConsultarPuesto(obj);
            lblPuesto.Text = datos.Rows[0]["puesto"].ToString();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //cargarPuesto();
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            if(txtEmpleado.Text=="")
            {

            }
            else
            {
                cargarPuesto();
            }
            
        }

        private void txtEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    
}
