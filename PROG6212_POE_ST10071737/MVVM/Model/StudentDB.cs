using PROG6212_POE_ST10071737.MVVM.View;
using PROG6212_POE_ST10071737.MVVM.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PROG6212_POE_ST10071737.MVVM.Model
{
    public class StudentDB
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Default constructor
        /// </summary>
        public StudentDB()
        {

        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Add a student object to the student table in the database
        /// </summary>
        /// <param name="student"></param>
        public void AddStudentToDB(StudentModel student)
        {
            Task.Run(() =>
            {
                try
                {
                    using (var Entity = new MyTimeManagementDatabaseEntities())
                    {
                        Student newStudent = new Student
                        {
                            StudentName = student.StudentName,
                            StudentSurname = student.StudentSurname,
                            StudentPassword = student.StudentPassword
                        };

                        Entity.Students.Add(newStudent);
                        Entity.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    var MyMessageBox = new MyMessageBox();
                    MyMessageBox.DataContext = new MyMessageBoxViewModel { Message = "An error occurred: " + ex.ToString() };
                    MyMessageBox.Show();
                }
            });
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Returns the StudentID associated with the given Student name from the database
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public int GetStudentIDByName(string studentName)
        {
            int studentID = -1; // Default value if no matching student is found

            try
            {
                using (var Entity = new MyTimeManagementDatabaseEntities())
                {
                    var student = Entity.Students.FirstOrDefault(s => s.StudentName == studentName);

                    if (student != null)
                    {
                        studentID = student.StudentID;
                    }
                }
            }
            catch (Exception ex)
            {
                var MyMessageBox = new MyMessageBox();
                MyMessageBox.DataContext = new MyMessageBoxViewModel { Message = "An error occurred: " + ex.ToString() };
                MyMessageBox.Show();
            }

            return studentID;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns the student password associated with the given Student name from the database
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public string GetStudentLogin(string studentName)
        {
            string password = "";
            try
            {
                using (var Entity = new MyTimeManagementDatabaseEntities())
                {
                    var student = Entity.Students.FirstOrDefault(s => s.StudentName == studentName);

                    if (student != null)
                    {
                        password = student.StudentPassword;
                    }
                    else
                    {
                        password = "Invalid Username";
                    }
                }
            }
            catch (Exception ex)
            {
                var MyMessageBox = new MyMessageBox();
                MyMessageBox.DataContext = new MyMessageBoxViewModel { Message = "An error occurred: " + ex.ToString() };
                MyMessageBox.Show();
            }

            return password;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// returns a student object based on the id given
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentModel loadStudent(int id)
        {
            var currentStudent = new StudentModel();

            try
            {
                using (var Entity = new MyTimeManagementDatabaseEntities())
                {
                    var student = Entity.Students.FirstOrDefault(s => s.StudentID == id);

                    if (student != null)
                    {
                        currentStudent.StudentID = student.StudentID;
                        currentStudent.StudentName = student.StudentName;
                        currentStudent.StudentSurname = student.StudentSurname;
                        currentStudent.StudentPassword = "";
                    }
                }
            }
            catch (Exception ex)
            {
                var MyMessageBox = new MyMessageBox();
                MyMessageBox.DataContext = new MyMessageBoxViewModel { Message = "An error occurred: " + ex.ToString() };
                MyMessageBox.Show();
            }

            return currentStudent;
        }
        //___________________________________________________________________________________________________________

    }
}
//____________________________________EOF_________________________________________________________________________