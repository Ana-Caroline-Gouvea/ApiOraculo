﻿using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.UsuarioId);
            builder.Property(x => x.UsuarioNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioFoto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioEmail).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioApelido).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioDataNascimento).IsRequired().HasMaxLength(255);          
            builder.Property(x => x.UsuarioSenha).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UsuarioConfirmarSenha).IsRequired().HasMaxLength(255);
        }
    }
}
