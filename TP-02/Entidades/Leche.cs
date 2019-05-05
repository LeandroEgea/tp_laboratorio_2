using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum TipoDeLeche
        {
            Entera,
            Descremada
        }

        private TipoDeLeche tipoDeLeche;

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Leche con sus 4 atributos setteados (tipoDeLeche Entera por Default)
        /// </summary>
        /// <param name="marca">marca to set</param>
        /// <param name="codigoDeBarras">codigoDeBarras to set</param>
        /// <param name="colorPrimarioEmpaque">colorPrimarioEmpaque to set</param>
        public Leche(Producto.Marca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque) 
            : this(marca, codigoDeBarras, colorPrimarioEmpaque, TipoDeLeche.Entera)
        {

        }

        /// <summary>
        /// Leche con sus 4 atributos setteados
        /// </summary>
        /// <param name="marca">marca to set</param>
        /// <param name="codigoDeBarras">codigoDeBarras to set</param>
        /// <param name="colorPrimarioEmpaque">colorPrimarioEmpaque to set</param>
        /// <param name="tipoDeLeche">tipoDeLeche to set</param>
        public Leche(Producto.Marca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque, TipoDeLeche tipoDeLeche) 
            : base(codigoDeBarras, marca, colorPrimarioEmpaque)
        {
            this.tipoDeLeche = tipoDeLeche;
        }

        /// <summary>
        /// Publica todos los datos de Leche.
        /// </summary>
        /// <returns>Un String con los datos de Leche</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS: {0}", this.CantidadCalorias);
            sb.AppendLine();
            sb.AppendFormat("TIPO    : {0}", this.tipoDeLeche.ToString());
            sb.AppendLine();
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
    }
}
