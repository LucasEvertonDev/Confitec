using Confitec.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Infra.Data.EntityConfigurations
{
    public class EscolaridadeConfiguration : IEntityTypeConfiguration<Escolaridade>
    {
        public void Configure(EntityTypeBuilder<Escolaridade> builder)
        {
            builder.ToTable("Escolaridades");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Descricao).IsRequired().HasMaxLength(50);
        }
    }
}
