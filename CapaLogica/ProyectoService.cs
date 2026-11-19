using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class ProyectoService : IProyectoService
    {
        private readonly IProyectoRepository _proyectoRepository;

        // Constructor único con Inyección de Dependencias
        public ProyectoService(IProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository ?? throw new ArgumentNullException(nameof(proyectoRepository));
        }

        public ProyectoService()
        {
        }

        public bool AgregarProyecto(Proyecto proyecto, out string mensajeError)
        {
            if (proyecto == null)
            {
                mensajeError = "El proyecto no puede ser nulo.";
                return false;
            }

            if (!ProyectoValidator.ValidarProyecto(proyecto, out mensajeError))
                return false;

            return _proyectoRepository.Agregar(proyecto) > 0;
        }

        public bool ModificarProyecto(Proyecto proyecto, out string mensajeError)
        {
            if (proyecto == null)
            {
                mensajeError = "El proyecto no puede ser nulo.";
                return false;
            }

            if (!ProyectoValidator.ValidarProyecto(proyecto, out mensajeError))
                return false;

            return _proyectoRepository.Modificar(proyecto);
        }

        public bool EliminarProyecto(int id, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (id <= 0)
            {
                mensajeError = "El identificador del proyecto debe ser mayor a cero.";
                return false;
            }

            return _proyectoRepository.Eliminar(id);
        }

        public Proyecto ObtenerPorId(int id)
        {
            if (id <= 0) return null;
            return _proyectoRepository.ObtenerPorId(id);
        }

        public List<Proyecto> ObtenerTodos()
        {
            return _proyectoRepository.ObtenerTodos() ?? new List<Proyecto>();
        }

        public List<Proyecto> ObtenerPorCliente(int clienteId)
        {
            if (clienteId <= 0) return new List<Proyecto>();
            return _proyectoRepository.ObtenerPorCliente(clienteId) ?? new List<Proyecto>();
        }

        public bool Agregar(Proyecto nuevo)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Proyecto p)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}