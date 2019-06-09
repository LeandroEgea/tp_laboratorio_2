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
        /// <summary>
        /// Estados de cuenta posibles de un Alumno
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor de Alumno
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de Alumno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma">Es la clase que toma el Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma">Es la clase que toma el Alumno</param>
        /// <param name="estadoCuenta">El estado de la cuenta del Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, 
            Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Datos del Alumno
        /// </summary>
        /// <returns>String con Nombre, nacionalidad, legajo, clase y estado de la cuenta</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}", estadoCuenta);
            sb.AppendLine();
            sb.AppendLine(ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Muestra la clase en la que participa el Alumno
        /// </summary>
        /// <returns>TOMA CLASE DE ?</returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("TOMA CLASE DE {0}", claseQueToma.ToString());
        }

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">alumno</param>
        /// <param name="clase">clase</param>
        /// <returns>True si son iguales, false si son distintos</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma.Equals(clase) && !a.estadoCuenta.Equals(EEstadoCuenta.Deudor));
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a">alumno</param>
        /// <param name="clase">clase</param>
        /// <returns>False si son iguales, true si son distintos</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !a.claseQueToma.Equals(clase);
        }

        /// <summary>
        /// Datos del Alumno
        /// </summary>
        /// <returns>String con Nombre, nacionalidad, legajo, clase y estado de la cuenta</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
    }
}