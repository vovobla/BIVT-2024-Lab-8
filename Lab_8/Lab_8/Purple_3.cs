using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_3 : Purple
    {
        private string _output;
        private (string, char)[] _codes;
        public string Output => _output;
        public (string, char)[] Codes => _codes;
        public Purple_3(string input) : base(input) { }

        private void FindPairs()
        {
            var pairCounts = new (string pair, int count, int index)[_output.Length];
            int uniqueCount = 0;

            for (int i = 0; i < _output.Length - 1; i++)
            {
                string pair = _output.Substring(i, 2);

                if (char.IsLetter(pair[0]) && char.IsLetter(pair[1]))
                {
                    bool found = false;

                    for (int j = 0; j < uniqueCount; j++)
                    {
                        if (pairCounts[j].pair == pair)
                        {
                            pairCounts[j].count++;
                            found = true;
                            break;
                        }
                    }

                    if (!found && uniqueCount < pairCounts.Length)
                    {
                        pairCounts[uniqueCount] = (pair, 1, i);
                        uniqueCount++;
                    }
                }
            }

            for (int i = 0; i < uniqueCount - 1; i++)
            {
                for (int j = 0; j < uniqueCount - i - 1; j++)
                {
                    if (pairCounts[j].count == pairCounts[j + 1].count && pairCounts[j].index > pairCounts[j + 1].index)
                    {
                        var temp = pairCounts[j];
                        pairCounts[j] = pairCounts[j + 1];
                        pairCounts[j + 1] = temp;
                    }
                }
            }

            _codes = new (string, char)[Math.Min(5, uniqueCount)];

            for (int i = 0; i < _codes.Length; i++)
            {
                int maxCount = 0;
                int maxIndex = -1;

                for (int j = 0; j < uniqueCount; j++)
                {
                    if (pairCounts[j].count > maxCount)
                    {
                        maxCount = pairCounts[j].count;
                        maxIndex = j;
                    }
                }

                if (maxIndex != -1)
                {
                    _codes[i] = (pairCounts[maxIndex].pair, '_');
                    pairCounts[maxIndex].count = -1;
                }
            }
        }

        private void AssignCodes()
        {
            bool[] usedSym = new bool[126 - 33 + 1];

            foreach (char symb in _output)
            {
                int ascii = (int)symb;

                if (ascii >= 33 && ascii <= 126)
                {
                    usedSym[ascii - 33] = true;
                }
            }

            int next = 33;

            for (int i = 0; i < _codes.Length; i++)
            {
                var (pair, _) = _codes[i];

                for (int j = next; j <= 126; j++)
                {
                    if (!usedSym[j - 33])
                    {
                        _codes[i] = (pair, (char)j);
                        usedSym[j] = true;
                        next = j + 1;
                        break;
                    }
                }
            }
        }

        private void Replace()
        {
            string result = _output;

            for (int i = 0; i < _codes.Length; i++)
            {
                var (pair, code) = _codes[i];
                int index = 0;

                while ((index = result.IndexOf(pair, index)) != -1)
                {
                    result = result.Remove(index, 2);
                    result = result.Insert(index, code.ToString());
                    index += 1;
                }
            }

            _output = result;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;

            _output = Input;
            FindPairs();
            AssignCodes();
            Replace();
        }

        public override string ToString()
        {
            return _output;
        }
    }
}
