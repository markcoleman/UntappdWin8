using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Beer
    {
        [JsonProperty("bid")]
        public int Bid { get; set; }
        [JsonProperty("beer_name")]
        public string BeerName { get; set; }
        [JsonProperty("beer_label")]
        public string BeerLabel { get; set; }
        [JsonProperty("beer_style")]
        public string BeerStyle { get; set; }
        [JsonProperty("auth_rating")]
        public int AuthRating { get; set; }
        [JsonProperty("wish_list")]
        public bool WishList { get; set; }
    }
}