using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DetalleFactura() { }
        public DetalleFactura(string descripcion, decimal monto)
        {
            Descripcion = descripcion;
            Monto = monto;
        }
    }
}
