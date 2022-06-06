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
    public class PatioAutosController : ControllerBase
    {
        private readonly IPatioAuto servicio;
        public PatioAutosController(IPatioAuto _servicio)
        {
            servicio = _servicio;
        }

        [HttpGet]
        [Route("PatioAutos")]
        public async Task<Respuesta> PatioAutos()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarPatioAutos();
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpGet]
        [Route("PatioAutos/{id}")]
        public async Task<Respuesta> PatioAuto(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarPatioAuto(id);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PatioAuto")]
        public async Task<Respuesta> CrearPatioAuto(Patio PatioAuto)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearPatioAuto(PatioAuto);
            }
            catch
            {
                respuesta.MensajeRespuesta = Mensajes.MensajeClienteError;
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PatioAutos/{id}")]
        public async Task<Respuesta> EditarPatioAuto(int id, Patio PatioAuto)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EditarPatioAuto(PatioAuto);
            }
            catch
            {
                respuesta.MensajeRespuesta = Mensajes.MensajePatioEditarError;
            }
            return respuesta;
        }

        [HttpDelete]
        [Route("PatioAuto/{id}")]
        public async Task<Respuesta> EliminarPatioAuto(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EliminarPatioAuto(id);
            }
            catch
            {
                respuesta.MensajeRespuesta = Mensajes.MensajePatioElminarError;
            }
            return respuesta;
        }
    }
}
