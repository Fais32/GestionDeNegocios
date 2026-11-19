using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class FacturaCompra
    {
        public int NroFactura { get; set; }
        public Proveedor Proveedor { get; set; } = new Proveedor();
        public DateTime FechaCompra { get; set; } = DateTime.Now;
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal MontoTotal { get; set; }
        public FacturaCompra() { }
        public FacturaCompra(int nroFactura, Proveedor proveedor, decimal subtotal, decimal iva)
        {
            NroFactura = nroFactura;
            Proveedor = proveedor;
            Subtotal = subtotal;
            Iva = iva;
            MontoTotal = subtotal + iva;
        }
    }
}
