using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Ticket")]
    [DatabaseTable(Name = "GEN_Ticket_U", PKeyName = "ID")]
    public class Ticket : BaseObject
    {
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextEditor=true)]
        public string Concerns { get; set; }

        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false)]
        public DateTime DatePosted { get; set; }

        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled=false)]
        public DateTime DateResolved { get; set; }

        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsEnabled = false)]
        public DateTime DateClosed { get; set; } 

        [DataLookUp]
        [DetailViewItem]
        [Display(Name = "Employee")]
        [DatabaseField(Name = "ID", RefModel = typeof(DifficultyLevel), RefField = "Description", RefAlias = "DF", RefTableAlias = "DF")]
        public int DifficultyLevelRefNo { get; set; }

        [DataLookUp]
        [DetailViewItem]
        [ListViewColumn]
        [Display(Name = "Department")]
        [DatabaseField(Name = "ID", RefModel = typeof(Department), RefField = "Description", RefAlias = "Dep", RefTableAlias = "Dep")]
        public int AssignedUserRefNo { get; set; }

        //[DataLookUp]
        //[DetailViewItem]
        //[ListViewColumn]
        //[Display(Name = "Department")]
        //[DatabaseField(Name = "ID", RefModel = typeof(Department), RefField = "Description", RefAlias = "Dep", RefTableAlias = "Dep")]
        //public int AssignedUserRefNo { get; set; }

        [DataLookUp]
        [DetailViewItem]
        [ListViewColumn]
        [Display(Name = "Department")]
        [DatabaseField(Name = "ID", RefModel = typeof(Department), RefField = "Description", RefAlias = "Dep", RefTableAlias = "Dep")]
        public int FilingStatusRefNo { get; set; }
    }
}