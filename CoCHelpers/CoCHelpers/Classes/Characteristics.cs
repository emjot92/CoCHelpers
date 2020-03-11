using System;

namespace CoCHelpers.Classes
{
    public class Characteristics
    {
        public int Strength { get; set; }

        public int Constitution { get; set; }

        public int Size { get; set; }

        public int Dexterity { get; set; }

        public int Appearance { get; set; }

        public int Intelligence { get; set; }

        public int Power { get; set; }

        public int Education { get; set; }

        public int Luck { get; set; }

        public int HitPoints { get; set; }

        public int MaxHitPoints { get => (int)Math.Floor((double)((Constitution + Size) / 10)); }

        public int MagicPoints { get; set; }

        public int MaxMagicPoints { get => (int)Math.Floor((double)(Power / 5)); }

        public int SanityPoints { get; set; }

        public int Movement 
        { 
            get 
            {
                if(Dexterity < Size && Strength < Size)
                {
                    return 7;
                }
                else if(Strength > Size && Dexterity >= Size)
                {
                    return 9;
                }
                else
                {
                    return 8;
                }
            }
        }
    }
}
