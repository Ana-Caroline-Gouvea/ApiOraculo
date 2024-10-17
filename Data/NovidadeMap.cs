using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class NovidadeMap : IEntityTypeConfiguration<NovidadeModel>
    {
        public void Configure(EntityTypeBuilder<NovidadeModel> builder)
        {
            builder.HasKey(x => x.NovidadeId);
            builder.Property(x => x.NovidadeTexto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.NovidadeFoto).IsRequired().HasMaxLength(255);
        }

    }
}
