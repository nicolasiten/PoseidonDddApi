using Microsoft.EntityFrameworkCore;
using PoseidonTradeDddApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<BidList> BidList { get; set; }

        DbSet<CurvePoint> CurvePoint { get; set; }

        DbSet<Rating> Rating { get; set; }

        DbSet<RuleName> RuleName { get; set; }

        DbSet<Trade> Trade { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
