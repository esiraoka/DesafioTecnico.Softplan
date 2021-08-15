using DesafioTecnico.Softplan.Domain.CalculaJuros.Interfaces;
using System;
using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.Domain.CalculaJuros.Classes
{
    public class CalculaJurosService : ICalculaJurosService
    {
        public async Task<decimal> CalcularJuros(decimal juros, decimal valor, int meses)
        {
            var valorFinal = (double)valor * Math.Pow(Convert.ToDouble(1 + juros), meses);
            return await Task.FromResult(Convert.ToDecimal(Math.Truncate(100 * valorFinal) / 100));
        }
    }
}
