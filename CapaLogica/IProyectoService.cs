using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public interface IProyectoService
    {
        bool AgregarProyecto(Proyecto proyecto, out string mensajeError);
        bool ModificarProyecto(Proyecto proyecto, out string mensajeError);
        bool EliminarProyecto(int id, out string mensajeError);
        Proyecto ObtenerPorId(int id);
        List<Proyecto> ObtenerTodos();
        List<Proyecto> ObtenerPorCliente(int clienteId);
        bool Agregar(Proyecto nuevo);
        bool Modificar(Proyecto p);
        bool Eliminar(int id);
    }
}
