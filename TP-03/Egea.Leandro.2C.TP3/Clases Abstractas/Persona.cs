using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            throw new NotImplementedException(); //TODO
        }

        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if (dato >= 1 && dato <= 99999999)
            {
                if (dato <= 89999999 && !nacionalidad.Equals(ENacionalidad.Argentino))
                {
                    string mensaje = String.Format("La nacionalidad de los DNI menores a 90.000.000 debe ser argentina. DNI:{0} - Nacionalidad:{1}", dato, nacionalidad);
                    throw new NacionalidadInvalidaException(mensaje);
                }
                else if (dato >= 90000000 && !nacionalidad.Equals(ENacionalidad.Extranjero))
                {
                    string mensaje = String.Format("La nacionalidad de los DNI mayores a 89.999.999 debe ser extranjera. DNI:{0} - Nacionalidad:{1}", dato, nacionalidad);
                    throw new NacionalidadInvalidaException(mensaje);
                }
                else
                    return dato;
            }
            else
            {
                throw new DniInvalidoException("El numero de DNI debe estar entre 1 y 99.999.999");
            }
        }

        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int datoEnEntero;
            if(dato.Length <= 8)
            {
                try
                {
                    datoEnEntero = Int32.Parse(dato);
                }
                catch(Exception e)
                {
                    throw new DniInvalidoException(e);
                }
                return ValidarDNI(nacionalidad, datoEnEntero);
            }
            else
            {
                throw new DniInvalidoException("El DNI excede el máximo de caracteres(8)");
            }
        }

        private string ValidarNombreApellido(string dato)
        {
            Match match = Regex.Match(dato, @"^[a-zA-ZáéíóúÁÉÍÓÚ '-]+$");
            if (match.Success)
            {
                return dato;
            }
            else
            {
                throw new Exception(String.Format("{0} no es un nombre válido", dato));
            }
        }
    }
}
