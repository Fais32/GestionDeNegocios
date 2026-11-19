using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.DTOs
{
    public class FacturaEmitidaDTO
    {
        public int NroFactura { get; set; }
        public int ClienteId { get; set; }
        public string RazonSocialCliente { get; set; } = string.Empty;
        public string RutCliente { get; set; } = string.Empty;
        public int? ProyectoId { get; set; }
        public string NombreProyecto { get; set; }
        public DateTime FechaEmision { get; set; }
        public List<DetalleFacturaDTO> Detalles { get; set; } = new List<DetalleFacturaDTO>();
        public double Subtotal { get; set; }
        public double Iva { get; set; }
        public double MontoTotal { get; set; }
    }
}
