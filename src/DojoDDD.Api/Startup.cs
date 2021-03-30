using DojoDDD.Application.Servico;
using DojoDDD.Domain.Repositorio;
using DojoDDD.Domain.Servico;
using DojoDDD.Infrastructure.Data;
using DojoDDD.Infrastructure.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DojoDDD.Api
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
            services.AddSwaggerGen();

            services.AddLogging();

            services.AddSingleton<DataStore>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IOrdemCompraServico, OrdemCompraServico>();
            services.AddScoped<IOrdemCompraRepositorio,OrdemCompraRepositorio>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c=> c.SwaggerEndpoint("/swagger/v1/swagger.json", "Compra"));

            
            app.UseMvc();
        }
    }
}
