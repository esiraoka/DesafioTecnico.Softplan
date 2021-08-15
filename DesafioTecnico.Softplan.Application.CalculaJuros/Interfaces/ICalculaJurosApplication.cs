using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.Application.CalculaJuros.Interfaces
{
    public interface ICalculaJurosApplication
    {
        Task<decimal> CalcularJuros(decimal valor, int meses);
    }
}
