using Newtonsoft.Json;
using System;

namespace CoCHelpers.Classes
{
    public class Characteristics
    {
        [JsonProperty]
        public int Strength { get; set; }

        [JsonProperty]
        public int Constitution { get; set; }

        [JsonProperty]
        public int Size { get; set; }

        [JsonProperty]
        public int Dexterity { get; set; }

        [JsonProperty]
        public int Appearance { get; set; }

        [JsonProperty]
        public int Intelligence { get; set; }

        [JsonProperty]
        public int Power { get; set; }

        [JsonProperty]
        public int Education { get; set; }

        [JsonProperty]
        public int Luck { get; set; }

        [JsonProperty]
        public int HitPoints { get; set; }

        public int MaxHitPoints { get => (int)Math.Floor((double)((Constitution + Size) / 10)); }

        [JsonProperty]
        public int MagicPoints { get; set; }

        public int MaxMagicPoints { get => (int)Math.Floor((double)(Power / 5)); }

        [JsonProperty]
        public int SanityPoints { get; set; }

        public int Movement
        {
            get
            {
                if (Dexterity < Size && Strength < Size)
                {
                    return 7;
                }
                else if (Strength > Size && Dexterity >= Size)
                {
                    return 9;
                }
                else
                {
                    return 8;
                }
            }
        }

        [JsonProperty]
        public bool MajorWound { get; set; }
    }
}
