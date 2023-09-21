using PROG6212_POE_ST10071737.Core;
using PROG6212_POE_ST10071737.MVVM.Model;
using System;
using System.Collections.ObjectModel;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class ProductivityManagerViewModel : ObservableObject
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the boolean that determines if the Error label is visible
        /// </summary>
        private Boolean _errorLabelVisible;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the boolean that determines if the Error label is visible
        /// </summary>
        public Boolean ErrorLabelVisible
        {
            get { return _errorLabelVisible; }
            set
            {
                _errorLabelVisible = value;
                OnPropertyChanged(nameof(ErrorLabelVisible));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the boolean that determines if the Error label is visible
        /// </summary>
        private Boolean _itemControlVisible;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the boolean that determines if the Error label is visible
        /// </summary>
        public Boolean ItemControlVisible
        {
            get { return _itemControlVisible; }
            set
            {
                _itemControlVisible = value;
                OnPropertyChanged(nameof(ItemControlVisible));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the current students list of semesters
        /// </summary>
        private ObservableCollection<SemesterModel> _semesters;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the current students list of semesters
        /// </summary>
        public ObservableCollection<SemesterModel> Semesters
        {
            get { return _semesters; }
            set
            {
                _semesters = value;
                OnPropertyChanged(nameof(Semesters));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected semester
        /// </summary>
        private SemesterModel _currentSemester;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected semester
        /// </summary>
        public SemesterModel CurrentSemester
        {
            get { return _currentSemester; }
            set
            {
                _currentSemester = value;
                OnPropertyChanged(nameof(CurrentSemester));
                this.LoadModules();
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected semesters modules
        /// </summary>
        private ObservableCollection<ModuleModel> _modules;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected semesters modules
        /// </summary>
        public ObservableCollection<ModuleModel> Modules
        {
            get { return _modules; }
            set
            {
                _modules = value;
                OnPropertyChanged(nameof(Modules));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the semesterNumString of the current semester
        /// </summary>
        private String _semesterString;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the semesterNumString of the current semester
        /// </summary>
        public String SemesterString
        {
            get { return _semesterString; }
            set
            {
                _semesterString = value;
                OnPropertyChanged(nameof(SemesterString));
            }
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductivityManagerViewModel()
        {
            this.SetUI();
            this.LoadModules();
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        private void SetUI()
        {
            this.ErrorLabelVisible = true;
            this.ItemControlVisible = false;
            var currentStudent = CurrentStudentModel.Instance;
            this.Semesters = new ObservableCollection<SemesterModel>(currentStudent.GetCurrentStudentSemesters());
            this.CurrentSemester = Semesters[0];
            this.SemesterString = CurrentSemester.ToString();
        }

        private void LoadModules()
        {
            if (this.CurrentSemester.SemesterModulesCount() == 0)
            {
                this.ErrorLabelVisible = true;
                this.ItemControlVisible = false;
            }
            else
            {
                this.ErrorLabelVisible = false;
                this.ItemControlVisible = true;
                this.Modules = new ObservableCollection<ModuleModel>(this.CurrentSemester.ReturnSemesterModules());
            }
        }
        //___________________________________________________________________________________________________________



    }
}
//____________________________________EOF_________________________________________________________________________