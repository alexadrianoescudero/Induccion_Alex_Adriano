using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface ISolicitudCredito
    {
        Task<Respuesta> ConsultarSolicitudCreditos();
        Task<Respuesta> ConsultarSolicitudCredito(int id);
        Task<Respuesta> CrearSolicitudCredito(SolicitudCredito oSolicitudCredito);
        Task<Respuesta> ValidarSolicitudPorDia(SolicitudCredito oSolicitudCredito, int Intestado);
        Task<int> ValidarSolicituEstado(SolicitudCredito oSolicitudCredito);
        Task<Respuesta> ValidarVehiculoReservado(SolicitudCredito oSolicitudCredito, int Intestado);
        Task<Respuesta> AsignacionClientePatio(SolicitudCredito oSolicitudCredito);
    }
}
