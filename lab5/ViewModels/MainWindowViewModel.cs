using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ReactiveUI;

namespace lab5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string input = "";
        string output = "";
        string regexTemplate = "";
        public string Input
        {
            get => input;
            set => this.RaiseAndSetIfChanged(ref input, value);
        }

        public string Output
        {
            get => output;
            set => this.RaiseAndSetIfChanged(ref output, value);
        }

        public string RegexTemplate
        {
            get => regexTemplate;
            set
            {
                this.RaiseAndSetIfChanged(ref regexTemplate, value);
                string result = "";
                Regex regex = new Regex(regexTemplate);
                foreach (Match match in regex.Matches(input))
                {
                    result += match.Value + '\n';
                }
                Output = result;
            }
        }
    }
}
