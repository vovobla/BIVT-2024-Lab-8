using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_4 : Purple
    {
        private string _output;
        private (string, char)[] _codes;
        public string Output => _output;
        public Purple_4(string input, (string, char)[] codes) : base(input) 
        {
            _codes = codes;  
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || _codes == null) return;
            
            string result = Input;

            foreach (var code in _codes)
            {
                result = result.Replace(code.Item2.ToString(), code.Item1);
            }

            _output = result;
        }

        public override string ToString()
        {
            return _output;
        }
    }
}
