using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        private static StreamWriter sw;

        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo;
                sw = new StreamWriter(path, true);
                sw.WriteLine(texto);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Se produjo un error al intentar guardar el archivo", e);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
