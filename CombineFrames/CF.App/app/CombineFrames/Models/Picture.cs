using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CombineFrames.Models
{
    public class Picture
    {
        #region Properties

        public System.Drawing.Image Image { get; private set; }
        public string Link { get; private set; }
        public string Name { get; private set; }
        public Size Size { get; private set; }

        #endregion

        #region .ctor

        public Picture(System.Drawing.Image image)
        {
            Image = image;
        }

        #endregion

        #region Statci Methods

        public static Picture Load(string path)
        {
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            var image = new Image();
            var src = new BitmapImage();
            src.BeginInit();
            src.StreamSource = stream;
            src.EndInit();
            image.Source = src;
            image.Stretch = Stretch.Uniform;

            var picture = new Picture(System.Drawing.Bitmap.FromFile(path))
            {
                Link = path,
                Name = Path.GetFileName(path),
                Size = new Size(src)
            };

            return picture;
        }

        #endregion
    }
}
