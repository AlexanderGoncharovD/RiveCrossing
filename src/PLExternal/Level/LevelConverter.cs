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
        public string GetLevelByIndex(int index)
        {
            var baseline= LevelModel.Levels[index];

            return ConvertToLevel(baseline);
        }

        /// <inheritdoc/>
        public string GetLevelByNumber(int number)
        {
            if (number == 0)
            {
                throw new Exception($"The value '{number}' is not a level number");
            }

            var index = number - 1;
            return GetLevelByIndex(index);
        }

        /// <inheritdoc/>
        public string GetLevelSolutionByIndex(int index)
        {
            var baseline = LevelModel.Solutions[index];

            return ConvertToSolution(baseline);
        }

        /// <inheritdoc/>
        public string GetLevelSolutionByNumber(int number)
        {
            if (number == 0)
            {
                throw new Exception($"The value '{number}' is not a level solution number");
            }

            var index = number - 1;

            return GetLevelSolutionByIndex(index);
        }

        /// <inheritdoc/>
        public string GetLevelPlatformsByIndex(int index)
        {
            var baseline = LevelModel.Platforms[index];

            return ConvertToPlatforms(baseline);
        }

        /// <inheritdoc/>
        public string GetLevelPlatformsByNumber(int number)
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
        private string ConvertToPlatforms(string baseline)
        {
            var map = new List<string>();

            var levelPairs = baseline.Split(' ');

            foreach (var pair in levelPairs)
            {
                var symbols = pair.ToCharArray();
                var platform = new List<LevelPoint>();

                foreach (var symbol in symbols)
                {
                    platform.Add(LevelModel.MapPoints[symbol.ToString()]);
                }
                map.Add(string.Join(";", platform));
            }

            return string.Join("#", map);
        }

        /// <summary>
        ///     Преобразует строку базового уровня в игровоей поле
        /// </summary>
        /// <param name="baseline">Строка базового уровня</param>
        private string ConvertToLevel(string baseline)
        {
            var map = new List<LevelPoint>();

            foreach (var symbol in baseline.Split(' '))
            {
                map.Add(LevelModel.MapPoints[symbol]);
            }

            return string.Join(";", map);
        }

        /// <summary>
        ///     Преобразует исходную строку решения уровня в строку решения для игрового поля
        /// </summary>
        /// <param name="baseline">Исходная строка решения уровня</param>
        private string ConvertToSolution(string baseline)
        {
            var map = new List<LevelPoint>();
            var symbols = baseline.ToCharArray();

            foreach (var symbol in symbols)
            {
                map.Add(LevelModel.MapPoints[symbol.ToString()]);
            }

            return string.Join(";", map);
        }
    }
}
