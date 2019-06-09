using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, 
            Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            throw new NotImplementedException(); //TODO
        }

        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASE DE {0}", claseQueToma.ToString());
        }

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma.Equals(clase) && !a.estadoCuenta.Equals(EEstadoCuenta.Deudor));
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !a.claseQueToma.Equals(clase);
        }

        public override string ToString()
        {
            return MostrarDatos();
        }
    }
}