using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {
            string connectionStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security = True";

            try
            {
                conexion = new SqlConnection(connectionStr);
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;
            }
            catch (Exception e)
            {
                throw new Exception("Se produjo un error en la conexion con la base de datos", e);
            }
        }

        public static bool Insertar(Paquete p)
        {
            bool respuesta = false;
            try
            {
                string consulta = String.Format("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES ('{0}','{1}','{2}')",
                    p.DireccionEntrega, p.TrackingID, "Leandro Egea");
                comando.CommandText = consulta;
                conexion.Open();
                comando.ExecuteNonQuery();
                respuesta = true;
            }
            catch (Exception e)
            {
                string message = String.Format("Se produjo un error al intentar guardar el paquete {0} en la base de datos",
                    p.ToString());
                throw new Exception(message, e);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return respuesta;
        }
    }
}
