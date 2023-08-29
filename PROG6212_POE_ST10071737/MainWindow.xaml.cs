using System;
using System.Windows;
using System.Windows.Threading;

namespace PROG6212_POE_ST10071737
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer DateTimeTimer;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DateTimeTimer = new DispatcherTimer();
            DateTimeTimer.Interval = TimeSpan.FromSeconds(1);
            DateTimeTimer.Tick += DateTimeTimer_Tick;
            DateTimeTimer.Start();
        }

        private void DateTimeTimer_Tick(object sender, EventArgs e)
        {
            this.dateTimeTB.Text = DateTime.Now.ToString();
        }
    }
}
