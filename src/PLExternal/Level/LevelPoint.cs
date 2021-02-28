using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLExternal.Level
{
    /// <summary>
    /// Координаты платформы на уровне
    /// </summary>
    public struct LevelPoint
    {
        public int Column { get; set; }

        public int Row { get; set; }

        public LevelPoint(int row, int col)
        {
            Column = col;
            Row = row;
        }

        public LevelPoint(string name)
        {
            var array = name.Split('-');
            Column = int.Parse(array[1]);
            Row = int.Parse(array[0]);
        }

        public override string ToString() => $"{Row}-{Column}";

        public static bool operator ==(LevelPoint point1, LevelPoint point2)
        {
            return point1.Row == point2.Row && point1.Column == point2.Column;
        }

        public static bool operator !=(LevelPoint point1, LevelPoint point2)
        {
            return point1.Row != point2.Row || point1.Column != point2.Column;
        }
    }
}
