namespace Libreria_web.clases
{
    public class TarjetaDeCredito
    {
        private long _numeroTarjeta = 1234;
        private DateTime _fechaVencimiento = new DateTime(2020, 1, 1);
        private int _codigoSeguridad = 012;
        private double _saldo = 345.70;

        public long NumeroTarjeta
        {
            get { return _numeroTarjeta; }
            set {  _numeroTarjeta = value; }             
        }

        public int CodigoSeguridad
        {
            get { return _codigoSeguridad; }
            set { _codigoSeguridad = value; }
        }

        public DateTime FechaVenc
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }

        public double Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }
    }
}
