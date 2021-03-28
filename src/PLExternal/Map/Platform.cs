using System;
using System.Collections;
using System.Collections.Generic;
using PLExternal.Level;
using UnityEngine;

namespace PLExternal.Map
{
    /// <summary>
    /// Класс платформы
    /// </summary>
    public struct Platform
    {
        public Transform First;
        public Transform Second;

        public LevelPoint FirstPoint{ get; set; }
        public LevelPoint SecondPoint{ get; set; }

        public Platform(Transform first, Transform second)
        {
            First = first;
            Second = second;
            FirstPoint = new LevelPoint(first.name);
            SecondPoint = new LevelPoint(second.name);
        }

        public Transform GetNextPoint(Transform curPoint)
        {
            if (First == curPoint)
                return Second;
            if (Second == curPoint)
                return First;
            return null;

        }

        public IEnumerable<LevelPoint> GetPoints()
        {
            return new[]
            {
                FirstPoint,
                SecondPoint
            };
        }

        /// <summary>
        ///     Сравнить платформу с точками
        /// </summary>
        /// <param name="onePoint">
        ///     первая точка
        /// </param>
        /// <param name="twoPoint">
        ///     Вторая точка
        /// </param>
        /// <returns>
        ///     Существует ли платформа с такими точками
        /// </returns>
        public bool Comapre(Transform onePoint, Transform twoPoint)
        {
            if ((First == onePoint && Second == twoPoint)
                || (First == twoPoint && Second == onePoint))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Есть ли совпадения с точками платформы
        /// </summary>
        /// <param name="point">Точка, с которой ищем совпадения</param>
        public bool Coincidences(LevelPoint point)
        {
            return point == FirstPoint || point == SecondPoint;
        }

        /// <summary>
        ///     Есть ли совпадения с точками платформы
        /// </summary>
        /// <param name="platform">Платформа, с которой ищем совпадения</param>
        public bool Coincidences(Platform platform)
        {
            return Coincidences(platform.FirstPoint) || Coincidences(platform.SecondPoint);
        }

        /// <summary>
        ///     Есть ли совпадения с точками платформы
        /// </summary>
        /// <param name="platform">Платформа, с которой ищем совпадения</param>
        public bool CoincidencesStrict(Platform platform)
        {
            return Coincidences(platform.FirstPoint) && Coincidences(platform.SecondPoint);
        }

        public List<string> ToStringList()
        {
            return new List<string>
            {
                FirstPoint.ToString(),
                SecondPoint.ToString()
            };
        }

        public override string ToString()
        {
            return $"{FirstPoint};{SecondPoint}";
        }
    }
}

