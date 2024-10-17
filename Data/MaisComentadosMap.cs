using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class MaisComentadosMap : IEntityTypeConfiguration<MaisComentadosModel>
    {
        public void Configure(EntityTypeBuilder<MaisComentadosModel> builder)
        {
            builder.HasKey(x => x.MaisComentadosId);
            builder.Property(x => x.PostagemId).IsRequired().HasMaxLength(255);
        }

    }
}
