using System.IO;
using DotGimei;

namespace Test
{
    public static class Mock
    {
        public static Gimei.Generator SingleDataGenerator()
        {
            var addressesReader = new StringReader("""
                addresses:
                  prefecture:
                    - ['東京都', 'とうきょうと', 'トウキョウト', 'Toukyouto']
                  city:
                  - ['千代田区', 'ちよだく', 'チヨダク', 'Chiyodaku']
                  town:
                  - ['千代田', 'ちよだ', 'チヨダ', 'Chiyoda']
                """);

            var namesReader = new StringReader("""
                first_name:
                  male:
                    - ['翔太', 'しょうた', 'ショウタ', 'Shouta']
                  female:
                    - ['美咲', 'みさき', 'ミサキ', 'Misaki']
                last_name:
                  - ['佐藤', 'さとう', 'サトウ', 'Satou']
                """);

            return new Gimei.Generator(addresses: addressesReader, names: namesReader);
        }
    }
}
