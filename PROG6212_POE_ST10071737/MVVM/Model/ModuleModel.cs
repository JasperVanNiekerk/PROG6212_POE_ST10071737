using System;
using System.Globalization;

namespace PROG6212_POE_ST10071737.MVVM.Model
{
    internal class ModuleModel
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the module code
        /// </summary>
        private string ModuleCode { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the module name
        /// </summary>
        private string ModuleName { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the module credits amount
        /// </summary>
        private int ModuleCredits { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the class hours per week for the module
        /// </summary>
        private double ModuleClassHourPerWeek { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the amount of self study hours needed for the module for the current week
        /// </summary>
        private double ModuleSSHoursForWeeks { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the amount of self studied hours done for the module for the current week
        /// </summary>
        private double ModuleSSHoursDoneForWeek { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the total amount of self study hours needed for the module
        /// </summary>
        private double ModuleTotalSSHours { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the total amount of self studied hours done for the module
        /// </summary>
        private double ModuleTotalSSHoursDone { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the Semester ID of the module
        /// </summary>
        private double ModuleSemesterID { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the semester start date
        /// </summary>
        private DateTime ModuleStartDate { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the amount of weeks in the semester
        /// </summary>
        private int ModuleTotalWeeks { get; set; }
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

        public ModuleModel(string MC, string MN, int MCredits, double MCHPW, DateTime MSD)
        {
            this.ModuleCode = MC;
            this.ModuleName = MN;
            this.ModuleCredits = MCredits;
            this.ModuleClassHourPerWeek = MCHPW;
            this.ModuleStartDate = MSD;
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to return the module code
        /// </summary>
        /// <returns></returns>
        public string DisplayModuleCode()
        {
            return this.ModuleCode;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to return the module name
        /// </summary>
        /// <returns></returns>
        public string DisplayModuleName()
        {
            return this.ModuleName;
        }
        //___________________________________________________________________________________________________________

        public void CalculateSSH()
        {
            //Semester will store the amount of weeks
            //so..................
            //I need to reset this.ModuleSSHoursDoneForWeek every week
            //but the ssh per week will stay the same and the total ssh will also stay the same
            //so a method in this should be made to check if its a new week?
            // so this method should take in the total amount of weeks and this.credits and this.ModuleClassHourPerWeek
            //and then pass it to the library for calculation
            //the library should have two methods one for per week ssh and one for the total ssh
            //so for that to work...........................
            //the module class should also have a variable for the start date and weeks that will be set when the modules are created
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Metod to add the Hours param to the Self studied hours for both per week an total
        /// </summary>
        /// <param name="hours"></param>
        public void UpdateSSH(double hours)
        {
            this.ModuleSSHoursDoneForWeek += hours;
            this.ModuleTotalSSHoursDone += hours;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to return the self studied hours for the current week
        /// </summary>
        /// <returns></returns>
        public double DisplayWeekSSH()
        {
            this.CheckNewWeek();
            return this.ModuleSSHoursDoneForWeek;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to return the total amount of self studied hours for the module
        /// </summary>
        /// <returns></returns>
        public double DisplayTotalSSH()
        {
            return this.ModuleTotalSSHoursDone;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to return the total amount of self study hours needed
        /// </summary>
        /// <returns></returns>
        public double displayTotalSSHNeeded()
        {
            return this.ModuleTotalSSHours;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to return the amount of self study hours needed per week
        /// </summary>
        /// <returns></returns>
        public double displayTotalSSHNeededPerWeek()
        {
            return this.ModuleSSHoursForWeeks;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Method to check if it is a new week
        /// </summary>
        private void CheckNewWeek()// chat helped with this method
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
            int startWeek = GetWeekOfYear(startDate);

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
    }
}
//____________________________________EOF_________________________________________________________________________