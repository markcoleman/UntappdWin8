using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Photo
    {
        [JsonProperty("photo_img_sm")]
        public string PhotoImgSm { get; set; }

        [JsonProperty("photo_img_md")]
        public string PhotoImgMd { get; set; }

        [JsonProperty("photo_img_lg")]
        public string PhotoImgLg { get; set; }

        [JsonProperty("photo_img_og")]
        public string PhotoImgOg { get; set; }
    }
}