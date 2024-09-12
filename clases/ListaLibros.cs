using Libreria_web.clases;


namespace Libreria_web.clases
{
    public class Libreria
    {
        public List<Libro> Lista { get; set; }

        public Libreria()
        {
            Lista = new List<Libro>
            {
                new Libro("Libro A1", "Ficción", 15.99, 100, 1),
                new Libro("Libro A2", "Ficción", 18.50, 120, 2),

                new Libro("Libro B1", "Ciencia", 20.99, 50, 3),
                new Libro("Libro B2", "Ciencia", 22.99, 60, 4),

                new Libro("Libro C1", "Historia", 10.50, 80, 5),
                new Libro("Libro C2", "Historia", 12.75, 90, 6),

                new Libro("Libro D1", "Fantasía", 25.30, 70, 7),
                new Libro("Libro D2", "Fantasía", 27.10, 85, 8),

                new Libro("Libro E1", "Misterio", 13.99, 40, 9),
                new Libro("Libro E2", "Misterio", 16.75, 45, 10),

                new Libro("Libro F1", "Programación", 30.99, 40, 12),
                new Libro("Libro F2", "Electrónica", 35.75, 45, 13)
            };
        }
    }
}
