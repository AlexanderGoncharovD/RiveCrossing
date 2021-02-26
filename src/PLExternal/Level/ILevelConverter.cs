using System;
using System.Collections.Generic;
using System.Text;

namespace PLExternal.Level
{
    public interface ILevelConverter
    {

        /// <summary>
        ///     Получить уровень по индексу
        /// </summary>
        string GetLevelByIndex(int index);

        /// <summary>
        ///     Получить уровень по номеру
        /// </summary>
        string GetLevelByNumber(int number);


        /// <summary>
        ///     Получить решение уровеня по индексу
        /// </summary>
        string GetLevelSolutionByIndex(int index);

        /// <summary>
        ///     Получить решение уровеня по номеру
        /// </summary>
        string GetLevelSolutionByNumber(int number);
    }
}
