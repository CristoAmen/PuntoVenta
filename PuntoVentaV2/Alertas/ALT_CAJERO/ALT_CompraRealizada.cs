﻿using PuntoVentaV2.Cajero;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoVentaV2.Alertas.ALT_CAJERO
{
    public partial class ALT_CompraRealizada : Form
    {
        public ALT_CompraRealizada()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.CenterToScreen();
        }

        private void ALT_CompraRealizada_Load(object sender, EventArgs e)
        {
           // lblCompra.Text = "La compra realizada fue de $" + TotalC.Text + ", gracias:)";
        }

        private void lblCompra_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            CAJ_Interfaz frm = new CAJ_Interfaz();
            frm.Show();
        }
    }
}
