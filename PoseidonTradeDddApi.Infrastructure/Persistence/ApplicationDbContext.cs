using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PoseidonTradeDddApi.Application.Interfaces;
using PoseidonTradeDddApi.Domain.Entities;
using PoseidonTradeDddApi.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PoseidonTradeDddApi.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) 
            : base(options, operationalStoreOptions)
        {
        }

        public virtual DbSet<BidList> BidList { get; set; }

        public virtual DbSet<CurvePoint> CurvePoint { get; set; }

        public virtual DbSet<Rating> Rating { get; set; }

        public virtual DbSet<RuleName> RuleName { get; set; }

        public virtual DbSet<Trade> Trade { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
