using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class PostagemMap : IEntityTypeConfiguration<PostagemModel>
    {
        public void Configure(EntityTypeBuilder<PostagemModel> builder)
        {
            builder.HasKey(x => x.PostagemId);
            builder.Property(x => x.PostagemNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PostagemImg).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CategoriaId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ComunidadesId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Like).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Compartilhamento).IsRequired().HasMaxLength(255);
        }
    
    }
}
