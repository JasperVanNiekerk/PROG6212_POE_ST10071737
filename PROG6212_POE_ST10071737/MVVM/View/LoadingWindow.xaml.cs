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

            ViewModel.ProgressDone += ViewModel_ProgressDone;
        }

        private void ViewModel_ProgressDone(object sender, EventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
