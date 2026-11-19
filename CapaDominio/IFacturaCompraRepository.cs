using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public interface IFacturaCompraRepository
    {
        int RegistrarCompra(FacturaCompra compra);
        List<FacturaCompra> ObtenerPorMes(int anio, int mes);
        List<FacturaCompra> ObtenerTodas();
        List<FacturaCompra> ObtenerPorMesYAnio(int mes, int anio);
        bool Agregar(FacturaCompra factura);
    }
}
