using Microsoft.AspNetCore.Mvc;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using System;
using System.Threading.Tasks;

namespace nombremicroservicio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudCreditosController : ControllerBase
    {
        private readonly ISolicitudCredito servicio;

        public SolicitudCreditosController(ISolicitudCredito _servicio)
        {
            servicio = _servicio;
        }
        [HttpGet]
        [Route("SolicitudCreditos")]
        public async Task<Respuesta> SolicitudCreditos()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarSolicitudCreditos();
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }
        [HttpGet]
        [Route("SolicitudCredito/{Id}")]
        public async Task<Respuesta> ConsultarSolicitudCredito(int Id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarSolicitudCredito(Id);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("SolicitudCredito")]
        public async Task<Respuesta> CrearSolicitudCredito(SolicitudCredito oSolicitudCredito)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearSolicitudCredito(oSolicitudCredito);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }       
    }
}
