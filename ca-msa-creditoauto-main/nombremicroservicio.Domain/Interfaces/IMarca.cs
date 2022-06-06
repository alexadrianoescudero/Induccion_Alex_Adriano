using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface IMarca
    {
        Task<Respuesta> ConsultarMarcas();
        Task<Respuesta> ConsultarMarca(int id);
        Task<Respuesta> CrearMarca(Marca oCliente);
        Task<Respuesta> EditarMarca(Marca oCliente);
        Task<Respuesta> EliminarMarca(int id);
    }
}
