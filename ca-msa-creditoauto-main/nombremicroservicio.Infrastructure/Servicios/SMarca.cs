using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using nombremicroservicio.Repository.Context;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure.Servicios
{
    public class SMarca : IMarca
    {
        private readonly DemoPichinchaContext _context;
        public SMarca(DemoPichinchaContext context)
        {
            _context = context;
        }
        public async Task<Respuesta> ConsultarMarcas()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Marcas.ToListAsync();
            return respuesta;
        }
        public async Task<Respuesta> ConsultarMarca(int id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Marcas.FirstOrDefaultAsync(x => x.MaId == id);
            return respuesta;
        }
        public async Task<Respuesta> CrearMarca(Marca oMarca)
        {
            Respuesta respuesta = new Respuesta();
            respuesta = await ConsultarMarca(oMarca.MaId);
            if (respuesta.ObjetoRespuesta != null)
            {
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteExiste}";
                respuesta.ObjetoRespuesta = oMarca;
            }
            else
            {
                _context.Marcas.Add(oMarca);
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteCorrecto}";
                respuesta.ObjetoRespuesta = oMarca;
                await _context.SaveChangesAsync();

            }
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

        public async Task<Respuesta> EditarMarca(Marca oMarca)
        {
            Respuesta respuesta = new Respuesta();
            _context.Entry(oMarca).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEditar}";
            respuesta.ObjetoRespuesta = oMarca;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

        public async Task<Respuesta> EliminarMarca(int id)
        {
            Respuesta respuesta = new Respuesta();
            var oMarca = await _context.Marcas.FindAsync(id);
            if (oMarca == null)
            {
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEliminarError}";
                respuesta.ObjetoRespuesta = oMarca;
                return respuesta;
            }
            _context.Marcas.Remove(oMarca);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEliminar}";
            respuesta.ObjetoRespuesta = oMarca;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

    }
}
