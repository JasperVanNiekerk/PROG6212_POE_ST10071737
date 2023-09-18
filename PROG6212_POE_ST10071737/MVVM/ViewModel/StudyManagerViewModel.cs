using PROG6212_POE_ST10071737.Core;
using PROG6212_POE_ST10071737.MVVM.Model;
using System;
using System.Collections.ObjectModel;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class StudyManagerViewModel : ObservableObject
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
        /// stores a list of the current students semesters
        /// </summary>
        private ObservableCollection<SemesterModel> _Semesters;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores a list of the current students semesters
        /// </summary>
        public ObservableCollection<SemesterModel> Semesters
        {
            get { return _Semesters; }
            set
            {
                _Semesters = value;
                OnPropertyChanged(nameof(Semesters));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the currently selected semester
        /// </summary>
        private SemesterModel _currentSemester;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the currently selected semester
        /// </summary>
        public SemesterModel CurrentSemester
        {
            get { return _currentSemester; }
            set
            {
                _currentSemester = value;
                OnPropertyChanged(nameof(CurrentSemester));
                this.CheckForModules();
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores a list of the currently selected semesters modules
        /// </summary>
        private ObservableCollection<ModuleModel> _modules;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores a list of the currently selected semesters modules
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

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// constructor
        /// </summary>
        public StudyManagerViewModel()
        {
            this.ErrorLabelVisible = true;
            this.SetSemesters();
            this.CheckForModules();
            this.SetCurrentModules();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// boolean to show whether the current semester has modules
        /// </summary>
        private Boolean ThereAreModules = false;

        //___________________________________________________________________________________________________________
        //______________________________________________COMMANDS_____________________________________________________
        //___________________________________________________________________________________________________________



        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        private void SetCurrentModules()
        {
            if (ThereAreModules)
            {
                this.Modules = new ObservableCollection<ModuleModel>(this.CurrentSemester.ReturnSemesterModules());
            }

        }
        //___________________________________________________________________________________________________________

        private void SetSemesters()
        {
            var CurrentStudent = CurrentStudentModel.Instance;
            this.Semesters = new ObservableCollection<SemesterModel>(CurrentStudent.GetCurrentStudentSemesters());
            this.CurrentSemester = this.Semesters[0];
        }
        //___________________________________________________________________________________________________________

        private void CheckForModules()
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
                this.ThereAreModules = true;
                this.SetCurrentModules();
            }
        }




    }
}
//____________________________________EOF_________________________________________________________________________