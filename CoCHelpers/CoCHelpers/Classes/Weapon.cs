using Newtonsoft.Json;

namespace CoCHelpers.Classes
{
    public class Weapon
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Damage { get; set; }

        [JsonProperty]
        public string Range { get; set; }

        [JsonProperty]
        public string NumberOfAttacks { get; set; }

        [JsonProperty]
        public int? Amunition { get; set; }

        [JsonProperty]
        public int? Fallibility { get; set; }
    }
}
