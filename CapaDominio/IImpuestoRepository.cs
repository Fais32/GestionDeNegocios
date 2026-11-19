using CapaDominio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public interface IImpuestoRepository
    {
        LiquidacionFiscalDTO ObtenerLiquidacionMensual(int anio, int mes);
    }
}
