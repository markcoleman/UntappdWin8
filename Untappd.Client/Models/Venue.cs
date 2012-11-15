using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Venue
    {
        [JsonProperty("venue_id")]
        public int venue_id { get; set; }
        [JsonProperty("venue_name")]
        public string venue_name { get; set; }
        [JsonProperty("primary_category")]
        public string primary_category { get; set; }
        [JsonProperty("parent_category_id")]
        public string parent_category_id { get; set; }
        [JsonProperty("categories")]
        public CategoryList categories { get; set; }
        [JsonProperty("location")]
        public VenueLocation location { get; set; }
        [JsonProperty("contact")]
        public Contact contact { get; set; }
        [JsonProperty("foursquare")]
        public Foursquare foursquare { get; set; }
        [JsonProperty("venue_icon")]
        public VenueIcon venue_icon { get; set; }
    }
}