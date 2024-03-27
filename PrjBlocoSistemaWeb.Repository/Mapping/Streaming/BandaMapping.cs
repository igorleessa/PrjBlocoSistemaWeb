﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrjBlocoSistemaWeb.Domain.Streaming.Agreggates;

namespace PrjBlocoSistemaWeb.Repository.Mapping.Streaming
{
    public class BandaMapping : IEntityTypeConfiguration<Banda>
    {
        public void Configure(EntityTypeBuilder<Banda> builder)
        {
            builder.ToTable(nameof(Banda));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Backdrop).IsRequired().HasMaxLength(500);
            builder.HasMany<Album>(x => x.Albums).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}