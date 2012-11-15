using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class AddOrRemoveFromWishListResponse
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("beer")]
        public BeerInformation BeerDetails { get; set; }
    }
}