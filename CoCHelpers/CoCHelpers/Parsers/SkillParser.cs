using CoCHelpers.Classes;
using CoCHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoCHelpers.Parsers
{
    public class SkillParser : ISkillParser
    {
        public async Task<IEnumerable<Skill>> ParseDataAsync(string pathToFile)
        {
            var parsedData = new List<Skill>();

            using (var file = File.OpenRead(pathToFile))
            {
                using (var reader = new StreamReader(file))
                {
                    string line = null;
                    do
                    {
                        line = await reader.ReadLineAsync();
                        var splitted = line.Split('\t');

                        if (splitted.Count() == 5)
                        {
                            Skill skill = null;
                            Enum.TryParse<SkillCategory>(splitted[2], out SkillCategory skillCategory);
                            bool isCategory = bool.Parse(splitted[4]);
                            if (isCategory)
                            {
                                skill = new CategorySkill
                                {
                                    Name = splitted[0],
                                    StartingValue = int.Parse(splitted[1]),
                                    Category = skillCategory,
                                    IsModern = bool.Parse(splitted[3]),
                                    Value = 0
                                };
                            }
                            else
                            {
                                skill = new Skill
                                {
                                    Name = splitted[0],
                                    StartingValue = int.Parse(splitted[1]),
                                    Category = skillCategory,
                                    IsModern = bool.Parse(splitted[3]),
                                    Value = int.Parse(splitted[1])
                                };
                            }
                            parsedData.Add(skill);
                        }
                    }
                    while (line != null);
                }
            }
            var categorySkills = parsedData.OfType<CategorySkill>();
            var skillsWithoutCategory = parsedData.Where(s => s.Category == SkillCategory.None);
            foreach (var categorySkill in categorySkills)
            {
                var skillsWithCurrentCategory = parsedData.Where(s => s.Category == categorySkill.Category);
                categorySkill.Skills = new ObservableCollection<Skill>(skillsWithCurrentCategory);
            }
            var skills = new List<Skill>();
            skills.AddRange(categorySkills);
            skills.AddRange(skillsWithoutCategory);
            skills.OrderBy(s => s.Name);
            return skills;
        }
    }
}
