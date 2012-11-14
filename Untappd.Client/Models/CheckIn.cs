namespace Untappd.Api.Models
{
    public class CheckIn
    {
        public int GmtOffset     { get; set; }
        public string TimeZone { get; set; }
        public int BeerId { get; set; }
        public string FourSquareId { get; set; }
        public int? GeoLat { get; set; }
        public int? GeoLng { get; set; }
        public string Shout { get; set; }
        public BeerRating Rating { get; set; }
        public bool PostToFacebook { get; set; }
        public bool PostToTwitter { get; set; }
        public bool PostToFourSquare { get; set; }
    }
}