using System.Windows;
using System.Windows.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Skydeo.Wpf.UserControls
{
    public partial class FolderPicker : UserControl
    {
        public FolderPicker()
        {
            InitializeComponent();
            this.Loaded += (sender, args) =>
            {
                TextBox.Text = Folder;
                PlaceholderTextBlock.Text = Placeholder;
            };
        }

        public static readonly DependencyProperty FolderProperty = DependencyProperty.Register("Folder", typeof(string), typeof(FolderPicker));
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register("Placeholder", typeof(string), typeof(FolderPicker));

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
        public string Folder
        {
            get => (string)GetValue(FolderProperty);
            set
            {
                PlaceholderTextBlock.Visibility = string.IsNullOrWhiteSpace(value) ? Visibility.Visible : Visibility.Collapsed;
                SetValue(FolderProperty, value);
            }
        }


        private void OpenFolderPicker(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                EnsurePathExists = true,
                EnsureFileExists = false,
                IsFolderPicker = true,
                AllowNonFileSystemItems = false,
                DefaultFileName = "Select Folder",
                Title = "Select The Folder To Process"
            };

            if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
                return;

            Folder = dialog.FileName;
            TextBox.Text = Folder;
        }
    }
}
