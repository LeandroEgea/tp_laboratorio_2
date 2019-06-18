using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return paquetes;
            }
            set
            {
                paquetes = value;
            }
        }

        public Correo()
        {
            mockPaquetes = new List<Thread>(); //???
            Paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {
            throw new NotImplementedException(); //TODO FinEntregas cerrará todos los hilos activos.
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            //StringBuilder sb = new StringBuilder();
            //foreach(Paquete paquete in elementos)
            //{
            //    sb.AppendFormat("{0} para {1} ({2})", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());
            //}
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //String.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            throw new NotImplementedException(); //TODO
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (p == paquete)
                    throw new TrackingIdRepetidoException(""); //TODO message
            }
            c.Paquetes.Add(p);
            return c;
            //c.Crear un hilo para el método MockCicloDeVida del paquete, y agregar dicho hilo a mockPaquetes.
            //d.Ejecutar el hilo.
        }
    }
}
