using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Audit Trail")]
    [DatabaseTable(Name = "SYS_AuditTrail_C")]
    public class AuditTrail : BaseObject
    {
        [DataLookUp]
        [Display(Name = "User")]
        [ListViewColumn]
        [DatabaseField(Name = "ID", RefModel = typeof(User), RefField = "Description",RefTableAlias="U", RefAlias="Usr")]
        [DetailViewItem(IsEnabled = false)]
        public int UserRefNo { get; set; }

        [ListViewColumn]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public int Menu { get; set; }

        [ListViewColumn]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public string Action { get; set; }

        [ListViewColumn]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        public int RefNo { get; set; }

        [Display(Name="Column")]
        [ListViewColumn]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public int ColumnName { get; set; }    

        [Display(Name="Old Value")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public string OldValue { get; set; }

        [Display(Name="New Value")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public string NewValue { get; set; }

        [Display(Name = "Host Name")]
        [ListViewColumn]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false, Column=2)]
        public string HostName { get; set; }

        [Display(Name = "Mac Address")]      
        [ListViewColumn]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public string MacAddress { get; set; }
        
    }
}