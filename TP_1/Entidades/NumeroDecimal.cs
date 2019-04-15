using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class NumeroDecimal
    {
        /// <summary>
        /// El numero decimal que se aloja en la entidad
        /// </summary>
        private double numero;

        /// <summary>
        /// Constructor que guarda el numero
        /// </summary>
        /// <param name="numero">Numero a guardar</param>
        private NumeroDecimal(double numero)
        {
            this.numero = numero;
        }

        public static implicit operator NumeroDecimal(double numero)
        {
            return new NumeroDecimal(numero);
        }

        public static explicit operator double(NumeroDecimal numeroDecimal)
        {
            return numeroDecimal.numero;
        }

        public static NumeroDecimal operator +(NumeroDecimal numeroDecimal, NumeroBinario numeroBinario)
        {
            return new NumeroDecimal((double)numeroDecimal + (double)Conversor.BinarioDecimal(numeroBinario));
        }

        public static NumeroDecimal operator -(NumeroDecimal numeroDecimal, NumeroBinario numeroBinario)
        {
            return new NumeroDecimal((double)numeroDecimal - (double)Conversor.BinarioDecimal(numeroBinario));
        }

        public static bool operator ==(NumeroDecimal numeroDecimal, NumeroBinario numeroBinario)
        {
            return numeroDecimal.numero == Conversor.BinarioDecimal(numeroBinario).numero;
        }

        public static bool operator !=(NumeroDecimal numeroDecimal, NumeroBinario numeroBinario)
        {
            return !(numeroDecimal == numeroBinario);
        }
    }
}
