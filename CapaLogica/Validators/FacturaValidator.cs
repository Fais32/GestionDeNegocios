using CapaDominio;
using CapaDominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public static class FacturaValidator
    {

        public static void ValidarFacturaEmitida(FacturaEmitida factura)
        {
            if (factura == null)
                throw new ArgumentNullException(nameof(factura), "La factura no puede ser nula.");

            if (factura.NroFactura <= 0)
                throw new DomainException("El número de factura debe ser un entero positivo.");

            if (factura.ClienteId <= 0 && factura.Cliente == null)
                throw new DomainException("La factura debe estar asociada a un cliente válido.");

            if (factura.FechaEmision == default)
                throw new DomainException("La fecha de emisión de la factura no es válida.");

            if (factura.Detalles == null || !factura.Detalles.Any())
                throw new DomainException("La factura debe contener al menos un renglón de detalle.");


            foreach (var detalle in factura.Detalles)
            {
                ValidarDetalle(detalle);
            }

            if (factura.Subtotal <= 0)
                throw new DomainException("El subtotal de la factura debe ser mayor a cero.");

            if (factura.Iva < 0)
                throw new DomainException("El monto de IVA no puede ser negativo.");

            if (factura.MontoTotal <= 0)
                throw new DomainException("El monto total de la factura debe ser mayor a cero.");
        }


        public static void ValidarFacturaCompra(FacturaCompra factura)
        {
            if (factura == null)
                throw new ArgumentNullException(nameof(factura), "La factura de compra no puede ser nula.");

            if (factura.NroFactura <= 0)
                throw new DomainException("El número de factura de compra debe ser mayor a cero.");

            if (factura.Proveedor == null)
                throw new DomainException("Debe ingresar la información del proveedor.");

            if (string.IsNullOrWhiteSpace(factura.Proveedor.RazonSocial))
                throw new DomainException("La Razón Social del proveedor es obligatoria.");

            if (string.IsNullOrWhiteSpace(factura.Proveedor.Rut))
                throw new DomainException("El RUT del proveedor es obligatorio.");

            if (factura.FechaCompra == default)
                throw new DomainException("La fecha de compra no es válida.");

            if (factura.Subtotal <= 0)
                throw new DomainException("El subtotal de la compra debe ser mayor a cero.");

            if (factura.Iva < 0)
                throw new DomainException("El IVA de la compra no puede ser negativo.");

            if (factura.MontoTotal <= 0)
                throw new DomainException("El monto total de la compra debe ser mayor a cero.");
        }


        public static void ValidarDetalle(DetalleFactura detalle)
        {
            if (detalle == null)
                throw new DomainException("El renglón de detalle no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(detalle.Descripcion))
                throw new DomainException("La descripción del renglón de detalle es obligatoria.");

            if (detalle.Monto <= 0)
                throw new DomainException("El monto del renglón de detalle debe ser mayor a cero.");
        }
    }
}