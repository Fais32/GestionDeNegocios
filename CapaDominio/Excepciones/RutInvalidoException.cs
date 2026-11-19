using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio.Excepciones
{
    public class RutInvalidoException : DomainException
    {
        
        public string RutIngresado { get; }

        public RutInvalidoException(string rut)
            : base($"El RUT '{rut}' no es válido. Debe contener 12 dígitos numéricos válidos.")
        {
            RutIngresado = rut ?? string.Empty;
        }

        public RutInvalidoException(string rut, string mensajeCustom)
            : base(mensajeCustom)
        {
            RutIngresado = rut ?? string.Empty;
        }
    }
}
