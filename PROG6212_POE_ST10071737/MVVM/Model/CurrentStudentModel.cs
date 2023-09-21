using System;
using System.Collections.ObjectModel;
using System.Linq;

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
        /// adds a semester to the current student
        /// </summary>
        /// <param name="semester"></param>
        public int GetCurrentStudentSemesterCount()
        {
            return CurrentStudent.ReturnStudentSemesters().Count;
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
            if (CurrentStudent != null)
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

        /// <summary>
        /// deletes a module from the current student
        /// </summary>
        /// <param name="module"></param>
        public void DeleteModule(ModuleModel module)
        {
            var searchedSemester = module.ModuleSemesterNum;
            var moduleSemester = CurrentStudent.ReturnStudentSemesters().FirstOrDefault(semester => semester.ReturnSemesterNumber() == searchedSemester);
            if (moduleSemester != null)
            {
                moduleSemester.ReturnSemesterModules().Remove(module);
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// updates module parameter of the current student
        /// </summary>
        /// <param name="module"></param>
        public void UpdateModule(ModuleModel module)
        {
            var searchedSemester = module.ModuleSemesterNum;
            var moduleSemester = CurrentStudent.ReturnStudentSemesters().FirstOrDefault(semester => semester.ReturnSemesterNumber() == searchedSemester);
            if (moduleSemester != null)
            {
                var index = moduleSemester.ReturnSemesterModules().IndexOf(module);
                if (index >= 0)
                {
                    moduleSemester.UpdateModuleInSemester(index, module);
                }
            }
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// adds the addHours param to the module param's self study hours 
        /// </summary>
        /// <param name="addedHours"></param>
        /// <param name="module"></param>
        public void UpdateModuleStudyHours(double addedHours, ModuleModel module)
        {
            var searchedSemester = module.ModuleSemesterNum;
            var moduleSemester = CurrentStudent.ReturnStudentSemesters().FirstOrDefault(semester => semester.ReturnSemesterNumber() == searchedSemester);
            if (moduleSemester != null)
            {
                var index = moduleSemester.ReturnSemesterModules().IndexOf(module);
                if (index >= 0)
                {
                    moduleSemester.UpdateModuleSSH(index, addedHours);
                }
            }
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________