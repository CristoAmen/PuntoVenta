using MySql.Data.MySqlClient;
using PuntoVentaV2.Alertas.ALT_CAJERO;
using PuntoVentaV2.Cajero.Clase_Con;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Schema;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PuntoVentaV2.Cajero
{
    public partial class CAJ_MetodoPago : Form
    {
        CAJ_Interfaz v = new CAJ_Interfaz();
        Conexion conx = new Conexion();
        public CAJ_MetodoPago()
        {
            InitializeComponent();
        }
        public void CAJ_MetodoPago_Load(object sender, EventArgs e)
        {
        }
        public static string fomr2T;

        public string ValorTextBox
        {
            get { return v.TotalC.Text; }
            set { v.TotalC.Text = value; }
        }
        public string Nombres { get; set; }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            string valorRecibido = ValorTextBox;
            float b = float.Parse(valorRecibido);
            CAJ_Interfaz rm = new CAJ_Interfaz();

            string orden = "Insert into ticket(precio,lista) values(" + b + ",'" + Nombres + "');";
            MySqlCommand comm = new MySqlCommand(orden, conx.establecerCon());
            comm.ExecuteNonQuery();

            rm.Compra();
            ALT_CompraRealizada xc = new ALT_CompraRealizada();
            xc.Show();
            
            this.Close();
        }
        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            TarjetaIn n = new TarjetaIn();
            n.ValorTextBoxG = ValorTextBox;
            n.NombresG = Nombres;
            n.Show();
            this.Close();
        }
    }
}
