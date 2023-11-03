using MyStudyHourCalculatorLibrary;
using PROG6212_POE_ST10071737.Core;
using System;
using System.Globalization;

namespace PROG6212_POE_ST10071737.MVVM.Model
{
    public class ModuleModel : ObservableObject
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the moduleID
        /// </summary>
        public int ModuleID { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the module code
        /// </summary>
        public string ModuleCode { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the module name
        /// </summary>
        public string ModuleName { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the module credits amount
        /// </summary>
        public int ModuleCredits { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the class hours per week for the module
        /// </summary>
        public double ModuleClassHourPerWeek { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the amount of self study hours needed for the module for the current week
        /// </summary>
        public double ModuleSSHoursForWeeks { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the amount of self studied hours done for the module for the current week
        /// </summary>
        public double ModuleSSHoursDoneForWeek { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the total amount of self study hours needed for the module
        /// </summary>
        public double ModuleTotalSSHours { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the total amount of self studied hours done for the module
        /// </summary>
        public double ModuleTotalSSHoursDone { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the Semester number of the module
        /// </summary>
        public int ModuleSemesterNum { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the semester start date
        /// </summary>
        public DateTime ModuleStartDate { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the amount of weeks in the semester
        /// </summary>
        public int ModuleTotalWeeks { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the SemesterID of the module
        /// </summary>
        public int ModuleSemesterID { get; private set; }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Default constructor
        /// </summary>
        public ModuleModel()
        {
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="MC"></param>
        /// <param name="MN"></param>
        /// <param name="MCredits"></param>
        /// <param name="MCHPW"></param>
        /// <param name="MSD"></param>
        /// <param name="MSN"></param>
        /// <param name="MTW"></param>
        public ModuleModel(string MC, string MN, int MCredits, double MCHPW, DateTime MSD, int MSN, int MTW, int MSID)
        {
            this.ModuleCode = MC;
            this.ModuleName = MN;
            this.ModuleCredits = MCredits;
            this.ModuleClassHourPerWeek = MCHPW;
            this.ModuleStartDate = MSD;
            this.ModuleSemesterNum = MSN;
            this.ModuleTotalWeeks = MTW;
            this.ModuleSemesterID = MSID;
            this.CalculateSSH();
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        public void CalculateSSH()
        {
            SSHCalculator SSHCalculatorHere = new SSHCalculator();
            this.ModuleSSHoursForWeeks = SSHCalculatorHere.CalculatePerWeekSSH(this.ModuleCredits, this.ModuleTotalWeeks, this.ModuleClassHourPerWeek);
            this.ModuleTotalSSHours = SSHCalculatorHere.CalculateTotalSSH(this.ModuleCredits, this.ModuleTotalWeeks, this.ModuleClassHourPerWeek);
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Method to check if it is a new week
        /// </summary>
        public void CheckNewWeek()// chat helped with this method
        {
            // Set the start date and the number of weeks to reset the value
            var year = this.ModuleStartDate.Year;
            var month = this.ModuleStartDate.Month;
            var day = this.ModuleStartDate.Day;

            DateTime startDate = new DateTime(year, month, day);
            int numberOfWeeks = this.ModuleTotalWeeks;

            // Calculate the current week
            DateTime currentDate = DateTime.Now;
            int currentWeek = GetWeekOfYear(currentDate);

            // Calculate the week number for the start date
            int startWeek = GetWeekOfYear(this.ModuleStartDate);

            // Calculate the week difference
            int weekDifference = currentWeek - startWeek;

            if (weekDifference >= 0 && weekDifference < numberOfWeeks)
            {
                // It's time to reset the value
                // Place your reset logic here
                this.ModuleSSHoursDoneForWeek = 0;
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns the date of the first day of the week in which the date parameter falls
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        static int GetWeekOfYear(DateTime date)//chat helped with this method
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// defines the toString of the Semester object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ModuleCode;
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________