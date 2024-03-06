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

namespace PuntoVentaV2.Gerencia
{
    public partial class FRM_GER_AddProductos : Form
    {
        public FRM_GER_AddProductos()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            dbProducto database = new dbProducto();
            ClassProducto obj = new ClassProducto();

            if (txtNombre.Text != "")
            {
                obj.Nombre = txtNombre.Text;
                obj.Precio = float.Parse(txtPrecio.Text);

                DataTable datos = new DataTable();
                datos = database.ConsultarCodigo(obj);
                if (datos.Rows.Count > 0)
                {
                    // MessageBox.Show("El registro ya existe","Sistema");

                    ALT_RegistroYaExiste registroYaExiste = new ALT_RegistroYaExiste();
                    registroYaExiste.Show();


                }
                else
                {
                    if (txtNombre.Text != "" && txtPrecio.Text != "")
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
            else
            {
                ALT_FaltaCapturar faltaCapturar = new ALT_FaltaCapturar();
                faltaCapturar.Show();
            }

        }

        private void Limpiar()
        {
            txtNombre.Text = null;
            txtPrecio.Text = null;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FRM_GER_Menu frmEmp = new FRM_GER_Menu();
            frmEmp.Visible = true;
            this.Visible = false;
        }
    }
}
