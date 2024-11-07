using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace DotGimei
{
    internal class Addresses
    {
        private const int KanjiIndex = 0;
        private const int HiraganaIndex = 1;
        private const int KatakanaIndex = 2;

        internal class Inner
        {
            public List<string[]> Prefecture { get; set; }
            public List<string[]> City { get; set; }
            public List<string[]> Town { get; set; }
        }
        public Inner addresses { get; set; }

        internal static Addresses Load(TextReader reader)
        {
            var deserializer = new Deserializer();
            var addr = deserializer.Deserialize<Addresses>(reader);
            return addr;
        }

        internal Address Next(Random r)
        {
            var pref = addresses.Prefecture[r.Next(addresses.Prefecture.Count)];
            var city = addresses.City[r.Next(addresses.City.Count)];
            var town = addresses.Town[r.Next(addresses.Town.Count)];
            return new Address
            {
                Prefecture = new JapaneseText
                {
                    Kanji = pref[KanjiIndex],
                    Hiragana = pref[HiraganaIndex],
                    Katakana = pref[KatakanaIndex]
                },
                City = new JapaneseText
                {
                    Kanji = city[KanjiIndex],
                    Hiragana = city[HiraganaIndex],
                    Katakana = city[KatakanaIndex]
                },
                Town = new JapaneseText
                {
                    Kanji = town[KanjiIndex],
                    Hiragana = town[HiraganaIndex],
                    Katakana = town[KatakanaIndex]
                }
            };
        }
    }
}

