using MySql.Data.MySqlClient;
using PuntoVentaV2.Cajero.Clase_Con;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace PuntoVentaV2.Cajero
{
    public partial class TarjetaIn : Form
    {
        DateTime fechahoy = DateTime.Now.Date;
        private CAJ_Interfaz formularioPrincipal;
        CAJ_Interfaz x = new CAJ_Interfaz();
        Conexion conx = new Conexion();
        CAJ_MetodoPago v = new CAJ_MetodoPago();
        public TarjetaIn()
        {
            InitializeComponent();
        }

        public partial class FormularioSecundario : Form
        {
            public FormularioSecundario(CAJ_Interfaz form)
            {

            }
        }


        private void TarjetaIn_Load(object sender, EventArgs e)
        {

        }
        public string ValorTextBoxG
        {
            get { return x.TotalC.Text; }
            set { x.TotalC.Text = value; }
        }
        public string NombresG { get; set; }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int num = rnd.Next(10);
            if (cvv.MaskFull)
            {
                CAJ_Interfaz n = new CAJ_Interfaz();
                if (num >= 1)
                {
                    float b = float.Parse(ValorTextBoxG);
                    string orden = "Insert into ticket(precio,lista) values(" + b + ",'" + NombresG + "');";
                    MySqlCommand comm = new MySqlCommand(orden, conx.establecerCon());
                    comm.ExecuteNonQuery();

                    x.Compra();

                    CAJ_TarjetaAprobada newForm = new CAJ_TarjetaAprobada();
                    newForm.Show();
                    this.Close();

                }
                else
                {
                    
                    cvv.Text = "";
                    CAJ_TarjetaRechazada newForm = new CAJ_TarjetaRechazada();
                    newForm.Show();
                }
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}