using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using nombremicroservicio.Repository.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure.Servicios
{
    public class SPatioAuto : IPatioAuto
    {
        private readonly DemoPichinchaContext _context;
        public SPatioAuto(DemoPichinchaContext context)
        {
            _context = context;
        }

        public async Task<Respuesta> ConsultarPatioAutos()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Patios.ToListAsync();
            return respuesta;
        }

        public async Task<Respuesta> ConsultarPatioAuto(int id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Patios.FindAsync(id);
            return respuesta;
        }

        public async Task<Respuesta> CrearPatioAuto(Patio oPatioAuto)
        {
            Respuesta obrespuesta = await ExistePatioAuto(oPatioAuto.PaNombre);
            if (obrespuesta.RegistroExistente)
            {
                obrespuesta.MensajeRespuesta = Mensajes.MensajePatioExiste;
                obrespuesta.ObjetoRespuesta = oPatioAuto;
                obrespuesta.EjecucionRespuesta = true;
                return obrespuesta;
            }
            _context.Patios.Add(oPatioAuto);
            await _context.SaveChangesAsync();
            obrespuesta.MensajeRespuesta = Mensajes.MensajePatioCorrecto;
            obrespuesta.ObjetoRespuesta = oPatioAuto;
            return obrespuesta;
        }

        public async Task<Respuesta> EditarPatioAuto(Patio oPatioAuto)
        {
            Respuesta respuesta = new Respuesta();
            _context.Entry(oPatioAuto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = Mensajes.MensajePatioEditar;
            respuesta.ObjetoRespuesta = oPatioAuto;
            return respuesta;
        }
        public async Task<Respuesta> EliminarPatioAuto(int id)
        {
            Respuesta respuesta = new Respuesta();
            var oPatioAuto = await _context.Patios.FindAsync(id);
            if (oPatioAuto == null)
            {
                respuesta.MensajeRespuesta = Mensajes.MensajePatioEliminar;
                return respuesta;
            }
            _context.Patios.Remove(oPatioAuto);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = Mensajes.MensajePatioEliminar;
            respuesta.ObjetoRespuesta = oPatioAuto;
            return respuesta;
        }
        private async Task<Respuesta> ExistePatioAuto(string Strnombre)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.RegistroExistente = await _context.Patios.AnyAsync(x => x.PaNombre == Strnombre);
            return respuesta;
        }
    }
}

