using PROG6212_POE_ST10071737.Core;
using System;
using System.Windows.Threading;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class MainWindowViewModel : ObservableObject
    {
        public RelayCommand ModualManagerViewCommand { get; set; }

        public RelayCommand StudyManagerViewCommand { get; set; }

        public RelayCommand ProductivityManagerViewCommand { get; set; }

        public ModualManagerViewModel ModualManagerVM { get; set; }

        public StudyManagerViewModel StudyManagerVM { get; set; }

        public ProductivityManagerViewModel ProductivityManagerVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private DispatcherTimer timer;

        private bool isStudyManagerVisible;

        public bool IsStudyManagerVisible
        {
            get { return isStudyManagerVisible; }
            set
            {
                if (isStudyManagerVisible != value)
                {
                    isStudyManagerVisible = value;
                    OnPropertyChanged(nameof(isStudyManagerVisible));
                }
            }
                
        }

        private bool isModualManagerVisible;

        public bool IsModualManagerVisible
        {
            get { return isModualManagerVisible; }
            set
            {
                if (isModualManagerVisible != value)
                {
                    isModualManagerVisible = value;
                    OnPropertyChanged(nameof(isModualManagerVisible));
                }
            }

        }
        private bool isProductivityManagerVisible;

        public bool IsProductivityManagerVisible
        {
            get { return isProductivityManagerVisible; }
            set
            {
                if (isProductivityManagerVisible != value)
                {
                    isProductivityManagerVisible = value;
                    OnPropertyChanged(nameof(isProductivityManagerVisible));
                }
            }

        }

        public MainWindowViewModel()
        {
            IsStudyManagerVisible = false;
            IsModualManagerVisible = false;
            IsProductivityManagerVisible = false;
            ModualManagerVM = new ModualManagerViewModel();
            StudyManagerVM = new StudyManagerViewModel();
            ProductivityManagerVM = new ProductivityManagerViewModel();
            CurrentView = StudyManagerVM;

            ModualManagerViewCommand = new RelayCommand(o =>
            {
                CurrentView = ModualManagerVM;
            });

            StudyManagerViewCommand = new RelayCommand(o =>
            {
                CurrentView = StudyManagerVM;
            });

            ProductivityManagerViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProductivityManagerVM;
            });

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3); // Interval between changes

            // Start the timer after the window is loaded
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Show the first radio button after 1.5 seconds
            IsStudyManagerVisible = true;

            // Configure the second timer
            timer.Interval = TimeSpan.FromSeconds(1.5);
            timer.Tick -= Timer_Tick;
            timer.Tick += Timer_Tick_Second;
            timer.Start();
        }

        private void Timer_Tick_Second(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Show the second radio button after 3 seconds
            IsModualManagerVisible = true;

            // Configure the third timer
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick -= Timer_Tick_Second;
            timer.Tick += Timer_Tick_Third;
            timer.Start();
        }

        private void Timer_Tick_Third(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Show the third radio button after 4.5 seconds
            IsProductivityManagerVisible = true;
        }
    }
}
