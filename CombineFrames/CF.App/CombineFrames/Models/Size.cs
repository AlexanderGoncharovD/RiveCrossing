using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CombineFrames.Models
{
    public struct Size
    {
        #region Properties

        public int Width { get; }
        public int Height { get; }

        #endregion

        #region .ctor

        public Size(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public Size(BitmapImage image)
        {
            Width = image.PixelWidth;
            Height = image.PixelHeight;
        }

        #endregion

        #region Override Methods

        public override string ToString()
        {
            return $"{Width}x{Height}";
        }

        #endregion
    }
}
