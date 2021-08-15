using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.API.Juros.Middlewares
{
    public class JurosMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _Logger;

        public JurosMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _Logger = loggerFactory.CreateLogger<JurosMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex?.Message,
                                 context.Request?.Method,
                                 context.Request?.Path.Value,
                                 context.Response?.StatusCode);
            }
        }
    }
}
