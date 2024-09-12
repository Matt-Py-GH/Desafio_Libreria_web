namespace Libreria_web.interfaces
{
    public interface ILibro
    {
        string Nombre { get; set; }
        string TipoLibro { get; set; }
        double Precio {  get; set; }
        int Cantidad { get; set; }
        int CodigoLibro { get; set; }
    }
}
