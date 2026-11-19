using CapaDominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.DTOs
{
    public class ProyectoDTO
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string RazonSocialCliente { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public TipoProyecto Tipo { get; set; }
        public string TipoTexto => Tipo.ToString();
        public DateTime FechaInicio { get; set; }
        public double PresupuestoInicial { get; set; }
        public DateTime FechaFinPlanificada { get; set; }
        public DateTime? FechaFin { get; set; }
        public EstadoProyecto Estado { get; set; }
        public string EstadoTexto => Estado.ToString();
    }
}
