using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface IEjecutivo
    {
        Task<Respuesta> ConsultarEjecutivos();
        Task<Respuesta> ConsultarEjecutivo(string id);
        Task<Respuesta> CrearEjecutivo(Ejecutivo oCliente);
        Task<Respuesta> EditarEjecutivo(Ejecutivo oCliente);
        Task<Respuesta> EliminarEjecutivo(string id);
    }
}
