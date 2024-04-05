using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrjBlocoSistemaWeb.Domain.Conta.Agreggates;
using PrjBlocoSistemaWeb.Domain.Streaming.Agreggates;
using PrjBlocoSistemaWeb.Domain.Streaming.ValueObject;

namespace PrjBlocoSistemaWeb.Repository.Mapping.Streaming
{
    public class PlaylistMapping : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable(nameof(Playlist));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Publica).IsRequired();
            builder.Property(x => x.DtCriacao).IsRequired();
            builder.HasKey(x => x.Usuario.Id);
            
        }
    }
}
