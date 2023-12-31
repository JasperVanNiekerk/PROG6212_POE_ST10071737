﻿namespace MyStudyHourCalculatorLibrary
{
    public class SSHCalculator
    {
        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        public double CalculateTotalSSH(int MC, int MWA, double MCH)
        {
            var SSH = (MC * 10) - (MCH*MWA);
            return SSH;
        }
        //___________________________________________________________________________________________________________

        public double CalculatePerWeekSSH(int MC, int MWA, double MCH)
        {
            var SSH = ((MC * 10)/MWA)-MCH;
            return SSH;
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________