using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// message "Se produjo un error con el archivo."
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException) : base("Se produjo un error con el archivo.", innerException)
        {

        }
    }
}
