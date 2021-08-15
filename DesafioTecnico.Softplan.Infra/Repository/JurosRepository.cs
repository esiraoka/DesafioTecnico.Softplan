using DesafioTecnico.Softplan.Domain.Classes;
using DesafioTecnico.Softplan.Infra.Context;
using DesafioTecnico.Softplan.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico.Softplan.Infra.Repository
{
    public class JurosRepository : IJurosRepository
    {
        public readonly DesafioTecnicoSoftPlanDbContext _SoftPlanDbContext;
        public JurosRepository(DesafioTecnicoSoftPlanDbContext context)
        {
            _SoftPlanDbContext = context;
        }

        public async Task Inserir(Juros juros)
        {
            _SoftPlanDbContext.Juros.Add(juros);
            await _SoftPlanDbContext.SaveChangesAsync();
        }

        public async Task<Juros> BuscarUltimoJuros()
        {
            return await _SoftPlanDbContext.Juros
                                     .OrderByDescending(juros => juros.DataCadastro)
                                     .FirstOrDefaultAsync();
        }
    }
}
