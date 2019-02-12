using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCenterExample
{
    public class ListviewVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    HandleSelectedItem();
                }
            }
        }

        public void HandleSelectedItem()
        {
            var abc = SelectedItem;
        }

        public ObservableCollection<string> _mySource;

        public ObservableCollection<string> MySource
        {
            get
            {
                return _mySource;
            }
            set
            {
                _mySource = value;
                OnPropertyChanged(nameof(MySource));
            }
        }

        public string _alertMessage;
        public string AlertMessage
        {
            get => _alertMessage;
            set
            {
                _alertMessage = value;
                OnPropertyChanged(nameof(AlertMessage));
            }
        }

        public ListviewVM()
        {
            MySource = new ObservableCollection<string>
            {
                "First","Second"
            };
        }

        public ICommand MyItemClickCommand
        {
            get
            {
                return new Command((item) =>
                {
                    AlertMessage = item as string;
                });
            }
        }
    }
}