using System;
using System.Collections.ObjectModel;

namespace PROG6212_POE_ST10071737.MVVM.Model
{
    public sealed class CurrentStudentModel
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Parameters_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// sets the class instance to null
        /// </summary>
        private static CurrentStudentModel instance = null;
        //___________________________________________________________________________________________________________

        public static CurrentStudentModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentStudentModel();
                }
                return instance;
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// sets the current student to a new studentModel
        /// </summary>
        private StudentModel CurrentStudent { get; set; }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor
        /// </summary>
        private CurrentStudentModel()
        {

        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns the current student
        /// </summary>
        /// <returns></returns>
        public StudentModel GetCurrentStudent()
        {
            return CurrentStudent;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// sets the current students details
        /// </summary>
        /// <param name="student"></param>
        public void SetCurrentStudent(StudentModel student)
        {
            this.CurrentStudent = student;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// adds a semester to the current student
        /// </summary>
        /// <param name="semester"></param>
        public void AddSemesterToStudent(SemesterModel semester)
        {
            this.CurrentStudent.AddSemester(semester);
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Method to return the current students full name
        /// </summary>
        /// <returns></returns>
        public string ReturnCurrentStudentFullName()
        {
            if (this.CurrentStudent.ReturnFullName() != string.Empty)
            {
                return this.CurrentStudent.ReturnFullName();
            }
            else
            {
                return "your Name here";
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// method to validate the current student
        /// </summary>
        /// <param name="login"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Boolean ValidateCurrentUser(string login, string Password)
        {
            if (CurrentStudent.ReturnName().Equals(login) && CurrentStudent.ReturnPassWord().Equals(Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns a Observable collection of the current students semesters
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<SemesterModel> GetCurrentStudentSemesters()
        {
            return CurrentStudent.ReturnStudentSemesters();
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Adds a module to the selected semester of the current student
        /// </summary>
        /// <param name="semesterNum"></param>
        /// <param name="MC"></param>
        /// <param name="MN"></param>
        /// <param name="MCredits"></param>
        /// <param name="MCHPW"></param>
        public void AddModuleToStudentSemester(int semesterNum, string MC, string MN, int MCredits, double MCHPW)
        {
            CurrentStudent.AddModuleToStudentSemester(semesterNum, MC, MN, MCredits, MCHPW);
        }
        //___________________________________________________________________________________________________________

    }
}
//____________________________________EOF_________________________________________________________________________