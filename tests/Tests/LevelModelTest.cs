using System;
using System.Linq;
using NUnit.Framework;
using PLExternal.Level;

namespace Tests
{
    public class LevelModelTest
    {
        /// <summary>
        /// Разрешённые символы для уровня
        /// </summary>
        public static string[] AllowedSymbols { get; } =
        {
            "1","2","3","4","5","6","7","8","9","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"
        };

        [SetUp]
        public void Setup()
        { }

        /// <summary>
        ///     Тест корректности записанных решений уровней
        /// </summary>
        [Test]
        public void LevelModal_Solutions_Test()
        {
            if (LevelModel.Solutions == null || LevelModel.Solutions?.Length == 0)
            {
                throw new Exception("Not found levels");
            }

            if (LevelModel.Solutions.Length != 40)
            {
                throw new Exception("Mismatching the number of levels");
            }

            foreach (var level in LevelModel.Solutions)
            {
                var pairs = level.Split(' ');

                if (pairs.Length == 0)
                {
                    throw new Exception("Level does not contain value pairs");
                }

                foreach (var pair in pairs)
                {
                    var poins = pair.Split('-');

                    if (poins.Length == 0)
                    {
                        throw new Exception("Points does not contain value");
                    }

                    if (poins.Length != 2)
                    {
                        throw new Exception("Number of points does not match 2");
                    }

                    foreach (var poin in poins)
                    {
                        if (poin.Length != 2)
                        {
                            throw new Exception("Point coordinates are incorrect");
                        }

                        var symbols = poin.ToCharArray();

                        foreach (var symbol in symbols)
                        {
                            if (!AllowedSymbols.Contains(symbol.ToString()))
                            {
                                throw new Exception($"Symbol: '{symbol}' not resolved");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Тест корректности конвертации из исходной строки уровня в карту игрового уровня
        /// </summary>
        [Test]
        public void Level_LevelConverter_Test()
        {
            var converter = new LevelConverter();

            var level25ByIndex = converter.GetLevelByIndex(24);
            var level25ByNumber = converter.GetLevelByNumber(25);

            Assert.AreEqual(level25ByIndex, level25ByNumber);
            Assert.AreEqual(level25ByNumber, "6-1;5-1;5-2;5-3;5-4;4-2;4-3;3-0;3-3;2-1;2-4;1-4;1-2;0-3");
        }

        /// <summary>
        ///     Корректность конвертации исходной строки расположения платформ в строку понятную для игрового уровня
        /// </summary>
        [Test]
        public void Platforms_LevelConverter_Test()
        {
            var converter = new LevelConverter();

            var level1ByIndex = converter.GetLevelPlatformsByIndex(0);
            var level1ByNumber = converter.GetLevelPlatformsByNumber(1);

            Assert.AreEqual(level1ByIndex, level1ByNumber);
            Assert.AreEqual(level1ByNumber, "6-1;4-1#4-1;3-1");
        }

    }
}