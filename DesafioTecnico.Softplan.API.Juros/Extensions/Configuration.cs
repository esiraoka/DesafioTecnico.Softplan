using DesafioTecnico.Softplan.Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace DesafioTecnico.Softplan.API.Juros.Extensions
{
    public static class Configuration
    {
        public static IServiceCollection ConfigurarVersaoAPI(this IServiceCollection services, 
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
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddDbContext<DesafioTecnicoSoftPlanDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<RemoverApiVersionSwagger>();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Desafio Técnico - SoftPlan",
                    Description = "Essa API realiza o cadastro de juros",
                    Contact = new OpenApiContact() { Name = "Eliton" },
                    License = new OpenApiLicense() { Name = "Eliton" }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
