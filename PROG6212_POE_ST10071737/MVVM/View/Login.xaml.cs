using PROG6212_POE_ST10071737.MVVM.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PROG6212_POE_ST10071737.MVVM.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Event to get the Password from the PasswordBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as LoginViewModel;
            if(viewModel != null)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }

            // Im gonna be honest i know this is not the correct way of doing this 
            // hopefully by the time i hand in part two i can do it better
            //but for now im sorry but i just want this to work
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________