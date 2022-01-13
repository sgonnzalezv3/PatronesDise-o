using Herramientas.Earn;
using Herramientas.Generator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatronesDiseno.Modelos.Data;
using PatronesDiseno.Repository;
using PatronesDiseñoASP.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronesDiseñoASP
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
            services.AddControllersWithViews();
            /* Inyectando la configuracion realizada en el appsettings.json */
            services.Configure<MyConfig>(Configuration.GetSection("MyConfig"));

            /* creando el objeto para la fabrica local */
            services.AddTransient((factory) =>
            {
                return new LocalEarnFactory(0.20m);
            });           
            
            /* creando el objeto para la fabrica foreign */
            services.AddScoped((factory) =>
            {
                return new ForeignEarnFactory(0.20m, Configuration.GetSection("MyConfig").GetValue<decimal>("ExtraValue"));
            });

            /* Inyectar la conexion en appsettings */
            services.AddDbContext<PatronesDisenoContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Connection"));
            });

            /* Inyectar el repository */

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            /* Inyectar unitOfWork */

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            /* inyectando builder */
            /* Se pone la clase directamente, porque el patron builder permite que el objeto concreto
             * tenga la generacion de un objeto que no esté ligado a la interfaz(IBuilderGenerator)
             * porque en la classe GeneratorConcreteBuilder se necesita el objeto de tipo Generator(_generator)
             */
            services.AddScoped<GeneratorConcreteBuilder>();
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
