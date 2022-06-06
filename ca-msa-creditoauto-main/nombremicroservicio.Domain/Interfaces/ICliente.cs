using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface ICliente
    {
        Task<Respuesta> ConsultarClientes();
        Task<Respuesta> ConsultarCliente(string id);
        Task<Respuesta> CrearCliente(Cliente oCliente);
        Task<Respuesta> EditarCliente(Cliente oCliente);
        Task<Respuesta> EliminarCliente(string id);
    }
}
