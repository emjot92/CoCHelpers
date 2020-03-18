using CoCHelpers.Classes;
using KellermanSoftware.CompareNetObjects;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CoCHelpersTests
{
    public class CharacterCardTests
    {
        [Test]
        public async Task CharacterCard_Should_BeProperlyExportedAndImported()
        {
            var investigatorData = new InvestigatorData
            {
                Name = "Elisabeth Grimaldi",
                Player = "Lao",
                Occupation = new Occupation
                {
                    Name = "Badacz"
                },
                Age = 26,
                Gender = Gender.Female,
                PlaceOfResidence = "Paryż",
                PlaceOfBirth = "Londyn"
            };
            var characteristics = new Characteristics
            {
                Strength = 45,
                Constitution = 70,
                Size = 71,
                Dexterity = 45,
                Appearance = 60,
                Intelligence = 55,
                Power = 55,
                Education = 65,
                HitPoints = 14,
                Luck = 55,
                MagicPoints = 11
            };
            var weapons = new System.Collections.ObjectModel.ObservableCollection<Weapon>
            {
                new Weapon
                {
                    Name = "Średni nóż",
                    Damage = "1D4 + 2 + MO",
                    NumberOfAttacks = "1"
                }
            };
            var history = new InvestigatorHistory
            {
                CharacterDescription = "Śliczna" +
                "Nieśmiała" +
                "Elegancka",
                IdeologyAndBeliefs = "Polityka - liberalizm",
                ImportantPeople = "Nauczyciel medycyny - Emmet Harding" +
                "ubóstwiam tą osobę za jej niesamowitą inteligencję",
                ImportantPlaces = "Wieża Eiffela",
                PersonalThings = "Okrągła, walcowata tuba bez otworu znaleziona pod wejściem do windy wieży Eiffela",
                Qualities = "Lojalność",
                InjuriesScars = "10cm blizna na prawej łopatce"
            };
            var belongings = new Belongings
            {
                Equipment = new System.Collections.Generic.List<string>
                {
                    "Książki historyczne",
                    "Średni nóż"
                },
                ExpenditureLevel = 10,
                Cash = 60,
                Possesions = new System.Collections.Generic.Dictionary<string, int>
                {
                    {"mieszkanie w Paryżu", 1500 }
                }
            };
            var relations = new System.Collections.ObjectModel.ObservableCollection<Relations>
            {
                new Relations
                {
                    Investigator = "Hudson Caffey",
                    Player = "Jasiu",
                    Relation = "kolega, poznany przez Howarda Barnhama"
                },
                new Relations
                {
                    Investigator = "Mortimer Caffey",
                    Player = "Gerard",
                    Relation = "kolega, poznany przez Howarda Barnhama"
                },
                new Relations
                {
                    Investigator = "Howard Barnham",
                    Player = "Bartek",
                    Relation = "Poznany 5 lat temu na bankiecie, dobry przyjaciel"
                }
            };
            var sut = CharacterCard.Create(investigatorData, characteristics, new System.Collections.ObjectModel.ObservableCollection<Skill>(), weapons, history, belongings, relations);
            await sut.InitializeAsync();
            await sut.ExportAsync("CharacterCard.json");

            var newSut = new CharacterCard();
            await newSut.ImportAsync("CharacterCard.json");
            var compareLogic = new CompareLogic();
            var result = compareLogic.Compare(sut, newSut);
            Assert.IsTrue(result.AreEqual);
        }
    }
}