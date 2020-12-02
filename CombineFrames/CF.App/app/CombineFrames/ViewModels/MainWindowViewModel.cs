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
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CombineFrames.Views;

namespace CombineFrames.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields

        private double _progress = 0.0D;
        private double _progress_unit = 0.0D;
        private const double MAX_PROGRESS = 100.0D;
        private readonly Configuration.Configuration _config;

        private string _resultImageLink;
        private Bitmap _resultBitmap;

        private GenerationSettings _generationSettings;

        #endregion

        #region Properties

        public ObservableCollection<Picture> Pictures { get; set; } = new ObservableCollection<Picture>();
        public List<string> FilesPaths { get; set; }

        public double Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }
        public bool IsCanGeneration { get; set; }

        public string ResultImageLink
        {
            get => _resultImageLink;
            set
            {
                _resultImageLink = value;
                OnPropertyChanged(nameof(ResultImageLink));
            }
        }

        public List<MenuItem> ResultImageContextMenuItems => new List<MenuItem>
        {
            new MenuItem {Header = "Save as", Command = new RelayCommand(o => SaveAsResultImage())}
        };

        #endregion

        #region Commands

        public  ICommand OpenCommand { get; set; }
        public  ICommand GenerationCommand { get; set; }
        public  ICommand OpenCreateSettingsCommand { get; set; }

        #endregion

        #region .ctro

        public MainWindowViewModel(MainWindow parent) 
            : base(parent)
        {
            _config = Configuration.Configuration.Config;
            _generationSettings = _config.GenerationSettings;

            OpenCommand = new RelayCommand(o => OpenExecute());
            OpenCreateSettingsCommand = new RelayCommand(o => OpenCreateSettingsModalExecute());
            GenerationCommand = new RelayCommand(o => GenerationExecute());
        }

        #endregion

        #region Private Methods

        private void OpenCreateSettingsModalExecute()
        {
            var result = OpenCreateSettingsView.Open(Parent, _generationSettings);
            if (result != null)
            {
                _generationSettings = result;
                GenerationExecute();
            }
        }

        private void OpenExecute()
        {
            var openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = string.IsNullOrEmpty(_config.SourceDirectory) 
                    ? Directory.GetCurrentDirectory() 
                    : _config.SourceDirectory,
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

                _config.SourceDirectory = path;

                foreach (var filesPath in FilesPaths)
                {
                    Pictures.Add(Picture.Load(filesPath));
                }

                Console.WriteLine("Successful");
                IsCanGeneration = true;
                OnPropertyChanged(nameof(IsCanGeneration));
            }
        }

        private void GenerationExecute()
        {
            ResultImageLink = string.Empty;
            var generationTask = Task.Run(() =>
            {
                IsCanGeneration = false;
                Progress = 0;
                _progress_unit = MAX_PROGRESS / Pictures.Count;
                var index = 0;
                _resultBitmap = new Bitmap(_generationSettings.CanvasWidth, _generationSettings.CanvasHeight);
                var graphics = Graphics.FromImage(_resultBitmap);
                
                // Делитель. Индекс преобразования изображения к нужному размеру холста
                var divider = (_generationSettings.ColumnsCount * Pictures[index].Image.Width) / (float)_generationSettings.CanvasWidth;

                for (var row = 0; row < _generationSettings.RowsCount; row++)
                {
                    for (var col = 0; col < _generationSettings.ColumnsCount; col++)
                    {
                        if (index >= Pictures.Count)
                            continue;

                        

                        var img = Pictures[index].Image;
                        graphics.DrawImage(img, col * img.Width / divider, row * img.Height / divider, img.Width / divider, img.Height / divider);
                        index++;
                        Progress += _progress_unit;
                    }
                }
                var name = $"{new FileInfo(Pictures.First().Link)?.Directory?.Name}-{Guid.NewGuid()}.png";
                var resultPath = Path.Combine(Configuration.Configuration.TempDirectoryPath, name);
                _resultBitmap.Save(resultPath);
                ResultImageLink = resultPath;

                IsCanGeneration = true;
            });
        }

        private void SaveAsResultImage()
        {
            var saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = string.IsNullOrEmpty(_config.SourceDirectory)
                    ? Directory.GetCurrentDirectory()
                    : _config.SourceDirectory,
                Filter = "Image files (*.png)|*.png|All files (*.*)|*.*",
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                _resultBitmap.Save(saveFileDialog.FileName);
            }
        }

        #endregion
    }
}
