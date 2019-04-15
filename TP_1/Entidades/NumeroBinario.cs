using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    class NumeroBinario
    {
        /// <summary>
        /// El numero binario que se aloja en la entidad
        /// </summary>
        private string numero;

        /// <summary>
        /// Constructor que guarda el numero tras una validacion
        /// </summary>
        /// <param name="numero">Numero a guardar</param>
        private NumeroBinario(string numero)
        {
            if (Regex.Match(numero, "[^01]").Success)
                this.numero = "0";
            this.numero = numero;
        }

        public static implicit operator NumeroBinario(string numero)
        {
            return new NumeroBinario(numero);
        }

        public static explicit operator string(NumeroBinario numeroBinario)
        {
            return numeroBinario.numero;
        }

        public static NumeroBinario operator +(NumeroBinario numeroBinario, NumeroDecimal numeroDecimal)
        {
            NumeroDecimal decim = numeroDecimal + numeroBinario;
            return Conversor.DecimalBinario(decim);
        }

        public static bool operator ==(NumeroBinario numeroBinario, NumeroDecimal numeroDecimal)
        {
            return numeroBinario.numero == Conversor.DecimalBinario(numeroDecimal).numero;
        }

        public static bool operator !=(NumeroBinario numeroBinario, NumeroDecimal numeroDecimal)
        {
            return !(numeroBinario == numeroDecimal);
        }
    }
}