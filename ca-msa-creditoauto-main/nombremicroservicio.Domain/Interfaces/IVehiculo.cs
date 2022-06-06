using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface IVehiculo
    {
        Task<Respuesta> ConsultarVehiculos();
        Task<Respuesta> ConsultarVehiculo(string strparametro);
        Task<Respuesta> CrearVehiculo(Vehiculo oVehiculo);
        Task<Respuesta> EditarVehiculo(Vehiculo oVehiculo);
        Task<Respuesta> EliminarVehiculo(int id);
    }
}
