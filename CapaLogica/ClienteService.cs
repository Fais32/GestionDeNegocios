using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public ClienteService()
        {
        }

        public bool AgregarCliente(Cliente cliente, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (cliente == null)
            {
                mensajeError = "El objeto cliente no puede ser nulo.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(cliente.RazonSocial))
            {
                mensajeError = "La Razón Social es requerida.";
                return false;
            }

            if (!RutValidator.EsRutValido(cliente.Rut))
            {
                mensajeError = "El número de RUT ingresado no es válido (debe tener 12 dígitos válidos).";
                return false;
            }

            return _clienteRepository.Agregar(cliente) > 0;
        }

        public bool ModificarCliente(Cliente cliente, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (cliente == null)
            {
                mensajeError = "El cliente no puede ser nulo.";
                return false;
            }

            if (!RutValidator.EsRutValido(cliente.Rut))
            {
                mensajeError = "El número de RUT ingresado no es válido.";
                return false;
            }

            return _clienteRepository.Modificar(cliente);
        }

        public bool EliminarCliente(int id, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (id <= 0)
            {
                mensajeError = "El identificador del cliente debe ser un entero positivo.";
                return false;
            }

            return _clienteRepository.Eliminar(id);
        }

        public Cliente ObtenerPorId(int id)
        {
            if (id <= 0) return null;
            return _clienteRepository.ObtenerPorId(id);
        }

        public List<Cliente> ObtenerTodos()
        {
            return _clienteRepository.ObtenerTodos() ?? new List<Cliente>();
        }

        public bool Agregar(Cliente nuevo)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Cliente existente)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }

}