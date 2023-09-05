using Microsoft.Xaml.Behaviors;
using PROG6212_POE_ST10071737.MVVM.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG6212_POE_ST10071737.MVVM.View
{
    /// <summary>
    /// Interaction logic for MyDatePicker.xaml
    /// </summary>
    public partial class MyDatePicker : UserControl
    {
        public MyDatePicker()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DayLBL.Content = DateTime.Now.Day.ToString();
        }

        private void DatePickCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string customDateFormat = "yyyy-MM-dd";
            DispalyDateTB.Text = DatePickCalendar.SelectedDate.Value.ToString(customDateFormat);
            calendarPopup.IsOpen = false;
        }

        private void CalendarOpenBTN_Click(object sender, RoutedEventArgs e)
        {
            
            calendarPopup.IsOpen = true;
        }
    }
}
