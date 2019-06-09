using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Constructor de Universitario
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor de Universitario
        /// </summary>
        /// <param name="legajo">legajo de Universitario</param>
        /// <param name="nombre">nombre de Universitario</param>
        /// <param name="apellido">apellido de Universitario</param>
        /// <param name="dni">apellido de Universitario</param>
        /// <param name="nacionalidad">nacionalidad de Universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Compara 2 universitarios. Son iguales si son del mismo tipo(Type) y tienen el mismo legajo o DNI
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>True si son iguales, false si son distintos</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.GetType().Equals(pg2.GetType()) && (pg1.legajo.Equals(pg2.legajo) || pg1.DNI.Equals(pg2.DNI));
        }

        /// <summary>
        /// Compara 2 universitarios. Son iguales si son del mismo tipo(Type) y tienen el mismo legajo o DNI
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>False si son iguales, true si son distintos</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Datos del Universitario
        /// </summary>
        /// <returns>String con Nombre, nacionalidad y legajo</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("LEGAJO NÚMERO: {0}", legajo);
            sb.AppendLine();
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara 2 universitarios. Son iguales si son del mismo tipo(Type) y tienen el mismo legajo o DNI 
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True si son iguales, false si son distintos</returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario && this == (Universitario)obj;
        }
    }
}