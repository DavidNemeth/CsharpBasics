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

namespace Inheritance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Circle s1 = new Circle(DrawingCanvas);
            Shape s2 = new Square(DrawingCanvas);
            Square s3 = new Square(DrawingCanvas);
            //Shape s5 = new Shape(DrawingCanvas);
            s1.Draw();s2.Draw();s3.Draw();

            for (int i = 0; i < 100; i++)
            {
                DrawShape(new Square(DrawingCanvas));
                DrawShape(new Circle(DrawingCanvas));
            }
        }

        private void DrawShape(Shape shape)
        {
            shape.Draw();
        }
    }
}
