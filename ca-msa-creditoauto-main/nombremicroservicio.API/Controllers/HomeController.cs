using Microsoft.AspNetCore.Mvc;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities.Utlitarios;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace nombremicroservicio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHome servicio;
        public HomeController(IHome _servicio)
        {
            servicio = _servicio;
        }
        [HttpGet]
        [Route("CargarDatosIniciales/{id}")]
        public async Task<Respuesta> CargarDarosIniciales(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CargarDatosIniciales(id);
            }
            catch (Exception ex)
            {
                respuesta.MensajeRespuesta = "Error: " + ex.StackTrace;
            }
            return respuesta;
        }
    }
}
