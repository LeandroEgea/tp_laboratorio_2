using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{

    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoSQLException(Exception e);
        public event DelegadoEstado InformaEstado;
        public event DelegadoSQLException InformaSQLException;

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
            Estado = EEstado.Ingresado;
            DireccionEntrega = direccionEntrega;
            TrackingID = trackingID;
        }

        public void MockCicloDeVida()
        {
            while (Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                Estado += 1;
                InformaEstado(this, null);
            } 
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                InformaSQLException(e);
            }
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }

        public override string ToString()
        {
            return MostrarDatos(this);
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
