using LocadoraFilmes.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraFilmes.Infra.CrossCutting.Data.DataContexts.Configurations
{
    public class LocacaoEntityTypeConfiguration : EntityTypeConfiguration<Locacao>
    {
        public override void Configure(EntityTypeBuilder<Locacao> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CpfCliente)
                   .IsRequired();

            builder.Property(x => x.DataLocacao)
                   .IsRequired();
        }
    }
}
