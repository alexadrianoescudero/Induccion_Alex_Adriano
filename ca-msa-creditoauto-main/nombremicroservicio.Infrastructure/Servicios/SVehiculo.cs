using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using nombremicroservicio.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure.Servicios
{
    public class SVehiculo : IVehiculo
    {
        private readonly DemoPichinchaContext _context;
        public SVehiculo(DemoPichinchaContext context)
        {
            _context = context;
        }
        public async Task<Respuesta> ConsultarVehiculos()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Vehiculos.ToListAsync();
            return respuesta;
        }
        public async Task<Respuesta> ConsultarVehiculo(string parametro)
        {
            List<Vehiculo> oVehiculo = new List<Vehiculo>();
            Respuesta respuesta = new Respuesta();
            int fecha = 0;
            if (int.TryParse(parametro, out fecha))
            {
                var datos= await _context.Asignacionclientes.Where(x => x.AcIdPatioNavigation.PaId == x.AcIdPatio && x.AcIdentificacionClienteNavigation.ClIdentificacion == x.AcIdentificacionCliente && x.AcFechaCreacion.Date.Year == fecha).ToListAsync();
                foreach (var item in datos)
                {
                    var valores = await _context.SolicitudCreditos.Include(x => x.ScVehiculoNavigation).FirstOrDefaultAsync(x => x.ScIdentificacionCliente == item.AcIdentificacionCliente && x.ScPatio == item.AcIdPatio);
                    oVehiculo.Add(valores.ScVehiculoNavigation);

                }
                respuesta.ObjetoRespuesta = oVehiculo.Distinct();
                return respuesta;
            }
            respuesta.ObjetoRespuesta = await _context.Vehiculos.Where(x => x.VeModelo == parametro || x.VeMarca.MaNombre == parametro).ToListAsync();
            return respuesta;
        }
        public async Task<Respuesta> CrearVehiculo(Vehiculo oVehiculo)
        {
            Respuesta respuesta = new Respuesta();
            respuesta = await ExisteVehiculo(oVehiculo.VePlaca);
            if (respuesta.ObjetoRespuesta != null)
            {
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteExiste}";
                respuesta.ObjetoRespuesta = oVehiculo;
            }
            else
            {
                _context.Vehiculos.Add(oVehiculo);
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteCorrecto}";
                respuesta.ObjetoRespuesta = oVehiculo;
                await _context.SaveChangesAsync();
            }
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

        public async Task<Respuesta> EditarVehiculo(Vehiculo oVehiculo)
        {
            Respuesta respuesta = new Respuesta();
            _context.Entry(oVehiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEditar}";
            respuesta.ObjetoRespuesta = oVehiculo;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

        public async Task<Respuesta> EliminarVehiculo(int id)
        {
            Respuesta respuesta = new Respuesta();
            var oVehiculo = await _context.Vehiculos.FindAsync(id);
            if (oVehiculo == null)
            {
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEliminarError}";
                respuesta.ObjetoRespuesta = oVehiculo;
                return respuesta;
            }
            _context.Vehiculos.Remove(oVehiculo);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEliminar}";
            respuesta.ObjetoRespuesta = oVehiculo;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
        private async Task<Respuesta> ExisteVehiculo(string id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Vehiculos.FirstOrDefaultAsync(x => x.VePlaca == id);
            return respuesta;
        }
    }
}

