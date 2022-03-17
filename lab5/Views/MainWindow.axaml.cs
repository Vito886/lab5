using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System.IO;
using lab5.ViewModels;

namespace lab5.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("openFileButton").Click += async delegate
            {
                var taskPatch = new OpenFileDialog()
                {
                    Title = "Open file"
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path = await taskPatch;
                var context = this.DataContext as MainWindowViewModel;
                
                if (path != null)
                {
                    context.Input = File.ReadAllText(string.Join(@"\", path));
                }
                
            };

            this.FindControl<Button>("saveFileButton").Click += async delegate
            {
                var taskPatch = new OpenFileDialog()
                {
                    Title = "Save file"
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path = await taskPatch;
                var context = this.DataContext as MainWindowViewModel;
                
                if (path != null)
                {
                    File.WriteAllText(string.Join(@"\", path), this.FindControl<TextBox>("output").Text);
                }
            };
        }

        private async void RegexButtonClickHandler(object sender, RoutedEventArgs e)
        {
            string currentTemplate = "";
            var context = this.DataContext as MainWindowViewModel;
            currentTemplate = context.RegexTemplate;
            string? template = await new RegexWindow(currentTemplate).ShowDialog<string?>((Window)this.VisualRoot);
            if (template != "Cancel") 
                context.RegexTemplate = template ?? "";
        }

    }
}
