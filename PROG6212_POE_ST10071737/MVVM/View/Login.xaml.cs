using System;
using System.Windows;

namespace PROG6212_POE_ST10071737.MVVM.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores whether one of the two buttons was clicked
        /// </summary>
        private Boolean ButtonWasClicked = false;
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Event for the Enter Button that opens the loadingView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        //___________________________________________________________________________________________________________


        /// <summary>
        /// Event for the Sign up button that opens up the secondary login view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________