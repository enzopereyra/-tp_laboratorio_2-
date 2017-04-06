using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculadora;
using Numero;


namespace TP1.Pereyra.Enzo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbOperacion.Text = "+";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperacion.Text = "+";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero.Numero numero1 = new Numero.Numero(txtNumero1.Text);
            Numero.Numero numero2 = new Numero.Numero(txtNumero2.Text);
            string operador = cmbOperacion.Text;

            double resultado = Calculadora.Calculadora.operar(numero1, numero2, operador);

            lblResultado.Text = resultado.ToString();

            if ( (numero2 == 0)  && (operador == "/"))
            {
                MessageBox.Show("No se puede dividir entre cero", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
