using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Desafio_EF.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Desafio_EF
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
            // Adicionar a a conexão com o banco aos serviços de configuração
            // Recebe a string de conexão do arquivo appsettings.json
            services.AddDbContext<DesafioContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DesafioEntityFramework")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            // Evita o erro de loop infinito em objetos relacionados
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Desafio_EF", 
                    Version = "v1",
                    Description = "Desafio do módulo de Entity Framework",
                    Contact = new OpenApiContact
                    {
                        Name = "Repositório do desafio de Entity Framework",
                        Url = new Uri("https://github.com/sthevanbello/Desafio_EF"),
                    }
                });

                // Adiciona os comentários na documentação do Swagger
                var xmlArquivo = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlArquivo));
            });

            // Injeção de dependência do DesafioContext
            services.AddTransient<DesafioContext, DesafioContext>();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IEspecialidadeRepository, EspecialidadeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio_EF v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
