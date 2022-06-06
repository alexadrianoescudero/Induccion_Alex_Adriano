using System;
using System.Collections.Generic;


namespace nombremicroservicio.Entities.Model
{
    public  class Marca
    {
        public Marca()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int MaId { get; set; }
        public string MaNombre { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
