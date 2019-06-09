using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

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

        public List<Profesor> Instructores
        {
            get
            {
                return profesores;
            }
            set
            {
                profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return jornadas;
            }
            set
            {
                jornadas = value;
            }
        }

        /// <summary>
        /// Se busca o ingresa una jornada a la universidad segun su indice
        /// </summary>
        /// <param name="i">Indice</param>
        /// <returns>La jornada de la lista segun el indice</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < Jornadas.Count)
                    return jornadas[i];
                return null;
            }
            set
            {
                if (i >= 0 && i < Jornadas.Count)
                {
                    jornadas[i] = value;
                }
                else if (i == Jornadas.Count)
                {
                    jornadas.Add(value);
                }
            }
        }

        /// <summary>
        /// Constructor de Universidad. Se inicializan los alumnos, instructores y jornadas.
        /// </summary>
        public Universidad()
        {
            Alumnos = new List<Alumno>();
            Instructores = new List<Profesor>();
            Jornadas = new List<Jornada>();
        }

        /// <summary>
        /// Guarda la universidad en un archivo .xml
        /// </summary>
        /// <param name="uni">universidad a guardar</param>
        /// <returns>True si salio todo bien</returns>
        public static bool Guardar(Universidad uni)
        {
            return new Xml<Universidad>().Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Lee la universidad de un archivo .xml
        /// </summary>
        /// <returns>Devuelve la Universidad si salio todo bien</returns>
        public static Universidad Leer()
        {
            Universidad universidad;
            new Xml<Universidad>().Leer("Universidad.xml", out universidad);
            return universidad;
        }

        /// <summary>
        /// Devuelve los datos de la universidad
        /// </summary>
        /// <param name="uni">universidad</param>
        /// <returns>Todos los datos de la universidad</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada jornada in Jornadas)
            {
                sb.Append(jornada.ToString());
                sb.AppendLine("<---------------------------------------------------->");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>True si son iguales, false si son distintos</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>False si son iguales, true si son distintos</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="i">profesor/instructor</param>
        /// <returns>True si son iguales, false si son distintos</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="i">profesor/instructor</param>
        /// <returns>False si son iguales, true si son distintos</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns>Retornará el primer Profesor capaz de dar esa clase. Throws SinProfesorException</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns>El distinto retornará el primer Profesor que no pueda dar la clase.</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                    return profesor;
            }
            return null;
        }

        /// <summary>
        /// Se agregarán Alumnos mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>Universidad. Throws AlumnoRepetidoException</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }

        /// <summary>
        /// Se agregarán Profesores mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="u">universidad</param>
        /// <param name="i">profesor/instructor</param>
        /// <returns>Universidad. Throws AlumnoRepetidoException</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            return u;
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
        /// clase, un Profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la
        /// toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="clase">clase</param>
        /// <returns>Universidad</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = (g == clase);
            Jornada jornada = new Jornada(clase, profesor);
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == clase)
                    jornada.Alumnos.Add(alumno);
            }
            g.Jornadas.Add(jornada);
            return g;
        }

        /// <summary>
        /// Devuelve los datos de la universidad
        /// </summary>
        /// <param name="uni">universidad</param>
        /// <returns>Todos los datos de la universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
    }
}