using Newtonsoft.Json;

namespace CoCHelpers.Classes
{
    public class InvestigatorData
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Player { get; set; }

        [JsonProperty]
        public Occupation Occupation { get; set; }

        [JsonProperty]
        public int Age { get; set; }

        [JsonProperty]
        public Gender Gender { get; set; }

        [JsonProperty]
        public string PlaceOfResidence { get; set; }

        [JsonProperty]
        public string PlaceOfBirth { get; set; }

    }
}
