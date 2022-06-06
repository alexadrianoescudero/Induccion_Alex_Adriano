using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface IAsignacionClientePatio
    {
        Task<Respuesta> ConsultarAsignacionClientePatios();
        Task<Respuesta> ConsultarAsignacionClientePatio(int id);
        Task<Respuesta> CrearAsignacionClientePatio(Asignacioncliente oAsignacioncliente);
        Task<Respuesta> EditarAsignacionClientePatio(Asignacioncliente oAsignacioncliente);
        Task<Respuesta> EliminarAsignacionClientePatio(int id);
    }
}
