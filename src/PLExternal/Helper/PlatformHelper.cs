using PLExternal.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PLExternal.Helper
{
    public static class PlatformHelper
    {
        /// <summary>
        ///		Получает длину платформы из её циферных координат
        /// </summary>
        /// <param name="platforms">Список платформ</param>
        public static List<int> GetPlatformLengths(IEnumerable<IEnumerable<string>> platforms)
        {
            var list = new List<int>();

            foreach (var platform in platforms)
            {
                list.Add(GetPlatformLength(platform));
            }

            return list;
        }

        /// <summary>
        ///     Возвращает длину платформы
        /// </summary>
        public static int GetPlatformLength(IEnumerable<string> platform)
        {
            var rowLength = GetRowLength(platform);
            var colLength = GetColLength(platform);
            return rowLength + colLength;
        }

        /// <summary>
        ///     Возвращет длину платформы по колонкам
        /// </summary>
        public static int GetColLength(IEnumerable<string> platform)
        {
            var firstPoint = GetPoint(platform.First());
            var secondPoint = GetPoint(platform.Last());
            var colLength = Mathf.Abs(firstPoint.Column - secondPoint.Column);
            return colLength;
        }

        /// <summary>
        ///     Возвращет длину платформы по строкам
        /// </summary>
        public static int GetRowLength(IEnumerable<string> platform)
        {
            var firstPoint = GetPoint(platform.First());
            var secondPoint = GetPoint(platform.Last());
            var colLength = Mathf.Abs(firstPoint.Row - secondPoint.Row);
            return colLength;
        }

        /// <summary>
        ///     Получает точку на основве текстовых координат
        /// </summary>
        public static LevelPoint GetPoint(string pointStr)
        {
            var array = pointStr.Split('-');
            return new LevelPoint(int.Parse(array[0]), int.Parse(array[1]));
        }
    }
}
