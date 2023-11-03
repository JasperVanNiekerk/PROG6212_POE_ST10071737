using PROG6212_POE_ST10071737.MVVM.View;
using PROG6212_POE_ST10071737.MVVM.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PROG6212_POE_ST10071737.MVVM.Model
{
    public class ModuleDB
    {
        //___________________________________________________________________________________________________________
        //__________________________________________Constructors_____________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// default constructor
        /// </summary>
        public ModuleDB()
        {

        }
        //___________________________________________________________________________________________________________

        //___________________________________________________________________________________________________________
        //_____________________________________________Methods_______________________________________________________
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Adds or updates a Module object to the Module table in the database
        /// </summary>
        /// <param name="module"></param>
        public void AddModuleToDatabase(ModuleModel module)
        {
            Task.Run(() =>
            {
                try
                {
                    using (var Entity = new MyTimeManagementDatabaseEntities())
                    {
                        Module newModule = new Module
                        {
                            ModuleCode = module.ModuleCode,
                            ModuleName = module.ModuleName,
                            ModuleCredits = module.ModuleCredits,
                            ModuleClassHoursPerWeek = (decimal?)module.ModuleClassHourPerWeek,
                            ModuleStartDate = module.ModuleStartDate,
                            ModuleTotalWeeks = module.ModuleTotalWeeks,
                            ModuleTotalSSHours = (decimal?)module.ModuleTotalSSHours,
                            ModuleSSHoursDoneForWeek = (decimal?)module.ModuleSSHoursDoneForWeek,
                            ModuleSSHoursForWeeks = (decimal?)module.ModuleSSHoursForWeeks,
                            ModuleTotalSSHoursDone = (decimal?)module.ModuleTotalSSHoursDone,
                            SemesterID = module.ModuleSemesterID
                        };
                        Entity.Modules.Add(newModule);
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
        /// loads the modules of specified semester
        /// </summary>
        /// <param name="SemesterID"></param>
        /// <returns></returns>
        public ObservableCollection<ModuleModel> LoadSemesterModulesFromDB(int SemesterID)
        {
            var SemesterModules = new ObservableCollection<ModuleModel>();
            try
            {
                using (var Entity = new MyTimeManagementDatabaseEntities())
                {
                    var modules = Entity.Modules.Where(m => m.SemesterID == SemesterID).ToList();

                    foreach (var module in modules)
                    {
                        var tempModule = new ModuleModel();
                        tempModule.ModuleID = module.ModuleID;
                        tempModule.ModuleCode = module.ModuleCode;
                        tempModule.ModuleName = module.ModuleName;
                        tempModule.ModuleCredits = (int)module.ModuleCredits;
                        tempModule.ModuleClassHourPerWeek = (double)module.ModuleClassHoursPerWeek;
                        tempModule.ModuleStartDate = (DateTime)module.ModuleStartDate;
                        tempModule.ModuleTotalWeeks = (int)module.ModuleTotalWeeks;
                        tempModule.ModuleTotalSSHours = (double)module.ModuleTotalSSHours;
                        tempModule.ModuleSSHoursDoneForWeek = (double)module.ModuleSSHoursDoneForWeek;
                        tempModule.ModuleSSHoursForWeeks = (double)module.ModuleSSHoursForWeeks;
                        tempModule.ModuleTotalSSHoursDone = (double)module.ModuleTotalSSHoursDone;
                        tempModule.ModuleSemesterNum = SemesterID;

                        SemesterModules.Add(tempModule);
                    }
                }
            }
            catch (Exception ex)
            {
                var MyMessageBox = new MyMessageBox();
                MyMessageBox.DataContext = new MyMessageBoxViewModel { Message = "An error occurred: " + ex.ToString() };
                MyMessageBox.Show();
            }

            return SemesterModules;
        }
        //___________________________________________________________________________________________________________

        public async Task UpdateModuleInDB(ModuleModel module)
        {
            try
            {
                using (var Entity = new MyTimeManagementDatabaseEntities())
                {

                    Module existingModule = Entity.Modules.Find(module.ModuleID);
                    if (existingModule != null)
                    {
                        // Update the existing module with the new values
                        existingModule.ModuleCode = module.ModuleCode;
                        existingModule.ModuleName = module.ModuleName;
                        existingModule.ModuleCredits = module.ModuleCredits;
                        existingModule.ModuleClassHoursPerWeek = (decimal?)module.ModuleClassHourPerWeek;
                        existingModule.ModuleStartDate = module.ModuleStartDate;
                        existingModule.ModuleTotalWeeks = module.ModuleTotalWeeks;
                        existingModule.ModuleTotalSSHours = (decimal?)module.ModuleTotalSSHours;
                        existingModule.ModuleSSHoursDoneForWeek = (decimal?)module.ModuleSSHoursDoneForWeek;
                        existingModule.ModuleSSHoursForWeeks = (decimal?)module.ModuleSSHoursForWeeks;
                        existingModule.ModuleTotalSSHoursDone = (decimal?)module.ModuleTotalSSHoursDone;

                        await Entity.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                var MyMessageBox = new MyMessageBox();
                MyMessageBox.DataContext = new MyMessageBoxViewModel { Message = "An error occurred: " + ex.ToString() };
                MyMessageBox.Show();
            }
        }
        //___________________________________________________________________________________________________________

    }
}
//____________________________________EOF_________________________________________________________________________