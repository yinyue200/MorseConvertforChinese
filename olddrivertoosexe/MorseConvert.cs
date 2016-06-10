using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace olddrivertools
{
    public static class MorseConvert
    {
        public static System.Collections.Generic.Dictionary<char, string> morseCode = new Dictionary<char, string>();
        static MorseConvert()
        {
            morseCode['A'] = ".-";
            morseCode['B'] = "-...";
            morseCode['C'] = "-.-.";
            morseCode['D'] = "-..";
            morseCode['E'] = ".";
            morseCode['F'] = "..-.";
            morseCode['G'] = "--.";
            morseCode['H'] = "....";
            morseCode['I'] = "..";
            morseCode['J'] = ".---";
            morseCode['K'] = "-.-";
            morseCode['L'] = ".-..";
            morseCode['M'] = "--";
            morseCode['N'] = "-.";
            morseCode['O'] = "---";
            morseCode['P'] = ".--.";
            morseCode['Q'] = "--.-";
            morseCode['R'] = ".-.";
            morseCode['S'] = "...";
            morseCode['T'] = "-";
            morseCode['U'] = "..-";
            morseCode['V'] = "...-";
            morseCode['W'] = ".--";
            morseCode['X'] = "-..-";
            morseCode['Y'] = "-.--";
            morseCode['Z'] = "--..";
            morseCode['1'] = ".----";
            morseCode['2'] = "..---";
            morseCode['3'] = "...--";
            morseCode['4'] = "....-";
            morseCode['5'] = ".....";
            morseCode['6'] = "-....";
            morseCode['7'] = "--...";
            morseCode['8'] = "---..";
            morseCode['9'] = "----.";
            morseCode['0'] = "-----";
            morseCode['?'] = "..--..";
            morseCode['/'] = "-..-.";
            morseCode['['] = "-.-..";
            morseCode[']'] = ".---.";
            morseCode['-'] = "-....-";
            morseCode['.'] = ".-.-.-";
            morseCode['@'] = "--.-.";
            morseCode['*'] = "----";
            morseCode['$'] = "...-.";
            morseCode['#'] = "..--";

        }

        public static string word2morse(string str)
        {
            StringBuilder morse = new StringBuilder();
            str = str.ToUpper();
            foreach (char s in str)
            {
                if (morseCode.ContainsKey(s))
                {
                    morse.Append(morseCode[s] + " ");
                }
            }
            return morse.ToString();
        }

        public static string morse2word(string morse)
        {
            StringBuilder word = new StringBuilder();
            string[] morseSplit = morse.Split(' ');
            foreach (string str in morseSplit)
            {
                foreach (var item in morseCode)
                {
                    if (item.Value.ToString() == str)
                    {
                        word.Append(item.Key.ToString());
                        break;
                    }
                }
            }
            return word.ToString();
        }
    }

}
