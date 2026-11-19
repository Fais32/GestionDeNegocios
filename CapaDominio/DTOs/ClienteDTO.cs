using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; } = string.Empty;
        public string Rut { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}
