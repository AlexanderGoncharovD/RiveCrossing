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

        public override string ToString() => $"{Row}-{Column}";
    }
}
