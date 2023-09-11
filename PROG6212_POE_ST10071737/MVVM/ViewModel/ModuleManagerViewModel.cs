using PROG6212_POE_ST10071737.Core;
using PROG6212_POE_ST10071737.MVVM.Model;
using System;
using System.Windows;

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
        /// stores the current Semester as a string
        /// </summary>
        private string _semesterString;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the current Semester as a string
        /// </summary>
        public string SemesterString
        {
            get { return _semesterString; }
            set
            {
                _semesterString = value;
                OnPropertyChanged(nameof(SemesterString));
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
            }
        }
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

        /// <summary>
        /// Relay command for the Plus Button
        /// </summary>
        public RelayCommand PlusBTNCommand { get; private set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Relay command for the Minus Button
        /// </summary>
        public RelayCommand MinusBTNCommand { get; private set; }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        private void LoadUI()
        {
            //set the current semester her dumbass
            //this.SemesterString = "Semester " + this.CurrentSemester.ReturnSemesterNumber(); 
            this.Question = "Would you like to add a Module to " + this.SemesterString + "\r\nYes/No";
            this.Input = "Answer Here";

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
                this.ModuleCredits = int.Parse(this.Input);//this needs data validation
                this.Question = "how many class hours of " + ModuleName + " do you have per week";
                this.QuestionCount++;
                this.Input = string.Empty;
            }
            if (this.QuestionCount == 4 && !this.Input.Equals(string.Empty))
            {
                this.ModuleHours = double.Parse(this.Input);
                this.AddNewModule();
                this.Question = "Would you like to add a Module to " + this.SemesterString + "\r\nYes/No";
                this.QuestionCount = 0;
                this.Input = "Answer Here";
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Method to add a new module to the current semester
        /// </summary>
        private void AddNewModule()
        {
            //CurrentSemester.AddModule(this.ModuleCode, this.ModuleName, this.ModuleCredits, this.ModuleHours);
            var MessageBoxTest = this.ModuleCode + this.ModuleName + this.ModuleCredits + this.ModuleHours;
            MessageBox.Show(MessageBoxTest);
        }
        //___________________________________________________________________________________________________________

    }
}
//____________________________________EOF_________________________________________________________________________