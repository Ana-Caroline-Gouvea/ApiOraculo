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
            builder.Property(x => x.UsuarioId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PostagemData).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PostagemLike).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PostagemCompartilhamento).IsRequired().HasMaxLength(255);
        }
    
    }
}
