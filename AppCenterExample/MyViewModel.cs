using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCenterExample
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public int count = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public string DisplayCount => $"You clicked {count} times";

        public MyViewModel()
        {
            IncreaseCommand = new Command(IncreaseCount);
        }

        public ICommand IncreaseCommand { get; }

        void IncreaseCount()
        {
            count++;
            OnPropertyChanged(nameof(DisplayCount));
        }

        public void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
