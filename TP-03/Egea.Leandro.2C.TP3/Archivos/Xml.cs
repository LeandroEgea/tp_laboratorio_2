using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda datos en un archivo .xml .
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se guarda</param>
        /// <param name="datos">Los datos que se van a guardar</param>
        /// <returns>Devuelve true si salio todo correctamente. Throws ArchivosException.</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            try
            {
                ser.Serialize(writer, datos);
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
        /// Lee un archivo .xml para extraer sus datos.
        /// </summary>
        /// <param name="archivo">Ruta del archivo donde se lee</param>
        /// <param name="datos">Parametro de salida que devuelve los datos</param>
        /// <returns>Devuelve true si salio todo bien. Throws ArchivosException.</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = new XmlTextReader(archivo);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            try
            {
                datos = (T)ser.Deserialize(reader);
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
