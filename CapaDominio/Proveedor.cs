using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Proveedor
    {
        public string RazonSocial { get; set; } = string.Empty;
        public string Rut { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public Proveedor() { }
        public Proveedor(string razonSocial, string rut, string direccion)
        {
            RazonSocial = razonSocial;
            Rut = rut;
            Direccion = direccion;
        }
    }
}
