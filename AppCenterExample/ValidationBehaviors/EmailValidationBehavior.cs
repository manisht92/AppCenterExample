using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AppCenterExample.ValidationBehaviors
{
    public class EmailValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }

        void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            var emailPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            var emailEntry = sender as Entry;
            if (Regex.IsMatch(emailEntry.Text, emailPattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                emailEntry.BackgroundColor = Color.Transparent;
            }
            else
            {
                emailEntry.BackgroundColor = Color.Red;
            }
        }

    }
}
