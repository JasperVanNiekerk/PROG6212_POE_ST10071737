using LiveCharts;
using LiveCharts.Wpf;
using PROG6212_POE_ST10071737.Core;
using PROG6212_POE_ST10071737.MVVM.Model;
using PROG6212_POE_ST10071737.MVVM.View;
using System;
using System.Linq;
using System.Windows;

namespace PROG6212_POE_ST10071737.MVVM.ViewModel
{
    internal class ModuleWindowViewModel : ObservableObject
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected module
        /// </summary>
        private ModuleModel _selectedModule;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected module
        /// </summary>
        public ModuleModel SelectedModule
        {
            get { return _selectedModule; }
            set
            {
                _selectedModule = value;
                OnPropertyChanged(nameof(SelectedModule));
                this.SetModuleInfo();
                this.PieChartSetter();
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the bool that determines if the textboxes are read only
        /// </summary>
        private Boolean _isEditable;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the bool that determines if the textboxes are read only
        /// </summary>
        public Boolean IsEditable
        {
            get { return _isEditable; }
            set
            {
                _isEditable = value;
                OnPropertyChanged(nameof(IsEditable));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the string displayed in the Edit button
        /// </summary>
        private string _editBTNString;
        //___________________________________________________________________________________________________________

        public string EditBTNString
        {
            get { return _editBTNString; }
            set
            {
                _editBTNString = value;
                OnPropertyChanged(nameof(EditBTNString));
            }
        }
        //__________________________________________________________________________________________________________

        /// <summary>
        /// store the user input for adding hours
        /// </summary>
        private string _hoursStudied;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// store the user input for adding hours
        /// </summary>
        public string HoursStudied
        {
            get { return _hoursStudied; }
            set
            {
                _hoursStudied = value;
                OnPropertyChanged(nameof(HoursStudied));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected Module's code
        /// </summary>
        private string _selectedModuleCode;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected Module's code
        /// </summary>
        public string SelectedModuleCode
        {
            get { return _selectedModuleCode; }
            set
            {
                _selectedModuleCode = value;
                OnPropertyChanged(nameof(SelectedModuleCode));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected Module's name
        /// </summary>
        private string _selectedModuleName;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected Module's name
        /// </summary>
        public string SelectedModuleName
        {
            get { return _selectedModuleName; }
            set
            {
                _selectedModuleName = value;
                OnPropertyChanged(nameof(SelectedModuleName));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected Module's Credits
        /// </summary>
        private string _selectedModuleCredits;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected Module's Credits
        /// </summary>
        public string SelectedModuleCredits
        {
            get { return _selectedModuleCredits; }
            set
            {
                _selectedModuleCredits = value;
                OnPropertyChanged(nameof(SelectedModuleCredits));
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the selected Module's Class hours
        /// </summary>
        private string _selectedModuleClassHours;
        //___________________________________________________________________________________________________________

        public string SelectedModuleClassHours
        {
            get { return _selectedModuleClassHours; }
            set
            {
                _selectedModuleClassHours = value;
                OnPropertyChanged(nameof(SelectedModuleClassHours));
            }
        }
        //___________________________________________________________________________________________________________

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

        /// <summary>
        /// stores the pie charts data collection
        /// </summary>
        private SeriesCollection _seriesCollection;
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the pie charts data collection
        /// </summary>
        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollection; }
            set
            {
                _seriesCollection = value;
                OnPropertyChanged(nameof(SeriesCollection));
            }
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        public ModuleWindowViewModel()
        {
            this.IsEditable = false;
            this.EditBTNString = "Edit";
            this.EditCommand = new RelayCommand(EditToggle);
            this.DeleteCommand = new RelayCommand(DeleteModule);
            this.DoneCommand = new RelayCommand(DoneWithWindow);
            this.AddHoursCommand = new RelayCommand(UpdateModuleSSH);
            this.ShowModuleInfoCommand = new RelayCommand(ShowModuleInfo);


        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //______________________________________________COMMANDS_____________________________________________________
        //___________________________________________________________________________________________________________

        public RelayCommand EditCommand { get; private set; }
        //___________________________________________________________________________________________________________

        public RelayCommand DeleteCommand { get; private set; }
        //___________________________________________________________________________________________________________

        public RelayCommand DoneCommand { get; private set; }
        //___________________________________________________________________________________________________________

        public RelayCommand AddHoursCommand { get; private set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// command to show module information
        /// </summary>
        public RelayCommand ShowModuleInfoCommand { get; private set; }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// sets the display info
        /// </summary>
        private void SetModuleInfo()
        {
            this.SelectedModuleCode = SelectedModule.ModuleCode;
            this.SelectedModuleName = SelectedModule.ModuleName;
            this.SelectedModuleCredits = SelectedModule.ModuleCredits.ToString();
            this.SelectedModuleClassHours = SelectedModule.ModuleClassHourPerWeek.ToString();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// sets the pie chart datasets
        /// </summary>
        private void PieChartSetter()
        {
            double SSHDone = this.SelectedModule.ModuleSSHoursDoneForWeek;
            double SSHNeeded = this.SelectedModule.ModuleSSHoursForWeeks - this.SelectedModule.ModuleSSHoursDoneForWeek;
            double OverlapVariable = this.SelectedModule.ModuleSSHoursDoneForWeek - this.SelectedModule.ModuleSSHoursForWeeks;

            if (SSHDone > SSHNeeded)
            {
                this.SelectedModule.ModuleSSHoursDoneForWeek = OverlapVariable;
            }

            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Self study hours done",
                    Values = new ChartValues<double> { SSHDone },
                    Fill = System.Windows.Media.Brushes.LightBlue,
                },
                new PieSeries
                {
                    Title = "self study hours needed",
                    Values = new ChartValues<double> { SSHNeeded },
                    Fill = System.Windows.Media.Brushes.Transparent,
                },
            };
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// changes the text display of the edit button and sets the IsEditable boolean appropriately
        /// </summary>
        /// <param name="p"></param>
        private void EditToggle(object p)
        {
            if (this.IsEditable)
            {
                this.EditBTNString = "Editing";
                this.IsEditable = false;
                this.ModuleWasEdited();
            }
            else
            {
                this.EditBTNString = "Edit";
                this.IsEditable = true;
                this.ModuleWasEdited();
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// deletes the selected module and closes the window
        /// </summary>
        /// <param name="p"></param>
        private void DeleteModule(object p)
        {
            var currentStudent = CurrentStudentModel.Instance;
            currentStudent.DeleteModule(SelectedModule);
            this.ChangeWindows();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// checks if the selected module was edited, update the selected module and then closes the window
        /// </summary>
        /// <param name="p"></param>
        private void DoneWithWindow(object p)
        {
            this.ModuleWasEdited();
            this.ChangeWindows();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// updates the SelectedModule
        /// </summary>
        private void ModuleWasEdited()
        {
            if (this.SelectedModuleCredits.All(c => char.IsDigit(c)) && this.SelectedModuleCredits.All(c => char.IsDigit(c)))
            {
                SelectedModule.ModuleCode = this.SelectedModuleCode;
                SelectedModule.ModuleName = this.SelectedModuleName;
                SelectedModule.ModuleCredits = Int32.Parse(this.SelectedModuleCredits);
                SelectedModule.ModuleClassHourPerWeek = double.Parse(this.SelectedModuleClassHours);

                var CurrentStudent = CurrentStudentModel.Instance;
                CurrentStudent.UpdateModule(SelectedModule);
            }
            else
            {
                this.ErrorLabel = "Your Module credits and module class hours are invalid";
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// updates the selectedModule's self study hours
        /// </summary>
        /// <param name="p"></param>
        private void UpdateModuleSSH(object p)
        {
            var currentStudent = CurrentStudentModel.Instance;
            if (Double.TryParse(HoursStudied, out double hours))
            {
                SelectedModule.ModuleSSHoursDoneForWeek += hours;
                SelectedModule.ModuleTotalSSHoursDone += hours;
                //currentStudent.UpdateModuleStudyHours(SelectedModule);
            }
            else
            {
                this.ErrorLabel = "Invalid Input";
            }
            this.PieChartSetter();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to switch windows
        /// </summary>
        /// <param name="newWindow"></param>
        private void ChangeWindows()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is ModuleWindow)
                {
                    window.Close();
                }
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to set the Selected Module
        /// </summary>
        /// <param name="p"></param>
        private void ShowModuleInfo(object p)
        {
            if (p is ModuleModel selectedModule)
            {
                var SelectedModuleInfo = new ModuleWindow();
                SelectedModuleInfo.DataContext = new ModuleWindowViewModel { SelectedModule = selectedModule };
                SelectedModuleInfo.Show();
            }
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________