using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(OldDriverTools.Mono.NativeCheckBox),typeof(OldDriverTools.Mono.Droid.NativeCheckBoxRenderer))]
namespace OldDriverTools.Mono.Droid
{
    class NativeCheckBoxRenderer: ViewRenderer<OldDriverTools.Mono.NativeCheckBox, AppCompatCheckBox>
    {
        AppCompatCheckBox checkbox;

        protected override void OnElementChanged(ElementChangedEventArgs<OldDriverTools.Mono.NativeCheckBox> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                checkbox = new AppCompatCheckBox(Context) { Checked = false };
                SetNativeControl(checkbox);
            }

            if (e.NewElement != null)
            {
                e.NewElement.IsCheckedPropertyChanged += Element_IsCheckedPropertyChanged;
                e.NewElement.TextPropertyChanged += Element_TextPropertyChanged;
                checkbox.CheckedChange += Checkbox_CheckedChange;
                Element_TextPropertyChanged(e.NewElement, EventArgs.Empty);
                Element_IsCheckedPropertyChanged(e.NewElement, EventArgs.Empty);
            }

            if (e.OldElement != null)
            {
                e.OldElement.IsCheckedPropertyChanged -= Element_IsCheckedPropertyChanged;
                e.OldElement.TextPropertyChanged -= Element_TextPropertyChanged;
                checkbox.CheckedChange -= Checkbox_CheckedChange;
            }
        }

        private void Checkbox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (Element.IsChecked != e.IsChecked)
            {
                Element.SendClicked();
            }
            Element.IsChecked = e.IsChecked;
        }

        private void Element_TextPropertyChanged(object sender, EventArgs e)
        {
            checkbox.Text = Element.Text;
        }

        private void Element_IsCheckedPropertyChanged(object sender, EventArgs e)
        {
            checkbox.Checked = Element.IsChecked;
        }
    }
}