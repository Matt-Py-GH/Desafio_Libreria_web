namespace Libreria_web.clases
{
    double totalCompra = 0;
    bool comprado = false;
    public void ComprarLibros()
    {
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
        }
    }


}