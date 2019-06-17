using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clases
{
    public delegate void DelegadoEstado();//object y eventargs

    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public string direccionEntrega;
        public EEstado estado;
        public string trackingID;

        public event DelegadoEstado InformaEstado;

        public string DireccionEntrega
        {
            get
            {
                return direccionEntrega;
            }
            set
            {
                direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return trackingID;
            }
            set
            {
                trackingID = value;
            }
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            DireccionEntrega = direccionEntrega;
            TrackingID = trackingID;
        }

        public void MockCicloDeVida()
        {
            if(Estado.Equals(EEstado.Ingresado))
            {
                Thread.Sleep(4000);
                Estado = EEstado.EnViaje;
            }
            if (Estado.Equals(EEstado.EnViaje))
            {
                Thread.Sleep(4000);
                Estado = EEstado.EnViaje;
            }
            //guardar
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            throw new NotImplementedException(); //TODO
            //return String.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        public override string ToString()
        {
            throw new NotImplementedException(); //TODO
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID.Equals(p2.TrackingID);
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
    }
}
