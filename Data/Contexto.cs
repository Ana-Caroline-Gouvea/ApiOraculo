using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<PostagemModel> Postagem { get; set; }
        public DbSet<NovidadeModel> Novidade { get; set; }
        public DbSet<MaisComentadosModel> MaisComentados { get; set; }
        public DbSet<EventoModel> Evento { get; set; }
        public DbSet<ComunidadesModel> Comunidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {      
            modelBuilder.ApplyConfiguration(new ComunidadesMap());
            modelBuilder.ApplyConfiguration(new EventoMap());
            modelBuilder.ApplyConfiguration(new MaisComentadosMap());
            modelBuilder.ApplyConfiguration(new NovidadeMap());
            modelBuilder.ApplyConfiguration(new PostagemMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
