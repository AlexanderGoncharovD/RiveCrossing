using System;
using System.Drawing;

namespace CombineFrame
{
    class Initialization
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Settings.WorkDirectory);

            Settings.SetSourceDirectory();

            Image img1 = Bitmap.FromFile(Settings.FilesPaths[0]);
            Image img2 = Bitmap.FromFile(Settings.FilesPaths[1]);

            var res = new Bitmap(img2.Size.Width * 2, img1.Size.Height);

            Graphics g = Graphics.FromImage(res);
            g.DrawImage(img1, 0, 0, img1.Size.Width, img1.Size.Height);
            g.DrawImage(img2, img1.Size.Width, 0, img2.Size.Width, img2.Size.Height);

            res.Save($"res.png");
        }
    }
}
