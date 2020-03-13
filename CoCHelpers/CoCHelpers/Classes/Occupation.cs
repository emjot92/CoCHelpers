using Newtonsoft.Json;

namespace CoCHelpers.Classes
{
    public class Occupation
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public string OccupationSkillPoints { get; set; }

        [JsonProperty]
        public int MinCredit { get; set; }

        [JsonProperty]
        public int MaxCredit { get; set; }

        [JsonProperty]
        public string Skills { get; set; }

        [JsonProperty]
        public OccupationType OccupationType { get; set; }
    }
}
