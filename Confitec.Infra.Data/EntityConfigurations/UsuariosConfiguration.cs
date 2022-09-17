using Confitec.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Infra.Data.EntityConfigurations
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome).IsRequired().HasMaxLength(30);

            builder.Property(u => u.Sobrenome).IsRequired().HasMaxLength(30);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);

            builder.Property(u => u.DataNascimento).IsRequired();

            builder.Property(u => u.EscolaridadeId).IsRequired();

            builder.HasOne(m => m.Escolaridade)
               .WithMany(Escolaridade => Escolaridade.Usuarios)
               .HasForeignKey(m => m.EscolaridadeId);
        }
    }
}
