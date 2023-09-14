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
        /// stores the semesters number
        /// </summary>
        private int SemesterNumber { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the Semester start date
        /// </summary>
        private DateTime SemesterStartDate { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the amount of weeks in the semester
        /// </summary>
        private int SemesterWeeksAmount { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the amount of weeks in the semester
        /// </summary>
        private String SemesterNumString { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores a list of modules in the semester
        /// </summary>
        private ObservableCollection<ModuleModel> SemesterModules { get; set; } = new ObservableCollection<ModuleModel>();
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
        /// Method to add Module to semester
        /// </summary>
        /// <param name="module"></param>
        public void AddModule(string MC, string MN, int MCredits, double MCHPW)
        {
            var module = new ModuleModel(MC, MN, MCredits, MCHPW, this.SemesterStartDate);
            this.SemesterModules.Add(module);
        }
        //___________________________________________________________________________________________________________

        public override string ToString()
        {
            return this.SemesterNumString;
        }
    }
}
//____________________________________EOF_________________________________________________________________________