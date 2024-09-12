using Libreria_web.interfaces;

namespace Libreria_web.clases
{
    public class Libro : ILibro
    {
        public string Nombre { get; set; }
        public string TipoLibro { get; set; }
        public double Precio { get; set; }
        public int Cantidad {  get; set; }
        public int CodigoLibro { get; set; }

        public Libro(string nombre, string tipo, double precio, int cantidad, int codigo)
        {
            Nombre = nombre;
            TipoLibro = tipo;
            Precio = precio;
            Cantidad = cantidad;
            CodigoLibro = codigo;
        }

    }
    
}
