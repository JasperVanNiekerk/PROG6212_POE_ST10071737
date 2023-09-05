using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PROG6212_POE_ST10071737.MVVM.View
{
    /// <summary>
    /// Interaction logic for RightMenuAnimation.xaml
    /// </summary>
    public partial class RightMenuAnimation : UserControl
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        private DispatcherTimer animationTimer;
        //___________________________________________________________________________________________________________

        private DispatcherTimer animationTimer2;
        //___________________________________________________________________________________________________________

        private Point endPoint1 = new Point(0, 0);
        //___________________________________________________________________________________________________________

        private Point endPoint2 = new Point(0, 0);
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// constructor to set thhe display of the RightMenuAnimation
        /// </summary>
        public RightMenuAnimation()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to load the timer chain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.timerManager1();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method the define and set the first timer
        /// </summary>
        private void timerManager1()
        {
            animationTimer = new DispatcherTimer();
            animationTimer.Interval = TimeSpan.FromMilliseconds(20);
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to define and set the second timmer
        /// </summary>
        private void timerManager2()
        {


            animationTimer2 = new DispatcherTimer();
            animationTimer2.Interval = TimeSpan.FromMilliseconds(20);
            animationTimer2.Tick += AnimationTimer_Tick2;
            animationTimer2.Start();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to draw the fist line of the right Menu animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to draw the second line of te right menu animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationTimer_Tick2(object sender, EventArgs e)
        {
            if (endPoint2.X < 700)
            {
                endPoint2.X += 4.2;
                drawingLine2.X2 = endPoint2.X;
            }
            else
            {
                animationTimer2.Stop();
            }
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________