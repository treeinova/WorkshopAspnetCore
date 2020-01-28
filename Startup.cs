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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using ExercicioLinqAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using ExercicioLinqAPI.Services;

namespace ExercicioLinqAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ConfigureDependencies(services);
            ConfigureConnection(services);
            ConfigureSwagger(services);
        }

        public void ConfigureDependencies(IServiceCollection services)
        {
            services.AddScoped<IVendaService, VendaService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vendas API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vendas API", Version = "v1.0.0" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


        }

        public void ConfigureConnection(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<EfDbContext>(
                    options =>
                        options
                            .UseSqlServer(Configuration.GetConnectionString("venda")));
            //             .UseLoggerFactory(new LoggerFactory().AddConsole((category, level) =>
            //  level == LogLevel.Information &&
            //     category == DbLoggerCategory.Database.Command.Name, true))
            //     );
        }
    }
}
