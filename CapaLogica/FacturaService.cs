using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaEmitidaRepository _facturaEmitidaRepo;
        private readonly IFacturaCompraRepository _facturaCompraRepo;

        // Inyección de dependencias mediante constructor
        public FacturaService(IFacturaEmitidaRepository facturaEmitidaRepo, IFacturaCompraRepository facturaCompraRepo)
        {
            _facturaEmitidaRepo = facturaEmitidaRepo ?? throw new ArgumentNullException(nameof(facturaEmitidaRepo));
            _facturaCompraRepo = facturaCompraRepo ?? throw new ArgumentNullException(nameof(facturaCompraRepo));
        }

        public bool RegistrarFacturaEmitida(FacturaEmitida factura, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (factura == null)
            {
                mensajeError = "La factura emitida no puede ser nula.";
                return false;
            }

            if (factura.Detalles == null || factura.Detalles.Count == 0)
            {
                mensajeError = "La factura debe contener al menos un renglón de detalle.";
                return false;
            }

            // Recalcular Subtotal en tipo decimal usando LINQ
            decimal subtotal = factura.Detalles.Sum(det => det.Monto);

            // Si las propiedades de la entidad son asignables (set):
            // factura.Subtotal = subtotal;
            // factura.Iva = subtotal * 0.22m; // 'm' indica literal decimal
            // factura.MontoTotal = factura.Subtotal + factura.Iva;

            // Registrar en el repositorio
            _facturaEmitidaRepo.Agregar(factura);
            return true;
        }

        public bool RegistrarFacturaCompra(FacturaCompra factura, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (factura == null)
            {
                mensajeError = "La factura de compra no puede ser nula.";
                return false;
            }

            if (factura.Subtotal <= 0)
            {
                mensajeError = "El subtotal de la compra debe ser mayor a cero.";
                return false;
            }

            // Garantizar la suma total en decimales
            factura.MontoTotal = factura.Subtotal + factura.Iva;

            // Registrar en el repositorio
            _facturaCompraRepo.Agregar(factura);
            return true;
        }

        public List<FacturaEmitida> ObtenerFacturasEmitidas()
        {
            return _facturaEmitidaRepo.ObtenerTodas() ?? new List<FacturaEmitida>();
        }

        public List<FacturaCompra> ObtenerFacturasCompra()
        {
            return _facturaCompraRepo.ObtenerTodas() ?? new List<FacturaCompra>();
        }
    }
}
