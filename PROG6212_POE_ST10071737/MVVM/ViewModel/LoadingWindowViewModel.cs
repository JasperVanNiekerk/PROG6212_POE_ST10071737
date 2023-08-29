using PROG6212_POE_ST10071737.Core;
using PROG6212_POE_ST10071737.MVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class LoadingWindowViewModel : ObservableObject
    {
        private DispatcherTimer timer;

        private int currentProgress = 0;

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

        private String progressString;

        public String ProgressString
        {
            get { return progressString; }
            set
            {
                progressString = value;
                OnPropertyChanged(nameof(ProgressString));
                
            }
        }

        public event EventHandler ProgressDone;

        public LoadingWindowViewModel()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(30);
            timer.Tick += Timer_Tick;
            timer.Start();
        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            // Simulate loading progress
            if (CurrentProgress < 100)
            {
                Random random = new Random();
                CurrentProgress += 1; //random.Next(1, 6);
                ProgressString = currentProgress.ToString() + "%";
            }
            else
            {
                // Loading completed, stop the timer
                timer.Stop();
            }
        }
    }
}
