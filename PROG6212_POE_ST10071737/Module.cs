//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROG6212_POE_ST10071737
{
    using System;
    using System.Collections.Generic;
    
    public partial class Module
    {
        public int ModuleID { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public Nullable<int> ModuleCredits { get; set; }
        public Nullable<decimal> ModuleClassHoursPerWeek { get; set; }
        public Nullable<System.DateTime> ModuleStartDate { get; set; }
        public Nullable<int> ModuleTotalWeeks { get; set; }
        public Nullable<decimal> ModuleTotalSSHours { get; set; }
        public Nullable<decimal> ModuleSSHoursDoneForWeek { get; set; }
        public Nullable<decimal> ModuleSSHoursForWeeks { get; set; }
        public Nullable<decimal> ModuleTotalSSHoursDone { get; set; }
        public Nullable<int> SemesterID { get; set; }
    
        public virtual Semester Semester { get; set; }
    }
}
