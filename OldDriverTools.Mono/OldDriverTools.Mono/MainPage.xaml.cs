using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using olddrivertools;

namespace OldDriverTools.Mono
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            jismichoose.SelectedIndex = 2;
            encodingchoose.SelectedIndex = 0;
        }

        private void Button_Click_1(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.yinyue200.com", UriKind.Absolute));
        }

        private async void Button_Click(object sender, EventArgs e)
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
                    input = await Plugin.Clipboard.CrossClipboard.Current.GetTextAsync();
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
                                break;
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
                                output = System.Text.Encoding.UTF8.GetString(content, 0, content.Length);
                                break;
                            case 1:
                                output = System.Text.Encoding.Unicode.GetString(content,0,content.Length);
                                break;
                            case 2:
                                output = System.Text.Encoding.BigEndianUnicode.GetString(content, 0, content.Length);
                                break;
                        }
                    }
                    finally
                    {

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
                if (onlycl.IsChecked == false)
                {
                    outputbox.Text = output;
                }
                zhuanhuanbutton.IsEnabled = true;
                if (!string.IsNullOrEmpty(output))
                {
                    Plugin.Clipboard.CrossClipboard.Current.SetText(output);
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
        private void jismichoose_SelectionChanged(object sender, EventArgs e)
        {
            if (encodingchoose == null)
            {
                return;
            }
            switch (jismichoose.SelectedIndex)
            {
                case 3:
                case 4:
                    encodingchoose.IsVisible = false;
                    break;
                default:
                    encodingchoose.IsVisible = true;
                    break;
            }
            onchangeincheckbox();
        }

        private void onchangeincheckbox()
        {

        }

        private void encodingchoose_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void checkbox_Checked(object sender, EventArgs e)
        {

        }
    }
}
