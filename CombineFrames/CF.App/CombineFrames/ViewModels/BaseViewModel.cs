using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CombineFrames.Helpers;

namespace CombineFrames.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected Window Parent { get; }

        public ICommand CloseCommand { get; }

        public BaseViewModel(Window parent)
        {
            Parent = parent;
            CloseCommand = new RelayCommand(o => CloseCommandExecute());
        }

        public void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected virtual void CloseCommandExecute()
        {
            Parent.Close();
        }
    }
}
