using CapaDatos;
using CapaDominio;
using CapaDominio.Enums;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.ConsoleApp
{

    /// Gestion CRUD de Clientes y Proyectos.

    internal class Program
    {
        // 1. Instanciar primero los repositorios de la Capa de Datos
        private static readonly IClienteRepository _clienteRepository = new ClienteRepository();
        private static readonly IProyectoRepository _proyectoRepository = new ProyectoRepository();

        // 2. Pasar los repositorios a los servicios de la Capa Lógica
        private static readonly IClienteService _clienteService = new ClienteService(_clienteRepository);
        private static readonly IProyectoService _proyectoService = new ProyectoService(_proyectoRepository);

        static void Main(string[] args)
        {
            Console.Title = "Sistema de Gestión - Empresa .NET";
            bool salir = false;

            while (!salir)
            {
                MostrarMenuPrincipal();
                string opcion = Console.ReadLine()?.Trim() ?? "";

                switch (opcion)
                {
                    case "1":
                        SubmenuClientes();
                        break;
                    case "2":
                        SubmenuProyectos();
                        break;
                    case "0":
                        salir = true;
                        Console.WriteLine("\n¡Gracias por utilizar el sistema!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar.");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==========================");
            Console.WriteLine("    SISTEMA DE GESTIÓN    ");
            Console.WriteLine("==========================");
            Console.ResetColor();
            Console.WriteLine("1. Gestión de Clientes");
            Console.WriteLine("2. Gestión de Proyectos");
            Console.WriteLine("0. Salir del Sistema");
            Console.WriteLine("==========================");
            Console.Write("Seleccione una opción: ");

        }

        //Submenú Clientes
        private static void SubmenuClientes()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- GESTIÓN DE CLIENTES ---");
                Console.ResetColor();
                Console.WriteLine("1. Listar Clientes");
                Console.WriteLine("2. Agregar Cliente");
                Console.WriteLine("3. Modificar Cliente");
                Console.WriteLine("4. Eliminar Cliente");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Opción: ");

                string op = Console.ReadLine()?.Trim() ?? "";
                switch (op)
                {
                    case "1": ListarClientes(); break;
                    case "2": AgregarCliente(); break;
                    case "3": ModificarCliente(); break;
                    case "4": EliminarCliente(); break;
                    case "0": volver = true; break;
                }
            }
        }

        private static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("--- LISTADO DE CLIENTES ---");
            try
            {
                var clientes = _clienteService.ObtenerTodos();
                if (clientes.Count == 0)
                {
                    Console.WriteLine("No hay clientes registrados.");
                }
                else
                {
                    Console.WriteLine("{0,-6} | {1,-25} | {2,-15} | {3,-25}", "ID", "Razón Social", "RUT", "Dirección");
                    Console.WriteLine(new string('-', 78));
                    foreach (var c in clientes)
                    {
                        Console.WriteLine("{0,-6} | {1,-25} | {2,-15} | {3,-25}", c.Id, c.RazonSocial, c.Rut, c.Direccion);
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al listar clientes: {ex.Message}");
            }
            Pausar();
        }

        private static void Pausar()
        {
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey(true);
        }

        private static void AgregarCliente()
        {
            Console.Clear();
            Console.WriteLine("--- AGREGAR CLIENTE ---");
            try
            {
                Console.Write("Razón Social: ");
                string razonSocial = Console.ReadLine()?.Trim() ?? "";

                Console.Write("RUT (12 dígitos): ");
                string rut = Console.ReadLine()?.Trim() ?? "";

                Console.Write("Dirección: ");
                string direccion = Console.ReadLine()?.Trim() ?? "";

                Cliente nuevo = new Cliente
                {
                    RazonSocial = razonSocial,
                    Rut = rut,
                    Direccion = direccion
                };

                bool exito = _clienteService.Agregar(nuevo);
                if (exito)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n¡Cliente registrado con éxito!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {

                MostrarError($"Error al agregar cliente: {ex.Message}");
            }
            Pausar();
        }

        private static void ModificarCliente()
        {
            Console.Clear();
            Console.WriteLine("--- MODIFICAR CLIENTE ---");
            try
            {
                Console.Write("Ingrese el ID del Cliente a modificar: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    MostrarError("ID no válido.");
                    Pausar();
                    return;
                }

                var existente = _clienteService.ObtenerPorId(id);
                if (existente == null)
                {
                    MostrarError("Cliente no encontrado.");
                    Pausar();
                    return;
                }

                Console.WriteLine($"Cliente actual: {existente.RazonSocial} (RUT: {existente.Rut})");
                Console.Write("Nueva Razón Social (dejar vacío para mantener): ");
                string rs = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrEmpty(rs)) existente.RazonSocial = rs;

                Console.Write("Nuevo RUT (dejar vacío para mantener): ");
                string rut = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrEmpty(rut)) existente.Rut = rut;

                Console.Write("Nueva Dirección (dejar vacío para mantener): ");
                string dir = Console.ReadLine()?.Trim() ?? "";
                if (!string.IsNullOrEmpty(dir)) existente.Direccion = dir;

                bool exito = _clienteService.Modificar(existente);
                if (exito)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n¡Cliente modificado con éxito!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al modificar cliente: {ex.Message}");
            }
            Pausar();
        }

        private static void EliminarCliente()
        {
            Console.Clear();
            Console.WriteLine("--- ELIMINAR CLIENTE ---");
            try
            {
                Console.Write("Ingrese el ID del Cliente a eliminar: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    MostrarError("ID no válido.");
                    Pausar();
                    return;
                }

                Console.Write($"¿Está seguro de eliminar al cliente con ID {id}? (S/N): ");
                string conf = Console.ReadLine()?.Trim().ToUpper() ?? "";
                if (conf == "S")
                {
                    bool exito = _clienteService.Eliminar(id);
                    if (exito)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n¡Cliente eliminado correctamente!");
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al eliminar cliente: {ex.Message}");
            }
            Pausar();
        }

        // Submenú Proyectos
        private static void SubmenuProyectos()
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- GESTIÓN DE PROYECTOS ---");
                Console.ResetColor();
                Console.WriteLine("1. Listar Proyectos");
                Console.WriteLine("2. Agregar Proyecto");
                Console.WriteLine("3. Modificar Estado / Fechas de Proyecto");
                Console.WriteLine("4. Eliminar Proyecto");
                Console.WriteLine("0. Volver al Menú Principal");
                Console.Write("Opción: ");

                string op = Console.ReadLine()?.Trim() ?? "";
                switch (op)
                {
                    case "1": ListarProyectos(); break;
                    case "2": AgregarProyecto(); break;
                    case "3": ModificarProyecto(); break;
                    case "4": EliminarProyecto(); break;
                    case "0": volver = true; break;
                }
            }
        }

        private static void ListarProyectos()
        {
            Console.Clear();
            Console.WriteLine("--- LISTADO DE PROYECTOS ---");
            try
            {
                var proyectos = _proyectoService.ObtenerTodos();
                if (proyectos.Count == 0)
                {
                    Console.WriteLine("No hay proyectos registrados.");
                }
                else
                {
                    Console.WriteLine("{0,-4} | {1,-20} | {2,-12} | {3,-12} | {4,-12} | {5,-12}",
                        "ID", "Nombre", "Tipo", "Estado", "Presupuesto", "F. Inicio");
                    Console.WriteLine(new string('-', 82));
                    foreach (var p in proyectos)
                    {
                        Console.WriteLine("{0,-4} | {1,-20} | {2,-12} | {3,-12} | {4,-12:C0} | {5,-12:yyyy-MM-dd}",
                            p.Id, p.Nombre, p.Tipo, p.Estado, p.PresupuestoInicial, p.FechaInicio);
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al listar proyectos: {ex.Message}");
            }
            Pausar();
        }

        private static void AgregarProyecto()
        {
            Console.Clear();
            Console.WriteLine("--- AGREGAR PROYECTO ---");
            try
            {
                Console.Write("ID del Cliente asociado: ");
                if (!int.TryParse(Console.ReadLine(), out int clienteId))
                {
                    MostrarError("ID de cliente inválido.");
                    Pausar();
                    return;
                }

                Console.Write("Nombre del Proyecto: ");
                string nombre = Console.ReadLine()?.Trim() ?? "";

                Console.WriteLine("Tipo de Proyecto (1: Por Hora, 2: Monto Mensual, 3: Precio Fijo): ");
                int.TryParse(Console.ReadLine(), out int tipoInt);
                TipoProyecto tipo = (TipoProyecto)tipoInt;
                Console.Write("Presupuesto Inicial ($): ");
                double.TryParse(Console.ReadLine(), out double presupuesto);

                Console.Write("Fecha de Inicio (YYYY-MM-DD): ");
                DateTime.TryParse(Console.ReadLine(), out DateTime fechaInicio);

                Console.Write("Fecha Fin Planificada (YYYY-MM-DD): ");
                DateTime.TryParse(Console.ReadLine(), out DateTime fechaFinPlan);

                Proyecto nuevo = new Proyecto
                {
                    ClienteId = clienteId,
                    Nombre = nombre,
                    Tipo = tipo,
                    PresupuestoInicial = presupuesto,
                    FechaInicio = fechaInicio,
                    FechaFinPlanificada = fechaFinPlan,
                    Estado = EstadoProyecto.Planificado
                };

                bool exito = _proyectoService.Agregar(nuevo);
                if (exito)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n¡Proyecto registrado correctamente!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al agregar proyecto: {ex.Message}");
            }
            Pausar();
        }

        private static void ModificarProyecto()
        {
            Console.Clear();
            Console.WriteLine("--- MODIFICAR PROYECTO ---");
            try
            {
                Console.Write("Ingrese el ID del Proyecto a modificar: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    MostrarError("ID inválido.");
                    Pausar();
                    return;
                }

                var p = _proyectoService.ObtenerPorId(id);
                if (p == null)
                {
                    MostrarError("Proyecto no encontrado.");
                    Pausar();
                    return;
                }
                Console.WriteLine($"Proyecto: {p.Nombre} | Estado Actual: {p.Estado}");
                Console.WriteLine("Nuevo Estado (1: Planificado, 2: EnCurso, 3: Finalizado, 4: Cancelado - Enter para mantener):");
                string stInput = Console.ReadLine()?.Trim() ?? "";
                if (int.TryParse(stInput, out int st)) p.Estado = (EstadoProyecto)st;

                if (p.Estado == EstadoProyecto.Finalizado && !p.FechaFin.HasValue)
                {
                    p.FechaFin = DateTime.Now;
                }

                bool exito = _proyectoService.Modificar(p);
                if (exito)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n¡Proyecto actualizado exitosamente!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al modificar proyecto: {ex.Message}");
            }
            Pausar();
        }

        private static void EliminarProyecto()
        {
            Console.Clear();
            Console.WriteLine("--- ELIMINAR PROYECTO ---");
            try
            {
                Console.Write("Ingrese el ID del Proyecto a eliminar: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    MostrarError("ID inválido.");
                    Pausar();
                    return;
                }

                Console.Write($"¿Confirmar eliminación del proyecto ID {id}? (S/N): ");
                if (Console.ReadLine()?.Trim().ToUpper() == "S")
                {
                    bool exito = _proyectoService.Eliminar(id);
                    if (exito)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n¡Proyecto eliminado!");
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError($"Error al eliminar proyecto: {ex.Message}");
            }
            Pausar();
        }

        // Auxiliares
        private static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ERROR] {mensaje}");
            Console.ResetColor();
        }
    }
}