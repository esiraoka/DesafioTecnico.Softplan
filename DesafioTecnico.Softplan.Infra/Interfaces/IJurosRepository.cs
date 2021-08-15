using DesafioTecnico.Softplan.Domain.Classes;
using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.Infra.Interfaces
{
    public interface IJurosRepository
    {
        Task Inserir(Juros juros);

        Task<Juros> BuscarUltimoJuros();
    }
}
