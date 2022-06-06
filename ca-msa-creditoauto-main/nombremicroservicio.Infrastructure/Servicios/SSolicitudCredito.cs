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
    public class SSolicitudCredito : ISolicitudCredito
    {
        private readonly DemoPichinchaContext _context;
        public SSolicitudCredito(DemoPichinchaContext context)
        {
            _context = context;
        }
        public async Task<Respuesta> ConsultarSolicitudCreditos()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.SolicitudCreditos.ToListAsync();
            return respuesta;
        }
        public async Task<Respuesta> ConsultarSolicitudCredito(int id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.ObjetoRespuesta = await _context.SolicitudCreditos.FirstOrDefaultAsync(x => x.ScId == id);
            return respuesta;
        }
        public async Task<Respuesta> CrearSolicitudCredito(SolicitudCredito oSolicitudCredito)
        {
            Respuesta respuesta = new Respuesta();
            int intestado = await ValidarSolicituEstado(oSolicitudCredito);
            respuesta = await ValidarSolicitudPorDia(oSolicitudCredito, intestado);
            if (respuesta.EjecucionRespuesta)
            {
                respuesta = await ValidarVehiculoReservado(oSolicitudCredito, intestado);
                if (respuesta.EjecucionRespuesta)
                {
                    _context.SolicitudCreditos.Add(oSolicitudCredito);
                    await AsignacionClientePatio(oSolicitudCredito);
                }
            }
            return respuesta;

        }
        public async Task<Respuesta> ValidarSolicitudPorDia(SolicitudCredito oSolicitudCredito, int Intestado)
        {
            Respuesta respuesta = new Respuesta();
            Asignacioncliente asignacioncliente = await _context.Asignacionclientes.Where(x => x.AcIdentificacionCliente == oSolicitudCredito.ScIdentificacionCliente
                && x.AcIdPatio == oSolicitudCredito.ScPatio).OrderByDescending(x => x.AcFechaCreacion).FirstOrDefaultAsync();
            if (asignacioncliente == null)
            {
                respuesta.EjecucionRespuesta = true;
                return respuesta;
            }
            if (DateTime.Compare(asignacioncliente.AcFechaCreacion.Date, DateTime.Now.Date) == 0 && Intestado > 0)
            {
                string strdatos = Intestado == 1 ? "Registrada" : Intestado == 2 ? "Despachada" : "Cancelada";
                respuesta.MensajeRespuesta = $"El cliente ya posee una solicitud de crédito del  día {asignacioncliente.AcFechaCreacion}  con Estado: " +
                    $"{strdatos}";
                return respuesta;
            }
            else
                Intestado = 0;
            if (Intestado == oSolicitudCredito.ScEstado)
            {
                string strdatos = Intestado == 1 ? "Registrada" : Intestado == 2 ? "Despachada" : "Cancelada";
                respuesta.MensajeRespuesta = $"El cliente ya posee una solicitud de crédito del  día {asignacioncliente.AcFechaCreacion}  con Estado: " +
                    $"{strdatos}";
                return respuesta;
            }
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
        public async Task<int> ValidarSolicituEstado(SolicitudCredito oSolicitudCredito)
        {
            SolicitudCredito solicitudCredito = await _context.SolicitudCreditos.FirstOrDefaultAsync(x => x.ScIdentificacionCliente == oSolicitudCredito.ScIdentificacionCliente
                && x.ScPatio == oSolicitudCredito.ScPatio && x.ScEstado == oSolicitudCredito.ScEstado);
            if (solicitudCredito == null) return 0;
            return solicitudCredito.ScEstado;
        }
        public async Task<Respuesta> ValidarVehiculoReservado(SolicitudCredito oSolicitudCredito, int Intestado)
        {
            Respuesta respuesta = new Respuesta();
            SolicitudCredito solicitudCredito = await _context.SolicitudCreditos.FirstOrDefaultAsync(x => x.ScIdentificacionCliente == oSolicitudCredito.ScIdentificacionCliente
                && x.ScPatio == oSolicitudCredito.ScPatio && x.ScEstado == oSolicitudCredito.ScEstado && x.ScVehiculo == oSolicitudCredito.ScVehiculo);
            if (solicitudCredito == null)
            {
                respuesta.EjecucionRespuesta = true;
                return respuesta;
            }
            if (Intestado == 1)
            {
                respuesta.EjecucionRespuesta = false;
                respuesta.MensajeRespuesta = $"El vehiculo esta en proceso de reserva por otro cliente con Estado: Registrada";
                return respuesta;
            }
            respuesta.EjecucionRespuesta = true;
            return respuesta;

        }
        public async Task<Respuesta> AsignacionClientePatio(SolicitudCredito oSolicitudCredito)
        {
            Respuesta respuesta = new Respuesta();            
            Asignacioncliente oasignacioncliente = new Asignacioncliente
            {
                AcIdentificacionCliente = oSolicitudCredito.ScIdentificacionCliente,
                AcIdPatio = oSolicitudCredito.ScPatio,
                AcFechaCreacion = DateTime.Now

            };
            _context.Asignacionclientes.Add(oasignacioncliente);
            await _context.SaveChangesAsync();
            respuesta.MensajeRespuesta = $"{Mensajes.MensajeClienteEliminar} {oSolicitudCredito}";
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }


    }
}
