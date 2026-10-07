using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;


namespace WCORE.Models
{
    [MenuDescription(Name = "Department Globe")]
    [DatabaseTable(Name = "View_DepartmentGlobe")]

    public class DepartmentGlobe : BaseObject
    {

        [DataLookUp]
        [Display(Name = "Names")]
        [DatabaseField(Name = "EmployeeRefNo", RefModel = typeof(GlobeEmployee), RefField = "Description", RefAlias = "Employee", RefTableAlias = "Employee",IsRequired = true)]
        [DetailViewItem]
        public int EmployeeRefNo { get; set; }

        //[Display(Name = "Names")]
        //[DatabaseField(IsProperCase = true)]
        //[DetailViewItem]
        //public string Description { get; set; }

        [DataLookUp]
        [Display(Name = "Department")]
        [DatabaseField(Name = "GlobeDeptRefNo", RefModel = typeof(GlobeDepartment), RefField = "Description", RefAlias = "Employee", RefTableAlias = "Employee", IsRequired = true)]
        [DetailViewItem]
        public int GlobeDeptRefNo { get; set; }


        [DataLookUp]
        [Display(Name = "Supervisor")]
        [DatabaseField(Name = "GlobeSupervisorRefNo", RefModel = typeof(GlobeSupervisor), RefField = "Description", RefAlias = "Employee", RefTableAlias = "Employee", IsRequired = true)]
        [DetailViewItem]
        public int GlobeSupervisorRefNo { get; set; }
        

        //[Display(Name = "Department")]
        //[DatabaseField(IsProperCase = true)]
        //[DetailViewItem]
        //public string Department { get; set; }

        //[Display(Name = "Supervisor")]
        //[DatabaseField(IsProperCase = true)]
        //[DetailViewItem]
        //public string Supervisor { get; set; }
    }
}