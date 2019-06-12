using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        //delegado

        public string direccionEntrega;
        public EEstado estado;
        public string trackingID;
        //evento

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
            throw new NotImplementedException(); //TODO
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
