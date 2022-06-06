using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities.Model;
using nombremicroservicio.Entities.Utlitarios;
using nombremicroservicio.Repository.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure.Servicios
{
    public class SHome : IHome
    {
        private readonly IConfiguration _configuration;
        private readonly DemoPichinchaContext _context;
        public SHome(DemoPichinchaContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Respuesta> CargarDatosIniciales(int intTipo)
        {
            Respuesta respuesta = new Respuesta();
            List<Cliente> ltsCliente = new List<Cliente>();
            List<Ejecutivo> ltsEjecutivo = new List<Ejecutivo>();
            List<Marca> ltsMarca = new List<Marca>();
            string strarchivo = string.Empty;
            switch (intTipo)
            {

                case 1:
                    
                    strarchivo = _configuration["RutasArchivo:Clientes"];
                   
                    break;
                case 2:
                    strarchivo = _configuration["RutasArchivo:Ejecutivo"];
                    break;
                case 3:
                    strarchivo = _configuration["RutasArchivo:Marcas"];
                    break;
                default:
                    break;
            }
            StreamReader archivo = new StreamReader(strarchivo);
            string separador = _configuration["RutasArchivo:Separador"];
            string linea;
            int i = 0;
            while ((linea = archivo.ReadLine()) != null)
            {
                i++;
                string[] fila = linea.Split(separador);
                switch (intTipo)
                {
                    case 1:
                        Cliente ocliente = new Cliente()
                        {
                            ClIdentificacion = fila[0],
                            ClNombres = fila[1],
                            ClEdad = Convert.ToInt32(fila[2]),
                            ClFechaNacimiento = Convert.ToDateTime(fila[3]),
                            ClApellidos = fila[4],
                            ClDireccion = fila[5],
                            ClTelefono = fila[6],
                            ClEstadoCivil = Convert.ToInt32(fila[7]),
                            ClIdentificacionConyugue = fila[8],
                            ClNombreConyugue = fila[9],
                            ClSujetoCredito = Convert.ToInt32(fila[10])
                        };
                        //_context.BulkInsert(ltsCliente, options => {
                        //    options.InsertIfNotExists = true;
                        //});
                        ltsCliente.Add(ocliente);
                        break;
                    case 2:
                        Ejecutivo oejecutivo = new Ejecutivo()
                        {
                            EjIdentificacion = fila[0],
                            EjNombre = fila[1],
                            EjApellido = fila[2],
                            EjDireccion = fila[3],
                            EjTelefono = fila[4],
                            EjCelular = fila[5],
                            EjPatio = Convert.ToInt32(fila[6]),
                            EjEdad = Convert.ToInt32(fila[7]),
                        };
                        ltsEjecutivo.Add(oejecutivo);
                        break;
                    case 3:
                        Marca omarca = new Marca()
                        {
                            MaNombre = fila[0]
                        };
                        ltsMarca.Add(omarca);
                        break;
                }

            }
            switch (intTipo)
            {

                case 1:
                    respuesta = await CrearClientes(ltsCliente);
                    break;
                case 2:
                    respuesta = await CrearEjecutivo(ltsEjecutivo);
                    break;
                case 3:
                    respuesta = await CrearMarca(ltsMarca);
                    break;
                default:
                    break;
            }
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
        public async Task<Respuesta> ConsultarCliente(string id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.RegistroExistente = await _context.Clientes.AnyAsync(x => x.ClIdentificacion == id);
            return respuesta;
        }
        public async Task<Respuesta> ConsultarEjecutivos(string id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.RegistroExistente = await _context.Ejecutivos.AnyAsync(x => x.EjIdentificacion == id);
            return respuesta;
        }
        public async Task<Respuesta> ConsultarMarca(string id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.RegistroExistente = await _context.Marcas.AnyAsync(x => x.MaNombre == id);
            return respuesta;
        }
        public async Task<Respuesta> CrearClientes(List<Cliente> oCliente)
        {
            Respuesta respuesta = new Respuesta();
            List<Cliente> oClientetem = new List<Cliente>(oCliente);
            foreach (Cliente item in oCliente)
            {
                respuesta = await ConsultarCliente(item.ClIdentificacion);
                if (respuesta.RegistroExistente)
                    oClientetem.Remove(item);
            }
            if (oClientetem.Count > 0)
            {
                _context.Clientes.AddRange(oClientetem);
                await _context.SaveChangesAsync();
            }
            respuesta.MensajeRespuesta = $"Registrado correctamente Cliente: {oClientetem.Count} ";
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
        public async Task<Respuesta> CrearEjecutivo(List<Ejecutivo> oEjecutivo)
        {
            Respuesta respuesta = new Respuesta();
            List<Ejecutivo> oEjecutivotem = new List<Ejecutivo>(oEjecutivo);
            foreach (Ejecutivo item in oEjecutivo)
            {
                respuesta = await ConsultarEjecutivos(item.EjIdentificacion);
                if (respuesta.RegistroExistente)
                    oEjecutivotem.Remove(item);
            }
            if (oEjecutivotem.Count > 0)
            {
                _context.Ejecutivos.AddRange(oEjecutivotem);
                await _context.SaveChangesAsync();
            }
            respuesta.MensajeRespuesta = $"Registrado correctamente Ejecutivo: {oEjecutivotem.Count} ";
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
        public async Task<Respuesta> CrearMarca(List<Marca> oMarca)
        {
            Respuesta respuesta = new Respuesta();
            List<Marca> oMarcatem = new List<Marca>(oMarca);
            foreach (Marca item in oMarca)
            {
                respuesta = await ConsultarMarca(item.MaNombre);
                if (respuesta.RegistroExistente)
                    oMarcatem.Remove(item);
            }
            if (oMarcatem.Count > 0)
            {
                _context.Marcas.AddRange(oMarcatem);
                await _context.SaveChangesAsync();
            }
            respuesta.MensajeRespuesta = $"Registrado correctamente Marca: {oMarcatem.Count} ";
            respuesta.EjecucionRespuesta = true;
            return respuesta;
        }
    }
}
