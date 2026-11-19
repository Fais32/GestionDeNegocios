using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDominio
{
    public interface IProyectoRepository
    {
        int Agregar(Proyecto proyecto);
        bool Modificar(Proyecto proyecto);
        bool Eliminar(int id);
        Proyecto ObtenerPorId(int id);
        List<Proyecto> ObtenerTodos();
        List<Proyecto> ObtenerPorCliente(int clienteId);
    }
}
