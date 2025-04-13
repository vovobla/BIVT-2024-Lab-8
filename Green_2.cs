namespace Lab_8 {
    public class Green_2 : Green {
        private char[]? _output;
        public char[]? Output => _output;

        public Green_2(string input) : base(input) {
            _output = null;
        }

        public override void Review() {
            if (Input == null || Input.Length == 0) {
                _output = new char[0];
                return;
            }

            string separators = @"/\,.?![]{};:()"""" ";
            string lowerInput = Input.ToLower();
            char[] unique_letters = new char[0];
            int[] counts = new int[0];

            for (int i = 0; i < lowerInput.Length; ++i) {
                char symbol = lowerInput[i];

                if (char.IsLetter(symbol) && (i == 0 || separators.Contains(lowerInput[i - 1]))) {
                    if (!unique_letters.Contains(symbol)) {
                        Array.Resize(ref unique_letters, unique_letters.Length + 1);
                        Array.Resize(ref counts, counts.Length + 1);
                        unique_letters[unique_letters.Length - 1] = symbol;
                        counts[counts.Length - 1] = 1;
                    }
                    else {
                        int idx = Array.IndexOf(unique_letters, symbol);
                        counts[idx] += 1;
                    }
                }
            }

            for (int i = 0 ; i < unique_letters.Length; ++i) {
                for (int j = i + 1; j < unique_letters.Length; ++j) {
                    if ((counts[i] < counts[j]) || (counts[i] == counts[j] && unique_letters[i] > unique_letters[j])) {
                        char tempLetter = unique_letters[i];
                        int tempCount = counts[i];

                        unique_letters[i] = unique_letters[j];
                        counts[i] = counts[j];

                        unique_letters[j] = tempLetter;
                        counts[j] = tempCount;
                    }
                }
            }

            _output = unique_letters;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) {
                return "";
            }

            string result = "";
            
            for (int i = 0; i < _output.Length; ++i) {
                result += $"{_output[i]}";
                if (i + 1 < _output.Length) {
                    result += ", ";
                }
            }

            return result;
        }
    }
}