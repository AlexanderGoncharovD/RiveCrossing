using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLExternal.Level
{
    /// <summary>
    ///     Конвретер уровней
    /// </summary>
    public class LevelConverter : ILevelConverter
    {
        #region .ctor

        public LevelConverter()
        { }

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public IEnumerable<string> GetLevelByIndex(int index)
        {
            var baseline= LevelModel.Levels[index];

            return ConvertToLevel(baseline);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetLevelByNumber(int number)
        {
            if (number == 0)
            {
                throw new Exception($"The value '{number}' is not a level number");
            }

            var index = number - 1;
            return GetLevelByIndex(index);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetLevelSolutionByIndex(int index)
        {
            var baseline = LevelModel.Solutions[index];

            return ConvertToSolution(baseline);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetLevelSolutionByNumber(int number)
        {
            if (number == 0)
            {
                throw new Exception($"The value '{number}' is not a level solution number");
            }

            var index = number - 1;

            return GetLevelSolutionByIndex(index);
        }

        /// <inheritdoc/>
        public IEnumerable<IEnumerable<string>> GetLevelPlatformsByIndex(int index)
        {
            var baseline = LevelModel.Platforms[index];

            return ConvertToPlatforms(baseline);
        }

        /// <inheritdoc/>
        public IEnumerable<IEnumerable<string>> GetLevelPlatformsByNumber(int number)
        {
            if (number == 0)
            {
                throw new Exception($"The value '{number}' is not a level number");
            }

            var index = number - 1;

            return GetLevelPlatformsByIndex(index);
        }

        #endregion

        /// <summary>
        ///     Преобразует изначальную строку расстановки платоформ в строку платформ для игровой карты
        /// </summary>
        /// <param name="baseline"></param>
        /// <returns></returns>
        private IEnumerable<IEnumerable<string>> ConvertToPlatforms(string baseline)
        {
            var map = new List<List<string>>();

            var levelPairs = baseline.Split(' ');

            foreach (var pair in levelPairs)
            {
                var symbols = pair.ToCharArray();
                var platform = new List<string>();

                foreach (var symbol in symbols)
                {
                    platform.Add(LevelModel.MapPoints[symbol.ToString()].ToString());
                }
                map.Add(platform);
            }

            return map;
        }

        /// <summary>
        ///     Преобразует строку базового уровня в игровоей поле
        /// </summary>
        /// <param name="baseline">Строка базового уровня</param>
        private IEnumerable<string> ConvertToLevel(string baseline)
        {
            var map = new List<string>();

            foreach (var symbol in baseline.Split(' '))
            {
                map.Add(LevelModel.MapPoints[symbol].ToString());
            }

            return map;
        }

        /// <summary>
        ///     Преобразует исходную строку решения уровня в строку решения для игрового поля
        /// </summary>
        /// <param name="baseline">Исходная строка решения уровня</param>
        private IEnumerable<string> ConvertToSolution(string baseline)
        {
            var map = new List<string>();
            var symbols = baseline.ToCharArray();

            foreach (var symbol in symbols)
            {
                map.Add(LevelModel.MapPoints[symbol.ToString()].ToString());
            }

            return map;
        }
    }
}
