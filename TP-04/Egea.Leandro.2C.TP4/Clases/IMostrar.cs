using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public interface IMostrar<T>
        //que significa el logo ese
    {
        string MostrarDatos(IMostrar<T> elemento);
    }
}
