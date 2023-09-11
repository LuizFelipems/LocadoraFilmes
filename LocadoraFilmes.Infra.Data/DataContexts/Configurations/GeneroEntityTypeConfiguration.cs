using LocadoraFilmes.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraFilmes.Infra.CrossCutting.Data.DataContexts.Configurations
{
    public class GeneroEntityTypeConfiguration : EntityTypeConfiguration<Genero>
    {
        public override void Configure(EntityTypeBuilder<Genero> builder)
        {
            base.Configure(builder);

            builder.HasQueryFilter(x => x.Ativo);

            builder.Property(x => x.Nome)
                   .IsRequired();

            builder.Property(x => x.Ativo)
                   .IsRequired();

            builder.Property(x => x.DataCriacao)
                   .IsRequired();
        }
    }
}
