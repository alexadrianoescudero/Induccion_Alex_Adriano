using System;
using System.Collections.Generic;

namespace nombremicroservicio.Entities.Model
{
    public  class Ejecutivo
    {
        public Ejecutivo()
        {
            SolicitudCreditos = new HashSet<SolicitudCredito>();
        }

        public string EjIdentificacion { get; set; }
        public string EjNombre { get; set; }
        public string EjApellido { get; set; }
        public string EjDireccion { get; set; }
        public string EjTelefono { get; set; }
        public string EjCelular { get; set; }
        public int EjEdad { get; set; }
        public int EjPatio { get; set; }

        public virtual Patio EjPatioNavigation { get; set; }
        public virtual ICollection<SolicitudCredito> SolicitudCreditos { get; set; }

    }
}
