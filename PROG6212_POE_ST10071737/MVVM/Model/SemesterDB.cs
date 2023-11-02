using PROG6212_POE_ST10071737.MVVM.View;
using PROG6212_POE_ST10071737.MVVM.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PROG6212_POE_ST10071737.MVVM.Model
{
    public class SemesterDB
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Default constructor
        /// </summary>
        public SemesterDB()
        {
        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Adds a Semester object linked to a student to the Semester table in the database
        /// </summary>
        /// <param name="semester"></param>
        /// <param name="studentID"></param>
        public void AddSemesterToDB(SemesterModel semester, int studentID)
        {
            Task.Run(() =>
            {
                try
                {
                    using (var Entity = new MyTimeManagementDatabaseEntities())
                    {
                        Semester newSemester = new Semester
                        {
                            SemesterNum = semester.SemesterNumber,
                            SemesterStartDate = semester.SemesterStartDate,
                            SemesterWeeksAmount = semester.SemesterWeeksAmount,
                            StudentID = studentID
                        };
                        Entity.Semesters.Add(newSemester);
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
        /// returns a list of a students semesters
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ObservableCollection<SemesterModel> LoadSemesters(int ID)
        {
            var Semesters = new ObservableCollection<SemesterModel>();

            try
            {
                using (var Entity = new MyTimeManagementDatabaseEntities())
                {
                    var semesters = Entity.Semesters.Where(s => s.StudentID == ID).ToList();

                    foreach (var semester in semesters)
                    {
                        var SemesterM = new SemesterModel();
                        SemesterM.SemesterNumber = (int)semester.SemesterNum;
                        SemesterM.SemesterStartDate = (DateTime)semester.SemesterStartDate;
                        SemesterM.SemesterWeeksAmount = (int)semester.SemesterWeeksAmount;

                        Semesters.Add(SemesterM);
                    }
                }
            }
            catch (Exception ex)
            {
                var MyMessageBox = new MyMessageBox();
                MyMessageBox.DataContext = new MyMessageBoxViewModel { Message = "An error occurred: " + ex.ToString() };
                MyMessageBox.Show();
            }
            return Semesters;
        }
        //___________________________________________________________________________________________________________

    }
}
//____________________________________EOF_________________________________________________________________________