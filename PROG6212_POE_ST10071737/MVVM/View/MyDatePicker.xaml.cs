using System;
using System.Windows;
using System.Windows.Controls;

namespace PROG6212_POE_ST10071737.MVVM.View
{
    /// <summary>
    /// Interaction logic for MyDatePicker.xaml
    /// </summary>
    public partial class MyDatePicker : UserControl
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Dependency Property for binding to the DisplayDateTB
        /// </summary>
        public static DependencyProperty SelectedDate = DependencyProperty.Register("DateContent",
                                                                                    typeof(DateTime),
                                                                                    typeof(MyDatePicker));
        //___________________________________________________________________________________________________________

        public DateTime DateContent
        {
            get { return (DateTime)GetValue(SelectedDate); }
            set { SetValue(SelectedDate, value); }

        }

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Default constructor
        /// </summary>
        public MyDatePicker()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to set the lable of the date picker to the current datetime day value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.DayLBL.Content = DateTime.Now.Day.ToString();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Event for when the selected date of the calendar is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePickCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string customDateFormat = "yyyy-MM-dd";
            DisplayDateTB.Text = DatePickCalendar.SelectedDate.Value.ToString(customDateFormat);
            DateContent = DatePickCalendar.SelectedDate.Value;
            calendarPopup.IsOpen = false;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Event for the Calendar open button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalendarOpenBTN_Click(object sender, RoutedEventArgs e)
        {

            calendarPopup.IsOpen = true;
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________