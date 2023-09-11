using PROG6212_POE_ST10071737.Core;
using PROG6212_POE_ST10071737.MVVM.Model;
using System.Windows;

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
            var Student = new StudentModel(StudentName, StudentSurname, StudentPassword);
            var currentStudent = CurrentStudentModel.Instance;
            currentStudent.SetCurrentStudent(Student);
            MessageBox.Show("hello " + currentStudent.ReturnCurrentStudentFullName());
        }
        //___________________________________________________________________________________________________________

        private void SetDisplay()
        {
            this.StudentName = "Name";
            this.StudentSurname = "Surname";
            this.StudentPassword = "Password";
        }

    }
}
//____________________________________EOF_________________________________________________________________________