using System;
using System.Collections.Generic;
using System.IO;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace olddrivertools
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string output = string.Empty;
            Button nowbutton = sender as Button;
            zhuanhuanbutton.IsEnabled = false;
            jiantieb.IsEnabled = false;
            string input = string.Empty;
            try
            {
                if (nowbutton == jiantieb)
                {
                    input = await Clipboard.GetContent().GetTextAsync();
                }
                else
                {
                    input = inputbox.Text;
                }
                if (checkbox.IsChecked == true)
                {
                    byte[] content = null;
                    try
                    {
                        switch (jismichoose.SelectedIndex)
                        {
                            case 0:
                                NewMethod2(out content);
                                break;
                            case 1:
                                NewMethod16(out content);
                                break;
                            case 2:
                                content = Convert.FromBase64String(input);
                                return;
                            case 3:
                                output = MorseConvert.morse2word(input);
                                return;
                            case 4:
                                output = MorseConvertChinese.morse2word(input);
                                return;
                        }
                        switch (encodingchoose.SelectedIndex)
                        {
                            case 0:
                                output = System.Text.Encoding.UTF8.GetString(content);
                                break;
                            case 1:
                                output = System.Text.Encoding.Unicode.GetString(content);
                                break;
                            case 2:
                                output = System.Text.Encoding.BigEndianUnicode.GetString(content);
                                break;
                        }
                    }
                    finally
                    {
                        if(encodingchoose.SelectedIndex==3)
                        {
                            Windows.Storage.Pickers.FileSavePicker fsp = new Windows.Storage.Pickers.FileSavePicker();
                            fsp.FileTypeChoices.Add("bin", new List<string> { ".bin" });
                            //fsp.FileTypeChoices.Add("*", new List<string> { "*" });

                            var file = await fsp.PickSaveFileAsync();
                            using (var stream = await file.OpenStreamForWriteAsync())
                            {
                                stream.Write(content, 0, content.Length);
                            }
                        }
                    }

                }
                else
                {
                    byte[] content = null;
                    switch (encodingchoose.SelectedIndex)
                    {
                        case 0:
                            content = System.Text.Encoding.UTF8.GetBytes(input);
                            break;
                        case 1:
                            content = System.Text.Encoding.Unicode.GetBytes(input);
                            break;
                        case 2:
                            content = System.Text.Encoding.BigEndianUnicode.GetBytes(input);
                            break;
                    }
                    output = bintostring(content);
                }
            }
            catch
            {
                outputbox.Text = "转换出错";
            }
            finally
            {
                jiantieb.IsEnabled = true;
                if(onlycl.IsChecked==false )
                {
                    outputbox.Text = output;
                }
                zhuanhuanbutton.IsEnabled = true;
                if(!string.IsNullOrEmpty(output))
                {
                    DataPackage dataPackage = new DataPackage();

                    dataPackage.SetText(output);
                    Clipboard.SetContent(dataPackage);
                }

            }
           
        }
        public string bintostring(byte[] content)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            switch (jismichoose.SelectedIndex)
            {
                case 0:
                    foreach (var one in content)
                    {
                        sb.Append(Convert.ToString(one, 2).PadLeft(8, '0'));
                    }
                    break;
                case 1:
                    foreach (var one in content)
                    {
                        sb.Append(one.ToString("X2"));
                    }
                    break;
                case 2:
                    return Convert.ToBase64String(content);
                case 3:
                    return MorseConvert.word2morse(inputbox.Text);
                case 4:
                    return MorseConvertChinese.word2morse(inputbox.Text);
            }
            return sb.ToString();
        }
        private void NewMethod2(out byte[] content)
        {
            int i, alli;
            char[] list;
            i = 0;
            alli = 0;
            list = new char[8];
            content = new byte[inputbox.Text.Length / list.Length];
            foreach (var one in inputbox.Text)
            {
                list[i] = one;
                i++;
                if (i >= list.Length)
                {
                    content[alli] = Convert.ToByte(new string(list), 2);
                    alli++;
                    i = 0;
                }
            }
        }
        private void NewMethod16(out byte[] content)
        {
            if ((inputbox.Text.Length % 2) != 0)
                throw new ArgumentException("十六进制字符串长度不对");
            content = new byte[inputbox.Text.Length / 2];
            for (int i = 0; i < content.Length; i++)
            {
                content[i] = Convert.ToByte(inputbox.Text.Substring(i * 2, 2).Trim(), 0x10);
            }
        }
        private void jismichoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (encodingchoose == null)
            {
                return;
            }
            switch (jismichoose.SelectedIndex)
            {
                case 3:
                case 4:
                    encodingchoose.Visibility = Visibility.Collapsed;
                    break;
                default:
                    encodingchoose.Visibility = Visibility.Visible;
                    break;
            }
            onchangeincheckbox();
        }

        private void onchangeincheckbox()
        {
            switch (jismichoose.SelectedIndex)
            {
                case 2:
                    if (checkbox.IsChecked == true)
                    {
                        choosefile.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        choosefile.Visibility = Visibility.Visible;
                    }
                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);
        }

        private void checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            onchangeincheckbox();
        }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            onchangeincheckbox();
        }

        private async void choosefile_Click(object sender, RoutedEventArgs e)
        {
            string output=string.Empty ;
            choosefile.IsEnabled = false;
            try
            {
                Windows.Storage.Pickers.FileOpenPicker fop = new Windows.Storage.Pickers.FileOpenPicker();
                fop.FileTypeFilter.Add("*");
                var file=await fop.PickSingleFileAsync();
                if(file==null )
                {
                    return;
                }
                byte[] buffer;
                using (var one = await file.OpenStreamForReadAsync())
                {
                    buffer = new byte[(int)one.Length];
                    one.Read(buffer, 0, (int)one.Length);
                }
                output = bintostring(buffer);
            }
            finally
            {
                choosefile.IsEnabled = true;
                if(onlycl.IsChecked ==false )
                {
                    outputbox.Text = output;
                }
                if (!string.IsNullOrEmpty(output))
                {
                    DataPackage dataPackage = new DataPackage();

                    dataPackage.SetText(output);
                    Clipboard.SetContent(dataPackage);
                }
            }

        }

        private void encodingchoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(encodingchoose.SelectedIndex==3)
            {
                jismichoose.SelectedIndex = 2;
            }
        }
    }
}
