using MySql.Data.MySqlClient;
using PuntoVentaV2.Alertas;
using PuntoVentaV2.Alertas.ALT_CAJERO;
using PuntoVentaV2.Cajero.Clase_Con;
using PuntoVentaV2.Gerencia;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;

namespace PuntoVentaV2.Cajero
{
    public partial class CAJ_Interfaz : Form
    {
        public float suma = 0;
        public DataTable dtProductos = new DataTable();
        public List<string> a = new List<string>();
        public string nombresConcatenados;

        public CAJ_Interfaz()
        {
            InitializeComponent();

            a = new List<string>();
            dtProductos.Columns.Add("ID");
            dtProductos.Columns.Add("Nombre");
            dtProductos.Columns.Add("Precio");
            DattaGrid.DataSource = dtProductos;
        }
        public string valor { get; set; }
        public static class DatosCompartidos
        {
            public static string Empleado { get; set; }
        }
        private void CAJ_Interfaz_Load(object sender, EventArgs e)
        {
            idEmp.Text = DatosCompartidos.Empleado.ToString();
            AgregarP.Focus();
        }

        private void AgregarProd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if ((string.IsNullOrEmpty(AgregarP.Text)))
                {
                    // MessageBox.Show("Tiene que poner el id del producto para agregarlo");

                    ALT_NoHayID noHayID = new ALT_NoHayID();
                    noHayID.Show();
                }
                else
                {
                    joder();

                    AgregarP.Text = "";
                    ObtenerNombresDesdeDataGridView();
                }
            }
        }
        public List<string> ObtenerNombresDesdeDataGridView()
        {
            List<string> nombres = new List<string>();

            foreach (DataGridViewRow fila in DattaGrid.Rows)
            {
                if (fila.Cells.Count >= 1)
                {
                    string segundoValor = fila.Cells[1].Value.ToString();
                    nombres.Add(segundoValor);

                    nombresConcatenados = string.Join(", ", nombres);
                }
            }

            return nombres;
        }

        public void act(string nuevoT)
        {
            TotalC.Text = nuevoT;
        }
        public void joder()
        {
            Conexion conx = new Conexion();
            string idProducto = AgregarP.Text;


            //Aqui solamente se hace la orden de que se necesesita de la Base de datos, chupas.
            string orden = "SELECT * FROM producto WHERE ID=" + AgregarP.Text + "";
            MySqlDataAdapter adapter = new MySqlDataAdapter(orden, conx.establecerCon());
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            MySqlCommand comm = new MySqlCommand(orden, conx.establecerCon());
            DattaGrid.DataSource = dt;
            MySqlDataReader comm2;
            comm2 = comm.ExecuteReader();


            if (comm2.HasRows == true)
            {
                TotalC.Text = DattaGrid.SelectedCells[2].Value.ToString();

                float v = float.Parse(TotalC.Text);
                suma = suma + v;
                TotalC.Text = suma.ToString();

                dtProductos.Rows.Add(DattaGrid.SelectedCells[0].Value, DattaGrid.SelectedCells[1].Value, DattaGrid.SelectedCells[2].Value);
                DattaGrid.DataSource = dtProductos;
                MetPa.Enabled = true;

            }
            else
            {
                ProductoNoEncontrado productoNoEncontrado = new ProductoNoEncontrado();
                productoNoEncontrado.Show();
                DattaGrid.DataSource = dtProductos;
            }

            conx.cerrar();
        }
        private void RCompra_Click(object sender, EventArgs e)
        {
            MessageBox.Show(valor);
        }
        public void Compra()
        {

            TotalC.Text = "";

            if (DattaGrid.Rows.Count >= 1)
            {
                DattaGrid.Rows.RemoveAt(DattaGrid.Rows.Count - 1);
            }
            a.Clear();
            dtProductos.Clear();
            DattaGrid.DataSource = dtProductos;

            suma = suma - suma;
            TotalC.Text = suma.ToString();
            MetPa.Enabled = false;
        }

        private void deleteA_Click(object sender, EventArgs e)
        {
            if (DattaGrid.SelectedRows.Count > 0)
            {
                float precio = Convert.ToSingle(DattaGrid.SelectedRows[0].Cells[2].Value);
                suma = suma - precio;

                TotalC.Text = suma.ToString();
                DattaGrid.Rows.RemoveAt(DattaGrid.SelectedRows[0].Index);
            }
            else
            {
                ALT_FilasEliminar noHayFilas = new ALT_FilasEliminar();
                noHayFilas.Show();
            }

        }

        private void MetPa_Click(object sender, EventArgs e)
        {

            List<string> nombres = new List<string>();
            foreach (DataGridViewRow fila in DattaGrid.Rows)
            {

                if (fila.Cells.Count >= 1)
                {
                    string segundoValor = fila.Cells[1].Value.ToString();
                    nombres.Add(segundoValor);
                }
            }
            string nombresConcatenados = string.Join(", ", nombres);


            CAJ_MetodoPago otroForm = new CAJ_MetodoPago();
            otroForm.Nombres = nombresConcatenados;
            otroForm.ValorTextBox = TotalC.Text;

            otroForm.Show();
            this.Hide();
        }

        private void AgregarP_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login n = new Login();
            n.Show();
            this.Hide();
        }

        private void AgregarP_TextChanged(object sender, EventArgs e)
        {

        }

        private void idEmp_Click(object sender, EventArgs e)
        {

        }
    }
}
