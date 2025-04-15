namespace Lab_8 {
    public abstract class Green {
        private string _input;

        public string Input => _input;

        public Green(string input) {
            _input = input;
        }

        public abstract void Review();
    }
}