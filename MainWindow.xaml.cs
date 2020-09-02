using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfSeaWar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isMouseCaptured;
        //double mouseVerticalPosition;
        //double mouseHorizontalPosition;
        private void rect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMouseCaptured = false;
            rect.ReleaseMouseCapture();
        }

        private void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isMouseCaptured = true;
            rect.CaptureMouse();
        }

        private void rect_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseCaptured)
            {
                return;
            }
            var mousePos = e.GetPosition(canvas);
            double x = mousePos.X - (rect.ActualWidth / 2);
            double y = mousePos.Y - (rect.ActualHeight / 2);
            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow about = new HelpWindow();
            about.Show();
        }
    }
}
