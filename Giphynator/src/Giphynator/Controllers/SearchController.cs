using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Newtonsoft.Json;
using Giphynator.Configuration;
using Giphynator.Models;
using Giphynator.Helpers;

namespace Giphynator.Controllers
{
    [Route("Giphynator/[controller]")]
    public class SearchController : Controller
    {
        public IOptions<GiphyConfig> _config;

        public SearchController(IOptions<GiphyConfig> config)
        {
            //use dependency injection to retrieve necessary config settings.
            _config = config;

        }

        // GET api/search
        [HttpGet]
        public string Get()
        {
            return "Please attach a search term to your url.";
        }

        // GET api/search/[searchterm]
        [HttpGet("{search}")]
        public async Task<string> Get(string search)
        {

            //call Giphy API - api parameters contained in appsettings.json file
            using (var client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri(_config.Value.BaseUrl);

                var response = await client.GetAsync(String.Format("{0}?q={1}&limit={2}&fmt={3}&api_key={4}",
                                                    _config.Value.Api, search,
                                                    _config.Value.SearchLimit,
                                                    _config.Value.ReturnFormat,
                                                    _config.Value.Key));

                //if search return >= return requirement, then print out json
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var giphyData = JsonConvert.DeserializeObject<GiphyData>(json);
                    if (giphyData.data.Count >= _config.Value.ReturnLimit)
                    {
                        var retval = JsonConvert.SerializeObject(giphyData, Formatting.Indented, new JsonSerializerSettings { ContractResolver = DataContractResolver.Instance });
                        return retval;
                    }
                }

                //if search return < return requirement, return empty set
                return JsonConvert.SerializeObject(new GiphyData(), Formatting.Indented);
            }
        }

    }
}
