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
    public class AsignacionClientePatioController : ControllerBase
    {
        private readonly IAsignacionClientePatio servicio;

        public AsignacionClientePatioController(IAsignacionClientePatio _servicio)
        {
            servicio = _servicio;
        }

        [HttpGet]
        [Route("AsignacionClientePatios")]
        public async Task<Respuesta> AsignacionClientePatios()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarAsignacionClientePatios();
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpGet]
        [Route("AsignacionClientePatio/{Id}")]
        public async Task<Respuesta> AsignacionClientePatio(int Id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarAsignacionClientePatio(Id);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("AsignacionClientePatio")]
        public async Task<Respuesta> CrearAsignacionClientePatio(Asignacioncliente oAsignacioncliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearAsignacionClientePatio(oAsignacioncliente);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpPut]
        [Route("AsignacionClientePatio/{Id}")]
        public async Task<Respuesta> EditarAsignacionClientePatio(int id, Asignacioncliente oAsignacioncliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id != oAsignacioncliente.AcId)
                {
                    respuesta.MensajeRespuesta = $"El id ingresano no existe: {oAsignacioncliente.AcId}";
                }
                else
                {
                    respuesta.ObjetoRespuesta = await servicio.EditarAsignacionClientePatio(oAsignacioncliente);
                }
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpDelete]
        [Route("AsignacionClientePatio/{Id}")]
        public async Task<Respuesta> EliminarAsignacionClientePatio(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EliminarAsignacionClientePatio(id);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;

        }
    }
}
