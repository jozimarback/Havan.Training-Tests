using Havan.CaixaEletronico.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace Havan.CaixaEletronico.Api
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
            services.AddTransient<ICaixa, Caixa>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API REST de Caixa Eletrônico",
                    Description = "Métodos do projeto Caixa Eletrôico",
                    Version = "v1.1"
                });
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                  $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);

            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1.1/swagger.json", "API REST de Caixa Eletrônico v1.1"); });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
