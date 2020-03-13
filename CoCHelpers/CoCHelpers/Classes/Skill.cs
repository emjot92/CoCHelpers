using Newtonsoft.Json;

namespace CoCHelpers.Classes
{
    public class Skill
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public int StartingValue { get; set; }

        [JsonProperty]
        public int Value { get; set; }

        [JsonProperty]
        public SkillCategory Category { get; set; }

        [JsonProperty]
        public bool IsModern { get; set; }
    }
}
