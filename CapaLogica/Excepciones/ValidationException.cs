using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Excepciones
{
    public class ValidationException : BusinessException
    {
        public IReadOnlyList<string> Errores { get; }

        public ValidationException(string mensaje)
            : base(mensaje)
        {
            Errores = new List<string> { mensaje }.AsReadOnly();
        }

        public ValidationException(IEnumerable<string> errores)
            : base("Se han encontrado uno o varios errores de validación.")
        {
            Errores = new List<string>(errores ?? Array.Empty<string>()).AsReadOnly();
        }

        public ValidationException(string mensajeGeneral, IEnumerable<string> errores)
            : base(mensajeGeneral)
        {
            Errores = new List<string>(errores ?? Array.Empty<string>()).AsReadOnly();
        }
    }
}
