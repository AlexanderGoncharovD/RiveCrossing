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
                var firstPoint = GetPoint(platform.First());
                var secondPoint = GetPoint(platform.Last());
                var rowLength = Mathf.Abs(firstPoint.Row - secondPoint.Row);
                var colLength = Mathf.Abs(firstPoint.Column - secondPoint.Column);
                list.Add(rowLength + colLength);
            }

            return list;

            LevelPoint GetPoint(string pointStr)
            {
                var array = pointStr.Split('-');
                return new LevelPoint(int.Parse(array[0]), int.Parse(array[1]));
            }
        }
    }
}
