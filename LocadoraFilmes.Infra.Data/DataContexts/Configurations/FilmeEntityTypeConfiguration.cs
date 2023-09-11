using LocadoraFilmes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraFilmes.Infra.CrossCutting.Data.DataContexts.Configurations
{
    public class FilmeEntityTypeConfiguration : EntityTypeConfiguration<Filme>
    {
        public override void Configure(EntityTypeBuilder<Filme> builder)
        {
            base.Configure(builder);

            builder.HasQueryFilter(x => x.Ativo);

            builder.Property(x => x.Nome)
                   .IsRequired();

            builder.HasOne(x => x.Genero)
                   .WithMany(x => x.Filmes)
                   .HasForeignKey(x => x.GeneroId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Ativo)
                   .IsRequired();
            
            builder.Property(x => x.DataCriacao)
                   .IsRequired();
        }
    }
}
