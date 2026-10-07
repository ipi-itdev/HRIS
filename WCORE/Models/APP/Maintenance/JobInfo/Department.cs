using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Department")]
    [DatabaseTable(Name = "GEN_Department_M", PKeyName = "DepartmentRefNo")]
    public class Department : BaseObject
    {

        [DetailViewItem]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn(Width=20)]
        public string Code { get; set; }

        [DetailViewItem(IsTextArea=true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn(Width =150)]
        public string Description { get; set; }

        [DataLookUp] 
        [Display(Name = "Manager")]
        [DetailViewItem]
        [ListViewColumn(Width = 20)]
        [DatabaseField(IsRequired = true, RefModel = typeof(User), RefField = "EmployeeName", RefTableAlias = "M", Name = "ID", RefAlias = "MR")]
        public int UserRefNo { get; set; }
    }
}