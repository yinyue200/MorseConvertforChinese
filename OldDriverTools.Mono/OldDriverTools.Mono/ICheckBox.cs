using System;
using System.Collections.Generic;
using System.Text;

namespace OldDriverTools.Mono
{
    public interface ICheckBox
    {
        bool IsChecked { get; set; }
        string Text { get; set; }
        event EventHandler Checked;
        event EventHandler UnChecked;
        event EventHandler Clicked;
    }
}
