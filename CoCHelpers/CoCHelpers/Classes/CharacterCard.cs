using CoCHelpers.Extensions;
using CoCHelpers.Interfaces;
using CoCHelpers.Parsers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoCHelpers.Classes
{
    public class CharacterCard
    {
        private const int DamageBonusBuildDivider = 80;
        private const int DamageBonusBuildBehaviorChangeLevel = 205;

        private readonly ISkillParser _skillParser;

        public CharacterCard() : this(new SkillParser(), new InvestigatorData(), new Characteristics(), new ObservableCollection<Skill>(), new ObservableCollection<Weapon>(), new InvestigatorHistory(), new Belongings(), new ObservableCollection<Relations>())
        {
        }

        private CharacterCard(InvestigatorData investigatorData, Characteristics characteristics, ObservableCollection<Skill> skills, ObservableCollection<Weapon> weapons, InvestigatorHistory investigatorHistory, Belongings belongings, ObservableCollection<Relations> relations) : this(new SkillParser())
        {
            InvestigatorData = investigatorData;
            Characteristics = characteristics;
            Skills = skills;
            Weapons = weapons;
            InvestigatorHistory = investigatorHistory;
            Belongings = belongings;
            Relations = relations;
        }

        private CharacterCard(ISkillParser skillParser, InvestigatorData investigatorData, Characteristics characteristics, ObservableCollection<Skill> skills, ObservableCollection<Weapon> weapons, InvestigatorHistory investigatorHistory, Belongings belongings, ObservableCollection<Relations> relations) : this(skillParser)
        {
            InvestigatorData = investigatorData;
            Characteristics = characteristics;
            Skills = skills;
            Weapons = weapons;
            InvestigatorHistory = investigatorHistory;
            Belongings = belongings;
            Relations = relations;
            InitializeAsync().Wait();
        }

        private CharacterCard(ISkillParser skillParser)
        {
            _skillParser = skillParser;
        }

        public static CharacterCard Create(InvestigatorData investigatorData, Characteristics characteristics, ObservableCollection<Skill> skills, ObservableCollection<Weapon> weapons, InvestigatorHistory investigatorHistory, Belongings belongings, ObservableCollection<Relations> relations)
        {
            return new CharacterCard(investigatorData,
                characteristics,
                skills,
                weapons,
                investigatorHistory,
                belongings,
                relations);
        }

        public InvestigatorData InvestigatorData { get; private set; }

        public Characteristics Characteristics { get; private set; }

        public ObservableCollection<Skill> Skills { get; private set; }

        public ObservableCollection<Weapon> Weapons { get; private set; }

        public InvestigatorHistory InvestigatorHistory { get; private set; }

        public Belongings Belongings { get; private set; }

        public ObservableCollection<Relations> Relations { get; private set; }

        public string DamageBonus
        {
            get
            {
                int sum = Characteristics.Strength + Characteristics.Size;
                if (sum < 2)
                {
                    return "-";
                }
                if (sum.IsBetween(2, 64))
                {
                    return "-2";
                }
                else if (sum.IsBetween(65, 84))
                {
                    return "-1";
                }
                else if (sum.IsBetween(85, 124))
                {
                    return "0";
                }
                else if (sum.IsBetween(125, 164))
                {
                    return "+1D4";
                }
                else if (sum.IsBetween(165, 204))
                {
                    return "1D6";
                }
                else
                {
                    if (sum >= DamageBonusBuildBehaviorChangeLevel)
                    {
                        int result = (sum - DamageBonusBuildBehaviorChangeLevel) / DamageBonusBuildDivider;
                        return $"{result + 2}D6";
                    }
                    else
                    {
                        return "-";//should never got here
                    }
                }
            }
        }

        public int Build
        {
            get
            {
                int sum = Characteristics.Strength + Characteristics.Size;
                if (sum < 2)
                {
                    return int.MinValue;
                }
                if (sum.IsBetween(2, 64))
                {
                    return -2;
                }
                else if (sum.IsBetween(65, 84))
                {
                    return -1;
                }
                else if (sum.IsBetween(85, 124))
                {
                    return 0;
                }
                else if (sum.IsBetween(125, 164))
                {
                    return 1;
                }
                else if (sum.IsBetween(165, 204))
                {
                    return 2;
                }
                else
                {
                    if (sum >= DamageBonusBuildBehaviorChangeLevel)
                    {
                        int result = (sum - DamageBonusBuildBehaviorChangeLevel) / DamageBonusBuildDivider;
                        return result + 3;
                    }
                    else
                    {
                        return int.MinValue;//should never got here
                    }
                }
            }
        }

        public async Task InitializeAsync()
        {
            var skills = await this._skillParser.ParseDataAsync("Skills.txt");
            foreach (var skill in skills)
            {
                Skills.Add(skill);
            }

        }

        public async Task ImportAsync(string pathToImport)
        {
            using (var file = File.OpenRead(pathToImport))
            {
                using (var reader = new StreamReader(file))
                {
                    var charactedCardJson = await reader.ReadToEndAsync().ConfigureAwait(false);
                    var characterCardSkillsCorrect = JsonConvert.DeserializeObject<CharacterCard>(charactedCardJson, new JsonSerializerSettings 
                    {
                        ObjectCreationHandling = ObjectCreationHandling.Replace
                    });
                    var characterCardRestCorrect = JsonConvert.DeserializeObject<CharacterCard>(charactedCardJson);
                    InvestigatorData = characterCardRestCorrect.InvestigatorData;
                    Characteristics = characterCardRestCorrect.Characteristics;
                    Skills = characterCardSkillsCorrect.Skills;
                    Weapons = characterCardRestCorrect.Weapons;
                    InvestigatorHistory = characterCardRestCorrect.InvestigatorHistory;
                    Belongings = characterCardRestCorrect.Belongings;
                    Relations = characterCardRestCorrect.Relations;
                }
            }
        }

        public Task ExportAsync(string pathToExport)
        {
            return Task.Run(() =>
            {
                var charactedCardJson = JsonConvert.SerializeObject(this, new JsonSerializerSettings { Formatting = Formatting.Indented, PreserveReferencesHandling = PreserveReferencesHandling.Objects });
                File.WriteAllText(pathToExport, charactedCardJson);
            });
        }
    }
}
