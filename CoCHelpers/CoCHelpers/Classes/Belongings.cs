using Newtonsoft.Json;
using System.Collections.Generic;

namespace CoCHelpers.Classes
{
    public class Belongings
    {
        [JsonProperty]
        public List<string> Equipment { get; set; }

        [JsonProperty]
        public int ExpenditureLevel { get; set; }

        [JsonProperty]
        public int Cash { get; set; }

        [JsonProperty]
        public Dictionary<string, int> Possesions { get; set; }
    }
}
