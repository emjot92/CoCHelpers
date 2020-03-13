using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoCHelpers.Classes
{
    public class InvestigatorHistory
    {
        [JsonProperty]
        public string CharacterDescription { get; set; }

        [JsonProperty]
        public string IdeologyAndBeliefs { get; set; }

        [JsonProperty]
        public string ImportantPeople { get; set; }

        [JsonProperty]
        public string ImportantPlaces { get; set; }

        [JsonProperty]
        public string PersonalThings { get; set; }

        [JsonProperty]
        public string Qualities { get; set; }

        [JsonProperty]
        public string InjuriesScars { get; set; }

        [JsonProperty]
        public string PhobiasManias { get; set; }

        [JsonProperty]
        public string SecreatBooksSpellsArtifacts { get; set; }

        [JsonProperty]
        public string MeetingWithStrangeCreatures { get; set; }
    }
}
