using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Holiday")]
    [DatabaseTable(Name = "GEN_Holiday_M")]
    public class Holiday : BaseObject
    {
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem]
        public string Code { get; set; }

        [DatabaseField(IsRequired=true,IsUnique =true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea=true)]
        public string Description { get; set; }

        [DataLookUp]
        [Display(Name = "Holiday Type")]
        [DetailViewItem]
        [DatabaseField(RefModel = typeof(HolidayType), RefField = "Description", RefTableAlias = "hol", Name = "HolidayRefNo", RefAlias = "hol")]
        public int HolidayTypeRefNo { get; set; }

        [Display(Name = "Holiday Date")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem(strFormat ="mm/dd/yyyy")]
        public string HolidayDate { get; set; }

        [Display(Name ="Is Constant?")]
        [DatabaseField]
        [DetailViewItem]
        public bool IsConstant { get; set; }
    }
}