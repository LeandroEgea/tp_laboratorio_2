using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Conversor
    {
        /// <summary>
        /// Convierte un binario en un decimal
        /// </summary>
        /// <param name="binario">Numero binario a convertir</param>
        /// <returns>Devuelve un numero decimal</returns>
        public static NumeroDecimal BinarioDecimal(NumeroBinario binario)
        {
            char[] arrayBinario = ((string)binario).ToCharArray();
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
            return numero;
        }

        /// <summary>
        /// Convierte un decimal en un binario
        /// </summary>
        /// <param name="numeroDecimal">Numero decimal a convertir</param>
        /// <returns>Devuelve un numero binario</returns>
        public static NumeroBinario DecimalBinario(NumeroDecimal numeroDecimal)
        {
            double numero = (double)numeroDecimal;
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
    }
}
