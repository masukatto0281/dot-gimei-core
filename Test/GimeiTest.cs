using DotGimei;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Test
{
    [TestFixture]
    public partial class GimeiTest
    {
        // 埋め込まれたデータはBMP内の文字しかないという想定
        [GeneratedRegex(@"^[ \p{IsCJKRadicalsSupplement}\p{IsCJKSymbolsandPunctuation}\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographsExtensionA}\p{IsCJKUnifiedIdeographs}\p{IsCJKCompatibilityIdeographs}]+$")]
        private static partial Regex RegKanjiPattern();

        [GeneratedRegex(@"^[ \p{IsHiragana}]+$")]
        private static partial Regex RegHiraganaPattern();
        [GeneratedRegex(@"^[ \p{IsKatakana}]+$")]
        private static partial Regex RegKatakanaPattern();

        [TestCase]
        public void Gimei_SharedGeneratorプロパティについて_規定値はnullではなく_nullを設定すると例外が発生して値が変更されないこと()
        {
            var before = Gimei.SharedGenerator;
            Assert.That(before, Is.Not.Null);
            Assert.Catch(() => Gimei.SharedGenerator = null);
            var after = Gimei.SharedGenerator;
            Assert.That(after, Is.SameAs(before));
        }

        [TestCase]
        public void Gimei_NewNameメソッドについて_100回連続で呼び出しても_KanjiプロパティはBMPの全角文字列とスペース_Hiraganaプロパティはひらがなとスペース_Katakanaプロパティはカタカナとスペースを返すこと()
        {


            for (var i = 0; i < 100; i++)
            {
                var target = Gimei.NewName();
                Assert.That(RegKanjiPattern().IsMatch(target.Kanji), Is.True, target.Kanji);
                Assert.That(RegHiraganaPattern().IsMatch(target.Hiragana), Is.True, target.Hiragana);
                Assert.That(RegKatakanaPattern().IsMatch(target.Katakana), Is.True, target.Katakana);
            }
        }

        [TestCase]
        public void Gimei_NewNameメソッドについて_100回連続で呼び出すと男性名と女性名がそれぞれ1個以上_計100個返ってくること()
        {
            var counter = new Dictionary<GenderIdentity, int>
            {
                { GenderIdentity.Male, 0 }, { GenderIdentity.Female, 0 }
            };
            for (var i = 0; i < 100; i++)
            {
                var target = Gimei.NewName();
                counter[target.Gender]++;
            }
            Assert.That(counter[GenderIdentity.Male], Is.GreaterThanOrEqualTo(1));
            Assert.That(counter[GenderIdentity.Female], Is.GreaterThanOrEqualTo(1));
            Assert.That(100, Is.EqualTo(counter[GenderIdentity.Male] + counter[GenderIdentity.Female]));
        }

        [TestCase]
        public void Gimei_NewMaleメソッドについて_データが1行の時にIsMaleプロパティ_IsFemaleプロパティ_ToStringメソッドがそれぞれ期待値を返すこと()
        {
            Gimei.SharedGenerator = Mock.SingleDataGenerator();
            var target = Gimei.NewMale();
            Assert.That(target.IsMale, Is.True);
            Assert.That(target.IsFemale, Is.False);
            Assert.That(target.ToString(), Is.EqualTo("佐藤 翔太"));
        }

        [TestCase]
        public void Gimei_NewFemaleメソッドについて_データが1行の時にIsMaleプロパティ_IsFemaleプロパティ_ToStringメソッドがそれぞれ期待値を返すこと()
        {
            Gimei.SharedGenerator = Mock.SingleDataGenerator();
            var target = Gimei.NewFemale();
            Assert.That(target.IsMale, Is.False);
            Assert.That(target.IsFemale, Is.True);
            Assert.That(target.ToString(), Is.EqualTo("佐藤 美咲"));
        }

        [TestCase]
        public void Gimei_NewAddressメソッドについて_100回連続で呼び出しても_KanjiプロパティはBMPの全角文字列_Hiraganaプロパティはひらがな_Katakanaプロパティはカタカナを返すこと()
        {
            for (var i = 0; i < 100; i++)
            {
                var target = Gimei.NewAddress();
                Assert.That(RegKanjiPattern().IsMatch(target.Kanji), Is.True, target.Kanji);
                Assert.That(RegHiraganaPattern().IsMatch(target.Hiragana), Is.True, target.Hiragana);
                Assert.That(RegKatakanaPattern().IsMatch(target.Katakana), Is.True, target.Katakana);
            }
        }

        [TestCase]
        public void Gimei_NewAddressメソッドについて_データが1行の時にPrefecture_City_Townプロパティがそれぞれ期待値を返すこと()
        {
            Gimei.SharedGenerator = Mock.SingleDataGenerator();
            var target = Gimei.NewAddress();
            Assert.That(target.Prefecture.ToString(), Is.EqualTo("東京都"));
            Assert.That(target.City.ToString(), Is.EqualTo("千代田区"));
            Assert.That(target.Town.ToString(), Is.EqualTo("千代田"));
        }

        [TestCase]
        public void Gimei_NewPrefectureメソッドについて_データが1行の時に期待値を返すこと()
        {
            Gimei.SharedGenerator = Mock.SingleDataGenerator();
            var target = Gimei.NewPrefecture();
            Assert.That(target.ToString(), Is.EqualTo("東京都"));
        }

        [TestCase]
        public void Gimei_NewCityメソッドについて_データが1行の時に期待値を返すこと()
        {
            Gimei.SharedGenerator = Mock.SingleDataGenerator();
            var target = Gimei.NewCity();
            Assert.That(target.ToString(), Is.EqualTo("千代田区"));
        }

        [TestCase]
        public void Gimei_NewTownメソッドについて_データが1行の時に期待値を返すこと()
        {
            Gimei.SharedGenerator = Mock.SingleDataGenerator();
            var target = Gimei.NewTown();
            Assert.That(target.ToString(), Is.EqualTo("千代田"));
        }
    }
}
