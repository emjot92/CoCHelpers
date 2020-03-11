using CoCHelpers.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoCHelpers.Interfaces
{
    public interface IOccupationParser
    {
        Task<IEnumerable<Occupation>> ParseDataAsync(string pathToFile);
    }
}
