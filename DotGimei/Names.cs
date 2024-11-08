using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace DotGimei
{
    internal class Names
    {
        private const int KanjiIndex = 0;
        private const int HiraganaIndex = 1;
        private const int KatakanaIndex = 2;
        private const int RomajiIndex = 3;

        internal class Inner
        {
            [YamlMember(Alias = "male")]
            public List<string[]> Male { get; set; }

            [YamlMember(Alias = "female")]
            public List<string[]> Female { get; set; }
        }

        [YamlMember(Alias = "first_name")]
        public Inner FirstName { get; set; }

        [YamlMember(Alias = "last_name")]
        public List<string[]> LastName { get; set; }

        internal static Names Load(TextReader reader)
        {
            var deserializer = new Deserializer();
            var names = deserializer.Deserialize<Names>(reader);
            return names;
        }

        internal Name NextMale(Random r)
        {
            var first = FirstName.Male[r.Next(FirstName.Male.Count)];
            var last = LastName[r.Next(LastName.Count)];
            return NewName(first, last, GenderIdentity.Male);
        }
        internal Name NextFemale(Random r)
        {
            var first = FirstName.Female[r.Next(FirstName.Female.Count)];
            var last = LastName[r.Next(LastName.Count)];
            return NewName(first, last, GenderIdentity.Female);
        }
        private static Name NewName(string[] first, string[] last, GenderIdentity gender)
        {
            return new Name
            {
                First = new JapaneseText
                {
                    Kanji = first[KanjiIndex],
                    Hiragana = first[HiraganaIndex],
                    Katakana = first[KatakanaIndex],
                    Romaji = first[RomajiIndex],
                },
                Last = new JapaneseText
                {
                    Kanji = last[KanjiIndex],
                    Hiragana = last[HiraganaIndex],
                    Katakana = last[KatakanaIndex],
                    Romaji = last[RomajiIndex],
                },
                Gender = gender,
            };
        }
    }
}
