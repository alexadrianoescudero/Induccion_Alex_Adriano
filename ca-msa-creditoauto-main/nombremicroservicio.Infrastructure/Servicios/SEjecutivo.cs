using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using nombremicroservicio.Repository.Context;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure.Servicios
{
    public class SEjecutivo : IEjecutivo
    {
        private readonly DemoPichinchaContext _context;
        public SEjecutivo(DemoPichinchaContext context)
        {
            _context = context;
        }
        public async Task<Respuesta> ConsultarEjecutivos()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Ejecutivos.ToListAsync();
            return respuesta;
        }
        public async Task<Respuesta> ConsultarEjecutivo(string id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Ejecutivos.FirstOrDefaultAsync(x => x.EjIdentificacion == id);
            return respuesta;
        }
        public async Task<Respuesta> CrearEjecutivo(Ejecutivo oEjecutivo)
        {
            Respuesta respuesta = new Respuesta();
            respuesta = await ConsultarEjecutivo(oEjecutivo.EjIdentificacion);
            if (respuesta.ObjetoRespuesta != null)
            {
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteExiste}";
                respuesta.ObjetoRespuesta = oEjecutivo;
            }
            else
            {
                _context.Ejecutivos.Add(oEjecutivo);
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteCorrecto}";
                respuesta.ObjetoRespuesta = oEjecutivo;
                await _context.SaveChangesAsync();

            }
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

        public async Task<Respuesta> EditarEjecutivo(Ejecutivo oEjecutivo)
        {
            Respuesta respuesta = new Respuesta();
            _context.Entry(oEjecutivo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEditar}";
            respuesta.ObjetoRespuesta = oEjecutivo;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

        public async Task<Respuesta> EliminarEjecutivo(string id)
        {
            Respuesta respuesta = new Respuesta();
            var oEjecutivo = await _context.Ejecutivos.FindAsync(id);
            if (oEjecutivo == null)
            {
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEliminarError}";
                respuesta.ObjetoRespuesta = oEjecutivo;
                return respuesta;
            }
            _context.Ejecutivos.Remove(oEjecutivo);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEliminar}";
            respuesta.ObjetoRespuesta = oEjecutivo;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

    }
}
