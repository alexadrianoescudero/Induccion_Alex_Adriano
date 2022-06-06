using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using nombremicroservicio.Repository.Context;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure.Servicios
{
    public class SAsignacionClientePatio : IAsignacionClientePatio
    {
        private readonly DemoPichinchaContext _context;
        public SAsignacionClientePatio(DemoPichinchaContext context)
        {
            _context = context;
        }
        public async Task<Respuesta> ConsultarAsignacionClientePatios()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Asignacionclientes.ToListAsync();
            return respuesta;
        }
        public async Task<Respuesta> ConsultarAsignacionClientePatio(int id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Asignacionclientes.FirstOrDefaultAsync(x => x.AcId == id);
            return respuesta;
        }
        public async Task<Respuesta> CrearAsignacionClientePatio(Asignacioncliente oAsignacioncliente)
        {
            Respuesta respuesta = new Respuesta();
            respuesta = await ConsultarAsignacionClientePatio(oAsignacioncliente.AcId);
            if (respuesta.ObjetoRespuesta != null)
            {
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteExiste}";
                respuesta.ObjetoRespuesta = oAsignacioncliente;
            }
            else
            {
                _context.Asignacionclientes.Add(oAsignacioncliente);
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteCorrecto}";
                respuesta.ObjetoRespuesta = oAsignacioncliente;
                await _context.SaveChangesAsync();

            }
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

        public async Task<Respuesta> EditarAsignacionClientePatio(Asignacioncliente oAsignacioncliente)
        {
            Respuesta respuesta = new Respuesta();
            _context.Entry(oAsignacioncliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEditar}";
            respuesta.ObjetoRespuesta = oAsignacioncliente;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

        public async Task<Respuesta> EliminarAsignacionClientePatio(int id)
        {
            Respuesta respuesta = new Respuesta();
            var oAsignacioncliente = await _context.Asignacionclientes.FindAsync(id);
            if (oAsignacioncliente == null)
            {
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEliminarError}";
                respuesta.ObjetoRespuesta = oAsignacioncliente;
                return respuesta;
            }
            _context.Asignacionclientes.Remove(oAsignacioncliente);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEliminar}";
            respuesta.ObjetoRespuesta = oAsignacioncliente;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

    }
}
