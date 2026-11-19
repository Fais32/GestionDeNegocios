using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDominio;
using CapaDominio.DTOs;

namespace CapaDatos
{
    public class ImpuestoRepository : IImpuestoRepository
    {
        
        public LiquidacionFiscalDTO ObtenerLiquidacionFiscalMensual(int anio, int mes)
        {
            var liquidacion = new LiquidacionFiscalDTO
            {
                Anio = anio,
                Mes = mes,
                FacturacionTotal = 0,
                TotalIvaVentas = 0,
                TotalIvaCompras = 0
            };

            using (SqlConnection connection = Conexion.ObtenerConexion())
            {
                connection.Open();

                // 1. Obtener Facturación Total (Subtotal) e IVA de Facturas Emitidas (Ventas)
                const string sqlVentas = @"
                    SELECT 
                        ISNULL(SUM(Subtotal), 0) AS FacturacionTotal,
                        ISNULL(SUM(Iva), 0) AS TotalIvaVentas
                    FROM FacturasEmitidas
                    WHERE YEAR(FechaEmision) = @Anio 
                      AND MONTH(FechaEmision) = @Mes;";

                using (SqlCommand cmdVentas = new SqlCommand(sqlVentas, connection))
                {
                    cmdVentas.Parameters.AddWithValue("@Anio", anio);
                    cmdVentas.Parameters.AddWithValue("@Mes", mes);

                    using (SqlDataReader reader = cmdVentas.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            liquidacion.FacturacionTotal = Convert.ToDouble(reader["FacturacionTotal"]);
                            liquidacion.TotalIvaVentas = Convert.ToDouble(reader["TotalIvaVentas"]);
                        }
                    }
                }

                // 2. Obtener el Total de IVA de Facturas de Compra (Compras)
                const string sqlCompras = @"
                    SELECT 
                        ISNULL(SUM(Iva), 0) AS TotalIvaCompras
                    FROM FacturasCompra
                    WHERE YEAR(FechaCompra) = @Anio 
                      AND MONTH(FechaCompra) = @Mes;";

                using (SqlCommand cmdCompras = new SqlCommand(sqlCompras, connection))
                {
                    cmdCompras.Parameters.AddWithValue("@Anio", anio);
                    cmdCompras.Parameters.AddWithValue("@Mes", mes);

                    object resultCompras = cmdCompras.ExecuteScalar();
                    if (resultCompras != null && resultCompras != DBNull.Value)
                    {
                        liquidacion.TotalIvaCompras = Convert.ToDouble(resultCompras);
                    }
                }
            }

            return liquidacion;
        }

        public LiquidacionFiscalDTO ObtenerLiquidacionMensual(int anio, int mes)
        {
            throw new NotImplementedException();
        }
    }

}
