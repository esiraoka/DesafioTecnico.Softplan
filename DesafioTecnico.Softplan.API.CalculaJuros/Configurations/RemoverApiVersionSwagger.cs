using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace DesafioTecnico.Softplan.API.CalculaJuros.Configurations
{
    //public class RemoverApiVersionSwagger : IDocumentFilter
    public class RemoverApiVersionSwagger : IOperationFilter
    {
        //public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //foreach (var apiDescription in context.ApiDescriptions)
            //{
            //    var versionParam = apiDescription.ParameterDescriptions
            //         .FirstOrDefault(p => p.Name == "api-version" &&
            //         p.Source.Id.Equals("Query", StringComparison.InvariantCultureIgnoreCase));

            //    if (versionParam == null)
            //        continue;

            //    var route = "/" + apiDescription.RelativePath.TrimEnd('/');
            //    swaggerDoc.Paths.Remove(route);
            //}

            var versionParameter = operation.Parameters
                .FirstOrDefault(p => p.Name == "api-version" && p.In == ParameterLocation.Query);

            if (versionParameter != null)
                operation.Parameters.Remove(versionParameter);
        }
    }
}
