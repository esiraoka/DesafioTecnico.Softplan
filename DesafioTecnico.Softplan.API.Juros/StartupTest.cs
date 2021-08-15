using DesafioTecnico.Softplan.API.Juros.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DesafioTecnico.Softplan.API.Juros
{
    public class StartupTest
    {
        public IConfiguration Configuration { get; }

        public StartupTest(IWebHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(hostEnvironment.ContentRootPath)
                           .AddJsonFile("appsettings.json", true, true)
                           .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                           .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigurarVersaoAPI(Configuration);
            services.ConfigurarDependencias();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
