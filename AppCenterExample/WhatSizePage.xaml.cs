using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AppCenterExample
{
    public partial class WhatSizePage : ContentPage
    {
        Label label;
        public WhatSizePage()
        {
            InitializeComponent();

            label = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Content = label;

            SizeChanged += WhatSizePage_SizeChanged;
        }

        void WhatSizePage_SizeChanged(object sender, EventArgs e)
        {
            label.Text = string.Format("{0} \u00D7 {1}", Width, Height);
        }

    }
}
