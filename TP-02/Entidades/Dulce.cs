using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Dulce con sus 3 atributos setteados
        /// </summary>
        /// <param name="codigoDeBarras">codigoDeBarras to set</param>
        /// <param name="marca">marca to set</param>
        /// <param name="colorPrimarioEmpaque">colorPrimarioEmpaque to set</param>
        public Dulce(string codigoDeBarras, Producto.Marca marca, ConsoleColor colorPrimarioEmpaque) : base(codigoDeBarras, marca, colorPrimarioEmpaque)
        {

        }

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        /// <summary>
        /// Publica todos los datos del Dulce.
        /// </summary>
        /// <returns>Un String con los datos del Dulce</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS: {0}", this.CantidadCalorias);
            sb.AppendLine();
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
    }
}
