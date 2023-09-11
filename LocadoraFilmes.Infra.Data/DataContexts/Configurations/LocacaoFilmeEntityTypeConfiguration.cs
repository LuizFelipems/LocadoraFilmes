using LocadoraFilmes.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraFilmes.Infra.Data.DataContexts.Configurations
{
    public class LocacaoFilmeEntityTypeConfiguration : IEntityTypeConfiguration<LocacaoFilme>
    {
        public void Configure(EntityTypeBuilder<LocacaoFilme> builder)
        {
            builder.HasKey(x => new { x.LocacaoId, x.FilmeId });

            builder.HasOne(x => x.Locacao)
                   .WithMany(x => x.Filmes)
                   .HasForeignKey(x => x.LocacaoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Filme)
                   .WithMany(x => x.Locacoes)
                   .HasForeignKey(x => x.FilmeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
