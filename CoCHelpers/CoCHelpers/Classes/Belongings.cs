using System.Collections.Generic;

namespace CoCHelpers.Classes
{
    public class Belongings
    {
        public List<string> Equipment { get; set; }

        public int ExpenditureLevel { get; set; }

        public int Cash { get; set; }

        public Dictionary<string, int> Possesions { get; set; }
    }
}
