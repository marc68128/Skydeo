using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Skydeo.Wpf.UserControls
{
    public partial class ImagePicker : UserControl
    {
        public ImagePicker()
        {
            InitializeComponent();

            Loaded += (sender, args) =>
            {
                if (string.IsNullOrWhiteSpace(ImagePath))
                {
                    Ellipse.Fill = new ImageBrush(new BitmapImage(new Uri("Images/defaultProfilPicture.png", UriKind.Relative)));
                }
            };
        }


        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register("ImagePath", typeof(string), typeof(ImagePicker));

        public string ImagePath
        {
            get => (string)GetValue(ImagePathProperty);
            set => SetValue(ImagePathProperty, value);
        }
    }
}
