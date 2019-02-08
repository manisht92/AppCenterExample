using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCenterExample
{
    public partial class CustomBehaviorPage : ContentPage
    {
        public ICommand OutputAgeCommand { get; private set; }

        public CustomBehaviorPage()
        {
            InitializeComponent();

            List<string> data = new List<string>
            {
                "a","b","c"
            };
            DemoList.ItemsSource = data;
            OutputAgeCommand = new Command(OutputAge);
        }

        public void OutputAge()
        {
            int abc = 1;
        }
    }
}
