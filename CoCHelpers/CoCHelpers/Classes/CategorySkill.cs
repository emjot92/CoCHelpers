using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace CoCHelpers.Classes
{
    public class CategorySkill : Skill
    {
        [JsonProperty]
        public ObservableCollection<Skill> CategorizedSkills { get; set; }
    }
}
