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
        IEnumerable<string> GetLevelByIndex(int index);

        /// <summary>
        ///     Получить уровень по номеру
        /// </summary>
        IEnumerable<string> GetLevelByNumber(int number);


        /// <summary>
        ///     Получить решение уровеня по индексу
        /// </summary>
        IEnumerable<string> GetLevelSolutionByIndex(int index);

        /// <summary>
        ///     Получить решение уровеня по номеру
        /// </summary>
        IEnumerable<string> GetLevelSolutionByNumber(int number);

        /// <summary>
        ///     Получить платофрмы для уровня по индексу
        /// </summary>
        IEnumerable<IEnumerable<string>> GetLevelPlatformsByIndex(int index);

        /// <summary>
        ///     Получить платофрмы для уровня по номеру
        /// </summary>
        IEnumerable<IEnumerable<string>> GetLevelPlatformsByNumber(int number);
    }
}
