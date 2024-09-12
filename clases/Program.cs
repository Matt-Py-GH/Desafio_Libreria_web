using Libreria_web.clases;
using System.Security.Cryptography.X509Certificates;

namespace Libreria_web {
    class Program
    {
        static void Main()
        {
            List<Libro> Pedido = new List<Libro>();
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
             
            
        }
    }
}