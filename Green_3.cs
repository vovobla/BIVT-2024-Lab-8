namespace Lab_8 {
    public class Green_3 : Green {
        private string[]? _output;
        private string _subseq;
        public string[]? Output => _output;

        public Green_3(string input, string subseq) : base(input) {
            _output = null;
            _subseq = subseq;
        }

        public override void Review() {
            if (Input == null || Input.Length == 0) {
                _output = new string[0];
                return;
            }

            string separators = @"/\,.?![]{};:()""""'' ";
            string lowerInput = Input.ToLower();
            string lowerSubseq = _subseq.ToLower();
            string[] words = lowerInput.Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] result = new string[0];

            foreach (string word in words) {
                bool is_valid = true;
                foreach (char symbol in word) {
                    if (!char.IsLetter(symbol)) {
                        is_valid = false;
                        break;
                    }
                }
                if (!is_valid) {
                    continue;
                }

                if (word.Contains(lowerSubseq)) {
                    if (!result.Contains(word)) {
                        Array.Resize(ref result, result.Length + 1);
                        result[result.Length - 1] = word;
                    }
                }
            }

            _output = result;
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
                    result += "\n";
                }
            }

            return result;
        }
    }
}