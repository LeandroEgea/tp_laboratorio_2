using Archivos;
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

        private Jornada()
        {
            Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            Clase = clase;
            Instructor = instructor;
        }

        public static bool Guardar(Jornada jornada)
        {
            return new Texto().Guardar("Jornada.txt", jornada.ToString());
        }

        public static string Leer()
        {
            string jornada;
            new Texto().Leer("Jornada.txt", out jornada);
            return jornada;
        }

        public static bool operator ==(Jornada j, Alumno a) //???
        {
            return j.Alumnos.Contains(a);
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);
            return j;
        }

        public override string ToString()
        {
            throw new NotImplementedException(); //TODO
        }
    }
}