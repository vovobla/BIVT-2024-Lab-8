using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        private string _output;
        public string Output => _output;
        public Purple_1(string input) : base(input) { }
        private string Reverse(string word)
        {
            if (string.IsNullOrEmpty(word)) return word;

            int start = 0;
            int end = word.Length - 1;
            string prefix = "";
            string suffix = "";

            while (start <= end && !char.IsLetter(word[start]))
            {
                prefix += word[start];
                start++;
            }

            while (end >= start && !char.IsLetter(word[end]))
            {
                suffix = word[end] + suffix;
                end--;
            }

            string coreWord = word.Substring(start, end - start + 1);
            string reversedWord = "";

            for (int i = coreWord.Length - 1; i >= 0; i--)
            {
                reversedWord += coreWord[i];
            }

            return prefix + reversedWord + suffix;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;

            string[] words = Input.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                bool hasDigit = false;

                foreach (char s in words[i])
                {
                    if (char.IsDigit(s))
                    {
                        hasDigit = true;
                        break;
                    }
                }

                if (hasDigit)
                    continue;

                words[i] = Reverse(words[i]);
            }

            _output = string.Join(" ", words);
        }

        public override string ToString()
        {
            if (_output == null) return null;

            return _output;
        }
    }
}
