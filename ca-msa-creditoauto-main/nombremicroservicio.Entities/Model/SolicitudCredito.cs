namespace nombremicroservicio.Entities.Model
{
    public partial class SolicitudCredito
    {
        public int ScId { get; set; }
        public string ScIdentificacionCliente { get; set; }
        public int ScPatio { get; set; }
        public int ScVehiculo { get; set; }
        public int ScMesesPlazo { get; set; }
        public int ScCuotas { get; set; }
        public decimal ScEntrada { get; set; }
        public string ScIdentificacionEjecutivo { get; set; }
        public string ScObservacion { get; set; }
        public int ScEstado { get; set; }
        public virtual Cliente ScIdentificacionClienteNavigation { get; set; }
        public virtual Ejecutivo ScIdentificacionEjecutivoNavigation { get; set; }
        public virtual Patio ScPatioNavigation { get; set; }
        public virtual Vehiculo ScVehiculoNavigation { get; set; }
    }
}
