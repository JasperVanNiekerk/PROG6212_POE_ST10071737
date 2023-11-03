using PROG6212_POE_ST10071737.Core;
using PROG6212_POE_ST10071737.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class ModuleManagerViewModel : ObservableObject
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the current question
        /// </summary>
        private String _question;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the current question
        /// </summary>
        public string Question
        {
            get { return _question; }
            set
            {
                _question = value;
                OnPropertyChanged(nameof(Question));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the last User Input
        /// </summary>
        private string _input;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the last User Input
        /// </summary>
        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                OnPropertyChanged(nameof(Input));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the current semester
        /// </summary>
        private SemesterModel _currentSemester;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the current semester
        /// </summary>
        public SemesterModel CurrentSemester
        {
            get { return _currentSemester; }
            set
            {
                _currentSemester = value;
                OnPropertyChanged(nameof(CurrentSemester));
                this.Question = "Would you like to add a Module to " + this.CurrentSemester.ReturnSemesterNumString() + "\r\nYes/No";
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the SemesterPopup IsOpen State
        /// </summary>
        private Boolean _semesterPopUpBool;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the SemesterPopup IsOpen State
        /// </summary>
        public Boolean SemesterPopUpBool
        {
            get { return _semesterPopUpBool; }
            set
            {
                _semesterPopUpBool = value;
                OnPropertyChanged(nameof(SemesterPopUpBool));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Stores the new semester Number
        /// </summary>
        private int _newSemesterNum;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Stores the new semester Number
        /// </summary>
        public int NewSemesterNum
        {
            get { return _newSemesterNum; }
            set
            {
                _newSemesterNum = value;
                OnPropertyChanged(nameof(NewSemesterNum));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Stores the New semester week num
        /// </summary>
        private int _newSemesterWeekNum;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Stores the New semester week num
        /// </summary>
        public int NewSemesterWeekNum
        {
            get { return _newSemesterWeekNum; }
            set
            {
                _newSemesterWeekNum = value;
                OnPropertyChanged(nameof(NewSemesterWeekNum));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the New semester Start date
        /// </summary>
        private DateTime _newSemesterStartDate;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the New semester Start date
        /// </summary>
        public DateTime NewSemesterStartDate
        {
            get { return _newSemesterStartDate; }
            set
            {
                _newSemesterStartDate = value;
                OnPropertyChanged(nameof(NewSemesterStartDate));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the current students Semesters
        /// </summary>
        private ObservableCollection<SemesterModel> _currentStudentSemesters;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the current students Semesters
        /// </summary>
        public ObservableCollection<SemesterModel> CurrentStudentSemesters
        {
            get { return _currentStudentSemesters; }
            set
            {
                _currentStudentSemesters = value;
                OnPropertyChanged(nameof(CurrentStudentSemesters));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the number of the current question
        /// </summary>
        private int QuestionCount = 0;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the user input for Module code
        /// </summary>
        private string ModuleCode = String.Empty;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the user input for Module name
        /// </summary>
        private string ModuleName = String.Empty;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the user input for Module credits
        /// </summary>
        private int ModuleCredits = 0;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the user input for Module hours
        /// </summary>
        private double ModuleHours = 0;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the Current SemesterNumber
        /// </summary>
        private int SemesterCounter = 0;
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor
        /// </summary>
        public ModuleManagerViewModel()
        {
            this.LoadUI();
            this.NextBTNCommand = new RelayCommand(QuestionCycle);
            this.NewBTNCommand = new RelayCommand(ToggleSemesterPopUp);
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //______________________________________________COMMANDS_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Relay command for the Next Button
        /// </summary>
        public RelayCommand NextBTNCommand { get; private set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Relay command for the New Button
        /// </summary>
        public RelayCommand NewBTNCommand { get; private set; }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Sets variables for the Start up of the View
        /// </summary>
        private void LoadUI()
        {
            var CurrentStudent = CurrentStudentModel.Instance;
            this.CurrentStudentSemesters = new ObservableCollection<SemesterModel>(CurrentStudent.GetCurrentStudentSemesters());
            this.CurrentSemester = this.CurrentStudentSemesters[0];
            this.SemesterCounter = CurrentStudent.GetCurrentStudentSemesterCount();
            this.Question = "Would you like to add a Module to " + this.CurrentSemester.ReturnSemesterNumString() + "\r\nYes/No";
            this.Input = "Please answer Here";
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Method that take user input to add a new module to the current semester
        /// </summary>
        /// <param name="p"></param>
        private void QuestionCycle(object p)//this whole method needs an error handling system
        {
            var LowercaseInput = this.Input.ToLower();
            if (this.QuestionCount == 0 && LowercaseInput.Equals("yes"))
            {
                this.Question = "What is your Modules code";
                this.QuestionCount++;
                this.Input = string.Empty;
            }
            if (this.QuestionCount == 1 && !this.Input.Equals(string.Empty))
            {
                this.ModuleCode = this.Input;
                this.Question = "What is your Modules name";
                this.QuestionCount++;
                this.Input = string.Empty;
            }
            if (this.QuestionCount == 2 && !this.Input.Equals(string.Empty))
            {
                this.ModuleName = this.Input;
                this.Question = "how many credits is your Module worth";
                this.QuestionCount++;
                this.Input = string.Empty;
            }
            if (this.QuestionCount == 3 && !this.Input.Equals(string.Empty))
            {
                if (this.Input.All(c => char.IsDigit(c)))
                {
                    this.ModuleCredits = int.Parse(this.Input);//this needs data validation
                    this.Question = "how many class hours of " + ModuleName + " do you have per week";
                    this.QuestionCount++;
                    this.Input = string.Empty;
                }
                else
                {
                    this.Question = "Your input is invalid the Module credits need to be a number";
                    this.Input = string.Empty;
                }
            }
            if (this.QuestionCount == 4 && !this.Input.Equals(string.Empty))
            {
                if (this.Input.All(c => char.IsDigit(c)))
                {
                    this.ModuleHours = double.Parse(this.Input);
                    this.AddNewModule();
                    this.Question = "Would you like to add a Module to " + this.CurrentSemester.ReturnSemesterNumString() + "\r\nYes/No";
                    this.QuestionCount = 0;
                    this.Input = "Answer Here";
                }
                else
                {
                    this.Question = "Your input is invalid the Module class hours need to be a number";
                    this.Input = string.Empty;
                }
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Method to add a new module to the current semester
        /// </summary>
        private void AddNewModule()
        {
            var CurrentStudent = CurrentStudentModel.Instance;
            var newModule = new ModuleModel(this.ModuleCode, this.ModuleName, this.ModuleCredits, this.ModuleHours, CurrentSemester.SemesterStartDate, CurrentSemester.SemesterNumber, CurrentSemester.SemesterWeeksAmount, CurrentSemester.SemesterID);
            CurrentStudent.AddModuleToStudentSemester(newModule);
            //CurrentStudent.LoadCurrentStudentSemesters();
            CurrentStudent.LoadCurrentStudentModules();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to toggle the New Semester pop up open and closed
        /// </summary>
        /// <param name="p"></param>
        public void ToggleSemesterPopUp(object p)
        {
            if (this.SemesterPopUpBool)
            {
                this.SemesterPopUpBool = false;
                this.AddNewSemester();
                this.LoadUI();
            }
            else
            {
                this.SemesterPopUpBool = true;
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Adds a New Semester to the current Student
        /// </summary>
        public void AddNewSemester()
        {
            var CurrentStudent = CurrentStudentModel.Instance;
            var NewSemester = new SemesterModel(this.SemesterCounter + 1, this.NewSemesterStartDate, this.NewSemesterWeekNum);
            CurrentStudent.AddSemesterToStudent(NewSemester);

        }
        //___________________________________________________________________________________________________________


    }
}
//____________________________________EOF_________________________________________________________________________