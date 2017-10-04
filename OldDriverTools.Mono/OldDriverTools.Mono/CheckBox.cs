using System;
using System.Collections.Generic;
using System.Text;
using CheckBoximplement = OldDriverTools.Mono.NativeCheckBox;



namespace OldDriverTools.Mono
{
    [Xamarin.Forms.ContentProperty(nameof(Text))]
    public class CheckBox: CheckBoximplement,ICheckBox
    {
    }
}
