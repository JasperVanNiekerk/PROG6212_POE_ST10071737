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
        /// the current student to a new studentModel
        /// </summary>
        private StudentModel CurrentStudent { get; set; }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// the name of the student in the login loop
        /// </summary>
        private string LoginStudent { get; set; }
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
        /// returns the logged in student name
        /// </summary>
        /// <returns></returns>
        public string GetLoginStudent()
        {
            return LoginStudent;
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
        /// sets the login students name
        /// </summary>
        /// <param name="student"></param>
        public void SetLoginStudent(String studentName)
        {
            this.LoginStudent = studentName;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// adds a semester to the current student
        /// </summary>
        /// <param name="semester"></param>
        public void AddSemesterToStudent(SemesterModel semester)
        {
            var semesters = new SemesterDB();
            semesters.AddSemesterToDB(semester, this.CurrentStudent.StudentID);
            this.CurrentStudent.AddSemester(semester);
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// adds a semester to the login student
        /// </summary>
        /// <param name="semester"></param>
        public void AddSemesterToLoginStudent(SemesterModel semester)
        {
            var students = new StudentDB();
            var studentID = students.GetStudentIDByName(this.LoginStudent);
            var semesters = new SemesterDB();
            semesters.AddSemesterToDB(semester, studentID);
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// sets the current students semesters from the database
        /// </summary>
        /// <param name="ID"></param>
        public void LoadCurrentStudentSemesters()
        {
            this.CurrentStudent.loadStudentSemesters(this.CurrentStudent.StudentID);
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// loads the modules for the current student
        /// </summary>
        public void LoadCurrentStudentModules()
        {
            this.CurrentStudent.loadModules();
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
        /// method to validate the student login
        /// </summary>
        /// <param name="login"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Boolean ValidateCurrentUser(string login, string Password)
        {
            // I don't check if the parameters are null because i validate that before i pass it to this method
            var Student = new StudentDB();
            var validPassword = Student.GetStudentLogin(login);
            if (!validPassword.Equals("Invalid Username"))
            {
                if (BCrypt.Net.BCrypt.Verify(Password, validPassword))
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
        /// adds a module to the current student
        /// </summary>
        /// <param name="module"></param>
        public void AddModuleToStudentSemester(ModuleModel module)
        {
            var Module = new ModuleDB();
            Module.AddModuleToDatabase(module);
            
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
        public void UpdateModuleStudyHours(ModuleModel module)
        {
            var Module = new ModuleDB();
            Module.UpdateModuleInDB(module);
        }
        //___________________________________________________________________________________________________________
    }
}
//____________________________________EOF_________________________________________________________________________