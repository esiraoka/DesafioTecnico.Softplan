using DesafioTecnico.Softplan.Domain.Classes;
using DesafioTecnico.Softplan.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnico.Softplan.Infra.Context
{
    public class DesafioTecnicoSoftPlanDbContext : DbContext
    {
        public DesafioTecnicoSoftPlanDbContext(DbContextOptions<DesafioTecnicoSoftPlanDbContext> options)
                : base(options)
        {

        }

        public DbSet<Juros> Juros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JurosMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
