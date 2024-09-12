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


            bool exito = false;
            while (!exito)
            {
                Console.WriteLine("Inicie sesión con su usuario:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Contraseña:");
                string password = Console.ReadLine();

                if (nombre != usuario.Nombre || password != usuario.Password)
                {
                    Console.WriteLine("Usuario o contraseña icnorrectos...");
                }

                else { exito = true; }
            }
            Console.WriteLine("\nBienvenido a BOOKSELLER-----A Continuación nuestro catalogo de libros\n");
            Console.WriteLine("NOMBRE --- PRECIO --- TIPO --- CANTIDAD --- ID\n");
            Console.WriteLine($"SALDO DISPONIBLE: {tarjeta.Saldo}\n");
            foreach (var libro in libreria.Lista)
            {
                Console.WriteLine($"{libro.Nombre}, {libro.Precio}, {libro.TipoLibro}, {libro.Cantidad}, {libro.CodigoLibro}\n");  
            }
            Console.WriteLine("1.Agregar libros al carrito\n2.Remover libros\n3.Ver carrito\n4.Salir");
            string opcionMenu = "0";
            while (opcionMenu != "3")
            {
                switch (opcionMenu)
                {
                    case "1":
                        Console.WriteLine("Agregar libros al carrito");
                        ComprarLibros();
                        break;

                    case "2":
                        Console.WriteLine("Eliminar libros del carrito");
                        break;
                    case "3":
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    case "4":
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opcion ingresada no valida");
                        break;

                }//Switch
            }//While menu
            void ComprarLibros()
            {
                List<Libro> Pedido = new List<Libro>();
                Libreria libreria = new Libreria();
                TarjetaDeCredito tarjeta = new TarjetaDeCredito();
                double totalCompra = 0;
                bool comprado = false;
                while (!comprado)
                {
                    Console.WriteLine("Seleccione los libros que desee comprar (escriba 00 para salir)");
                    int codigoElegido = int.Parse(Console.ReadLine());
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
                                                Pedido.Add(libro);
                                            }
                                            totalCompra += libro.Precio * cantidadElegida;
                                            tarjeta.Saldo -= cantidadElegida * libro.Precio;
                                            libro.Cantidad -= cantidadElegida;
                                            Console.WriteLine($"Su total es: {totalCompra}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Saldo insuficiente...");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Datos de tarjeta invalidos...");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error cantidad invalida...");
                                }
                            }
                        }
                        else if (codigoElegido == 00)
                        {
                            comprado = true;
                        }
                        else
                        {
                            encontrado = false;
                        }
                    }
                    if (!encontrado)
                    {
                        Console.WriteLine("El libro elegido no existe...");
                    }

                }//While comprando
            }//ComprarLibros()
        }//Main
    }//Program
}//Namespace