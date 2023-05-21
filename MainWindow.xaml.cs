using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private Random random;
        private SolidColorBrush brush;

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            brush = new SolidColorBrush();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte red = (byte)random.Next(256);
            byte green = (byte)random.Next(256);
            byte blue = (byte)random.Next(256);
            Color color = Color.FromRgb(red, green, blue);
            brush.Color = color;
            AnimateBackgroundColor();
        }

        private void AnimateBackgroundColor()
        {
            ColorAnimation animation = new ColorAnimation(brush.Color, TimeSpan.FromSeconds(1));
            Storyboard.SetTarget(animation, this);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Background.Color"));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
    }
}
