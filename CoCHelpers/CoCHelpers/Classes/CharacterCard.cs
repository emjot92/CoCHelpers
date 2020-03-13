using CoCHelpers.Extensions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CoCHelpers.Classes
{
    public class CharacterCard
    {
        private const int DamageBonusBuildDivider = 80;
        private const int DamageBonusBuildBehaviorChangeLevel = 205;

        public InvestigatorData InvestigatorData { get; }

        public Characteristics Characteristics { get; }

        public ObservableCollection<Skill> Skills { get; }

        public ObservableCollection<Weapon> Weapons { get; }

        public InvestigatorHistory InvestigatorHistory { get; }

        public Belongings Belongings { get; }

        public ObservableCollection<Relations> Relations { get; }

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

        public void Import(string pathToImport)
        {

        }

        public void Export(string pathToExport)
        {

        }
    }
}
