using DesafioTecnico.Softplan.Application.CalculaJuros.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.API.CalculaJuros.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosApplication _CalcularJurosApplication;

        public CalculaJurosController(ICalculaJurosApplication calcularJurosApplication)
        {
            _CalcularJurosApplication = calcularJurosApplication;
        }

        /// <summary>
        /// Calcula os juros baseado no valor e meses informados.
        /// </summary>
        /// <param name="valor">Valor Inicial</param>
        /// <param name="meses">Meses para calcular os juros compostos</param>
        /// <returns>Valor calculado com os juros</returns>
        /// <response code="200">Valor calculado</response>
        [HttpGet("calcularJuros/{valor:decimal}/{meses:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CalcularJuros([Required(ErrorMessage="Valor Inicial é obrigatório")]decimal valor,
                                                       [Required(ErrorMessage="Meses é obrigatório")][Range(1, 12, ErrorMessage="Meses devem estar entre {0} e {1}")]
                                                       int meses)
        {
            return Ok(await _CalcularJurosApplication.CalcularJuros(valor, meses));
        }
    }
}
