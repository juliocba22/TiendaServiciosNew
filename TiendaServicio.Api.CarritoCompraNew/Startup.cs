using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.Api.CarritoCompraNew.Aplicacion;
using TiendaServicio.Api.CarritoCompraNew.Persistencia;
using TiendaServicio.Api.CarritoCompraNew.RemoteInterface;
using TiendaServicio.Api.CarritoCompraNew.RemoteService;

namespace TiendaServicio.Api.CarritoCompraNew
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ILibrosService, LibrosService>();
            services.AddControllers();
            services.AddDbContext<CarritoContexto>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("ConexionDataBase"));
            });
            services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
            services.AddHttpClient("Libros", config =>
             {
                 config.BaseAddress = new Uri(Configuration["Services:Libros"]);
             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
