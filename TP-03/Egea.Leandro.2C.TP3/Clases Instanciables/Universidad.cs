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

        public Universidad()
        {
            Alumnos = new List<Alumno>();
            Instructores = new List<Profesor>();
            Jornadas = new List<Jornada>();
        }

        public static bool Guardar(Universidad uni)
        {
            return new Xml<Universidad>().Guardar("Universidad.xml", uni);
        }

        public static Universidad Leer()
        {
            Universidad universidad;
            new Xml<Universidad>().Leer("Universidad.xml", out universidad);
            return universidad;
        }

        private string MostrarDatos(Universidad uni)
        {
            throw new NotImplementedException(); //TODO
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a) //???
                    return true;
            }
            return false;
            //return g.Instructores.Contains(i); //???
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i) //???
                    return true;
            }
            return false;
            //return g.Instructores.Contains(i); //???
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                    return profesor;
            }
            return null;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            return u;
        }

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

        public override string ToString()
        {
            return MostrarDatos(this);
        }
    }
}