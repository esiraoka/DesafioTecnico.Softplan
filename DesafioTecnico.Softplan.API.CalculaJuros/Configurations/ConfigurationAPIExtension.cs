using DesafioTecnico.Softplan.Infra.CalcularJuros.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace DesafioTecnico.Softplan.API.CalculaJuros.Configurations
{
    public static class ConfigurationAPIExtension
    {
        public static IServiceCollection Configurar(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            services.AddVersionedApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
            }); 
            services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ReportApiVersions = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<RemoverApiVersionSwagger>();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Desafio Técnico - SoftPlan",
                    Description = "Essa API realiza o cálculo dos juros",
                    Contact = new OpenApiContact() { Name = "Eliton" },
                    License = new OpenApiLicense() { Name = "Eliton" }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);
            });

            string baseAddress = configuration.GetValue<string>("BaseUrl");
            services.AddHttpClient<CalcularJurosInfra>("buscarJuros", opt =>
            {
                opt.BaseAddress = new Uri(baseAddress);
            });

            return services;
        }
    }
}
