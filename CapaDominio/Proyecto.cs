using CapaDominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public class Proyecto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public TipoProyecto Tipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public double PresupuestoInicial { get; set; }
        public DateTime FechaFinPlanificada { get; set; }
        public DateTime? FechaFin { get; set; }
        public EstadoProyecto Estado { get; set; }
        public decimal Presupuesto { get; set; }

        public Proyecto() { }
        public Proyecto(int id, int clienteId, string nombre, TipoProyecto tipo,
        DateTime fechaInicio, double presupuestoInicial,
        DateTime fechaFinPlanificada)
        {
            Id = id;
            ClienteId = clienteId;
            Nombre = nombre;
            Tipo = tipo;
            FechaInicio = fechaInicio;
            PresupuestoInicial = presupuestoInicial;
            FechaFinPlanificada = fechaFinPlanificada;
            Estado = EstadoProyecto.Planificado;
        }
    }
}
