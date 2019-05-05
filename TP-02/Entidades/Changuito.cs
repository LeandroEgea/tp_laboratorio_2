using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public sealed class Changuito
    {
        public enum TipoDeProducto
        {
            Dulce,
            Leche,
            Snacks,
            Todos
        }

        private List<Producto> productos;
        private int espacioDisponible;


        #region "Constructores"
        /// <summary>
        /// Crea un changuito e inicializa productos
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }

        /// <summary>
        /// Crea un changuito, indicando el espacioDisponible e inicializa productos 
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Changuito(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns>Un string con todos los datos</returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, TipoDeProducto.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="changuito">Elemento a exponer</param>
        /// <param name="tipoDeProducto">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito changuito, TipoDeProducto tipoDeProducto)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", changuito.productos.Count, changuito.espacioDisponible);
            sb.AppendLine();
            foreach (Producto producto in changuito.productos)
            {
                switch (tipoDeProducto)
                {
                    case TipoDeProducto.Snacks:
                        if (producto is Snacks)
                            sb.AppendLine(producto.Mostrar());
                        break;
                    case TipoDeProducto.Dulce:
                        if (producto is Dulce)
                            sb.AppendLine(producto.Mostrar());
                        break;
                    case TipoDeProducto.Leche:
                        if (producto is Leche)
                            sb.AppendLine(producto.Mostrar());
                        break;
                    default:
                        sb.AppendLine(producto.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="changuito">Objeto donde se agregará el elemento</param>
        /// <param name="producto">Objeto a agregar</param>
        /// <returns>El Changuito con el nuevo producto si se pudo agregar, o como estaba en caso contrario</returns>
        public static Changuito operator +(Changuito changuito, Producto producto)
        {
            if (changuito.productos.Count >= changuito.espacioDisponible)
                return changuito;
            foreach (Producto p in changuito.productos)
            {
                if (producto == p)
                    return changuito;
            }
            changuito.productos.Add(producto);
            return changuito;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="changuito">Objeto donde se quitará el elemento</param>
        /// <param name="producto">Objeto a quitar</param>
        /// <returns>El Changuito sin el producto si se pudo quitar, o como estaba en caso contrario</returns>
        public static Changuito operator -(Changuito changuito, Producto producto)
        {
            foreach (Producto p in changuito.productos)
            {
                if (producto == p)
                {
                    changuito.productos.Remove(p);
                    return changuito;
                }
            }
            return changuito;
        }
        #endregion
    }
}
