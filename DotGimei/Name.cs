using System;

namespace DotGimei
{
    /// <summary>
    /// 日本の氏名を表現します。
    /// </summary>
    public class Name : IJapaneseText
    {
        private JapaneseText _last = new();
        private JapaneseText _first = new();
        private static JapaneseText EnsureNotNull(JapaneseText value)
        {
            ArgumentNullException.ThrowIfNull(value);

            return value;
        }

        /// <summary>
        /// 性自認を取得または設定します。
        /// </summary>
        public GenderIdentity Gender { get; set; }
        /// <summary>
        /// 氏（名字）を取得または設定します。
        /// </summary>
        public JapaneseText Last
        {
            get { return _last; }
            set { _last = EnsureNotNull(value); }
        }
        /// <summary>
        /// 名（名前）を取得または設定します。
        /// </summary>
        public JapaneseText First
        {
            get { return _first; }
            set { _first = EnsureNotNull(value); }
        }
        /// <summary>
        /// 男性を表す名前かどうかを返します。
        /// 不明の場合はnullを返します。
        /// </summary>
        public bool? IsMale
        {
            get
            {
                return Gender switch
                {
                    GenderIdentity.Male => true,
                    GenderIdentity.Female => false,
                    _ => null,
                };
            }
        }
        /// <summary>
        /// 女性を表す名前かどうかを返します。
        /// 不明の場合はnullを返します。
        /// </summary>
        public bool? IsFemale
        {
            get
            {
                return Gender switch
                {
                    GenderIdentity.Male => false,
                    GenderIdentity.Female => true,
                    _ => null,
                };
            }
        }
        /// <summary>
        /// ひらがなの氏名を取得します。
        /// </summary>
        /// <remarks>
        /// 氏（名字）、スペース（<c>" "</c>）、および名（名前）を結合します。
        /// </remarks>
        public string Hiragana
        {
            get { return Last.Hiragana + " " + First.Hiragana; }
        }
        /// <summary>
        /// カタカナの氏名を取得します。
        /// </summary>
        /// <remarks>
        /// 氏（名字）、スペース（<c>" "</c>）、および名（名前）を結合します。
        /// </remarks>
        public string Katakana
        {
            get { return Last.Katakana + " " + First.Katakana; }
        }
        /// <summary>
        /// 漢字の氏名を取得します。
        /// </summary>
        /// <remarks>
        /// 氏（名字）、スペース（<c>" "</c>）、および名（名前）を結合します。
        /// </remarks>
        public string Kanji
        {
            get { return Last.Kanji + " " + First.Kanji; }
        }
        /// <summary>
        /// ローマ字の氏名を取得します。
        /// </summary>
        /// <remarks>
        /// 氏（名字）、スペース（<c>" "</c>）、および名（名前）を結合します。
        /// </remarks>
        public string Romaji
        {
            get { return Last.Romaji + " " + First.Romaji; }
        }
        /// <summary>
        /// 現在のオブジェクトを表す文字列を返します。
        /// 返される文字列は、漢字の氏名です。
        /// </summary>
        /// <returns>漢字の氏名。</returns>
        public override string ToString()
        {
            return Kanji;
        }
    }
}

