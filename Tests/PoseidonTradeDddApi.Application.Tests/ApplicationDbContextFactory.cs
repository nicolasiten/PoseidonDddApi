using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using PoseidonTradeDddApi.Application.Common.Interfaces;
using PoseidonTradeDddApi.Domain.Constants;
using PoseidonTradeDddApi.Domain.Entities;
using PoseidonTradeDddApi.Infrastructure.Persistence;
using System;

namespace PoseidonTradeDddApi.Application.Tests
{
    public static class ApplicationDbContextFactory
    {
        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var operationalStoreOptions = Options.Create(
                new OperationalStoreOptions
                {
                    DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
                    PersistedGrants = new TableConfiguration("PersistedGrants")
                });

            var currentUserServiceMock = new Mock<ICurrentUserService>();
            currentUserServiceMock.Setup(m => m.UserName)
                .Returns("admin@poseidon.com");
            currentUserServiceMock.Setup(m => m.RoleClaims)
                .Returns(new[] { RoleNames.Admin });

            var dbContext = new ApplicationDbContext(
                options, operationalStoreOptions,
                currentUserServiceMock.Object);

            dbContext.Database.EnsureCreated();

            SeedSampleData(dbContext);

            return dbContext;
        }

        public static void SeedSampleData(ApplicationDbContext dbContext)
        {
            dbContext.CurvePoint.Add(new CurvePoint
            {
                AsOfDate = new DateTime(2020, 01, 10),
                CurveId = 1,
                Term = 1,
                Value = 2
            });

            dbContext.Rating.Add(new Rating
            {
                FitchRating = "Fitch",
                MoodysRating = "Moody",
                SandPrating = "Sand",
                OrderNumber = 1
            });

            dbContext.RuleName.Add(new RuleName
            {
                Description = "Description",
                Json = "Json",
                Name = "Name",
                SqlPart = "Sql",
                SqlStr = "Sqlstr",
                Template = "Template"
            });

            dbContext.BidList.Add(new BidList
            {
                Account = "Account",
                Ask = 1,
                AskQuantity = 2,
                Benchmark = "Benchmark",
                Bid = 3,
                BidListDate = new DateTime(2020, 01, 09),
                BidQuantity = 4,
                Book = "Book",
                Commentary = "Commentary",
                DealName = "DealName",
                DealType = "DealType",
                Security = "Security",
                Side = "Side",
                SourceListId = "SourceListId",
                Status = "Status",
                Trader = "Trader",
                Type = "Type"
            });

            dbContext.Trade.Add(new Trade
            {
                Account = "Account",
                Book = "Book",
                DealName = "DealName",
                DealType = "DealType",
                Security = "Security",
                Side = "Side",
                SourceListId = "SourceListId",
                Status = "Status",
                Trader = "Trader",
                Type = "Type",
                Benchmark = "Benchmark",
                BuyPrice = 1,
                BuyQuantity = 2,
                SellPrice = 3,
                SellQuantity = 4,
                TradeDate = new DateTime(2020, 01, 10)
            });

            dbContext.SaveChanges();
        }
    }
}
