using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero() : this(0)
        {
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.SetNumero(numero);
        }

        private void SetNumero(string numero)
        {
            this.numero = ValidarNumero(numero);
        }

        private double ValidarNumero(string numero)
        {
            double doubleNumero;
            try
            {
                double.TryParse(numero, out doubleNumero);
                return doubleNumero;
            }
            catch
            {
                return 0;
            }
        }

        public string BinarioDecimal(string binario)
        {
            if (Regex.Match(binario, "[^01]").Success)
                return "Valor Invalido";
            this.SetNumero(binario);
            NumeroBinario numeroBinario = (TomarEnteroPositivo(this.numero)).ToString();
            return ((double)Conversor.BinarioDecimal(numeroBinario)).ToString();
        }

        public string DecimalBinario(double numero)
        {
            NumeroDecimal numeroDecimal = (TomarEnteroPositivo(numero));
            return (string)Conversor.DecimalBinario(numeroDecimal);
        }

        public string DecimalBinario(string numero)
        {
            this.SetNumero(numero);
            if (numero != "0" && this.numero == 0)
                return "Valor Invalido";
            return DecimalBinario(this.numero);
        }

        private double TomarEnteroPositivo(double numero)
        {
            return Math.Abs(Math.Floor(numero));
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        public static bool operator ==(Numero n1, Numero n2)
        {
            return n1.numero == n2.numero;
        }

        public static bool operator !=(Numero n1, Numero n2)
        {
            return !(n1 == n2);
        }
    }
}
