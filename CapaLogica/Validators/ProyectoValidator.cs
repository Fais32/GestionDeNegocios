using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public static class ProyectoValidator
    {
        public static bool ValidarProyecto(Proyecto proyecto, out string mensajeError)
        {
            mensajeError = string.Empty;
            if (string.IsNullOrWhiteSpace(proyecto.Nombre))
            {
                mensajeError = "El nombre del proyecto no puede estar vacío.";
                return false;
            }
            if (proyecto.PresupuestoInicial <= 0)
            {
                mensajeError = "El presupuesto inicial debe ser mayor a cero.";
                return false;
            }
            if (proyecto.FechaFinPlanificada <= proyecto.FechaInicio)
            {
                mensajeError = "La fecha de fin planificada debe ser posterior a la fecha de inicio.";
                return false;
            }
            if (proyecto.FechaFin.HasValue && proyecto.FechaFin.Value < proyecto.FechaInicio)
            {
                mensajeError = "La fecha de fin real no puede ser anterior a la fecha de inicio.";
                return false;
            }
            return true;
        }
    }
}
