using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Entities.Utlitarios
{
    public class Respuesta
    {
        public bool EjecucionRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public object ObjetoRespuesta { get; set; }
        public bool RegistroExistente { get; set; }
    }
}
