using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Guarda datos en un archivo.
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se guarda</param>
        /// <param name="datos">Los datos que se van a guardar</param>
        /// <returns>Devuelve true si salio todo correctamente.</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee un archivo para extraer sus datos.
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se lee</param>
        /// <param name="datos">Parametro de salida que devuelve los datos</param>
        /// <returns>Devuelve true si salio todo bien.</returns>
        bool Leer(string archivo, out T datos);
    }
}
