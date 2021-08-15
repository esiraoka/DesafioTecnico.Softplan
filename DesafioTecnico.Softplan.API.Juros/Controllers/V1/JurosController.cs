using DesafioTecnico.Softplan.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.API.Juros.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        private readonly IJurosApplication _JurosApplication;

        public JurosController(IJurosApplication jurosApplication)
        {
            _JurosApplication = jurosApplication;
        }

        /// <summary>
        /// Exibe o valor do último juros cadastrado.
        /// </summary>
        /// <returns> Retorna o valor do último juros cadastrado. Ex: Se 1%, o retorno será: 0,01</returns>
        /// <response code="200">Valor calculado</response>
        /// <response code="500">Erro interno no servidor</response>
        /// <response code="400">Parâmetros incorretos</response>
        [HttpGet("taxajuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BuscarUltimoJurosCadastrado()
        {
            return Ok(await _JurosApplication.ListarValorUltimoJuros());
        }

        /// <summary>
        /// Cadastra a taxa de juros.
        /// </summary>
        /// <param name="taxaJuros">Taxa de juros em porcentagem que deseja cadastrar.</param>
        /// <response code="200">Valor calculado</response>
        /// <response code="500">Erro interno no servidor</response>
        /// <response code="400">Parâmetros incorretos</response>
        [HttpPost("taxajuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastrarTaxadeJuros([FromBody]
                                                              [Required(ErrorMessage ="Taxa de juros é obrigatório")]
                                                              [Range(1,100, ErrorMessage="Taxa de Juros deve estar entre {0} e {1}")]
                                                              decimal taxaJuros)
        {
            await _JurosApplication.Inserir(taxaJuros);
            return Ok();
        }
    }
}
