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
    public class AsignacionClientePatio : BaseTest
    {        
        [TestMethod]
        public async Task AsignacionCliente()
        {
            //prepacion
            string nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);
            Asignacioncliente oAsignacionclientes = new Asignacioncliente()
            {
                AcIdentificacionCliente = "0604434572",
                AcIdPatio = 1,
                AcFechaCreacion = DateTime.Now
            };
            contexto.Asignacionclientes.Add(oAsignacionclientes);
            await contexto.SaveChangesAsync();
            //Prueba
            IAsignacionClientePatio _servicio = new SAsignacionClientePatio(contexto);
            var respuesta = await _servicio.CrearAsignacionClientePatio(oAsignacionclientes);
            //verificacion
            Assert.IsTrue(respuesta.EjecucionRespuesta, "true");

        }
    }
}
