using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "User Roles")]
    [DatabaseTable(Name = "SYS_UserPrivileges_U",PKeyName="ID")]
    public class UserRoles : BaseObject
    {
        [DetailViewItem(IsTextArea=true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn]
        public string Description { get; set; }
    }
}