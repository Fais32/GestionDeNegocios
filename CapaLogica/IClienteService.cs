using CapaDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public interface IClienteService
    {
        bool AgregarCliente(Cliente cliente, out string mensajeError);
        bool ModificarCliente(Cliente cliente, out string mensajeError);
        bool EliminarCliente(int id, out string mensajeError);
        Cliente ObtenerPorId(int id);
        List<Cliente> ObtenerTodos();
        bool Agregar(Cliente nuevo);
        bool Eliminar(int id);
        bool Modificar(Cliente existente);
    }
}
