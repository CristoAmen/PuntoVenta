using PuntoVentaV2.Alertas;
using PuntoVentaV2.Alertas.ALT_GERENTE;
using PuntoVentaV2.Alertas.CustomMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PuntoVentaV2.Gerencia
{
    public partial class FRM_GER_AgregarUsuario : Form
    {
        public FRM_GER_AgregarUsuario()
        {
            InitializeComponent();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            dbUsuario database = new dbUsuario();
            ClassUsuario obj = new ClassUsuario();
            if (txtNewPass.Text == txtRepPass.Text)
            {
                if(cmbUsuario.Text!="")
                {
                    obj.Password = txtNewPass.Text;
                    obj.Id = int.Parse(cmbUsuario.SelectedValue.ToString());
                    obj.Puesto = int.Parse(lblPuesto.Text);

                    DataTable datos = new DataTable();
                    datos = database.ConsultarCodigo(obj);
                    if (datos.Rows.Count > 0)
                    {
                        // MessageBox.Show("El registro ya existe", "Sistema");


                        ALT_RegistroYaExiste registroYaExiste = new ALT_RegistroYaExiste();
                        registroYaExiste.Show();
                    }
                    else
                    {

                        if (txtNewPass.Text != "" && txtRepPass.Text != "")
                        {
                            database.Agregar(obj);
                            // MessageBox.Show("Se realizo la inserccion con exito", "Sistema");
                            ALT_Incersion Incersion = new ALT_Incersion();
                            Incersion.Show();

                            limpiar();
                        }
                        else
                        {
                            // MessageBox.Show("Falto capturar informacion", "Sistema");
                            ALT_FaltaCapturar faltaCapturar = new ALT_FaltaCapturar();
                            faltaCapturar.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Valor invalido","Sistema");
                }
                
            }
            else
            {
                //  MessageBox.Show("La contraseña no coincide");
                ALT_ContrasenaNoCoincide contrasenaNoCoincide = new ALT_ContrasenaNoCoincide();
                contrasenaNoCoincide.Show();
            }
        }
        private void FRM_GER_AgregarUsuario_Load(object sender, EventArgs e)
        {
            if(cmbUsuario.Text != "")
            {
                cargarPuesto();
            }
            cargarComboE();
        }
        private void cargarComboE()
        {
            cmbUsuario.Text = "Selecciona una opcion";
            dbUsuario db = new dbUsuario();

            cmbUsuario.DataSource = db.Consultar("usuario");
            cmbUsuario.DisplayMember = "idEmpleado";
            cmbUsuario.ValueMember = "idEmpleado";
        }
        private void cargarPuesto()
        {
            dbEmpleado dbe = new dbEmpleado();
            ClassEmpleado obj = new ClassEmpleado();
            DataTable datos = new DataTable();

            obj.Id = int.Parse(cmbUsuario.SelectedValue.ToString());
            datos = dbe.ConsultarPuesto(obj);
            lblPuesto.Text = datos.Rows[0]["puesto"].ToString();
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FRM_GER_Empleados frmEmp = new FRM_GER_Empleados();
            frmEmp.Visible = true;
            this.Visible = false;
        }
        private void limpiar()
        {
            txtNewPass.Text = null;
            txtRepPass.Text = null;
        }
        private void txtNewPass_Click_1(object sender, EventArgs e)
        {
            if (cmbUsuario.Text != "")
            {
                cargarPuesto();
            }
        }
    }
}
