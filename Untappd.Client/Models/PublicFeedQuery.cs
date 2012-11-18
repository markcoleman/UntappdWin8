namespace Untappd.Api.Models
{
    public class PublicFeedQuery
    {
        public int? Since { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? Radius { get; set; }
        public int? Offset { get; set; }
        public int? Count { get; set; }
    }
}