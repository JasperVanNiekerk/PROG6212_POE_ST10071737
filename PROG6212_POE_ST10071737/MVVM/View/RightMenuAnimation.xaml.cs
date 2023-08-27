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

namespace PROG6212_POE_ST10071737.MVVM.View
{
    /// <summary>
    /// Interaction logic for RightMenuAnimation.xaml
    /// </summary>
    public partial class RightMenuAnimation : UserControl
    {
        private DispatcherTimer animationTimer;
        private DispatcherTimer animationTimer2;
        private Point endPoint1 = new Point(0, 0);
        private Point endPoint2 = new Point(0, 0);
        public RightMenuAnimation()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.timerManager1();
        }

        private void timerManager1()
        {
            animationTimer = new DispatcherTimer();
            animationTimer.Interval = TimeSpan.FromMilliseconds(20);
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }
        private void timerManager2()
        {


            animationTimer2 = new DispatcherTimer();
            animationTimer2.Interval = TimeSpan.FromMilliseconds(20);
            animationTimer2.Tick += AnimationTimer_Tick2;
            animationTimer2.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (endPoint1.X < 60 && endPoint1.Y < 60)
            {
                endPoint1.X += 2;
                endPoint1.Y += 2;
                drawingLine.X2 = endPoint1.X;
                drawingLine.Y2 = endPoint1.Y;
            }
            else
            {
                this.timerManager2();
                animationTimer.Stop();
            }
        }

        private void AnimationTimer_Tick2(object sender, EventArgs e)
        {
            if(endPoint2.X < 700)
            {
                endPoint2.X += 5.5;
                drawingLine2.X2 = endPoint2.X;
            }
            else
            {
                animationTimer2.Stop();
            }
        }
    }
}
