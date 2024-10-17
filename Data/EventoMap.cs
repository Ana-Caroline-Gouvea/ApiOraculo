using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class EventoMap : IEntityTypeConfiguration<EventoModel>
    {
        public void Configure(EntityTypeBuilder<EventoModel> builder)
        {
            builder.HasKey(x => x.EventoId);
            builder.Property(x => x.EventoTexto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.EventoFoto).IsRequired().HasMaxLength(255);

        }

    }
}
