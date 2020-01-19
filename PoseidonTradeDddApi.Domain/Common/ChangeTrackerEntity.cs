using System;

namespace PoseidonTradeDddApi.Domain.Common
{
    public class ChangeTrackerEntity
    {
        public string CreationName { get; set; }

        public DateTime? CreationDate { get; set; }

        public string RevisionName { get; set; }

        public DateTime? RevisionDate { get; set; }
    }
}
