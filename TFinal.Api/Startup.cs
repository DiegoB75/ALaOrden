using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Repository;
using TFinal.Repository.Implementation;
using TFinal.Service;
using TFinal.Service.Implementation;

namespace TFinal.Api
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
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //
            services.AddTransient<ICarritoItemRepository, CarritoItemRepository>();
            services.AddTransient<ICarritoItemService, CarritoItemService>();

            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<ICategoriaService, CategoriaService>();

            services.AddTransient<ICuponRepository, CuponRepository>();
            services.AddTransient<ICuponService, CuponService>();

            services.AddTransient<IDetallePedidoRepository, DetallePedidoRepository>();
            services.AddTransient<IDetallePedidoService, DetallePedidoService>();

            services.AddTransient<IDireccionRepository, DireccionRepository>();
            services.AddTransient<IDireccionService, DireccionService>();

            services.AddTransient<IFranquiciaRepository, FranquiciaRepository>();
            services.AddTransient<IFranquiciaService, FranquiciaService>();

            services.AddTransient<IMarcaRepository, MarcaRepository>();
            services.AddTransient<IMarcaService, MarcaService>();

            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IPedidoService, PedidoService>();

            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IProductoService, ProductoService>();

            services.AddTransient<IProductoFranquiciaRepository, ProductoFranquiciaRepository>();
            services.AddTransient<IProductoFranquiciaService, ProductoFranquiciaService>();

            services.AddTransient<ISedeRepository, SedeRepository>();
            services.AddTransient<ISedeService, SedeService>();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
