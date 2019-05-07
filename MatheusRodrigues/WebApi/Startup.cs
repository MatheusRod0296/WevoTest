using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //separa as injeções de depencia  para manter a organização
            services.UseInjectionDependency();

            // busca a connection string  e insere seu valor no classe 'ConnectionString' , assim fica disponivel para o Contexto
            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionStrings"));

            //configuração do swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Wevo", Version = "v1" });
            });
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wevo");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();

            

        }
    }
}
