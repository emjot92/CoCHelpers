using System.Collections.ObjectModel;

namespace CoCHelpers.Classes
{
    public class CategorySkill : Skill
    {
        public ObservableCollection<Skill> Skills { get; set; }
    }
}
