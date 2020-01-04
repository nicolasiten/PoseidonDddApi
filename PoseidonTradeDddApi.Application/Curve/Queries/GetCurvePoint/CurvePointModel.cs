using System;
using System.Collections.Generic;
using System.Text;

namespace PoseidonTradeDddApi.Application.Curve.Queries.GetCurvePoint
{
    public class CurvePointModel
    {
        public int Id { get; set; }

        public byte? CurveId { get; set; }

        public DateTime? AsOfDate { get; set; }

        public double? Term { get; set; }

        public double? Value { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
