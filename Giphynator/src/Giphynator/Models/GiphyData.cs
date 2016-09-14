using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Giphynator.Models
{
    public class GiphyData
    {
        [JsonProperty("data")]
        public List<GiphyItem> data { get; set; }
    }
}
