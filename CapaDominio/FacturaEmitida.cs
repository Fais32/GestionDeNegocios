using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class FacturaEmitida
    {
        public int NroFactura { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int? ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
        public DateTime FechaEmision { get; set; } = DateTime.Now;
        public List<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
        public decimal Subtotal => Detalles.Sum(d => d.Monto);
        public decimal Iva => Subtotal * 0.22m; // IVA Básico 22%
        public decimal MontoTotal => Subtotal + Iva;

        public int Id { get; set; }
        public double Total { get; set; }

        public FacturaEmitida() { }
        public FacturaEmitida(int nroFactura, Cliente cliente, Proyecto proyecto = null)
        {
            NroFactura = nroFactura;
            Cliente = cliente;
            ClienteId = cliente.Id;
            Proyecto = proyecto;
            ProyectoId = proyecto?.Id;
        }
        public void AgregarDetalle(string descripcion, decimal monto)
        {
            Detalles.Add(new DetalleFactura(descripcion, monto));
        }
    }
}
