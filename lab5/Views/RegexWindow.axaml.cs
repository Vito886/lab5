using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using lab5.ViewModels;

namespace lab5.Views
{
    public partial class RegexWindow : Window
    {
        public RegexWindow(string str) : this()
        {
            this.FindControl<TextBox>("regexInput").Text = str;
        }

        public RegexWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            //regexInput.Text = "";
            this.FindControl<Button>("okButton").Click += async delegate
            {
                Close(this.FindControl<TextBox>("regexInput").Text);
            };

            this.FindControl<Button>("cancelButton").Click += async delegate
            {
                Close("Cancel");
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
