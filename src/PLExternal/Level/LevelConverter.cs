using System;
using System.Collections.Generic;
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

            return GetLevelByIndex(index);
        }

        #endregion

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
            
            var levelPairs = baseline.Split(' ');
            
            foreach (var pair in levelPairs)
            {
                foreach (var point in pair.Split('-'))
                {
                    var symbols = point.ToCharArray();

                    foreach (var symbol in symbols)
                    {
                        map.Add(LevelModel.MapPoints[symbol.ToString()]);
                    }
                }
            }

            return string.Join(";", map);
        }
    }
}
