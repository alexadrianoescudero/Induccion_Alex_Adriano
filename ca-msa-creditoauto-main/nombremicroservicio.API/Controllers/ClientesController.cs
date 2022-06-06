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
    public class ClientesController : ControllerBase
    {
        private readonly ICliente servicio;

        public ClientesController(ICliente _servicio)
        {
            servicio = _servicio;
        }
        [HttpGet]
        [Route("Clientes")]
        public async Task<Respuesta> Clientes()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarClientes();
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }
        [HttpGet]
        [Route("Cliente/{Identificacion}")]
        public async Task<Respuesta> ConsultarCliente(string Identificacion)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarCliente(Identificacion);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = "Ocurrio un error: " + e.StackTrace;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("Cliente")]
        public async Task<Respuesta> CrearCliente(Cliente oCLiente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearCliente(oCLiente);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpPut]
        [Route("Cliente/{Identificacion}")]
        public async Task<Respuesta> EditarCliente(string Identificacion, Cliente oCliente)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EditarCliente(oCliente);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpDelete]
        [Route("Cliente/{Identificacion}")]
        public async Task<Respuesta> EliminarCliente(string Identificacion)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EliminarCliente(Identificacion);
            }
            catch
            {
                respuesta.MensajeRespuesta = Mensajes.MensajeClienteEliminarError;
            }
            return respuesta;
        }
    }
}
