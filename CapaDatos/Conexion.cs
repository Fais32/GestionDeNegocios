using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public static class Conexion
    {
        private static readonly string _connectionString = ("Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = BMSDataBase; Data Source = LAPTOP-G79BVQ27\\SQLEXPRESS");
        public static SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(_connectionString);
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            return conexion;
        }
    }
}
