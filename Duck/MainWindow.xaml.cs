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


namespace Duck
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int duckVx = -2;
        int duck1Vx = -1;
        int score = 0;
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new

            System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick; //event!!
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer.Start();
            
            
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            duck.Margin = new Thickness(duck.Margin.Left + duckVx, duck.Margin.Top, 0, 0);
            duck1.Margin = new Thickness(duck1.Margin.Left +duck1Vx, duck1.Margin.Top, 0, 0);
            counterLabel.Content = "Duck Counter 2/" + score;
            if (duck.Margin.Left ==0)
            {
                duck.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = -1;
                duck.RenderTransform = flipTrans;
                duckVx = duckVx * -1;
            }
            if (duck.Margin.Left + duck.Width == this.Width)
            {
                duck.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = 1;
                duck.RenderTransform = flipTrans;
                duckVx = duckVx * -1;
            }
            if (duck1.Margin.Left == 0)
            {
                duck1.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = -1;
                duck1.RenderTransform = flipTrans;
                duck1Vx = duck1Vx * -1;
            }
            if (duck1.Margin.Left + duck1.Width == this.Width)
            {
                duck1.RenderTransformOrigin = new Point(0.5, 0.5);
                ScaleTransform flipTrans = new ScaleTransform();
                flipTrans.ScaleX = 1;
                duck1.RenderTransform = flipTrans;
                duck1Vx = duck1Vx * -1;
            }
        }


        private void mouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(imageBackground);
            target.Margin = new Thickness(point.X - target.Height / 2, point.Y -target.Height/2, point.X + target.Width / 2, point.Y + target.Height / 2);
        }
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            var point = e.GetPosition(this);
            target.Margin = new Thickness(point.X - target.ActualWidth / 2, point.Y - target.ActualHeight / 2, 0, 0);
        }

        private void duck_shoot(object sender, MouseButtonEventArgs e)
        {
            duck.Visibility = Visibility.Hidden;
            score++;
        }

        private void duck1_shoot(object sender, MouseButtonEventArgs e)
        {
            duck1.Visibility = Visibility.Hidden;
            score++;
        }
    }
}
