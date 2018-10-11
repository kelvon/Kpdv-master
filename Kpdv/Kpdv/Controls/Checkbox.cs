using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace BackOn.Controls
{
    public class Checkbox : Xamarin.Forms.View
    {
        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(Checkbox), false);

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

    }
}
