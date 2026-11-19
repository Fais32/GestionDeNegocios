using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;

namespace CapaDatos
{
    public class FacturaEmitidaRepository : IFacturaEmitidaRepository
    {
        public int RegistrarFactura(FacturaEmitida factura)
        {
            using (var conn = Conexion.ObtenerConexion())
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string sqlFactura = @"INSERT INTO FacturasEmitidas (ClienteId, ProyectoId, FechaEmision,
Subtotal, Iva, Total)
                                          VALUES (@ClienteId, @ProyectoId, @FechaEmision, @Subtotal, @Iva, @Total);
                                          SELECT SCOPE_IDENTITY();";

                    int facturaId;
                    using (var cmd = new SqlCommand(sqlFactura, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ClienteId", factura.ClienteId);
                        cmd.Parameters.AddWithValue("@ProyectoId", (object)factura.ProyectoId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@FechaEmision", factura.FechaEmision);
                        cmd.Parameters.AddWithValue("@Subtotal", factura.Subtotal);
                        cmd.Parameters.AddWithValue("@Iva", factura.Iva);
                        cmd.Parameters.AddWithValue("@Total", factura.MontoTotal);
                        facturaId = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                    // Insertar Renglones de Detalle
                    string sqlDetalle = @"INSERT INTO DetallesFactura (FacturaId, Descripcion, Monto)
                                          VALUES (@FacturaId, @Descripcion, @Monto);";
                    foreach (var det in factura.Detalles)
                    {
                        using (var cmdDet = new SqlCommand(sqlDetalle, conn, transaction))
                        {
                            cmdDet.Parameters.AddWithValue("@FacturaId", facturaId);
                            cmdDet.Parameters.AddWithValue("@Descripcion", det.Descripcion);
                            cmdDet.Parameters.AddWithValue("@Monto", det.Monto);
                            cmdDet.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    return facturaId;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public List<FacturaEmitida> ObtenerPorMes(int anio, int mes)
        {
            var lista = new List<FacturaEmitida>();
            using (var conn = Conexion.ObtenerConexion())
            {
                string sql = @"SELECT Id, ClienteId, ProyectoId, FechaEmision, Subtotal, Iva, Total
                               FROM FacturasEmitidas
                               WHERE YEAR(FechaEmision) = @Anio AND MONTH(FechaEmision) = @Mes";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Anio", anio);
                    cmd.Parameters.AddWithValue("@Mes", mes);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new FacturaEmitida
                            {
                                Id = reader.GetInt32(0),
                                ClienteId = reader.GetInt32(1),
                                ProyectoId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                                FechaEmision = reader.GetDateTime(3),
                                Total = Convert.ToDouble(reader.GetDecimal(6))
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public List<FacturaEmitida> ObtenerTodas()
        {
            throw new NotImplementedException();
        }

        public List<FacturaEmitida> ObtenerPorMesYAnio(int mes, int anio)
        {
            throw new NotImplementedException();
        }

        public bool Agregar(FacturaEmitida factura)
        {
            throw new NotImplementedException();
        }
    }
}
