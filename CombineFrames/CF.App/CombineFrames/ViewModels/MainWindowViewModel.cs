using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CombineFrames.Helpers;
using CombineFrames.Models;
using Microsoft.Win32;

namespace CombineFrames.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Properties

        public ObservableCollection<Picture> Pictures { get; set; } = new ObservableCollection<Picture>();
        public List<string> FilesPaths { get; set; }
        public string SourceDirectory { get; set; }

        #endregion

        #region Commands

        public  ICommand OpenCommand { get; set; }
        public  ICommand ClearCommand { get; set; }

        #endregion

        #region .ctro

        public MainWindowViewModel()
        {
            OpenCommand = new RelayCommand(o => OpenExecute());
            ClearCommand = new RelayCommand(o => ClearExecute());
        }

        #endregion

        #region Private Methods

        private void OpenExecute()
        {
            var openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = string.IsNullOrEmpty(SourceDirectory) ? Directory.GetCurrentDirectory() : SourceDirectory,
                Filter = "Image files (*.png)|*.png|All files (*.*)|*.*",
            };
            if (openFileDialog.ShowDialog() == true)
            {
                var path = Path.GetDirectoryName(openFileDialog.FileName);

                if (string.IsNullOrEmpty(path))
                {
                    Console.WriteLine("Path is null");
                    return;
                }

                path = path?.Replace("\"", "");

                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Directory not exists");
                    return;
                }

                FilesPaths = Directory.GetFiles(Path.GetFullPath(path), "*.png").ToList();

                if (!FilesPaths.Any())
                {
                    Console.WriteLine("Directory does not contains PNG");
                    return;
                }

                SourceDirectory = path;

                foreach (var filesPath in FilesPaths)
                {
                    Pictures.Add(Picture.Load(filesPath));
                }

                Console.WriteLine("Successful");
            }
        }

        private void ClearExecute()
        {
            Pictures.Clear();
        }

        #endregion
    }
}
