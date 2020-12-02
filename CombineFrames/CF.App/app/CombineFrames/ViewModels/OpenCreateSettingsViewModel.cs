using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CombineFrames.Helpers;
using CombineFrames.Models;
using CombineFrames.Views;

namespace CombineFrames.ViewModels
{
    public class OpenCreateSettingsViewModel : BaseViewModel
    {
        private int _columns;
        private int _rows;
        private int _width;
        private int _height;
        private GenerationSettings _generationSettings;

        public GenerationSettings Result
        {
            get => _generationSettings;
            private set
            {
                _generationSettings = value;
                Configuration.Configuration.Config.GenerationSettings = _generationSettings;
            }
        }

        public ICommand ExecuteCommand { get; set; }

        public int Columns
        {
            get => _columns;
            set
            {
                _columns = value;
                OnPropertyChanged(nameof(Columns));
            }
        }
        public int Rows
        {
            get => _rows;
            set
            {
                _rows = value;
                OnPropertyChanged(nameof(Rows));
            }
        }
        public int Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }
        public int Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public OpenCreateSettingsViewModel(Window window, OpenCreateSettingsView parent, GenerationSettings settings) 
            :base(parent)
        {
            if (settings != null)
            {
                Columns = settings.ColumnsCount;
                Rows = settings.RowsCount;
                Width = settings.CanvasWidth;
                Height = settings.CanvasHeight;
            }
            ExecuteCommand = new RelayCommand(o => ExecuteCommandExecute());
            Parent.Owner = window;
        }

        private void ExecuteCommandExecute()
        {
            Result = new GenerationSettings(Columns, Rows, Width, Height);

            Parent.DialogResult = true;
            
            Parent.Close();
        }
    }
}
