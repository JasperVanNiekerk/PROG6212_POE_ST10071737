using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PROG6212_POE_ST10071737.MVVM.View
{
    /// <summary>
    /// Interaction logic for CoreSmall.xaml
    /// </summary>
    public partial class CoreSmall : UserControl
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// constructor used to set the display for the small core
        /// </summary>
        public CoreSmall()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to start all the arcs animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard animation1 = (Storyboard)FindResource("Arc1animation");
            animation1.Begin(Arc1Border);

            Storyboard animation2 = (Storyboard)FindResource("Arc2animation");
            animation2.Begin(Arc2Border);

            Storyboard animation3 = (Storyboard)FindResource("Arc3animation");
            animation3.Begin(Arc3Border);

            Storyboard animation4 = (Storyboard)FindResource("Arc4animation");
            animation4.Begin(Arc4Border);
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________