using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public interface IFacturaService
    {
        bool RegistrarFacturaEmitida(FacturaEmitida factura, out string mensajeError);
        bool RegistrarFacturaCompra(FacturaCompra factura, out string mensajeError);
        List<FacturaEmitida> ObtenerFacturasEmitidas();
        List<FacturaCompra> ObtenerFacturasCompra();
    }
}
