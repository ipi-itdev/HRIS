using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    //[MenuDescription(Name = "Department Globe")]
    //[DatabaseTable(Name = "PIS_Employee_U")]
    [DatabaseTable(Name = "View_EmployeeGlobe", PKeyName = "ID")]
    public class GlobeEmployee : BaseObject
    {
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}