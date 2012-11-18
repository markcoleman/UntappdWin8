using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class BeerSearchResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("search_version")]
        public int SearchVersion { get; set; }

        [JsonProperty("found")]
        public int Found { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("parsed_term")]
        public string ParsedTerm { get; set; }

        [JsonProperty("breweries")]
        public BreweryList Breweries { get; set; }

        [JsonProperty("beers")]
        public BeerList Beers { get; set; }

        [JsonProperty("homebrew")]
        public Homebrew Homebrew { get; set; }
    }
}