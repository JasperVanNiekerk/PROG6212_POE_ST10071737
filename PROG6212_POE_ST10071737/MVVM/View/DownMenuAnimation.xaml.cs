using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PROG6212_POE_ST10071737.MVVM.View
{
    /// <summary>
    /// Interaction logic for DownMenuAnimation.xaml
    /// </summary>
    public partial class DownMenuAnimation : UserControl
    {

        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        private DispatcherTimer animationTimer;
        //___________________________________________________________________________________________________________

        private DispatcherTimer animationTimer2;
        //___________________________________________________________________________________________________________

        private DispatcherTimer animationTimer3;
        //___________________________________________________________________________________________________________

        private DispatcherTimer animationTimer4;
        //___________________________________________________________________________________________________________

        private Point endPoint1 = new Point(0, 0);
        //___________________________________________________________________________________________________________

        private Point endPoint2 = new Point(0, 0);
        //___________________________________________________________________________________________________________

        private Point endPoint3 = new Point(0, 0);
        //___________________________________________________________________________________________________________

        private Point endPoint4 = new Point(0, 0);
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// constructor to set the display for the down menu animation
        /// </summary>
        public DownMenuAnimation()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to load the timer chain for the Down menu animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.timerManager1();

        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to define and start the first timer
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
        /// method to define and start the second timer
        /// </summary>
        private void timerManager2()
        {
            drawingLine2.Y1 = endPoint1.Y - 1.5;
            drawingLine2.X1 = endPoint1.X;
            endPoint2 = endPoint1;

            animationTimer2 = new DispatcherTimer();
            animationTimer2.Interval = TimeSpan.FromMilliseconds(20);
            animationTimer2.Tick += AnimationTimer_Tick2;
            animationTimer2.Start();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to define and start the third timer
        /// </summary>
        private void timerManager3()
        {
            drawingLine3.Y1 = endPoint1.Y - 1.5;
            drawingLine3.X1 = endPoint1.X;
            endPoint3 = endPoint1;

            animationTimer3 = new DispatcherTimer();
            animationTimer3.Interval = TimeSpan.FromMilliseconds(20);
            animationTimer3.Tick += AnimationTimer_Tick3;
            animationTimer3.Start();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to define and start the fourth timer
        /// </summary>
        private void timerManager4()
        {
            drawingLine4.Y1 = endPoint1.Y - 1.5;
            drawingLine4.X1 = endPoint1.X;
            endPoint4 = endPoint1;

            animationTimer4 = new DispatcherTimer();
            animationTimer4.Interval = TimeSpan.FromMilliseconds(20);
            animationTimer4.Tick += AnimationTimer_Tick4;
            animationTimer4.Start();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to draw the first line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (endPoint1.Y < 228)
            {
                endPoint1.Y += 2;
                drawingLine.Y2 = endPoint1.Y;

                if (endPoint1.Y == 76)
                {
                    this.timerManager2();
                }

                if (endPoint1.Y == 152)
                {
                    this.timerManager3();
                }

                if (endPoint1.Y == 228)
                {
                    this.timerManager4();
                }
            }
            else
            {
                animationTimer.Stop();
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to draw the second line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationTimer_Tick2(object sender, EventArgs e)
        {
            if (endPoint2.X < 40 && endPoint2.Y < 120)
            {
                endPoint2.X += 0.7;
                endPoint2.Y += 1;
                drawingLine2.X2 = endPoint2.X;
                drawingLine2.Y2 = endPoint2.Y;
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to draw the third line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationTimer_Tick3(object sender, EventArgs e)
        {
            if (endPoint3.X < 40 && endPoint3.Y < 196)
            {
                endPoint3.X += 0.7;
                endPoint3.Y += 1;
                drawingLine3.X2 = endPoint3.X;
                drawingLine3.Y2 = endPoint3.Y;
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to draw the fourth line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimationTimer_Tick4(object sender, EventArgs e)
        {
            if (endPoint4.X < 40 && endPoint4.Y < 272)
            {
                endPoint4.X += 0.7;
                endPoint4.Y += 1;
                drawingLine4.X2 = endPoint4.X;
                drawingLine4.Y2 = endPoint4.Y;
            }
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________