using Libreria_web.clases;
using System.Security.Cryptography.X509Certificates;

namespace Libreria_web {
    class Program
    {
        static void Main()
        {
            
            Usuario usuario = new Usuario();
            Libreria libreria = new Libreria();
            TarjetaDeCredito tarjeta = new TarjetaDeCredito();
            List<Libro> pedido = new List<Libro>();


            bool exito = false;
            while (!exito)
            {
                Console.WriteLine("Inicie sesión con su usuario:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Contraseña:");
                string password = Console.ReadLine();

                if (nombre != usuario.Nombre.Trim() || password != usuario.Password.Trim())
                {
                    Console.WriteLine("Usuario o contraseña icnorrectos...");
                }

                else { exito = true; }
            }

            string opcionMenu = "0";
            while (opcionMenu != "4")
            {
                Console.Clear();
                Console.WriteLine("1.Agregar libros al carrito\n2.Remover libros\n3.Ver carrito\n4.Salir");
                Console.WriteLine("Ingrese la opcion que desea: ");
                opcionMenu = Console.ReadLine();
                switch (opcionMenu)
                {
                    case "1":
                        Console.WriteLine("Agregar libros al carrito");
                        ComprarLibros();
                        break;

                    case "2":
                        EliminarLibrosCarrito();
                        break;
                    case "3":
                        ListarCarrito(true);
                        break;
                    case "4":
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opcion ingresada no valida");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }//Switch
            }

            void ListarCarrito(bool beep)
            {
                Console.Clear();
                Console.WriteLine("Carrito: \n");
                foreach (var item in pedido)
                {
                    Console.WriteLine($"{item.CodigoLibro}, {item.Nombre}\n");
                }
                Console.Beep();
                
                if (beep) { Console.ReadKey(); Console.WriteLine("Presione cualquier tecla para continuar..."); }
                
            }

            void EliminarLibrosCarrito()
            {
                Console.Clear();
                ListarCarrito(false);
                Console.WriteLine("Escriba el ID del libro que desea eliminar de su carrito: ");
                string codigo = Console.ReadLine();

                Libro libroEncontrado = null;
                foreach (var item in pedido)
                {
                    if (item.CodigoLibro.ToString() == codigo)
                    {
                        libroEncontrado = item;
                        break;
                    }
                }

                if (libroEncontrado != null)
                {
                    Console.WriteLine("Libro encontrado, seguro que desea eliminarlo? (S/N)");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "s")
                    {
                        pedido.Remove(libroEncontrado);
                        tarjeta.Saldo += libroEncontrado.Precio;
                        Console.WriteLine("Libro eliminado del carrito.");
                    }
                    else
                    {
                        Console.WriteLine("Operación cancelada...");
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Libro no encontrado...");
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadLine();
                }
            }

            void Listado()
            {
                Console.Clear();
                Console.Beep();
                Console.WriteLine("\nBienvenido a BOOKSELLER-----A Continuación nuestro catalogo de libros\n");
                Console.WriteLine("NOMBRE --- PRECIO --- TIPO --- CANTIDAD --- ID\n");
                Console.WriteLine($"SALDO DISPONIBLE: {tarjeta.Saldo}\n");
                foreach (var libro in libreria.Lista)
                {
                    Console.WriteLine($"{libro.Nombre}, {libro.Precio}, {libro.TipoLibro}, {libro.Cantidad}, {libro.CodigoLibro}\n");
                }
            }

            void ComprarLibros()
            {
                Listado();
                double totalCompra = 0;
                int codigoElegido = -1;
                while (codigoElegido != 0)
                {
                    Console.WriteLine("Seleccione los libros que desee comprar (escriba 0 para salir)");
                    codigoElegido = int.Parse(Console.ReadLine());
                    bool encontrado = false;
                    foreach (var libro in libreria.Lista)
                    {
                        if (codigoElegido == libro.CodigoLibro)
                        {
                            encontrado = true;
                            if (encontrado == true)
                            {
                                Console.WriteLine("Elija cuantos quiere:");
                                int cantidadElegida = int.Parse(Console.ReadLine());
                                if (cantidadElegida <= libro.Cantidad)
                                {
                                    Console.WriteLine("Introduzca num tarjeta, CVC");
                                    string num = Console.ReadLine();
                                    string CVC = Console.ReadLine();

                                    if (num == tarjeta.NumeroTarjeta.ToString() && CVC == tarjeta.CodigoSeguridad.ToString())
                                    {
                                        if (tarjeta.Saldo >= cantidadElegida * libro.Precio)
                                        {
                                            for (int i = 0; i < cantidadElegida; i++)
                                            {
                                                pedido.Add(libro);
                                            }
                                            totalCompra += libro.Precio * cantidadElegida;
                                            tarjeta.Saldo -= cantidadElegida * libro.Precio;
                                            libro.Cantidad -= cantidadElegida;
                                            Console.WriteLine($"Su total es: {totalCompra}");
                                            Console.WriteLine($"Su saldo restante es: {tarjeta.Saldo}");
                                            Console.WriteLine("Libros añadidos al carrito\n");
                                            Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                            Console.ReadLine();
                                            break;
                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine("Saldo insuficiente...");
                                            Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                            Console.ReadLine();
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Datos de tarjeta invalidos...");
                                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                        Console.ReadLine();
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error cantidad invalida...");
                                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Libro no encontrado...");
                                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                Console.ReadLine();
                                break;
                            }
                        }//if compara codigos
                    }//foreach

                }//While comprando
            }//ComprarLibros()
        }//Main
    }//Program
}//Namespace