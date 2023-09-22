using PROG6212_POE_ST10071737.Core;
using PROG6212_POE_ST10071737.MVVM.Model;
using PROG6212_POE_ST10071737.MVVM.View;
using System.Windows;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class LoginViewModel : ObservableObject
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the login username
        /// </summary>
        private string _username;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the login username
        /// </summary>
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the login password
        /// </summary>
        private string _password;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the login password
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the error message
        /// </summary>
        private string _errorLabel;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the error message
        /// </summary>
        public string ErrorLabel
        {
            get { return _errorLabel; }
            set
            {
                _errorLabel = value;
                OnPropertyChanged(nameof(ErrorLabel));
            }
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        public LoginViewModel()
        {
            this.StartMusic();
            EnterBTNCommand = new RelayCommand(ValidateLogin);
            SignUpBTNCommand = new RelayCommand(SignUp);
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //______________________________________________COMMANDS_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// relay command for the enter button
        /// </summary>
        public RelayCommand EnterBTNCommand { get; private set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// relay command for the Sign up button
        /// </summary>
        public RelayCommand SignUpBTNCommand { get; private set; }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        private void StartMusic()
        {
            var AudioPlayer = AudioPlayerSingletonModel.Instance;
            AudioPlayer.Play();
            var Supprise = new MyFunSuppriseClass();
            Supprise.Supprise();
        }

        /// <summary>
        /// Method to validate the Students login credentials
        /// </summary>
        /// <param name="p"></param>
        private void ValidateLogin(object p)
        {
            if (!string.IsNullOrEmpty(this.Username) && !string.IsNullOrEmpty(this.Password))
            {
                var CurrentUser = CurrentStudentModel.Instance;
                if (CurrentUser.ValidateCurrentUser(this.Username, this.Password))
                {
                    this.ChangeWindows(1);
                }
                else
                {
                    this.ErrorLabel = "Your login credentials are invalid please retry or Sign in";
                }
            }
            else
            {
                this.ErrorLabel = "You did not enter any Login Information.\r\nIf you do not have any Login Information please sign in";
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Method to open signUp Window
        /// </summary>
        private void SignUp(object p)
        {
            this.ChangeWindows(2);
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to switch windows
        /// </summary>
        /// <param name="newWindow"></param>
        private void ChangeWindows(int newWindow)
        {
            if (newWindow == 1)
            {
                var Loading = new LoadingWindow();
                Loading.Show();
            }

            if (newWindow == 2)
            {
                var signUp = new Login2View();
                signUp.Show();
            }

            foreach (Window window in Application.Current.Windows)
            {
                if (window is Login)
                {
                    window.Close();
                }
            }
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________