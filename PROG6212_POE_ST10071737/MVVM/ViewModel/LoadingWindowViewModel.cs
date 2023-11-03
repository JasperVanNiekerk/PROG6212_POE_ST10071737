using PROG6212_POE_ST10071737.Core;
using PROG6212_POE_ST10071737.MVVM.Model;
using PROG6212_POE_ST10071737.MVVM.View;
using System;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Threading;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class LoadingWindowViewModel : ObservableObject
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// new dispatch timer for the progress bar
        /// </summary>
        private DispatcherTimer timer;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Percentage of the progress bar
        /// </summary>
        private int currentProgress = 0;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Percentage of the progress bar
        /// </summary>
        public int CurrentProgress
        {
            get { return currentProgress; }
            set
            {
                currentProgress = value;
                RaisePropertyChanged(nameof(CurrentProgress));
                if (currentProgress >= 100)
                {
                    ProgressDone?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// String display of the current progress
        /// </summary>
        private String progressString;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// String display of the current progress
        /// </summary>
        public String ProgressString
        {
            get { return progressString; }
            set
            {
                progressString = value;
                OnPropertyChanged(nameof(ProgressString));

            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// event to be called once the progress bar is done
        /// </summary>
        public event EventHandler ProgressDone;
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor
        /// </summary>
        public LoadingWindowViewModel()
        {
            this.AudioManager();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(95);
            timer.Tick += Timer_Tick;
            timer.Start();
            this.DataLoaders();
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// pauses the background music and runs the Jarvis voice track
        /// </summary>
        private void AudioManager()
        {
            var AudioPlayer = AudioPlayerSingletonModel.Instance;
            AudioPlayer.Pause();
            this.Jarvis();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Manages the Jarvis voice track
        /// </summary>
        private void Jarvis()
        {
            var audioFilePath = "Jarvis.wav";

            if (File.Exists(audioFilePath))
            {
                SoundPlayer player = new SoundPlayer(audioFilePath);
                player.Play();
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Loads the current students data
        /// </summary>
        private void DataLoaders()
        {
            var CurrentUser = CurrentStudentModel.Instance;
            var Student = new StudentDB();
            var ID = Student.GetStudentIDByName(CurrentUser.GetLoginStudent());
            CurrentUser.SetCurrentStudent(Student.loadStudent(ID));

            CurrentUser.LoadCurrentStudentSemesters();

            CurrentUser.LoadCurrentStudentModules();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Event for the dispatch timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Simulate loading progress
            if (CurrentProgress < 100)
            {
                Random random = new Random();
                CurrentProgress += random.Next(1, 6);
                ProgressString = currentProgress.ToString() + "%";
            }
            else
            {
                // Loading completed, stop the timer
                timer.Stop();
                this.ChangeWindows();
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to switch windows
        /// </summary>
        /// <param name="newWindow"></param>
        private void ChangeWindows()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window is LoadingWindow)
                {
                    window.Close();
                }
            }
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________