using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CombineFrame
{
    public class Settings
    {
        #region Properties

        public static string WorkDirectory { get; } = Directory.GetCurrentDirectory();
        public static string SourceDirectory { get; private set; }
        public static string[] FilesPaths { get; private set; }

        #endregion

        #region Methods

        public static void SetSourceDirectory()
        {
            var isSet = false;

            while (!isSet)
            {
                Console.Write("Set path source: ");
                var path = Console.ReadLine();

                if (string.IsNullOrEmpty(path))
                {
                    Console.WriteLine("Path is null");
                    continue;
                }

                path = path.Replace("\"", "");

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Directory not exists");
                    continue;
                }

                FilesPaths = Directory.GetFiles(Path.GetFullPath(path), "*.png");

                if (!FilesPaths.Any())
                {
                    Console.WriteLine("Directory does not contains PNG");
                    continue;
                }

                SourceDirectory = path;

                Console.WriteLine("Successful");

                isSet = true;
            }
        }

        #endregion
    }
}
