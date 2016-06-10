using olddrivertools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace olddrivertoosexe
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("http://www.yinyue200.com");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkbox.IsChecked == true)
                {
                    byte[] content = null;
                    switch (jismichoose.SelectedIndex)
                    {
                        case 0:
                            NewMethod2(out content);
                            break;
                        case 1:
                            NewMethod16(out content);
                            break;
                        case 2:
                            content = Convert.FromBase64String(inputbox.Text);
                            return;
                        case 3:
                            outputbox.Text = MorseConvert.morse2word(inputbox.Text);
                            return;
                        case 4:
                            outputbox.Text = MorseConvertChinese.morse2word(inputbox.Text);
                            return;
                    }
                    switch (encodingchoose.SelectedIndex)
                    {
                        case 0:
                            outputbox.Text = System.Text.Encoding.UTF8.GetString(content);
                            break;
                        case 1:
                            outputbox.Text = System.Text.Encoding.Unicode.GetString(content);
                            break;
                        case 2:
                            outputbox.Text = System.Text.Encoding.BigEndianUnicode.GetString(content);
                            break;
                    }
                }
                else
                {
                    byte[] content = null;
                    switch (encodingchoose.SelectedIndex)
                    {
                        case 0:
                            content = System.Text.Encoding.UTF8.GetBytes(inputbox.Text);
                            break;
                        case 1:
                            content = System.Text.Encoding.Unicode.GetBytes(inputbox.Text);
                            break;
                        case 2:
                            content = System.Text.Encoding.BigEndianUnicode.GetBytes(inputbox.Text);
                            break;
                    }
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
                            outputbox.Text = Convert.ToBase64String(content);
                            return;
                        case 3:
                            outputbox.Text = MorseConvert.word2morse(inputbox.Text);
                            return;
                        case 4:
                            outputbox.Text = MorseConvertChinese.word2morse(inputbox.Text);
                            return;
                    }
                    outputbox.Text = sb.ToString();
                }
            }
            catch
            {
                outputbox.Text = "转换出错";
            }

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
        }
    }
}
