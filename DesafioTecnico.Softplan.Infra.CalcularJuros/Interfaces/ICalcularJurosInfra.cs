using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.Infra.CalcularJuros.Interfaces
{
    public interface ICalcularJurosInfra
    {
        Task<decimal> BuscarJuros();
    }
}
