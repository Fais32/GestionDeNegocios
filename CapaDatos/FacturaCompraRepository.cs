using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaDatos
{
    public class FacturaCompraRepository : IFacturaCompraRepository
    {
        
        public bool Agregar(FacturaCompra factura)
        {
            const string sql = @"
                INSERT INTO FacturasCompra 
                    (NroFactura, FechaCompra, ProveedorRazonSocial, ProveedorRut, ProveedorDireccion, Subtotal, Iva, MontoTotal)
                VALUES 
                    (@NroFactura, @FechaCompra, @ProveedorRazonSocial, @ProveedorRut, @ProveedorDireccion, @Subtotal, @Iva, @MontoTotal);";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@NroFactura", factura.NroFactura);
                    cmd.Parameters.AddWithValue("@FechaCompra", factura.FechaCompra);
                    cmd.Parameters.AddWithValue("@ProveedorRazonSocial", factura.Proveedor.RazonSocial);
                    cmd.Parameters.AddWithValue("@ProveedorRut", factura.Proveedor.Rut);
                    cmd.Parameters.AddWithValue("@ProveedorDireccion", factura.Proveedor.Direccion);
                    cmd.Parameters.AddWithValue("@Subtotal", factura.Subtotal);
                    cmd.Parameters.AddWithValue("@Iva", factura.Iva);
                    cmd.Parameters.AddWithValue("@MontoTotal", factura.MontoTotal);

                    cn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        
        public List<FacturaCompra> ObtenerTodas()
        {
            List<FacturaCompra> lista = new List<FacturaCompra>();
            const string sql = @"
                SELECT NroFactura, FechaCompra, ProveedorRazonSocial, ProveedorRut, ProveedorDireccion, Subtotal, Iva, MontoTotal
                FROM FacturasCompra
                ORDER BY FechaCompra DESC;";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearFacturaCompra(reader));
                        }
                    }
                }
            }
            return lista;
        }

        
        public List<FacturaCompra> ObtenerPorMesYAnio(int mes, int anio)
        {
            List<FacturaCompra> lista = new List<FacturaCompra>();
            const string sql = @"
                SELECT NroFactura, FechaCompra, ProveedorRazonSocial, ProveedorRut, ProveedorDireccion, Subtotal, Iva, MontoTotal
                FROM FacturasCompra
                WHERE MONTH(FechaCompra) = @Mes AND YEAR(FechaCompra) = @Anio
                ORDER BY FechaCompra ASC;";

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    cmd.Parameters.AddWithValue("@Anio", anio);

                    cn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearFacturaCompra(reader));
                        }
                    }
                }
            }
            return lista;
        }

        
        private static FacturaCompra MapearFacturaCompra(SqlDataReader reader)
        {
            return new FacturaCompra
            {
                NroFactura = Convert.ToInt32(reader["NroFactura"]),
                FechaCompra = Convert.ToDateTime(reader["FechaCompra"]),
                Proveedor = new Proveedor
                {
                    RazonSocial = reader["ProveedorRazonSocial"].ToString() ?? string.Empty,
                    Rut = reader["ProveedorRut"].ToString() ?? string.Empty,
                    Direccion = reader["ProveedorDireccion"].ToString() ?? string.Empty
                },
                Subtotal = Convert.ToDecimal(reader["Subtotal"]),
                Iva = Convert.ToDecimal(reader["Iva"]),
                MontoTotal = Convert.ToDecimal(reader["MontoTotal"])
            };
        }

        public int RegistrarCompra(FacturaCompra compra)
        {
            throw new NotImplementedException();
        }

        public List<FacturaCompra> ObtenerPorMes(int anio, int mes)
        {
            throw new NotImplementedException();
        }
    }
}
