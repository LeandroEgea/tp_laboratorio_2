using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesInstanciables
{
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
                return jornadas[i]; //???
            }
            set
            {
                throw new NotImplementedException(); //TODO
            }
        }

        public Universidad()
        {
            Alumnos = new List<Alumno>();
            Instructores = new List<Profesor>();
            Jornadas = new List<Jornada>();
        }

        public static bool Guardar(Universidad uni) //STATIC ???
        {
            throw new NotImplementedException(); //TODO
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
            foreach(Profesor profesor in g.Instructores)
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
            return null;
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
                u.Alumnos.Add(a);
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);
            return u;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            throw new NotImplementedException(); //TODO
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        //LEER STATIC ???
    }
}