using System;
using System.Collections.Generic;


namespace nombremicroservicio.Entities.Model
{
    public  class Cliente
    {
        public Cliente()
        {
            Asignacionclientes = new HashSet<Asignacioncliente>();
            SolicitudCreditos = new HashSet<SolicitudCredito>();
        }

        public string ClIdentificacion { get; set; }
        public string ClNombres { get; set; }
        public int ClEdad { get; set; }
        public DateTime ClFechaNacimiento { get; set; }
        public string ClApellidos { get; set; }
        public string ClDireccion { get; set; }
        public string ClTelefono { get; set; }
        public int ClEstadoCivil { get; set; }
        public string ClIdentificacionConyugue { get; set; }
        public string ClNombreConyugue { get; set; }
        public int? ClSujetoCredito { get; set; }

        public virtual ICollection<Asignacioncliente> Asignacionclientes { get; set; }
        public virtual ICollection<SolicitudCredito> SolicitudCreditos { get; set; }
    }
}
