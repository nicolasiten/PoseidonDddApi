using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoseidonTradeDddApi.Domain.Entities;

namespace PoseidonTradeDddApi.Infrastructure.Persistence.Configuration
{
    public class RuleNameConfiguration : IEntityTypeConfiguration<RuleName>
    {
        public void Configure(EntityTypeBuilder<RuleName> builder)
        {
            builder.Property(e => e.Description).HasMaxLength(125);

            builder.Property(e => e.Json).HasMaxLength(125);

            builder.Property(e => e.Name).HasMaxLength(125);

            builder.Property(e => e.SqlPart).HasMaxLength(125);

            builder.Property(e => e.SqlStr).HasMaxLength(125);

            builder.Property(e => e.Template).HasMaxLength(512);
        }
    }
}
