using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public interface IClienteRepository
    {
        int Agregar(Cliente cliente);
        bool Modificar(Cliente cliente);
        bool Eliminar(int id);
        Cliente ObtenerPorId(int id);
        List<Cliente> ObtenerTodos();
    }
}
