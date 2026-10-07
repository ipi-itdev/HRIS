using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Signatory")]
    [DatabaseTable(Name = "SYS_Signatory_U")]
    public class Signatories : BaseObject
    {
        
        [Display(Name = "Signatory")]
        [DatabaseField]
        [DetailViewItem]
        [ListViewColumn(Width = 20)]
        public string EmployeeName { get; set; }

        [DatabaseField]
        [DetailViewItem]
        [ListViewColumn(Width = 20)]
        public string Position { get; set; }

        [Display(Name="Menu Form")]
        [DataLookUp]
        [DatabaseField(Name = "MenuRefNo", RefModel = typeof(Menu), RefField = "Description", RefAlias = "MEN", RefTableAlias = "M")]
        [DetailViewItem(IsEnabled=false)]
        [ListViewColumn(Width = 20)]
        public int MenuRefNo { get; set; }

        [DatabaseField]
        [DetailViewItem(IsTextArea=true,IsEnabled = false)]
        public string Remarks { get; set; }

        [Display(Name="Sequence")]
        [DatabaseField]
        [DetailViewItem(IsTextArea = true, IsEnabled=false)]
        public int SignatoryRefNo { get; set; }

        [DatabaseField]
        [DetailViewItem]
        public string Contact { get; set; }
    }
}