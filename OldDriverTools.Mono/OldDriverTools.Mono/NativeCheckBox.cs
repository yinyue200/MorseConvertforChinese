using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace OldDriverTools.Mono
{
    public class NativeCheckBox : View, ICheckBox
    {
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(NativeCheckBox), false,propertyChanged: ischeckedchanged);
        public bool IsChecked { get => (bool)GetValue(IsCheckedProperty); set => SetValue(IsCheckedProperty, value); }
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(NativeCheckBox), string.Empty,propertyChanged: textchanged);
        public string Text { get => (string)GetValue(TextProperty); set => SetValue(TextProperty,value); }

        public event EventHandler Checked;
        public event EventHandler UnChecked;
        public event EventHandler Clicked;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler IsCheckedPropertyChanged;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler TextPropertyChanged;
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendClicked()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
        private static void ischeckedchanged(BindableObject obj, object oldobj, object newobj)
        {
            var nc = (NativeCheckBox)obj;
            nc.IsCheckedPropertyChanged?.Invoke(obj, EventArgs.Empty);
            if ((bool)newobj)
            {
                nc.Checked?.Invoke(obj, EventArgs.Empty);
            }
            else
            {
                nc.UnChecked?.Invoke(obj, EventArgs.Empty);
            }
        }
        private static void textchanged(BindableObject obj,object oldobj,object newobj)
        {
            ((NativeCheckBox)obj).TextPropertyChanged?.Invoke(obj, EventArgs.Empty);
        }
    }
}