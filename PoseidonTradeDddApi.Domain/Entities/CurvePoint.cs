using System;

namespace PoseidonTradeDddApi.Domain.Entities
{
    public partial class CurvePoint
    {
        public int Id { get; set; }

        public byte? CurveId { get; set; }

        public DateTime? AsOfDate { get; set; }

        public double? Term { get; set; }

        public double? Value { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
