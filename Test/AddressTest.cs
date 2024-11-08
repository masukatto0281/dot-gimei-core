using DotGimei;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class AddressTest
    {
        [TestCase]
        public void Address_Prefectureプロパティについて_規定値はnullではなく_nullを設定すると例外が発生して値が変更されないこと()
        {
            var target = new Address();
            var before = target.Prefecture;
            Assert.Catch(() => target.Prefecture = null);
            var after = target.Prefecture;
            Assert.That(after, Is.SameAs(before));
        }

        [TestCase]
        public void Address_Cityプロパティについて_規定値はnullではなく_nullを設定すると例外が発生して値が変更されないこと()
        {
            var target = new Address();
            var before = target.City;
            Assert.Catch(() => target.City = null);
            var after = target.City;
            Assert.That(after, Is.SameAs(before));
        }

        [TestCase]
        public void Address_Townプロパティについて_規定値はnullではなく_nullを設定すると例外が発生して値が変更されないこと()
        {
            var target = new Address();
            var before = target.Town;
            Assert.Catch(() => target.Town = null);
            var after = target.Town;
            Assert.That(after, Is.SameAs(before));
        }

        [TestCase]
        public void Address_Kanjiプロパティについて_Prefecture_City_Townの漢字が結合されること()
        {
            var target = new Address
            {
                Prefecture = new JapaneseText { Kanji = "東京都" },
                City = new JapaneseText { Kanji = "千代田区" },
                Town = new JapaneseText { Kanji = "千代田" },
            };
            Assert.That(target.Kanji, Is.EqualTo("東京都千代田区千代田"));
        }

        [TestCase]
        public void Address_Hiraganaプロパティについて_Prefecture_City_Townのひらがなが結合されること()
        {
            var target = new Address
            {
                Prefecture = new JapaneseText { Hiragana = "とうきょうと" },
                City = new JapaneseText { Hiragana = "ちよだく" },
                Town = new JapaneseText { Hiragana = "ちよだ" },
            };
            Assert.That(target.Hiragana, Is.EqualTo("とうきょうとちよだくちよだ"));
        }

        [TestCase]
        public void Address_Katakanaプロパティについて_Prefecture_City_Townのカタカナが結合されること()
        {
            var target = new Address
            {
                Prefecture = new JapaneseText { Katakana = "トウキョウト" },
                City = new JapaneseText { Katakana = "チヨダク" },
                Town = new JapaneseText { Katakana = "チヨダ" },
            };
            Assert.That(target.Katakana, Is.EqualTo("トウキョウトチヨダクチヨダ"));
        }

        [TestCase]
        public void Address_Romajiプロパティについて_Prefecture_City_Townのローマ字が結合されること()
        {
            var target = new Address
            {
                Prefecture = new JapaneseText { Romaji = "Toukyouto" },
                City = new JapaneseText { Romaji = "Chiyodaku" },
                Town = new JapaneseText { Romaji = "Chiyoda" },
            };
            Assert.That(target.Romaji, Is.EqualTo("ToukyoutoChiyodakuChiyoda"));
        }

        [TestCase]
        public void Address_ToStringメソッドについて_Kanjiプロパティと同じ文字列であること()
        {
            var target = new Address
            {
                Prefecture = new JapaneseText { Kanji = "東京都" },
                City = new JapaneseText { Kanji = "千代田区" },
                Town = new JapaneseText { Kanji = "千代田" },
            };
            Assert.That(target.ToString(), Is.EqualTo(target.Kanji));
        }
    }
}
