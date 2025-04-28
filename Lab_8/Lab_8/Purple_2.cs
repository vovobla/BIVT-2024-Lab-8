using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2 : Purple
    {
        private const int required_length = 50; //символов
        private string[] _output;
        public string[] Output => _output;

        public Purple_2(string input) : base(input) { }

        private string AlignLine(string line)
        {
            string[] words = line.Trim().Split(' ');
            int spacesToAdd = required_length - line.Trim().Length;

            while (spacesToAdd > 0 && words.Length > 1)
            {
                for (int i = 0; i < words.Length - 1 && spacesToAdd > 0; i++)
                {
                    words[i] += " ";
                    spacesToAdd--;
                }
            }

            return string.Join(" ", words);
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;

            string[] words = Input.Split(' ');
            var lines = new string[0];
            string currentLine = "";

            for (int i = 0; i < words.Length; i++)
            {
                currentLine += words[i] + " ";

                if (i == words.Length - 1 || currentLine.Length + words[i + 1].Length > required_length)
                {
                    string aligned = AlignLine(currentLine);
                    Array.Resize(ref lines, lines.Length + 1);
                    lines[lines.Length - 1] = aligned;
                    currentLine = "";
                }
            }

            _output = lines;
        }

        public override string ToString()
        {
            if (_output == null) return null;

            return string.Join("\n", _output);
        }
    }
}
