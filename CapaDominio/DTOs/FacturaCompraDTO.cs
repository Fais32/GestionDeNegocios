using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.DTOs
{
    public class FacturaCompraDTO
    {
        public int NroFactura { get; set; }
        public DateTime FechaCompra { get; set; }
        public string ProveedorRazonSocial { get; set; } = string.Empty;
        public string ProveedorRut { get; set; } = string.Empty;
        public string ProveedorDireccion { get; set; } = string.Empty;
        public double Subtotal { get; set; }
        public double Iva { get; set; }
        public double MontoTotal { get; set; }
    }
}
