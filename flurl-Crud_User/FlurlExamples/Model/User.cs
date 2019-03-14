using Newtonsoft.Json;

namespace FlurlExamples.Model
{
    public class User
    {
        [JsonProperty(PropertyName = "username")]
        public string userName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string password { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "reassign")]
        public int reassignId { get; set; }
    }
}

