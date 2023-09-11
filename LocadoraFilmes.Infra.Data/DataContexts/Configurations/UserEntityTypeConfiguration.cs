using LocadoraFilmes.Domain.Models;
using LocadoraFilmes.Infra.CrossCutting.Data.DataContexts.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraFilmes.Infra.Data.DataContexts.Configurations
{
    public class UserEntityTypeConfiguration : EntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome)
                   .IsRequired();

            builder.Property(x => x.Login)
                   .IsRequired();

            builder.Property(x => x.Password)
                   .IsRequired();
            
            builder.Property(x => x.Role)
                   .IsRequired();
        }
    }
}
