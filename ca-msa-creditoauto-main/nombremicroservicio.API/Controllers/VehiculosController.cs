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
    public class VehiculosController
    {
        private readonly IVehiculo servicio;

        public VehiculosController(IVehiculo _servicio)
        {
            servicio = _servicio;
        }

        [HttpGet]
        [Route("Vehiculos")]
        public async Task<Respuesta> Vehiculos()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarVehiculos();
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpGet]
        [Route("Vehiculo/{strparametro}")]
        public async Task<Respuesta> CrearVehiculo(string strparametro)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.ConsultarVehiculo(strparametro);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("Vehiculo")]
        public async Task<Respuesta> CrearVehiculo(Vehiculo oVehiculo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.CrearVehiculo(oVehiculo);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpPut]
        [Route("Vehiculo/{id}")]
        public async Task<Respuesta> EditarVehiculo(int id , Vehiculo oVehiculo)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                if (id != oVehiculo.VeMarcaId)
                {
                    respuesta.MensajeRespuesta = $"El id ingresado no coincide: {oVehiculo.VeMarcaId}";
                }
                else
                {
                    respuesta.ObjetoRespuesta = await servicio.EditarVehiculo(oVehiculo);
                }
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;
        }

        [HttpDelete]
        [Route("Vehiculo/{id}")]
        public async Task<Respuesta> EliminarVehiculo(int id)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                respuesta = await servicio.EliminarVehiculo(id);
            }
            catch (Exception e)
            {
                respuesta.MensajeRespuesta = e.Message;
            }
            return respuesta;

        }
    }
}
