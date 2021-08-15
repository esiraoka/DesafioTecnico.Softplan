using DesafioTecnico.Softplan.Application.CalculaJuros.Interfaces;
using DesafioTecnico.Softplan.Domain.CalculaJuros.Interfaces;
using DesafioTecnico.Softplan.Infra.CalcularJuros.Interfaces;
using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.Application.CalculaJuros.Classes
{
    public class CalculaJurosApplication : ICalculaJurosApplication
    {
        private readonly ICalcularJurosInfra _CalculaJurosInfra;
        private readonly ICalculaJurosService _CalculaJurosService;

        public CalculaJurosApplication(ICalcularJurosInfra calculaJurosInfra, 
                                       ICalculaJurosService calculaJurosService)
        {
            _CalculaJurosInfra = calculaJurosInfra;
            _CalculaJurosService = calculaJurosService;
        }

        public async Task<decimal> CalcularJuros(decimal valor, int meses)
        {
           var juros = await _CalculaJurosInfra.BuscarJuros();
           return await _CalculaJurosService.CalcularJuros(juros, valor, meses);
        }
    }
}
