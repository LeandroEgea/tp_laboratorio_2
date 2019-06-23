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
            mockPaquetes = new List<Thread>();
            Paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {
            foreach (Thread hilo in mockPaquetes)
            {
                if (hilo.IsAlive)
                    hilo.Abort();
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete paquete in ((Correo)elementos).Paquetes)
            {
                sb.AppendFormat("{0} para {1} ({2})", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (p == paquete)
                {
                    string message = String.Format("El tracking ID {0} ya figura en la lista de envios", p.TrackingID);
                    throw new TrackingIdRepetidoException(message);
                }
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();
            return c;
        }
    }
}
