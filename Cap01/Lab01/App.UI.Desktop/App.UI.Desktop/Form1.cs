using App.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           label1.Text=
                ConfigurationManager.AppSettings["IGV"].ToString();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Documento documento = new Factura();
            documento.Total = 
                Convert.ToDecimal(txtTotal.Text);

            documento.onDespuesCalcular 
                += new Entities.Events.Listeners.DespuesCalcular(MostrarDatos);

            documento.Calcular();

            
        }

        private void MostrarDatos(object obj)
        {
            var documento = (Factura)obj;
            lblTotal.Text = documento.Total.ToString();
            lblIGV.Text = ((Factura)documento).IGV.ToString();
            lblSubTotal.Text = ((Factura)documento).SubTotal.ToString();
        }
    }
}
