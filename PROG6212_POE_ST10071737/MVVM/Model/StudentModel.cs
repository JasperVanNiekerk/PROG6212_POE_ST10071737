using System;
using System.Collections.ObjectModel;

namespace PROG6212_POE_ST10071737.MVVM.Model
{
    public class StudentModel
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Stores the students name
        /// </summary>
        public String StudentName { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the students surname
        /// </summary>
        public String StudentSurname { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the students password
        /// </summary>
        public String StudentPassword { get; set; }
        //___________________________________________________________________________________________________________

        private ObservableCollection<SemesterModel> StudentSemesters { get; set; } = new ObservableCollection<SemesterModel>();
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// default constructor
        /// </summary>
        public StudentModel()
        {
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="SN"></param>
        /// <param name="SS"></param>
        public StudentModel(string SN, string SS, string SP)
        {
            this.StudentName = SN;
            this.StudentSurname = SS;
            this.StudentPassword = SP;
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns the Full name of the student
        /// </summary>
        /// <returns></returns>
        public string ReturnFullName()
        {
            return this.StudentName + " " + this.StudentSurname;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns the name of the student
        /// </summary>
        /// <returns></returns>
        public string ReturnName()
        {
            return this.StudentName;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns the Full name of the student
        /// </summary>
        /// <returns></returns>
        public string ReturnPassWord()
        {
            return this.StudentPassword;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns the Semester list of the student
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<SemesterModel> ReturnStudentSemesters()
        {
            return this.StudentSemesters;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to add a semester to the students semester list
        /// </summary>
        /// <param name="semester"></param>
        public void AddSemester(SemesterModel semester)
        {
            this.StudentSemesters.Add(semester);
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Adds a Module to the specified semester
        /// </summary>
        /// <param name="semesterNum"></param>
        /// <param name="MC"></param>
        /// <param name="MN"></param>
        /// <param name="MCredits"></param>
        /// <param name="MCHPW"></param>
        public void AddModuleToStudentSemester(int semesterNum, string MC, string MN, int MCredits, double MCHPW)
        {
            this.StudentSemesters[semesterNum].AddModule(MC, MN, MCredits, MCHPW);
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________