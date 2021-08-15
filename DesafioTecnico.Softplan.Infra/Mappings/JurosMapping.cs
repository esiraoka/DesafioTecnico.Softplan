using DesafioTecnico.Softplan.Domain.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DesafioTecnico.Softplan.Infra.Mappings
{
    public class JurosMapping : IEntityTypeConfiguration<Juros>
    {
        public void Configure(EntityTypeBuilder<Juros> builder)
        {
            builder.HasKey(p => p.ID);

            builder.Property(c => c.Porcentagem)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.Property(c => c.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            builder.ToTable("Juros");
        }
    }
}
