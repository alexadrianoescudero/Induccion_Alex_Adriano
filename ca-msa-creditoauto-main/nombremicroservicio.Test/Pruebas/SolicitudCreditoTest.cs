using Microsoft.VisualStudio.TestTools.UnitTesting;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities.Model;
using nombremicroservicio.Infrastructure.Servicios;
using nombremicroservicio.Test.Utilitarios;
using System;
using System.Threading.Tasks;
namespace nombremicroservicio.Test.Pruebas
{
    [TestClass]
    public class SolicitudCreditoTest : BaseTest
    {
        [TestMethod]
        public async Task ValidarSolicitudPorDia()
        {
            //prepacion
            string nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            SolicitudCredito oSolicitudCredito = new SolicitudCredito()
            {
                ScIdentificacionCliente = "0604434970",
                ScPatio = 1,
                ScVehiculo = 4,
                ScMesesPlazo = 10,
                ScEntrada = 11000,
                ScIdentificacionEjecutivo = "0604434571",
                ScObservacion = "",
                ScEstado = 1
            };
            contexto.SolicitudCreditos.Add(oSolicitudCredito);
            await contexto.SaveChangesAsync();
            //Prueba
            ISolicitudCredito _servicio = new SSolicitudCredito(contexto);
            var respuesta = await _servicio.ValidarSolicitudPorDia(oSolicitudCredito, 1);
            //verificacion
            Assert.IsTrue(respuesta.EjecucionRespuesta, "true");

        }
        [TestMethod]
        public async Task ValidarSolicituEstado()
        {
            //prepacion
            string nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            SolicitudCredito oSolicitudCredito = new SolicitudCredito()
            {
                ScIdentificacionCliente = "0604434970",
                ScPatio = 1,
                ScVehiculo = 4,
                ScMesesPlazo = 10,
                ScEntrada = 11000,
                ScIdentificacionEjecutivo = "0604434571",
                ScObservacion = "",
                ScEstado = 1
            };
            contexto.SolicitudCreditos.Add(oSolicitudCredito);
            await contexto.SaveChangesAsync();
            //Prueba
            ISolicitudCredito _servicio = new SSolicitudCredito(contexto);
            var respuesta = await _servicio.ValidarSolicituEstado(oSolicitudCredito);
            //verificacion
            Assert.AreEqual(respuesta, 1);

        }
        [TestMethod]
        public async Task ValidarVehiculoReservado()
        {
            //prepacion
            string nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            SolicitudCredito oSolicitudCredito = new SolicitudCredito()
            {
                ScIdentificacionCliente = "0604434970",
                ScPatio = 1,
                ScVehiculo = 4,
                ScMesesPlazo = 10,
                ScEntrada = 11000,
                ScIdentificacionEjecutivo = "0604434571",
                ScObservacion = "",
                ScEstado = 1
            };
            contexto.SolicitudCreditos.Add(oSolicitudCredito);
            await contexto.SaveChangesAsync();
            //Prueba
            ISolicitudCredito _servicio = new SSolicitudCredito(contexto);
            var respuesta = await _servicio.ValidarVehiculoReservado(oSolicitudCredito, 2);
            //verificacion
            Assert.IsTrue(respuesta.EjecucionRespuesta, "true");

        }
    }
}
