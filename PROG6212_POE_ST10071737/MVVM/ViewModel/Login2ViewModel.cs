using PROG6212_POE_ST10071737.Core;
using PROG6212_POE_ST10071737.MVVM.Model;
using PROG6212_POE_ST10071737.MVVM.View;
using System.Windows;
using BCrypt.Net;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class Login2ViewModel : ObservableObject
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the student name
        /// </summary>
        private string _StudentName;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the student name
        /// </summary>
        public string StudentName
        {
            get { return _StudentName; }
            set
            {
                _StudentName = value;
                OnPropertyChanged(nameof(StudentName));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the student surname
        /// </summary>
        private string _studentSurname;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the student surname
        /// </summary>
        public string StudentSurname
        {
            get { return _studentSurname; }
            set
            {
                _studentSurname = value;
                OnPropertyChanged(nameof(StudentSurname));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the student password
        /// </summary>
        private string _studentPassword;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the student password
        /// </summary>
        public string StudentPassword
        {
            get { return _studentPassword; }
            set
            {
                _studentPassword = value;
                OnPropertyChanged(nameof(StudentPassword));
            }
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// constructor
        /// </summary>
        public Login2ViewModel()
        {
            this.SetDisplay();
            NextBTNCommand = new RelayCommand(SetCurrentStudent);
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //______________________________________________COMMANDS_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// command for the Next Button
        /// </summary>
        public RelayCommand NextBTNCommand { get; private set; }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// sets the current student to the new student login
        /// </summary>
        /// <param name="p"></param>
        private void SetCurrentStudent(object p)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(StudentPassword);

            var Student = new StudentModel(StudentName, StudentSurname, hashedPassword);
            var currentStudent = CurrentStudentModel.Instance;
            currentStudent.SetLoginStudent(StudentName);
            var studentDB = new StudentDB();
            studentDB.AddStudentToDB(Student);
            this.ChangeWindows();
        }
        //___________________________________________________________________________________________________________

        private void SetDisplay()
        {
            this.StudentName = "Name";
            this.StudentSurname = "Surname";
            this.StudentPassword = "Password";
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to switch windows
        /// </summary>
        /// <param name="newWindow"></param>
        private void ChangeWindows()
        {

            var Semester = new SemesterInfoView();
            Semester.Show();


            foreach (Window window in Application.Current.Windows)
            {
                if (window is Login2View)
                {
                    window.Close();
                }
            }
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________