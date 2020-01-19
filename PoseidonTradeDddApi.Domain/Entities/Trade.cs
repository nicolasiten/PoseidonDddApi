using PoseidonTradeDddApi.Domain.Common;
using System;

namespace PoseidonTradeDddApi.Domain.Entities
{
    public partial class Trade : ChangeTrackerEntity
    {
        public int TradeId { get; set; }

        public string Account { get; set; }

        public string Type { get; set; }

        public double? BuyQuantity { get; set; }

        public double? SellQuantity { get; set; }

        public double? BuyPrice { get; set; }

        public double? SellPrice { get; set; }

        public DateTime? TradeDate { get; set; }

        public string Security { get; set; }

        public string Status { get; set; }

        public string Trader { get; set; }

        public string Benchmark { get; set; }

        public string Book { get; set; }

        public string DealName { get; set; }

        public string DealType { get; set; }

        public string SourceListId { get; set; }

        public string Side { get; set; }
    }
}
