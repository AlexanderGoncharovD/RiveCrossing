using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CombineFrames.Models;
using CombineFrames.ViewModels;

namespace CombineFrames.Views
{
    /// <summary>
    /// Interaction logic for OpenCreateSettingsView.xaml
    /// </summary>
    public partial class OpenCreateSettingsView : Window
    {
        private OpenCreateSettingsViewModel _viewModel;

        public OpenCreateSettingsView(Window window, GenerationSettings settings)
        {
            InitializeComponent();
            _viewModel = new OpenCreateSettingsViewModel(window, this, settings);
            DataContext = _viewModel;
        }

        public static GenerationSettings Open(Window mainWindow, GenerationSettings settings)
        {
            var window = new OpenCreateSettingsView(mainWindow, settings);

            if (window.ShowDialog() ?? false)
            {
                return window._viewModel.Result;
            }

            return null;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is StackPanel)
            {
            }
        }
    }
}
