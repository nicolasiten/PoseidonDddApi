using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Common;
using PoseidonTradeDddApi.Domain.Entities;
using PoseidonTradeDddApi.Infrastructure.Identity;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService)
            : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
        }

        public virtual DbSet<BidList> BidList { get; set; }

        public virtual DbSet<CurvePoint> CurvePoint { get; set; }

        public virtual DbSet<Rating> Rating { get; set; }

        public virtual DbSet<RuleName> RuleName { get; set; }

        public virtual DbSet<Trade> Trade { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<ChangeTrackerEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationName = _currentUserService.UserName;
                        entry.Entity.CreationDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.RevisionName = _currentUserService.UserName;
                        entry.Entity.RevisionDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
