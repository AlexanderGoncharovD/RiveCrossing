using System;
using System.Collections.Generic;
using System.Text;

namespace CombineFrames.Models
{
    public class GenerationSettings
    {
        public int ColumnsCount { get; set; }
        public int RowsCount { get; set; }
        public int CanvasHeight { get; set; }
        public int CanvasWidth { get; set; }

        public GenerationSettings()
        { }

        public GenerationSettings(int columns, int rows, int width, int height)
        {
            ColumnsCount = columns;
            RowsCount = rows;
            CanvasWidth = width;
            CanvasHeight = height;
        }
    }
}
