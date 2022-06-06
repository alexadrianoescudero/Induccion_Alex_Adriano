using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using nombremicroservicio.Repository.Context;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure.Servicios
{
    public class SCliente : ICliente
    {
        private readonly DemoPichinchaContext _context;
        public SCliente(DemoPichinchaContext context)
        {
            _context = context;
        }
        public async Task<Respuesta> ConsultarClientes()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Clientes.ToListAsync();
            return respuesta;
        }
        public async Task<Respuesta> ConsultarCliente(string id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.Clientes.FirstOrDefaultAsync(x => x.ClIdentificacion == id);
           return respuesta;
        }
        public async Task<Respuesta> CrearCliente(Cliente oCliente)
        {
            Respuesta respuesta = new Respuesta();
            respuesta = await ConsultarCliente(oCliente.ClIdentificacion);
            if (respuesta.ObjetoRespuesta != null)
            {
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteExiste}";
                respuesta.ObjetoRespuesta = oCliente;
            }
            else
            {
                _context.Clientes.Add(oCliente);
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteCorrecto}";
                respuesta.ObjetoRespuesta = oCliente;
                await _context.SaveChangesAsync();

            }
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

        public async Task<Respuesta> EditarCliente(Cliente oCliente)
        {
            Respuesta respuesta = new Respuesta();
            _context.Update(oCliente);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEditar}";
            respuesta.ObjetoRespuesta = oCliente;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

        public async Task<Respuesta> EliminarCliente(string id)
        {
            Respuesta respuesta = new Respuesta();
            var oCliente = await _context.Clientes.FindAsync(id);
            if (oCliente == null)
            {
                respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEliminarError}";
                respuesta.ObjetoRespuesta = oCliente;
                return respuesta;
            }
            _context.Clientes.Remove(oCliente);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEliminar}";
            respuesta.ObjetoRespuesta = oCliente;
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }

    }
}
