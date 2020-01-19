using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoseidonTradeDddApi.Domain.Entities;

namespace PoseidonTradeDddApi.Infrastructure.Persistence.Configuration
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(e => e.FitchRating).HasMaxLength(125);

            builder.Property(e => e.MoodysRating).HasMaxLength(125);

            builder.Property(e => e.SandPrating)
                .HasColumnName("SandPRating")
                .HasMaxLength(125);
        }
    }
}
