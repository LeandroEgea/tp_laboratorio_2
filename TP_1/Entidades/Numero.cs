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
        /// <summary>
        /// El numero que se aloja en la entidad
        /// </summary>
        private double numero;

        /// <summary>
        /// Constructor por defecto con numero en 0
        /// </summary>
        public Numero() : this(0)
        {
        }

        /// <summary>
        /// Contructor que guarda el numero
        /// </summary>
        /// <param name="numero">Numero a guardar</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que guarda el numero tras una validacion
        /// </summary>
        /// <param name="numero">Numero a guardar</param>
        public Numero(string numero)
        {
            this.SetNumero(numero);
        }

        /// <summary>
        /// Guarda el numero tras una validacion
        /// </summary>
        /// <param name="numero">Numero a settear</param>
        private void SetNumero(string numero)
        {
            this.numero = ValidarNumero(numero);
        }

        /// <summary>
        /// Comprueba que el valor recibido sea un numero
        /// </summary>
        /// <param name="numero">Es el numero sobre el que se realiza la validacion</param>
        /// <returns>Devuelve el numero validado, si no es valido, se devuelve un 0</returns>
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

        /// <summary>
        /// Convierte un binario en un decimal
        /// </summary>
        /// <param name="binario">Numero binario a convertir</param>
        /// <returns>Devuelve un numero decimal en forma de string, o "Valor Invalido" si no se puede realizar la conversion</returns>
        public string BinarioDecimal(string binario)
        {
            if (Regex.Match(binario, "[^01]").Success)
                return "Valor Invalido";
            NumeroBinario numeroBinario = binario;
            return ((double)Conversor.BinarioDecimal(numeroBinario)).ToString();
        }

        /// <summary>
        /// Convierte un decimal en un binario
        /// </summary>
        /// <param name="numero">Numero decimal a convertir</param>
        /// <returns>Devuelve un numero binario en forma de string</returns>
        public string DecimalBinario(double numero)
        {
            NumeroDecimal numeroDecimal = (TomarEnteroPositivo(numero));
            return (string)Conversor.DecimalBinario(numeroDecimal);
        }

        /// <summary>
        /// Convierte un decimal en forma de string en un binario
        /// </summary>
        /// <param name="numero">Numero recibido para convertirlo</param>
        /// <returns>Devuelve un numero binario en forma de string, o "Valor Invalido" si no se puede realizar la conversion</returns>
        public string DecimalBinario(string numero)
        {
            this.SetNumero(numero);
            if (numero != "0" && this.numero == 0)
                return "Valor Invalido";
            return DecimalBinario(this.numero);
        }

        /// <summary>
        /// Se transforma el numero a positivo sacando su parte decimal (-211212.33 -> 211212)
        /// </summary>
        /// <param name="numero">Numero recibido</param>
        /// <returns></returns>
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

        public static bool operator ==(Numero n1, double doubleValue)
        {
            return n1.numero == doubleValue;
        }

        public static bool operator !=(Numero n1, double doubleValue)
        {
            return !(n1 == doubleValue);
        }
    }
}
