using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ComunidadesMap : IEntityTypeConfiguration<ComunidadesModel>
    {
        public void Configure(EntityTypeBuilder<ComunidadesModel> builder)
        {
            builder.HasKey(x => x.ComunidadesId);
            builder.Property(x => x.NomeComunidade).IsRequired().HasMaxLength(255);

        }

    }
}
