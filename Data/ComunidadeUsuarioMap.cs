using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ComunidadeUsuarioMap : IEntityTypeConfiguration<ComunidadeUsuarioModel>
    {
        public void Configure(EntityTypeBuilder<ComunidadeUsuarioModel> builder)
        {
            builder.HasKey(x => x.ComunidadeUsuarioId);
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ComunidadesId).IsRequired().HasMaxLength(255);

        }
    }
}
