﻿using System.Windows;

namespace PROG6212_POE_ST10071737.MVVM.View
{
    /// <summary>
    /// Interaction logic for SemesterInfoView.xaml
    /// </summary>
    public partial class SemesterInfoView : Window
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Default constructor
        /// </summary>
        public SemesterInfoView()
        {
            InitializeComponent();
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Event for the Next button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextBTN_Click(object sender, RoutedEventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Close();
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________