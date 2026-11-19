using CapaDominio.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public interface IImpuestoService
    {
        LiquidacionFiscalDTO CalcularLiquidacionMensual(int anio, int mes);
    }
}
