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
    
    public partial class Semester
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semester()
        {
            this.Modules = new HashSet<Module>();
        }
    
        public int SemesterID { get; set; }
        public Nullable<int> SemesterNum { get; set; }
        public Nullable<System.DateTime> SemesterStartDate { get; set; }
        public Nullable<int> SemesterWeeksAmount { get; set; }
        public Nullable<int> StudentID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Module> Modules { get; set; }
        public virtual Student Student { get; set; }
    }
}
