using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Giphynator.Models;

namespace Giphynator.Helpers
{
    //routine to modify output json to requirements (no 'gif_id' field in Giphy API return json)...
    public class DataContractResolver : DefaultContractResolver
    {
        public static readonly DataContractResolver Instance = new DataContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType == typeof(GiphyItem))
            {
                if (property.PropertyName.Equals("id", StringComparison.OrdinalIgnoreCase))
                {
                    property.PropertyName = "gif_id";
                }
            }
            return property;
        }
    }
}
