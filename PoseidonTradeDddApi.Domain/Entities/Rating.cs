namespace PoseidonTradeDddApi.Domain.Entities
{
    public partial class Rating
    {
        public int Id { get; set; }

        public string MoodysRating { get; set; }

        public string SandPrating { get; set; }

        public string FitchRating { get; set; }

        public byte? OrderNumber { get; set; }
    }
}
