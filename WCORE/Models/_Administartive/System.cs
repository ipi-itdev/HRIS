using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "System")]
    [DatabaseTable(Name = "SYS_System_U", PKeyName = "SystemRefNo")]
    public class System : BaseObject
    {
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public string Code { get; set; }

        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true)]
        public string Description { get; set; }
    }
}