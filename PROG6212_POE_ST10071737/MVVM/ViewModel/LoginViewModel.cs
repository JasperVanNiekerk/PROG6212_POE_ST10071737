using PROG6212_POE_ST10071737.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class LoginViewModel
    {
        private RelayCommand LoginCommand { get; set; }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        public LoginViewModel() 
        {
            LoginCommand = new RelayCommand(this.LoginUser);
        }

        private void LoginUser(object p)
        {
            var MainWindow = new MainWindow();
            MainWindow.Show();

        }
    }
}
