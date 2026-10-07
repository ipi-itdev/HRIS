using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name= "EmpAccountabilityDetails")]
    [DatabaseTable(Name = "INV_EmpAccountabilityDetails_U", ViewName = "vEmpAccountabilityDetails")]
    public class INVEmpAccountabilityDetails : BaseObject
    {
        [DatabaseField]
        public int EmpAccountabilityRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Item")]
        [DatabaseField(RefModel = typeof(INVAvailableItems), RefField = "Description", RefTableAlias = "ITT", Name = "ID", RefAlias = "ITT",AllowUpdate =false, IsRequired = true)]
        [DetailViewItem]
        public int ItemsRefNo { get; set; }

        [DatabaseField]
        [DetailViewItem(IsTextArea = true,Column = 2)]
        [ListViewColumn]    
        public string Remarks { get; set; }
    }


}