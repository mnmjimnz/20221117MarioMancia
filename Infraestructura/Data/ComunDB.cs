using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _20221117MarioMancia.Infraestructura.Data
{
    public class ComunDB
    {
        const string CadenaDeConexion = @"Data Source=DESKTOP-V51EC0T;Initial Catalog=ClinicaMedica;Integrated Security=True;;Max Pool Size=10024;Pooling=true";

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(CadenaDeConexion);
            conexion.Open();
            return conexion;
        }
        public static SqlCommand ObtenerComando()
        {
            SqlCommand comando = new SqlCommand();
            return comando;
        }

        public static string ObtenerConexion(object cadenaDeConexion)
        {
            throw new NotImplementedException();
        }

        public static int EjecutarComando(SqlCommand pComando)
        {
            pComando.Connection = ObtenerConexion();
            int resultado = pComando.ExecuteNonQuery();
            pComando.Connection.Close();
            return resultado;
        }
        public static SqlDataReader EjecutarComandoReader(SqlCommand pComando)
        {
            pComando.Connection = ObtenerConexion();
            return pComando.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
