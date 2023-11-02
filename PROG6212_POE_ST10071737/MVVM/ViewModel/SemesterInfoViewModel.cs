using PROG6212_POE_ST10071737.Core;
using PROG6212_POE_ST10071737.MVVM.Model;
using PROG6212_POE_ST10071737.MVVM.View;
using System;
using System.Windows;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class SemesterInfoViewModel : ObservableObject
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the semester number
        /// </summary>
        private int _semesterNum;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the semester number
        /// </summary>
        public int SemesterNum
        {
            get { return _semesterNum; }
            set
            {
                _semesterNum = value;
                OnPropertyChanged(nameof(SemesterNum));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the semester week Number
        /// </summary>
        private int _semesterWeeksNum;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the semester week Number
        /// </summary>
        public int SemesterWeeksNum
        {
            get { return _semesterWeeksNum; }
            set
            {
                _semesterWeeksNum = value;
                OnPropertyChanged(nameof(SemesterWeeksNum));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the semester Start date
        /// </summary>
        private DateTime _semesterStartDate;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the semester Start date
        /// </summary>
        public DateTime SemesterStartDate
        {
            get { return _semesterStartDate; }
            set
            {
                _semesterStartDate = value;
                OnPropertyChanged(nameof(SemesterStartDate));
            }
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor
        /// </summary>
        public SemesterInfoViewModel()
        {
            this.SetDisplay();
            NextBTNCommand = new RelayCommand(AddSemesterToCurrentStudent);
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //______________________________________________COMMANDS_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Relay command for the NextBTN
        /// </summary>
        public RelayCommand NextBTNCommand { get; private set; }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Adds a semester to the current student
        /// </summary>
        /// <param name="p"></param>
        private void AddSemesterToCurrentStudent(object p)
        {
            var newSemester = new SemesterModel(this.SemesterNum, this.SemesterStartDate, this.SemesterWeeksNum);
            var CurrentStudent = CurrentStudentModel.Instance;
            CurrentStudent.AddSemesterToLoginStudent(newSemester);
            this.ChangeWindows();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// sets the views display data
        /// </summary>
        private void SetDisplay()
        {
            this.SemesterNum = 1;
            this.SemesterWeeksNum = 1;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to switch windows
        /// </summary>
        /// <param name="newWindow"></param>
        private void ChangeWindows()
        {

            var login = new Login();
            login.Show();


            foreach (Window window in Application.Current.Windows)
            {
                if (window is SemesterInfoView)
                {
                    window.Close();
                }
            }
        }
        //___________________________________________________________________________________________________________

    }
}
//____________________________________EOF_________________________________________________________________________