using Newtonsoft.Json;

namespace CoCHelpers.Classes
{
    public class Relations
    {
        [JsonProperty]
        public string Investigator { get; set; }

        [JsonProperty]
        public string Player { get; set; }

        [JsonProperty]
        public string Relation { get; set; }
    }
}
