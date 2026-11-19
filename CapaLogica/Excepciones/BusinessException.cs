using CapaDominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica.Excepciones
{
    public class BusinessException : DomainException
    {
        public BusinessException() { }

        public BusinessException(string message)
            : base(message) { }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
