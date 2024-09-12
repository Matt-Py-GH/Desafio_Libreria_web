using Libreria_web.clases;
public class Usuario
{
    private string _nombre = "Mateo";
    private string _password = "1234Pass";
    private TarjetaDeCredito _creditCard;
    private double _dinero;

    public string Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }

    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    public double Dinero { get { return _dinero; } set { _dinero = value; } }
}