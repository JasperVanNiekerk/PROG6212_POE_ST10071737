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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG6212_POE_ST10071737.MVVM.View
{
    /// <summary>
    /// Interaction logic for CoreSmall.xaml
    /// </summary>
    public partial class CoreSmall : UserControl
    {
        public CoreSmall()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

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
    }
}
