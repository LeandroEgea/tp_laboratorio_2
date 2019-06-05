using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

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
                apellido = ValidarNombreApellido(value);
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
                dni = ValidarDNI(Nacionalidad, value);
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
                nombre = ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                dni = ValidarDNI(Nacionalidad, value);
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
            if(dato >= 1 && dato <= 99999999)
            {
                if (dato <= 89999999 && !nacionalidad.Equals(ENacionalidad.Argentino))
                {
                    throw new NacionalidadInvalidaException(); //TODO mensaje
                }
                else if (dato >= 90000000 && !nacionalidad.Equals(ENacionalidad.Extranjero))
                {
                    throw new NacionalidadInvalidaException(); //TODO mensaje
                }
                else
                    return dato;
            }
            else
            {
                throw new NotImplementedException(); //TODO
            }
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
