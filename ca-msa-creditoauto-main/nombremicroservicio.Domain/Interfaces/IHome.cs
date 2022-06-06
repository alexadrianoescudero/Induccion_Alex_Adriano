using nombremicroservicio.Entities.Utlitarios;
using System.Threading.Tasks;

namespace nombremicroservicio.Domain.Interfaces
{
    public interface IHome
    {
        Task<Respuesta> CargarDatosIniciales(int intTipo);
    }
}
