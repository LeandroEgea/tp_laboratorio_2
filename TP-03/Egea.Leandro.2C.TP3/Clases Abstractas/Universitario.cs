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

        public Universitario() //???
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.GetType().Equals(pg2.GetType()) && (pg1.legajo.Equals(pg2.legajo) || pg1.DNI.Equals(pg2.legajo)); //???
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        protected virtual string MostrarDatos()
        {
            throw new NotImplementedException(); //TODO
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            return obj is Universitario && this == (Universitario)obj; //???
        }
    }
}