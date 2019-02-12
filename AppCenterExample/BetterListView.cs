﻿using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCenterExample
{
    public class BetterListView : ListView
    {
        public static BindableProperty ItemClickCommandProperty = BindableProperty.Create(nameof(ItemClickCommand),
        typeof(ICommand), typeof(BetterListView), null);

        public ICommand ItemClickCommand
        {
            get
            {
                return (ICommand)this.GetValue(ItemClickCommandProperty);
            }
            set
            {
                this.SetValue(ItemClickCommandProperty, value);
            }
        }

        public BetterListView()
        {
            this.ItemTapped += OnItemTapped;
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                ItemClickCommand?.Execute(e.Item);
                SelectedItem = null;
            }
        }

    }
}
