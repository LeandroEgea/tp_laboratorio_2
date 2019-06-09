using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Inicializa el random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de Profesor
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// Constructor de Profesor.Inicializa la cola clasesDelDia, toma 2 clases de manera aleatoria y las encola.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Toma 2 clases de manera aleatoria y las encola en clasesDelDia
        /// </summary>
        private void _randomClases()
        {
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }

        /// <summary>
        /// Datos del Profesor
        /// </summary>
        /// <returns>String con Nombre, nacionalidad, legajo y clase</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append(ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i">profesor/instructor</param>
        /// <param name="clase">clase</param>
        /// <returns>True si son iguales, false si son distintos</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i">profesor/instructor</param>
        /// <param name="clase">clase</param>
        /// <returns>False si son iguales, true si son distintos</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Muestra las clases del Profesor
        /// </summary>
        /// <returns>CLASES DEL DÍA: + las clases que están en la cola</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases clase in clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Datos del Profesor
        /// </summary>
        /// <returns>String con Nombre, nacionalidad, legajo y clase</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
    }
}