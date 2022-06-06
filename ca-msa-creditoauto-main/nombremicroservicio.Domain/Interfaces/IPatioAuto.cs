using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface IPatioAuto
    {
        Task<Respuesta> ConsultarPatioAutos();
        Task<Respuesta> ConsultarPatioAuto(int id);
        Task<Respuesta> CrearPatioAuto(Patio oPatioAuto);
        Task<Respuesta> EditarPatioAuto(Patio oPatioAuto);
        Task<Respuesta> EliminarPatioAuto(int id);
    }
}
