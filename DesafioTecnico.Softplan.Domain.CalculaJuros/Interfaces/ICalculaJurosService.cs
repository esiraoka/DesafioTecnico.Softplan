using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.Domain.CalculaJuros.Interfaces
{
    public interface ICalculaJurosService
    {
        Task<decimal> CalcularJuros(decimal juros, decimal valor, int meses);
    }
}
