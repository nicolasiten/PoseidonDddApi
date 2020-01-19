using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoseidonTradeDddApi.Domain.Entities;

namespace PoseidonTradeDddApi.Infrastructure.Persistence.Configuration
{
    public class TradeConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.Property(e => e.Account)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Benchmark).HasMaxLength(125);

            builder.Property(e => e.Book).HasMaxLength(125);

            builder.Property(e => e.CreationDate).HasColumnType("datetime");

            builder.Property(e => e.CreationName).HasMaxLength(125);

            builder.Property(e => e.DealName).HasMaxLength(125);

            builder.Property(e => e.DealType).HasMaxLength(125);

            builder.Property(e => e.RevisionDate).HasColumnType("datetime");

            builder.Property(e => e.RevisionName).HasMaxLength(125);

            builder.Property(e => e.Security).HasMaxLength(125);

            builder.Property(e => e.Side).HasMaxLength(125);

            builder.Property(e => e.SourceListId).HasMaxLength(125);

            builder.Property(e => e.Status).HasMaxLength(10);

            builder.Property(e => e.TradeDate).HasColumnType("datetime");

            builder.Property(e => e.Trader).HasMaxLength(125);

            builder.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
