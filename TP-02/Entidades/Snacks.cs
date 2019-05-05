using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        /// <summary>
        /// Snacks con sus 3 atributos setteados
        /// </summary>
        /// <param name="marca">marca to set</param>
        /// <param name="codigoDeBarras">codigoDeBarras to set</param>
        /// <param name="colorPrimarioEmpaque">colorPrimarioEmpaque to set</param>
        public Snacks(Producto.Marca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque) : base(codigoDeBarras, marca, colorPrimarioEmpaque)
        {

        }

        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        /// <summary>
        /// Publica todos los datos del Snacks.
        /// </summary>
        /// <returns>Un String con los datos del Snacks</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS: {0}", this.CantidadCalorias);
            sb.AppendLine();
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
    }
}
