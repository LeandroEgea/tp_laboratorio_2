using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda datos en un archivo de texto (.txt).
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se guarda</param>
        /// <param name="datos">Los datos que se van a guardar</param>
        /// <returns>Devuelve true si salio todo correctamente. Throws ArchivosException.</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter writer = new StreamWriter(archivo, false);
            try
            {
                writer.WriteLine(datos);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                writer.Close();
            }
        }

        /// <summary>
        /// Lee un archivo de texto (.txt) para extraer sus datos.
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se lee</param>
        /// <param name="datos">Parametro de salida que devuelve los datos</param>
        /// <returns>Devuelve true si salio todo bien. Throws ArchivosException.</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader reader = new StreamReader(archivo, Encoding.UTF8);
            try
            {
                datos = reader.ReadToEnd();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
