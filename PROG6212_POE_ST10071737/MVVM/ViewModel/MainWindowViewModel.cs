using PROG6212_POE_ST10071737.Core;
using System;
using System.Windows.Threading;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class MainWindowViewModel : ObservableObject
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________

        /// <summary>
        /// creates a relay command to set the current view to the modual manager
        /// </summary>
        public RelayCommand ModualManagerViewCommand { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// creates a relay command to set the current view to the study manager
        /// </summary>
        public RelayCommand StudyManagerViewCommand { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// creates a relay command to set the current view to the productivity manager
        /// </summary>
        public RelayCommand ProductivityManagerViewCommand { get; set; }
        //___________________________________________________________________________________________________________


        /// <summary>
        /// creates a relay command to set the current view to the productivity manager
        /// </summary>
        public RelayCommand SettingsViewCommand { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// creates a new instance of the ModualManagerViewModel
        /// </summary>
        public ModualManagerViewModel ModualManagerVM { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// creates a new instance of the StudyManagerViewModel
        /// </summary>
        public StudyManagerViewModel StudyManagerVM { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// creates a new instance of the ProductivityManagerViewModel
        /// </summary>
        public ProductivityManagerViewModel ProductivityManagerVM { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// creates a new instance of the ProductivityManagerViewModel
        /// </summary>
        public SettingsViewModel SettingsVM { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// variable to store the current view displayed in the main window
        /// </summary>
        private object _currentView;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// variable to store the current view displayed in the main window
        /// </summary>
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// timer variable used to time the radio buttons in the main windows visibility
        /// </summary>
        private DispatcherTimer timer;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// boolean to set the visibility of the study manager radio button
        /// </summary>
        private bool isStudyManagerVisible;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// boolean to set the visibility of the study manager radio button
        /// </summary>
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
        //___________________________________________________________________________________________________________

        /// <summary>
        /// boolean to set the visibility of the modual manager radio button
        /// </summary>
        private bool isModualManagerVisible;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// boolean to set the visibility of the Modual manager radio button
        /// </summary>
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
        //___________________________________________________________________________________________________________

        /// <summary>
        /// boolean to set the visibility of the Productivity manager radio button
        /// </summary>
        private bool isProductivityManagerVisible;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// boolean to set the visibility of the Productivity manager radio button
        /// </summary>
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
        //___________________________________________________________________________________________________________

        /// <summary>
        /// boolean to set the visibility of the Productivity manager radio button
        /// </summary>
        private bool isSettingsVisible;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// boolean to set the visibility of the Productivity manager radio button
        /// </summary>
        public bool IsSettingsVisible
        {
            get { return isSettingsVisible; }
            set
            {
                if (isSettingsVisible != value)
                {
                    isSettingsVisible = value;
                    OnPropertyChanged(nameof(isSettingsVisible));
                }
            }

        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// constructor used to set the display of the main window
        /// </summary>
        public MainWindowViewModel()
        {
            IsStudyManagerVisible = false;
            IsModualManagerVisible = false;
            IsProductivityManagerVisible = false;
            IsSettingsVisible = false;
            ModualManagerVM = new ModualManagerViewModel();
            StudyManagerVM = new StudyManagerViewModel();
            ProductivityManagerVM = new ProductivityManagerViewModel();
            SettingsVM = new SettingsViewModel();
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

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3); // Interval between changes

            // Start the timer after the window is loaded
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// timer for first radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Show the first radio button
            IsStudyManagerVisible = true;

            // Configure the second timer
            timer.Interval = TimeSpan.FromSeconds(1.5);
            timer.Tick -= Timer_Tick;
            timer.Tick += Timer_Tick_Second;
            timer.Start();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// timer for second radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick_Second(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Show the second radio button
            IsModualManagerVisible = true;

            // Configure the third timer
            timer.Interval = TimeSpan.FromSeconds(0.7);
            timer.Tick -= Timer_Tick_Second;
            timer.Tick += Timer_Tick_Third;
            timer.Start();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// timer for third radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick_Third(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Show the third radio button
            IsProductivityManagerVisible = true;

            // Configure the forth timer
            timer.Interval = TimeSpan.FromSeconds(0.7);
            timer.Tick -= Timer_Tick_Second;
            timer.Tick += Timer_Tick_Fourth;
            timer.Start();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// timer for fourth radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick_Fourth(object sender, EventArgs e)
        {
            // Stop the timer
            timer.Stop();

            // Show the third radio button
            IsSettingsVisible = true;
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________