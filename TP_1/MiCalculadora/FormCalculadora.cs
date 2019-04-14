using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double numero = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            this.lblResultado.Text = numero.ToString();
            popUpResultado();
        }

        private double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "0";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numero = new Numero().DecimalBinario(this.lblResultado.Text);
            this.lblResultado.Text = numero;
            popUpResultado();
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numero = new Numero().BinarioDecimal(this.lblResultado.Text);
            this.lblResultado.Text = numero.ToString();
            popUpResultado();
        }

        private void popUpResultado()
        {
            if (this.lblResultado.Text.Length > 28)
            {
                Form resultado = new Resultado(this.lblResultado.Text);
                resultado.ShowDialog();
            }
        }
    }
}
