using System.Collections.Generic;

namespace nombremicroservicio.Entities.Model
{
    public class Patio
    {
        public Patio()
        {
            Asignacionclientes = new HashSet<Asignacioncliente>();
            Ejecutivos = new HashSet<Ejecutivo>();
            SolicitudCreditos = new HashSet<SolicitudCredito>();
        }

        public int PaId { get; set; }
        public string PaNombre { get; set; }
        public string PaDireccion { get; set; }
        public string PaTelefono { get; set; }
        public int PaNumeroPuntoVenta { get; set; }

        public virtual ICollection<Asignacioncliente> Asignacionclientes { get; set; }
        public virtual ICollection<Ejecutivo> Ejecutivos { get; set; }
        public virtual ICollection<SolicitudCredito> SolicitudCreditos { get; set; }
    }
}
