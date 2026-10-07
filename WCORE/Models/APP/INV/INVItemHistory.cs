using System;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Item History")]
    [DatabaseTable(Name = "INV_ItemsHistory_U", ViewName = "dbo.fINVItemHistory(@ItemRefNo)")]
    public class INVItemHistory : BaseObject
    {
        [DatabaseField]
        public int ItemsRefNo { get; set; }

        [Display(Name = "Date Performed")]
        [DatabaseField(IsRequired =true)]
        [DetailViewItem(strFormat = "mm/dd/yyyy")]
        [ListViewColumn]
        public DateTime DatePerformed { get; set; }

        [Display(Name = "Activity")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(Column = 2, IsTextArea = true)]
        [ListViewColumn]
        public string Remarks { get; set; }
    }
}