namespace Parking.Entity
{
    public class Vehiculo
    {
        public int IDVehiculo { get; set; }
        public int IDCliente { get; set; }
        public int IDMarca { get; set; }
        public string NombreMarca { get; set; }
        public int IDModelo { get; set; }
        public string DescripcionModelo { get; set; }
        public string Placa { get; set; }
    }
}