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

        /// <summary>
        /// Realiza la operacion entre el txtNumero1 y el txtNumero2 con el operador de cmbOperador
        /// Mostrando el resultado en lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double numero = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            this.lblResultado.Text = numero.ToString();
            popUpResultado();
        }

        /// <summary>
        /// Realiza el calculo de dos numeros
        /// </summary>
        /// <param name="numero1">Primer argumento de la operacion</param>
        /// <param name="numero2">Segundo argumento de la operacion</param>
        /// <param name="operador">Indica la operacion entre los numeros</param>
        /// <returns>Resultado de la operacion</returns>
        private double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
        }
        
        /// <summary>
        /// Llama al metodo que se encarga de dejar el form tras inicializar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Deja el form como al inicializar
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "0";
        }

        /// <summary>
        /// Cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Convierte lo que se encuentre en lblResultado a binario y sobreescribe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Numero().DecimalBinario(this.lblResultado.Text);
            popUpResultado();
        }

        /// <summary>
        /// Convierte lo que se encuentre en lblResultado a decimal y sobreescribe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = new Numero().BinarioDecimal(this.lblResultado.Text);
            popUpResultado();
        }


        /// <summary>
        /// Si el resultado es demasiado largo se muestra en un Dialog
        /// </summary>
        private void popUpResultado()
        {
            if (this.lblResultado.Width > this.Width)
            {
                MessageBox.Show(this.lblResultado.Text);
            }
        }
    }
}
