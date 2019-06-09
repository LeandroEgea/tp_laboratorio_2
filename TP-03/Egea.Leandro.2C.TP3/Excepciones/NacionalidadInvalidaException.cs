using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// message "La nacionalidad no es válida."
        /// </summary>
        public NacionalidadInvalidaException() : base("La nacionalidad no es válida.")
        {

        }

        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
    }
}
