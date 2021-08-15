using DesafioTecnico.Softplan.Application.CalculaJuros.Classes;
using DesafioTecnico.Softplan.Application.CalculaJuros.Interfaces;
using DesafioTecnico.Softplan.Domain.CalculaJuros.Classes;
using DesafioTecnico.Softplan.Domain.CalculaJuros.Interfaces;
using DesafioTecnico.Softplan.Infra.CalcularJuros.Classes;
using DesafioTecnico.Softplan.Infra.CalcularJuros.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioTecnico.Softplan.API.CalculaJuros.Configurations
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection InserirDependencias(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddLogging();
            services.AddScoped<ICalcularJurosInfra, CalcularJurosInfra>();
            services.AddScoped<ICalculaJurosApplication, CalculaJurosApplication>();
            services.AddScoped<ICalculaJurosService, CalculaJurosService>();
            
            return services;
        }
    }
}
