using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoseidonTradeDddApi.Domain.Entities;

namespace PoseidonTradeDddApi.Infrastructure.Persistence.Configuration
{
    public class CurvePointConfiguration : IEntityTypeConfiguration<CurvePoint>
    {
        public void Configure(EntityTypeBuilder<CurvePoint> builder)
        {
            builder.Property(e => e.AsOfDate).HasColumnType("datetime");

            builder.Property(e => e.CreationDate).HasColumnType("datetime");
        }
    }
}
