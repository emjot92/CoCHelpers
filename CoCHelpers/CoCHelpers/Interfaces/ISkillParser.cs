using CoCHelpers.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoCHelpers.Interfaces
{
    public interface ISkillParser
    {
        Task<IEnumerable<Skill>> ParseDataAsync(string pathToFile);
    }
}
