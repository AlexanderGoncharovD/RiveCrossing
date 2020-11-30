using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using CombineFrames.ViewModels;

namespace CombineFrames
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
                Configuration.Configuration.Load();

                if (Directory.Exists(Configuration.Configuration.TempDirectoryPath))
                {
                    Directory.Delete(Configuration.Configuration.TempDirectoryPath, true);
                }

                Directory.CreateDirectory(Configuration.Configuration.TempDirectoryPath);
            }
            catch 
            { }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            Configuration.Configuration.Save();

            try
            {
                if (Directory.Exists(Configuration.Configuration.TempDirectoryPath))
                {
                    Directory.Delete(Configuration.Configuration.TempDirectoryPath, true);
                }
            }
            catch
            { }
        }
    }
}
