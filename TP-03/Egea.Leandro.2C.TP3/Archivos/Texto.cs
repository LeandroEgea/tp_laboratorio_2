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
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter writer = new StreamWriter(archivo, true);
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
