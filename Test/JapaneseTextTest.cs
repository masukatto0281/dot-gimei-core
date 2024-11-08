using DotGimei;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class JapaneseTextTest
    {
        [TestCase]
        public void JapaneseText_Kanjiプロパティについて_規定値はnullではないこと()
        {
            var target = new JapaneseText();
            Assert.That(target.Kanji, Is.Not.Null);
        }

        [TestCase]
        public void JapaneseText_Kanjiプロパティについて_nullでない値を設定できること()
        {
            var target = new JapaneseText
            {
                Kanji = "漢字"
            };
            Assert.That(target.Kanji, Is.EqualTo("漢字"));
        }

        [TestCase]
        public void JapaneseText_Kanjiプロパティについて_nullを設定すると値が空文字列になること()
        {
            var target = new JapaneseText
            {
                Kanji = null
            };
            Assert.That(target.Kanji, Is.EqualTo(""));
        }

        [TestCase]
        public void JapaneseText_Hiraganaプロパティについて_規定値はnullではないこと()
        {
            var target = new JapaneseText();
            Assert.That(target.Hiragana, Is.Not.Null);
        }

        [TestCase]
        public void JapaneseText_Hiraganaプロパティについて_nullでない値を設定できること()
        {
            var target = new JapaneseText
            {
                Hiragana = "ひらがな"
            };
            Assert.That(target.Hiragana, Is.EqualTo("ひらがな"));
        }

        [TestCase]
        public void JapaneseText_Hiraganaプロパティについて_nullを設定すると値が空文字列になること()
        {
            var target = new JapaneseText
            {
                Hiragana = null
            };
            Assert.That(target.Hiragana, Is.EqualTo(""));
        }

        [TestCase]
        public void JapaneseText_Katakanaプロパティについて_規定値はnullではないこと()
        {
            var target = new JapaneseText();
            Assert.That(target.Katakana, Is.Not.Null);
        }

        [TestCase]
        public void JapaneseText_Katakanaプロパティについて_nullでない値を設定できること()
        {
            var target = new JapaneseText
            {
                Katakana = "カタカナ"
            };
            Assert.That(target.Katakana, Is.EqualTo("カタカナ"));
        }

        [TestCase]
        public void JapaneseText_Katakanaプロパティについて_nullを設定すると値が空文字列になること()
        {
            var target = new JapaneseText
            {
                Katakana = null
            };
            Assert.That(target.Katakana, Is.EqualTo(""));
        }

        [TestCase]
        public void JapaneseText_Romajiプロパティについて_規定値はnullではないこと()
        {
            var target = new JapaneseText();
            Assert.That(target.Romaji, Is.Not.Null);
        }

        [TestCase]
        public void JapaneseText_Romajiプロパティについて_nullでない値を設定できること()
        {
            var target = new JapaneseText
            {
                Romaji = "Romaji"
            };
            Assert.That(target.Romaji, Is.EqualTo("Romaji"));
        }

        [TestCase]
        public void JapaneseText_Romajiプロパティについて_nullを設定すると値が空文字列になること()
        {
            var target = new JapaneseText
            {
                Romaji = null
            };
            Assert.That(target.Romaji, Is.EqualTo(""));
        }

        [TestCase]
        public void JapaneseText_ToStringメソッドについて_Kanjiプロパティと同じ文字列であること()
        {
            var target = new JapaneseText
            {
                Kanji = "漢字"
            };
            Assert.That(target.ToString(), Is.EqualTo(target.Kanji));
        }
    }
}
