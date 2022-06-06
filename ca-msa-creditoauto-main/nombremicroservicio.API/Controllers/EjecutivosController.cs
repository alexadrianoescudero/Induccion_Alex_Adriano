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
    public class EjecutivosController : ControllerBase
    {
        private readonly IEjecutivo servicio;

        public EjecutivosController(IEjecutivo _servicio)
        {
            servicio = _servicio;
        }
        [HttpGet]
        [Route("Ejecutivos")]
        public async Task<Respuesta> Ejecutivos()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarEjecutivos();
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }
        [HttpGet]
        [Route("Ejecutivo/{Identificacion}")]
        public async Task<Respuesta> ConsultarEjecutivo(string Identificacion)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarEjecutivo(Identificacion);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("Ejecutivo")]
        public async Task<Respuesta> CrearEjecutivo(Ejecutivo oEjecutivo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearEjecutivo(oEjecutivo);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpPut]
        [Route("Ejecutivo/{Identificacion}")]
        public async Task<Respuesta> EditarEjecutivo(string Identificacion, Ejecutivo oEjecutivo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (Identificacion != oEjecutivo.EjIdentificacion)
                {
                    respuesta.MensajeRespuesta = $"La identificacion ingresano no existe: {Identificacion}";
                }
                else
                {
                    respuesta = await servicio.EditarEjecutivo(oEjecutivo);
                }
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpDelete]
        [Route("Ejecutivo/{Identificacion}")]
        public async Task<Respuesta> EliminarEjecutivo(string Identificacion)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EliminarEjecutivo(Identificacion);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }
    }
}
