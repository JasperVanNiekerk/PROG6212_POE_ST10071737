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
        private String StudentName { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the students surname
        /// </summary>
        private String StudentSurname { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// stores the students password
        /// </summary>
        private String StudentPassword { get; set; }
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
        /// method to add a semester to the students semester list
        /// </summary>
        /// <param name="semester"></param>
        public void AddSemester(SemesterModel semester)
        {
            this.StudentSemesters.Add(semester);
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// gets the semester based on the semesterNum param
        /// </summary>
        /// <param name="semesterNum"></param>
        /// <returns></returns>
        public SemesterModel GetSemester(int semesterNum)
        {
            return this.StudentSemesters[semesterNum];
        }
        //___________________________________________________________________________________________________________

        public void AddModuleToStudentSemester(int semesterNum, string MC, string MN, int MCredits, double MCHPW)
        {
            this.StudentSemesters[semesterNum].AddModule(MC, MN, MCredits, MCHPW);
        }

        public ObservableCollection<SemesterModel> GetStudentSemesters()
        {
            return this.StudentSemesters;
        }

    }
}
//____________________________________EOF_________________________________________________________________________