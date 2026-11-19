using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Excepciones
{
    public class PresupuestoInvalidoException : DomainException
    {
       
        public double PresupuestoIngresado { get; }

        public PresupuestoInvalidoException(double presupuesto)
            : base($"El presupuesto inicial del proyecto debe ser mayor a cero. Valor ingresado: {presupuesto}.")
        {
            PresupuestoIngresado = presupuesto;
        }

        public PresupuestoInvalidoException(double presupuesto, string mensajeCustom)
            : base(mensajeCustom)
        {
            PresupuestoIngresado = presupuesto;
        }
    }
}
