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
    public class MarcasController
    {
        private readonly IMarca servicio;

        public MarcasController(IMarca _servicio)
        {
            servicio = _servicio;
        }

        [HttpGet]
        [Route("Marcas")]
        public async Task<Respuesta> Marcas()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarMarcas();
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpGet]
        [Route("Marca/{Id}")]
        public async Task<Respuesta> Marca(int Id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarMarca(Id);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("Marca")]
        public async Task<Respuesta> CrearMarca(Marca oMarca)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearMarca(oMarca);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpPut]
        [Route("Marca/{Id}")]
        public async Task<Respuesta> EditarMarca(int Id , Marca oMarca)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (Id != oMarca.MaId)
                {
                    respuesta.MensajeRespuesta = $"El id ingresa no existe: {oMarca.MaId}";
                }
                else
                {
                    respuesta.ObjetoRespuesta = await servicio.EditarMarca(oMarca);
                }
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpDelete]
        [Route("Marca/{id}")]
        public async Task<Respuesta> EliminarMarca(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EliminarMarca(id);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;

        }
    }
}
