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
        public LoadingWindow()
        {
            InitializeComponent();
            var ViewModel = new LoadingWindowViewModel();
            DataContext = ViewModel;

            ViewModel.ProgressDone += ViewMdel_ProgressDone;
        }

        private void ViewMdel_ProgressDone(object sender, EventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Close();
        }
    }
}
