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
using System.Windows.Shapes;

namespace PROG6212_POE_ST10071737.MVVM.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Boolean ButtonWasClicked = false;

        public Login()
        {
            InitializeComponent();
        }

        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            if (!ButtonWasClicked)
            {
                var Loading = new LoadingWindow();
                this.Close();
                Loading.Show();
                ButtonWasClicked = true;
            }

        }

        private void SignUpBTN_Click(object sender, RoutedEventArgs e)
        {
            if (!ButtonWasClicked)
            {
                var Login2view = new Login2View();
                this.Close();
                Login2view.Show();
                ButtonWasClicked = true;
            }
        }
    }
}
