using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.DTOs
{
    public class DetalleFacturaDTO
    {
        public string Descripcion { get; set; } = string.Empty;
        public double Monto { get; set; }
    }
}
