using DesafioTecnico.Softplan.Application.Classes;
using DesafioTecnico.Softplan.Application.Interfaces;
using DesafioTecnico.Softplan.Infra.Context;
using DesafioTecnico.Softplan.Infra.Interfaces;
using DesafioTecnico.Softplan.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioTecnico.Softplan.API.Juros.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigurarDependencias(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddScoped<DesafioTecnicoSoftPlanDbContext>();
            services.AddScoped<IJurosApplication, JurosApplication>();
            services.AddScoped<IJurosRepository, JurosRepository>();

            return services;
        }
    }
}
