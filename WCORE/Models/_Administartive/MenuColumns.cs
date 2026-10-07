using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Menu Columns")]
    [DatabaseTable(Name = "SYS_MenuListColumn_U", PKeyName = "ID")]
    public class MenuColumns : BaseObject
    {
        [DatabaseField]
        public int MenuRefNo { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public string Description { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public string Caption { get; set; }

        [Display(Name ="Seq No.")]
        [DatabaseField]
        [DetailViewItem]
        [ListViewColumn]
        public string SeqNo { get; set; }

        [DatabaseField]
        [DetailViewItem]
        public string Align { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        public string Width { get; set; }

        [Display(Name = "Model")]
        [DatabaseField]
        [DetailViewItem]
        public string ModelName { get; set; }

        [Display(Name = "Control Type")]
        [DataLookUp]
        [DatabaseField(IsRequired = true, Name = "ControlTypeRefNo", RefModel = typeof(ControlTypeField), RefField = "Description", RefAlias = "CT", RefTableAlias = "CType")]
        [DetailViewItem]
        public int ControlTypeRefNo { get; set; }

        [Display(Name = "Default Value")]
        [DatabaseField]
        [DetailViewItem]
        public string DefaultValue { get; set; }

        [Display(Name = "Is List Column?")]
        [DatabaseField]
        [DetailViewItem]
        public bool IsListColumn { get; set; }

        [Display(Name = "Is Filter?")]
        [DatabaseField]
        [DetailViewItem]
        public bool IsFilter { get; set; }
    }
}