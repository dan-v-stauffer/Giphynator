using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Giphynator.Configuration
{
    //using Options pattern for Giphy API settings
    public class GiphyConfig
    {
        public string BaseUrl { get; set; }
        public string Key { get; set; }
        public string Api { get; set; }
        public int SearchLimit { get; set; }
        public int ReturnLimit { get; set; }
        public string ReturnFormat { get; set; }
    }
}
