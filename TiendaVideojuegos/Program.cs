using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaVideojuegos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GestorUsuarios gestor = new GestorUsuarios();
            ServicioApi api = new ServicioApi();
            List<Usuario> usuarios = gestor.CargarUsuarios();
            List<Juego> catalogogames = await api.ObtenerJuegosAsync();
            Usuario usuarioActual = null;

            while (usuarioActual == null)
            {
                Console.Clear();
                Console.WriteLine("=== BIENVENIDO A LA TIENDA DE VIDEOJUEGOS ===");
                Console.WriteLine("1. Registrarse");
                Console.WriteLine("2. Iniciar Sesión");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.Write("Ingrese Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Ingrese Contraseña: ");
                    string pass = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(pass))
                    {
                        var nuevoUsuario = new Usuario(nombre, email, pass, RolUsuario.Cliente);
                        usuarios.Add(nuevoUsuario);
                        gestor.GuardarUsuarios(usuarios);
                        Console.WriteLine("¡Registro exitoso! Presione Enter...");
                    }
                    else
                    {
                        Console.WriteLine("Datos inválidos. Presione Enter...");
                    }
                    Console.ReadLine();
                }
                else if (opcion == "2")
                {
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Contraseña: ");
                    string pass = Console.ReadLine();

                    usuarioActual = usuarios.FirstOrDefault(u => u.Email == email && u.Password == pass);

                    if (usuarioActual == null)
                    {
                        Console.WriteLine("Credenciales incorrectas. Presione Enter...");
                        Console.ReadLine();
                    }
                }
                else if (opcion == "3")
                {
                    return;
                }
            }

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine($"=== SESIÓN INICIADA: {usuarioActual.Nombre.ToUpper()} ===");
                Console.WriteLine("1. Ver Catálogo de Juegos");
                Console.WriteLine("2. Comprar Juego");
                Console.WriteLine("3. Ver mis Juegos Comprados");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--- CATÁLOGO DE JUEGOS ---");
                        foreach (var item in catalogogames)
                        {
                            IMostrable mostrable = item;
                            mostrable.MostrarDetalle();
                        }
                        Console.WriteLine("\nPresione Enter para volver...");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Ingrese el ID del juego que desea comprar: ");
                        if (int.TryParse(Console.ReadLine(), out int idBuscado))
                        {
                            Juego juegoEncontrado = catalogogames.FirstOrDefault(j => j.Id == idBuscado);
                            if (juegoEncontrado != null)
                            {
                                usuarioActual.JuegosComprados.Add(juegoEncontrado);
                                gestor.GuardarUsuarios(usuarios);
                                Console.WriteLine($"¡Compraste '{juegoEncontrado.Titulo}' con éxito!");
                            }
                            else
                            {
                                Console.WriteLine("El ID ingresado no existe.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID inválido.");
                        }
                        Console.WriteLine("Presione Enter para continuar...");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("--- MIS JUEGOS COMPRADOS ---");
                        if (usuarioActual.JuegosComprados.Count == 0)
                        {
                            Console.WriteLine("Aún no has comprado juegos.");
                        }
                        else
                        {
                            foreach (var juego in usuarioActual.JuegosComprados)
                            {
                                IMostrable mostrable = juego;
                                mostrable.MostrarDetalle();
                            }
                        }
                        Console.WriteLine("\nPresione Enter para volver...");
                        Console.ReadLine();
                        break;

                    case "4":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Presione Enter...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}