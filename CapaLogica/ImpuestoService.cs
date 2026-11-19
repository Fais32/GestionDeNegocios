using CapaDominio;
using CapaDominio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ImpuestoService : IImpuestoService
    {
        private readonly IFacturaEmitidaRepository _facturaEmitidaRepo;
        private readonly IFacturaCompraRepository _facturaCompraRepo;
        public ImpuestoService(IFacturaEmitidaRepository facturaEmitidaRepo, IFacturaCompraRepository facturaCompraRepo)
        {
            _facturaEmitidaRepo = facturaEmitidaRepo;
            _facturaCompraRepo = facturaCompraRepo;
        }
        public LiquidacionFiscalDTO CalcularLiquidacionMensual(int anio, int mes)
        {
            // 1. Obtener facturas emitidas (Ventas) del período
            List<FacturaEmitida> ventas = _facturaEmitidaRepo.ObtenerPorMesYAnio(mes, anio);
            double facturacionTotal = 0;
            double totalIvaVentas = 0;
            foreach (var v in ventas)
            {
                facturacionTotal += Convert.ToDouble(v.Subtotal);
                totalIvaVentas += Convert.ToDouble(v.Iva);
            }
            // 2. Obtener facturas de compra del período
            List<FacturaCompra> compras = _facturaCompraRepo.ObtenerPorMesYAnio(mes, anio);
            double totalIvaCompras = 0;
            foreach (var c in compras)
            {
                totalIvaCompras += Convert.ToDouble(c.Iva);
            }
            // 3. Crear DTO consolidado
            return new LiquidacionFiscalDTO
            {
                Anio = anio,
                Mes = mes,
                FacturacionTotal = facturacionTotal,
                TotalIvaVentas = totalIvaVentas,
                TotalIvaCompras = totalIvaCompras
            };
        }

        LiquidacionFiscalDTO IImpuestoService.CalcularLiquidacionMensual(int anio, int mes)
        {
            throw new NotImplementedException();
        }

    }
}