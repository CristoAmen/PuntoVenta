using PuntoVentaV2.Alertas.CustomMessageBox;
using PuntoVentaV2.Alertas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoVentaV2.Alertas.ALT_GERENTE;

namespace PuntoVentaV2.Gerencia.Dar_de_Baja
{
    public partial class FRM_GER_DarBajaEmpleado : Form
    {
        public FRM_GER_DarBajaEmpleado()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbUsuario database = new dbUsuario();
            ClassUsuario obj = new ClassUsuario();

            if (cmbEmpleado.Text != "")
            {
                obj.Id = int.Parse(cmbEmpleado.SelectedValue.ToString());

                DataTable datos = new DataTable();
                datos = database.ConsultarCodigo(obj);
                if (datos.Rows.Count > 0)
                {
                    DialogResult res;
                    res = MessageBox.Show("Este empleado tiene registrado una cuenta de usuario, desea eliminarla?", "Sistema",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                    if (res == DialogResult.Yes)
                    {
                        dbEmpleado database2 = new dbEmpleado();
                        ClassEmpleado obj2 = new ClassEmpleado();

                        database2.DesactivarFK();
                        obj.Id = int.Parse(cmbEmpleado.SelectedValue.ToString());
                        obj2.Id = int.Parse(cmbEmpleado.SelectedValue.ToString());
                        DataTable dato = new DataTable();
                        database2.EliminarE(obj2);
                        database.EliminarU(obj);

                        // MessageBox.Show("Se elimino con exito", "Sistema");

                        //Saldra un mensaje
                        ALT_SeEliminoConExito seEliminoConExito = new ALT_SeEliminoConExito();
                        seEliminoConExito.Show();

                        database2.ActivarFK();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else
                {
                    dbEmpleado database2 = new dbEmpleado();
                    ClassEmpleado obj2 = new ClassEmpleado();

                    tCombo.Start();
                    database2.DesactivarFK();
                    obj2.Id = int.Parse(cmbEmpleado.SelectedValue.ToString());
                    DataTable dato = new DataTable();
                    database2.EliminarE(obj2);

                   // MessageBox.Show("Se elimino con exito", "Sistema");

                    //Saldra un mensaje
                    ALT_SeEliminoConExito seEliminoConExito = new ALT_SeEliminoConExito();
                    seEliminoConExito.Show();

                    database2.ActivarFK();
                    tCombo.Stop();
                }
            }
            else
            {
                //MessageBox.Show("Seleccion no valida", "Sistema");

                //Saldra un mensaje
                ALT_SeleccionNoValida seleccionNoValida = new ALT_SeleccionNoValida();
                seleccionNoValida.Show();


            }

        }
        private void FRM_GER_DarBajaEmpleado_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }
        private void cargarCombo()
        {
            cmbEmpleado.Text = "Selecciona una opcion";
            dbUsuario db = new dbUsuario();

            cmbEmpleado.DataSource = db.Consultar("empleado");
            cmbEmpleado.DisplayMember = "idEmpleado";
            cmbEmpleado.ValueMember = "idEmpleado";
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FRM_GER_DarBaja frmEmp = new FRM_GER_DarBaja();
            frmEmp.Visible = true;
            this.Visible = false;
        }

        private void FRM_GER_DarBajaEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void tCombo_Tick(object sender, EventArgs e)
        {
            cargarCombo();
        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {

        }
    }
}
