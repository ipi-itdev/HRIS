using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;
namespace WCORE.Models
{
    //[MenuDescription(Name = "Department Globe")]
    //[DatabaseTable(Name = "GEN_GlobeDepartment_U")]
    [DatabaseTable(Name = "GEN_GlobeDepartment_U", PKeyName = "GlobeDeptRefNo")]
    public class GlobeDepartment : BaseObject
    {
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}