using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return clase;
            }
            set
            {
                clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return instructor;
            }
            set
            {
                instructor = value;
            }
        }

        /// <summary>
        /// Inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de Jornada. Inicializa la lista de alumnos
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            Clase = clase;
            Instructor = instructor;
        }

        /// <summary>
        /// Guarda la jornada en un archivo .txt
        /// </summary>
        /// <param name="jornada">jornada a guardar</param>
        /// <returns>True si salio todo bien</returns>
        public static bool Guardar(Jornada jornada)
        {
            return new Texto().Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Lee la jornada de un archivo .txt
        /// </summary>
        /// <returns>Devuelve el string con la jornada si salio todo bien</returns>
        public static string Leer()
        {
            string jornada;
            new Texto().Leer("Jornada.txt", out jornada);
            return jornada;
        }

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>True si son iguales, false si son distintos</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>False si son iguales, true si son distintos</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>Devuelve la Jornada si salio todo bien. Throws AlumnoRepetidoException</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
                return j;
            }
            throw new AlumnoRepetidoException();
        }

        /// <summary>
        /// Devuelve todos los datos de la Jornada.
        /// </summary>
        /// <returns>Clase, Instructor y Alumnos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR ", Clase);
            sb.AppendLine(Instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno alumno in Alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            return sb.ToString();
        }
    }
}