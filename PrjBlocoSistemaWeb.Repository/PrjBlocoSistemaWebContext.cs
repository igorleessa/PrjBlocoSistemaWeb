using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PrjBlocoSistemaWeb.Domain.Conta.Agreggates;
using PrjBlocoSistemaWeb.Domain.Notificacao;
using PrjBlocoSistemaWeb.Domain.Streaming.Agreggates;
using PrjBlocoSistemaWeb.Domain.Transacao.Agreggates;

namespace PrjBlocoSistemaWeb.Repository
{
    public class PrjBlocoSistemaWebContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Banda> Bandas { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Plano> Planos { get; set; }

        public PrjBlocoSistemaWebContext(DbContextOptions<PrjBlocoSistemaWebContext> options) : base(options)
        {

        }


        //Escrever protected internal e vai aparecer OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrjBlocoSistemaWebContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
