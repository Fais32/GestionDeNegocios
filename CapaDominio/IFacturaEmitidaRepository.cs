using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public interface IFacturaEmitidaRepository
    {
        int RegistrarFactura(FacturaEmitida factura);
        List<FacturaEmitida> ObtenerPorMes(int anio, int mes);
        List<FacturaEmitida> ObtenerTodas();
        List<FacturaEmitida> ObtenerPorMesYAnio(int mes, int anio);
        bool Agregar(FacturaEmitida factura);
    }
}
