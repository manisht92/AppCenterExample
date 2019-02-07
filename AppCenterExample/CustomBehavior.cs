using System;
using Xamarin.Forms;

namespace AppCenterExample
{
    public class CustomBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += CheckValidation;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
        }

        void CheckValidation(object sender, TextChangedEventArgs eventArgs)
        {
            int result;
            bool isValid = int.TryParse(eventArgs.NewTextValue, out result);
            (sender as Entry).TextColor = isValid ? Color.Green : Color.Red;
        }
    }
}
