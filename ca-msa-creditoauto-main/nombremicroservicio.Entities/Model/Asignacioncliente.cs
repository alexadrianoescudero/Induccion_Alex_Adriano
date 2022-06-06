using System;


namespace nombremicroservicio.Entities.Model
{
    public partial class Asignacioncliente
    {
        public int AcId { get; set; }
        public string AcIdentificacionCliente { get; set; }
        public int AcIdPatio { get; set; }
        public DateTime AcFechaCreacion { get; set; }

        public virtual Patio AcIdPatioNavigation { get; set; }
        public virtual Cliente AcIdentificacionClienteNavigation { get; set; }
    }
}
