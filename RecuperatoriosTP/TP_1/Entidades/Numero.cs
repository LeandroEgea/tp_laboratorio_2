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
        /// <param name="strNumero">Numero a guardar en forma de string</param>
        public Numero(string strNumero)
        {
            this.SetNumero(strNumero);
        }

        /// <summary>
        /// Guarda el numero tras una validacion
        /// </summary>
        /// <param name="strNumero">Numero a settear en forma de string</param>
        private void SetNumero(string strNumero)
        {
            this.numero = ValidarNumero(strNumero);
        }

        /// <summary>
        /// Comprueba que el valor recibido sea un numero
        /// </summary>
        /// <param name="strNumero">Es el numero en forma de string sobre el que se realiza la validacion</param>
        /// <returns>Devuelve el numero validado, si no es valido, se devuelve un 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double doubleNumero;
            try
            {
                double.TryParse(strNumero, out doubleNumero);
                return doubleNumero;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convierte un binario positivo y entero en un decimal
        /// </summary>
        /// <param name="binario">Numero binario a convertir</param>
        /// <returns>Devuelve un numero decimal en forma de string, o "Valor Invalido" si no se puede realizar la conversion</returns>
        public string BinarioDecimal(string binario)
        {
            if (Regex.Match(binario, "[^01]").Success)
                return "Valor Invalido";

            char[] arrayBinario = binario.ToCharArray();
            Array.Reverse(arrayBinario);
            double numero = 0;
            for (int i = 0; i < arrayBinario.Length; i++)
            {
                if (arrayBinario[i] == '1')
                {
                    if (i == 0)
                    {
                        numero += 1;
                    }
                    else
                    {
                        numero += Math.Pow(2, i);
                    }
                }
            }
            return numero.ToString();
        }

        /// <summary>
        /// Convierte un decimal positivo y entero en un binario
        /// </summary>
        /// <param name="numero">Numero decimal a convertir</param>
        /// <returns>Devuelve un numero binario en forma de string</returns>
        public string DecimalBinario(double numero)
        {
            numero = Math.Abs(Math.Floor(numero));
            string binario = "";
            for (int i = 0; numero > 0; i++)
            {
                binario += (numero % 2).ToString();
                numero = Math.Floor(numero / 2);
            }
            if (binario.Equals(""))
                binario = "0";
            char[] arrayBinario = binario.ToCharArray();
            Array.Reverse(arrayBinario);
            return new string(arrayBinario);
        }

        /// <summary>
        /// Convierte un decimal en forma de string en un binario
        /// </summary>
        /// <param name="numero">Numero decimal a convertir</param>
        /// <returns>Devuelve un numero binario en forma de string, o "Valor Invalido" si no se puede realizar la conversion</returns>
        public string DecimalBinario(string numero)
        {
            this.SetNumero(numero);// SetNumero es el unico metodo donde se debe validar segun la consigna
            if (numero != "0" && this.numero == 0)
                return "Valor Invalido";
            return DecimalBinario(this.numero);
        }

        /// <summary>
        /// Suma los atributos numero de dos Numero
        /// </summary>
        /// <param name="n1">Primer Sumando</param>
        /// <param name="n2">Segundo Sumando</param>
        /// <returns>La suma de ambos</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta los atributos numero de dos Numero
        /// </summary>
        /// <param name="n1">Minuendo</param>
        /// <param name="n2">Sustraendo</param>
        /// <returns>La resta de ambos</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica los atributos numero de dos Numero
        /// </summary>
        /// <param name="n1">Primer Factor</param>
        /// <param name="n2">Segundo Factor</param>
        /// <returns>La multiplicacion de ambos</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Multiplica los atributos numero de dos Numero
        /// </summary>
        /// <param name="n1">Dividendo</param>
        /// <param name="n2">Divisor</param>
        /// <returns>La division de ambos</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
                return double.MinValue;
            return n1.numero / n2.numero;
        }
    }
}
