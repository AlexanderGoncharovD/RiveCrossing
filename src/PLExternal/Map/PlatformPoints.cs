using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLExternal.Map
{
    /// <summary>
    /// Класс платформы
    /// </summary>
    public class PlatformPoints
    {
        public Transform First;
        public Transform Second;

        public void SetPoints(Transform first, Transform second)
        {
            First = first;
            Second = second;
        }

        public Transform GetNextPoint(Transform curPoint)
        {
            if (First == curPoint)
                return Second;
            if (Second == curPoint)
                return First;
            return null;

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
    }
}

