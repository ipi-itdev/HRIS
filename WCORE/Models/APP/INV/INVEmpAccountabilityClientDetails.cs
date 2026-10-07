using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name= "EmpAccountabilityDetails")]
    [DatabaseTable(Name = "INV_EmpAccountabilityDetails_U", ViewName = "vEmpAccountabilityDetails")]
    public class INVEmpAccountabilityClientDetails : BaseObject
    {
        [DatabaseField]
        public int EmpAccountabilityRefNo { get; set; }

        [Display(Name = "Item Definition")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        public string ItemDefinition { get; set; }

        [Display(Name = "Specification")]
        [DatabaseField(IsRequired =true)]
        [DetailViewItem(IsTextArea = true)]
        public string ItemSpecifications { get; set; }

        [Display(Name = "Is From Client?")]
        [DatabaseField(DefaultValue = "True")]
        [DetailViewItem(IsEnabled =true)]
        public bool IsFromClient { get; set; }

        [DatabaseField]
        [DetailViewItem(IsTextArea = true,Column = 2)]
        [ListViewColumn]
        public string Remarks { get; set; }
    }
}