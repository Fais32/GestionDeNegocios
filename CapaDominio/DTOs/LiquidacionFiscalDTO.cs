using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.DTOs
{
    public class LiquidacionFiscalDTO
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public double FacturacionTotal { get; set; }
        public double TotalIvaVentas { get; set; }
        public double TotalIvaCompras { get; set; }

        // IVA Líquido a pagar
        public double LiquidacionIva => TotalIvaVentas - TotalIvaCompras;

        // IRAE
        public double LiquidacionIrae => FacturacionTotal * 0.12;
    }
}
