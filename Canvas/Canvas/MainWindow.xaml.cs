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

namespace Canvas
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Point initial;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var element = sender as UIElement;
            var position = e.GetPosition(element);
            var transform = element.RenderTransform as MatrixTransform;
            var matrix = transform.Matrix;
            var scale = e.Delta >= 0 ? 1.1 : (1.0 / 1.1); // choose appropriate scaling factor
            matrix.ScaleAtPrepend(scale, scale, position.X, position.Y);
            transform.Matrix = matrix;
        }

        
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
            {
                var element = sender as UIElement;
                var transform = element.RenderTransform as MatrixTransform;
                var matrix = transform.Matrix;
                var position = e.GetPosition(element);
                var xOffset = e.GetPosition(this).X - initial.X;
                var yOffset = e.GetPosition(this).Y - initial.Y;
                matrix.Translate(xOffset, yOffset);
                transform.Matrix = matrix;

            }
            initial = Mouse.GetPosition(this);


        }

    }
}
