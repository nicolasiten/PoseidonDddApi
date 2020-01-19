using IdentityModel;
using Microsoft.AspNetCore.Identity;
using PoseidonTradeDddApi.Domain.Constants;
using PoseidonTradeDddApi.Domain.Entities;
using PoseidonTradeDddApi.Infrastructure.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PoseidonTradeDddApi.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedIdentityAsync(UserManager<ApplicationUser> userManager)
        {
            if ((await userManager.FindByEmailAsync("admin@poseidon.com")) == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@poseidon.com",
                    Email = "admin@poseidon.com",
                };

                if ((await userManager.CreateAsync(adminUser, "Poseidon1!")).Succeeded)
                {
                    await userManager.AddClaimAsync(adminUser, new Claim(JwtClaimTypes.Role, RoleNames.Admin));
                }
            }

            if ((await userManager.FindByEmailAsync("user@poseidon.com")) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "user@poseidon.com",
                    Email = "user@poseidon.com"
                };

                await userManager.CreateAsync(user, "Poseidon1!");
            }
        }

        public static async Task SeedDataAsync(ApplicationDbContext dbContext)
        {
            if (!dbContext.CurvePoint.Any())
            {
                dbContext.CurvePoint.Add(new CurvePoint
                {
                    AsOfDate = new DateTime(2020, 01, 10),
                    CurveId = 1,
                    Term = 1,
                    Value = 2
                });
            }

            if (!dbContext.Rating.Any())
            {
                dbContext.Rating.Add(new Rating
                {
                    FitchRating = "Fitch",
                    MoodysRating = "Moody",
                    SandPrating = "Sand",
                    OrderNumber = 1
                });
            }

            if (!dbContext.RuleName.Any())
            {
                dbContext.RuleName.Add(new RuleName
                {
                    Description = "Description",
                    Json = "Json",
                    Name = "Name",
                    SqlPart = "Sql",
                    SqlStr = "Sqlstr",
                    Template = "Template"
                });
            }

            if (!dbContext.BidList.Any())
            {
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
            }

            if (!dbContext.Trade.Any())
            {
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
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
