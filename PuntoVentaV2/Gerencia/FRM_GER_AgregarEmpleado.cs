using PuntoVentaV2.Alertas;
using PuntoVentaV2.Alertas.CustomMessageBox;
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
    public partial class FRM_GER_AgregarEmpleado : Form
    {
        private string asd;
        public FRM_GER_AgregarEmpleado()
        {
            InitializeComponent();
            
        }
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            dbEmpleado database = new dbEmpleado();
            ClassEmpleado obj = new ClassEmpleado();
            obj.Nombre = txtNombre.Text;
            obj.aPaterno = txtApPaterno.Text;
            obj.aMaterno = txtApMaterno.Text;
            obj.Curp = txtCURP.Text;
            obj.Puesto = int.Parse(cmbPuesto.SelectedValue.ToString());
            obj.Telefono = txtNumTel.Text;
            asd = cmbPuesto.Text;

            DataTable datos = new DataTable();
            datos = database.ConsultarCodigoH(obj);
            if (datos.Rows.Count > 0)
            {
                // MessageBox.Show("El registro ya existe","Sistema");

                ALT_RegistroYaExiste registroYaExiste = new ALT_RegistroYaExiste();
                registroYaExiste.Show();


            }
            else
            {
                if (txtNombre.Text != "" && txtApPaterno.Text != "" && txtApMaterno.Text != "" && txtCURP.Text != "" && txtNumTel.Text != "" && cmbPuesto.Text != "")
                {
                    database.Agregar(obj);

                    //  MessageBox.Show("Se realizo la inserccion con exito", "Sistema");

                    ALT_Incersion Incersion = new ALT_Incersion();
                    Incersion.Show();


                    Limpiar();
                }
                else
                {
                    // MessageBox.Show("Falta capturar informacion","Sistema");

                    // Saldra un mensaje
                    ALT_FaltaCapturar faltaCapturar = new ALT_FaltaCapturar();
                    faltaCapturar.Show();


                }
            }
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FRM_GER_Empleados frmEmp = new FRM_GER_Empleados();
            frmEmp.Visible = true;
            this.Visible = false;
        }
        private void txtNumTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtApPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtApMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        private void Limpiar()
        {
            txtNombre.Text = null;
            txtApPaterno.Text = null;
            txtApMaterno.Text = null;
            txtCURP.Text = null;
            txtNumTel.Text = null;
            cmbPuesto.Text = null;
        }
        private void cargarCombo()
        {
            cmbPuesto.Text = "Selecciona una opcion";
            dbEmpleado db = new dbEmpleado();

            cmbPuesto.DataSource = db.Consultar("puesto");
            cmbPuesto.DisplayMember = "nombre";
            cmbPuesto.ValueMember = "idPuesto";
        }

        private void FRM_GER_AgregarEmpleado_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }
    }
}
