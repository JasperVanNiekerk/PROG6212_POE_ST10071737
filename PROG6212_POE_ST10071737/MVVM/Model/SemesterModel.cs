using System;
using System.Collections.ObjectModel;

namespace PROG6212_POE_ST10071737.MVVM.Model
{
    public class SemesterModel
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the semesters ID
        /// </summary>
        public int SemesterID { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the semesters number
        /// </summary>
        public int SemesterNumber { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the Semester start date
        /// </summary>
        public DateTime SemesterStartDate { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the amount of weeks in the semester
        /// </summary>
        public int SemesterWeeksAmount { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the amount of weeks in the semester
        /// </summary>
        public String SemesterNumString { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores a list of modules in the semester
        /// </summary>
        private ObservableCollection<ModuleModel> SemesterModules { get; set; }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Default constructor
        /// </summary>
        public SemesterModel()
        {
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="SN"></param>
        /// <param name="SSD"></param>
        /// <param name="SWA"></param>
        public SemesterModel(int SN, DateTime SSD, int SWA)
        {
            this.SemesterNumber = SN;
            this.SemesterStartDate = SSD;
            this.SemesterWeeksAmount = SWA;
            this.SemesterNumString = "Semester " + SN;
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns the Semester number
        /// </summary>
        /// <returns></returns>
        public int ReturnSemesterNumber()
        {
            return this.SemesterNumber;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns the SemesterNum String
        /// </summary>
        /// <returns></returns>
        public string ReturnSemesterNumString()
        {
            return this.SemesterNumString;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// loads the modules of the semester from the database
        /// </summary>
        public async void LoadSemesterModules()
        {
            var Module = new ModuleDB();
            this.SemesterModules = new ObservableCollection<ModuleModel>( await Module.LoadSemesterModulesFromDB(SemesterID));
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// defines the toString of the Semester object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.SemesterNumString;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns a ObservableColection of the modules in the Semester
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<ModuleModel> ReturnSemesterModules()
        {
            return this.SemesterModules;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns a count of the modules in the semester
        /// </summary>
        /// <returns></returns>
        public int SemesterModulesCount()
        {
            return this.SemesterModules.Count;
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________