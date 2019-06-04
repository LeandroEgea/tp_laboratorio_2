using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = value;
            }
        }

        public int DNI
        {
            get
            {
                return dni;
            }
            set
            {
                throw new NotImplementedException(); //TODO
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return nacionalidad;
            }
            set
            {
                nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public string StringToDNI
        {
            set
            {
                throw new NotImplementedException();//TODO
            }
        }

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni;
        }

        public override string ToString()
        {
            throw new NotImplementedException();//TODO
        }

        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            throw new NotImplementedException();//TODO
        }

        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            throw new NotImplementedException();//TODO
        }

        private string ValidarNombreApellido(string dato)
        {
            throw new NotImplementedException();//TODO
        }
    }
}
