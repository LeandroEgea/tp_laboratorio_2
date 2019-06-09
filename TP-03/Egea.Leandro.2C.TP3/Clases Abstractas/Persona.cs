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
        /// <summary>
        /// Enumerado de nacionalidades posibles
        /// </summary>
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

        /// <summary>
        /// Transforma una cadena en un DNI mediante validacion previa
        /// </summary>
        public string StringToDNI
        {
            set
            {
                dni = ValidarDNI(Nacionalidad, value);
            }
        }

        /// <summary>
        /// Constructor de Persona
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">nombre de la Persona</param>
        /// <param name="apellido">apellido de la Persona</param>
        /// <param name="nacionalidad">nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">nombre de la Persona</param>
        /// <param name="apellido">apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona en numero</param>
        /// <param name="nacionalidad">nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            DNI = dni;
        }

        /// <summary>
        /// Constructor de Persona
        /// </summary>
        /// <param name="nombre">nombre de la Persona</param>
        /// <param name="apellido">apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona en string</param>
        /// <param name="nacionalidad">nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni;
        }

        /// <summary>
        /// Datos de la Persona
        /// </summary>
        /// <returns>String con Nombre Completo y nacionalidad</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", Apellido, Nombre);
            sb.AppendLine();
            sb.AppendFormat("NACIONALIDAD: {0}", Nacionalidad);
            sb.AppendLine();
            return sb.ToString();
        }

        /// <summary>
        /// Valida que el DNI este entre 1 y 99.999.999. Y coincida con la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la Persona</param>
        /// <param name="dato">el DNI a validar</param>
        /// <returns>el DNI si es válido. Throws NacionalidadInvalidaException, DniInvalidoException</returns>
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

        /// <summary>
        /// Valida que el string tenga el formato valido y lo envia a ValidarDNI(ENacionalidad, int)
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la Persona</param>
        /// <param name="dato">el DNI a validar en string</param>
        /// <returns>el DNI si es válido. Throws DniInvalidoException</returns>
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
                throw new DniInvalidoException("El DNI excede el máximo de caracteres(8).");
            }
        }

        /// <summary>
        /// Valida que el string sea un nombre válido.
        /// </summary>
        /// <param name="dato">nombre a validar</param>
        /// <returns>el Nombre si es válido. Throws Exception</returns>
        private string ValidarNombreApellido(string dato)
        {
            Match match = Regex.Match(dato, @"^[a-zA-ZáéíóúÁÉÍÓÚ '-]+$");
            if (match.Success)
            {
                return dato;
            }
            else
            {
                throw new Exception(String.Format("{0} no es un nombre válido.", dato));
            }
        }
    }
}
