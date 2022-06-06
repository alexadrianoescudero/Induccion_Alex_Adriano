using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Infrastructure.Servicios;
using nombremicroservicio.Repository.Context;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using System;
using System.IO;
using System.Reflection;

namespace nombremicroservicio.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            #region ConexionDB

            var datos = services.AddDbContext<DemoPichinchaContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("Conexion")));

            #endregion

            #region OPENTELEMETRY
            string otelServer = Environment.GetEnvironmentVariable("OTEL_SERVER");
            var serviceName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;

            services.AddHttpContextAccessor();
            if (!String.IsNullOrEmpty(otelServer))
            {
            }

            services.AddLogging(logging =>
            {
                logging.AddOpenTelemetry(options =>
                {
                    options.AddConsoleExporter();
                });
            });

            #endregion OPENTELEMETRY

            #region INFRASTRUCTURE
            services.AddScoped<IAsignacionClientePatio, SAsignacionClientePatio>();
            services.AddScoped<ICliente, SCliente>();
            services.AddScoped<IEjecutivo, SEjecutivo>();
            services.AddScoped<IHome, SHome>();
            services.AddScoped<IMarca, SMarca>();
            services.AddScoped<IPatioAuto, SPatioAuto>();
            services.AddScoped<IVehiculo, SVehiculo>();
            services.AddScoped<ISolicitudCredito, SSolicitudCredito>();

            #endregion INFRASTRUCTURE            

            #region HANDLING API VERSIONS
            services.AddApiVersioning(options => options.UseApiBehavior = true);
            services.AddApiVersioning(options => options.AssumeDefaultVersionWhenUnspecified = true);
            #endregion HANDLING API VERSIONS

            #region POLICY FOR CROSS DOMAIN
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                   .AllowAnyMethod()
                                                                   .AllowAnyHeader()));
            #endregion POLICY FOR CROSS DOMAIN

            services.AddControllers();
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "nombremicroservicio",
                    Description = "Una descripcion del microservicio",
                    Contact = new OpenApiContact
                    {
                        Name = "Banco Pichincha",
                        Email = "devops@pichincha.com",
                        Url = new Uri("https://www.pichincha.com"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            #endregion Swagger
            #region
            //var context = new  DbContextOptionsBuilder(services.AddDbContext<DemoPichinchaContext>);
            //SHome datos = new SHome(context, Configuration);
            //datos.CargarDatosIniciales(1);
            #endregion
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region SwaggerUI
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "nombremicroservicio API");
                c.RoutePrefix = "swagger";
                c.InjectStylesheet("/swagger/custom.css");
            });
            #endregion Swagger

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=CargarDatosIniciales}/{id=1}");
            });
        }
    }
}
