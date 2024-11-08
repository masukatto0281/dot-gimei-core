using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using YamlDotNet.Serialization;

namespace DotGimei
{
    internal class Addresses
    {
        private const int KanjiIndex = 0;
        private const int HiraganaIndex = 1;
        private const int KatakanaIndex = 2;
        private const int RomajiIndex = 3;

        internal class Inner
        {
            [YamlMember(Alias = "prefecture")]
            public List<string[]> Prefecture { get; set; }

            [YamlMember(Alias = "city")]
            public List<string[]> City { get; set; }

            [YamlMember(Alias = "town")]
            public List<string[]> Town { get; set; }
        }

        [YamlMember(Alias = "addresses")]
        public Inner Address { get; set; }

        internal static Addresses Load(TextReader reader)
        {
            var deserializer = new Deserializer();
            var addr = deserializer.Deserialize<Addresses>(reader);
            return addr;
        }

        internal Address Next(Random r)
        {
            var pref = Address.Prefecture[r.Next(Address.Prefecture.Count)];
            var city = Address.City[r.Next(Address.City.Count)];
            var town = Address.Town[r.Next(Address.Town.Count)];
            return new Address
            {
                Prefecture = new JapaneseText
                {
                    Kanji = pref[KanjiIndex],
                    Hiragana = pref[HiraganaIndex],
                    Katakana = pref[KatakanaIndex],
                    Romaji = pref[RomajiIndex],
                },
                City = new JapaneseText
                {
                    Kanji = city[KanjiIndex],
                    Hiragana = city[HiraganaIndex],
                    Katakana = city[KatakanaIndex],
                    Romaji = city[RomajiIndex],
                },
                Town = new JapaneseText
                {
                    Kanji = town[KanjiIndex],
                    Hiragana = town[HiraganaIndex],
                    Katakana = town[KatakanaIndex],
                    Romaji = town[RomajiIndex],
                }
            };
        }
    }
}
