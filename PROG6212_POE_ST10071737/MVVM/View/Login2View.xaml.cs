﻿using System;
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
    /// Interaction logic for Login2View.xaml
    /// </summary>
    public partial class Login2View : Window
    {
        public Login2View()
        {
            InitializeComponent();
        }

        private void NextBTN_Click(object sender, RoutedEventArgs e)
        {
            var Semester = new SemesterInfoView();
            Semester.Show();
            this.Close();
        }
    }
}
