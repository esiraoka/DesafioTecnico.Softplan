using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.Application.Interfaces
{
    public interface IJurosApplication
    {
        Task Inserir(decimal juros);
        Task<decimal> ListarValorUltimoJuros();
    }
}
