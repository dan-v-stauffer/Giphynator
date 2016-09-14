using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Giphynator.Models
{
    public class GiphyItem
    {
        [JsonProperty("id")]
        public string gif_id { get; set; }

        [JsonProperty("url")]
        public Uri url { get; set; }
    }
}
