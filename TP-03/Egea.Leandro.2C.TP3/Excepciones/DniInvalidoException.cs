using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Mensaje por defecto
        /// </summary>
        private static string mensajeBase = "El DNI no es válido.";

        /// <summary>
        /// Mensaje por defecto
        /// </summary>
        public DniInvalidoException() : base(mensajeBase)
        {

        }

        /// <summary>
        /// Mensaje por defecto
        /// </summary>
        public DniInvalidoException(Exception e) : base(mensajeBase, e)
        {

        }

        public DniInvalidoException(string message) : base(message)
        {

        }

        public DniInvalidoException(string message, Exception e) : base(message, e)
        {

        }
    }
}
