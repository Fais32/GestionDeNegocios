using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; } = string.Empty;
        public string Rut { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public Cliente() { }
        public Cliente(int id, string razonSocial, string rut, string direccion)
        {
            Id = id;
            RazonSocial = razonSocial;
            Rut = rut;
            Direccion = direccion;
        }
        public override string ToString()
        {
            return $"[{Id}] {RazonSocial} - RUT: {Rut}";
        }
    }
}
