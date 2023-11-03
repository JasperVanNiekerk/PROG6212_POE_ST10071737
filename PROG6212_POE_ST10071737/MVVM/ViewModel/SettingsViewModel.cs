using PROG6212_POE_ST10071737.Core;
using PROG6212_POE_ST10071737.MVVM.Model;
using PROG6212_POE_ST10071737.MVVM.View;
using System;
using System.Diagnostics;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class SettingsViewModel : ObservableObject
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the Music String
        /// </summary>
        private string _musicString;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the Music String
        /// </summary>
        public string MusicString
        {
            get { return _musicString; }
            set
            {
                _musicString = value;
                OnPropertyChanged(nameof(MusicString));
            }
        }
        //___________________________________________________________________________________________________________


        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor
        /// </summary>
        public SettingsViewModel()
        {
            this.GitHubCommand = new RelayCommand(DisplayGitHub);
            this.CreditsCommand = new RelayCommand(DisplayCredits);
            this.MusicCommand = new RelayCommand(DisplayMusic);
            this.ExitCommand = new RelayCommand(DisplayExit);
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //______________________________________________COMMANDS_____________________________________________________
        //___________________________________________________________________________________________________________

        public RelayCommand GitHubCommand { get; private set; }
        //___________________________________________________________________________________________________________

        public RelayCommand CreditsCommand { get; private set; }
        //___________________________________________________________________________________________________________

        public RelayCommand MusicCommand { get; private set; }
        //___________________________________________________________________________________________________________

        public RelayCommand ExitCommand { get; private set; }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        private void DisplayGitHub(object p)
        {
            string websiteUrl = "https://github.com/JasperVanNiekerk/PROG6212_POE_ST10071737";
            Process.Start(new ProcessStartInfo(websiteUrl));
        }
        //___________________________________________________________________________________________________________

        private void DisplayCredits(object p)
        {
            var Credits = "CREDITS\r\n" +
                "OpenAI ChatGPT 3.5\r\n" +
                "Bing Chat\r\n" +
                "Anneme Holzhausen -- UI specialist/UI consultant";
            var MyMessageBox = new MyMessageBox();
            MyMessageBox.DataContext = new MyMessageBoxViewModel { Message = Credits };
            MyMessageBox.Show();
        }

        private void DisplayMusic(object p) 
        {
            var AudioPlayer = AudioPlayerSingletonModel.Instance;
            AudioPlayer.Play();
        }

        private void DisplayExit(object p)
        {
            Environment.Exit(0);
        }
    }

}
//____________________________________EOF_________________________________________________________________________