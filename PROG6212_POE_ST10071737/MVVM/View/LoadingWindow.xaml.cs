using PROG6212_POE_ST10071737.MVVM.ViewModel;
using System;
using System.Windows;

namespace PROG6212_POE_ST10071737.MVVM.View
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Method runs while Loading view is shown
        /// </summary>
        public LoadingWindow()
        {
            InitializeComponent();
            var ViewModel = new LoadingWindowViewModel();
            DataContext = ViewModel;

            ViewModel.ProgressDone += ViewModel_ProgressDone;
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Event that is called when the progress bar is done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewModel_ProgressDone(object sender, EventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________