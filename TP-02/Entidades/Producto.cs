using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public abstract class Producto
    {
        public enum Marca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }

        private string codigoDeBarras;
        private Marca marca;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias { get; }

        /// <summary>
        /// Producto con sus 3 atributos setteados
        /// </summary>
        /// <param name="codigoDeBarras">codigoDeBarras to set</param>
        /// <param name="marca">marca to set</param>
        /// <param name="colorPrimarioEmpaque">colorPrimarioEmpaque to set</param>
        public Producto(string codigoDeBarras, Marca marca, ConsoleColor colorPrimarioEmpaque)
        {
            this.codigoDeBarras = codigoDeBarras;
            this.marca = marca;
            this.colorPrimarioEmpaque = colorPrimarioEmpaque;
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>Un String con los datos del producto</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Convierte el producto en un string con todos sus datos
        /// </summary>
        /// <param name="producto">Producto del que obtenemos los datos</param>
        public static explicit operator string(Producto producto)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CODIGO DE BARRAS: {0}", producto.codigoDeBarras);
            sb.AppendLine();
            sb.AppendFormat("MARCA           : {0}", producto.marca.ToString());
            sb.AppendLine();
            sb.AppendFormat("COLOR EMPAQUE   : {0}", producto.colorPrimarioEmpaque.ToString());
            sb.AppendLine();
            sb.AppendLine("---------------------");
            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="productoUno">Primer Producto a comparar</param>
        /// <param name="productoDos">Segundo Producto a comparar</param>
        /// <returns>True si son iguales, false en caso contrario</returns>
        public static bool operator ==(Producto productoUno, Producto productoDos)
        {
            return (productoUno.codigoDeBarras == productoDos.codigoDeBarras);
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="productoUno">Primer Producto a comparar</param>
        /// <param name="productoDos">Segundo Producto a comparar</param>
        /// <returns>True si no son iguales, false en caso contrario</returns>
        public static bool operator !=(Producto productoUno, Producto productoDos)
        {
            return !(productoUno == productoDos);
        }
    }
}
