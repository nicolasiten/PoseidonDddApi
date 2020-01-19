using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PoseidonTradeDddApi.Infrastructure.Persistence.Migrations
{
    public partial class PoseidonTradeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BidList",
                columns: table => new
                {
                    BidListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false),
                    BidQuantity = table.Column<double>(nullable: true),
                    AskQuantity = table.Column<double>(nullable: true),
                    Bid = table.Column<double>(nullable: true),
                    Ask = table.Column<double>(nullable: true),
                    Benchmark = table.Column<string>(maxLength: 125, nullable: true),
                    BidListDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Commentary = table.Column<string>(maxLength: 125, nullable: true),
                    Security = table.Column<string>(maxLength: 125, nullable: true),
                    Status = table.Column<string>(maxLength: 10, nullable: true),
                    Trader = table.Column<string>(maxLength: 125, nullable: true),
                    Book = table.Column<string>(maxLength: 125, nullable: true),
                    CreationName = table.Column<string>(maxLength: 125, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RevisionName = table.Column<string>(maxLength: 125, nullable: true),
                    RevisionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealName = table.Column<string>(maxLength: 125, nullable: true),
                    DealType = table.Column<string>(maxLength: 125, nullable: true),
                    SourceListId = table.Column<string>(maxLength: 125, nullable: true),
                    Side = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidList", x => x.BidListId);
                });

            migrationBuilder.CreateTable(
                name: "CurvePoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurveId = table.Column<byte>(nullable: true),
                    AsOfDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Term = table.Column<double>(nullable: true),
                    Value = table.Column<double>(nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurvePoint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoodysRating = table.Column<string>(maxLength: 125, nullable: true),
                    SandPRating = table.Column<string>(maxLength: 125, nullable: true),
                    FitchRating = table.Column<string>(maxLength: 125, nullable: true),
                    OrderNumber = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuleName",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 125, nullable: true),
                    Description = table.Column<string>(maxLength: 125, nullable: true),
                    Json = table.Column<string>(maxLength: 125, nullable: true),
                    Template = table.Column<string>(maxLength: 512, nullable: true),
                    SqlStr = table.Column<string>(maxLength: 125, nullable: true),
                    SqlPart = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trade",
                columns: table => new
                {
                    TradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(maxLength: 30, nullable: false),
                    Type = table.Column<string>(maxLength: 30, nullable: false),
                    BuyQuantity = table.Column<double>(nullable: true),
                    SellQuantity = table.Column<double>(nullable: true),
                    BuyPrice = table.Column<double>(nullable: true),
                    SellPrice = table.Column<double>(nullable: true),
                    TradeDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Security = table.Column<string>(maxLength: 125, nullable: true),
                    Status = table.Column<string>(maxLength: 10, nullable: true),
                    Trader = table.Column<string>(maxLength: 125, nullable: true),
                    Benchmark = table.Column<string>(maxLength: 125, nullable: true),
                    Book = table.Column<string>(maxLength: 125, nullable: true),
                    CreationName = table.Column<string>(maxLength: 125, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RevisionName = table.Column<string>(maxLength: 125, nullable: true),
                    RevisionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealName = table.Column<string>(maxLength: 125, nullable: true),
                    DealType = table.Column<string>(maxLength: 125, nullable: true),
                    SourceListId = table.Column<string>(maxLength: 125, nullable: true),
                    Side = table.Column<string>(maxLength: 125, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade", x => x.TradeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidList");

            migrationBuilder.DropTable(
                name: "CurvePoint");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "RuleName");

            migrationBuilder.DropTable(
                name: "Trade");
        }
    }
}
