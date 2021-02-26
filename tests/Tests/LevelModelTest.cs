using System;
using System.Linq;
using NUnit.Framework;
using PLExternal.Level;

namespace Tests
{
    public class LevelModelTest
    {
        [SetUp]
        public void Setup()
        { }

        [Test]
        public void LevelModal_Levels_Test()
        {
            if (LevelModel.Levels == null || LevelModel.Levels?.Length == 0)
            {
                throw new Exception("Not found levels");
            }

            if (LevelModel.Levels.Length != 40)
            {
                throw new Exception("Mismatching the number of levels");
            }

            foreach (var level in LevelModel.Levels)
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
                            if (!LevelModel.AllowedSymbols.Contains(symbol.ToString()))
                            {
                                throw new Exception($"Symbol: '{symbol}' not resolved");
                            }
                        }
                    }
                }
            }
        }
    }
}