using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductCatalog.Application.Context;
using ProductCatalog.Infra.Repositories;

namespace ProductCatalog
{
  public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // ConfigureServices -> Pipline -> adicionar middlewares
            // services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddResponseCompression();

            // resolvendo dependências:
            services.AddScoped<StoreDataContext, StoreDataContext>(); // cria apenas um item por requisição
             // AddScoped -> nesse caso, verifica se já existe um StoreDataContext na memória e, caso não exista, cria um novo.
            services.AddTransient<ProductRepository, ProductRepository>();

            services.AddTransient<CategoryRepository, CategoryRepository>();
            // AddTransient -> cria várias instâncias de conexões com o banco, sempre que solicitado.


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
            app.UseResponseCompression();
        }
    }
}
