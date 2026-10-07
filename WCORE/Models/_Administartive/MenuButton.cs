using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Menu Columns")]
    [DatabaseTable(Name = "SYS_MenuListButton_U",PKeyName = "ID")]
    public class MenuButton : BaseObject
    {
        [DatabaseField]
        public int MenuRefNo { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public string Code { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public string Description { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public string Icon { get; set; }

        [Display(Name = "Seq. No")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public string SeqNo { get; set; }

        [Display(Name = "Action")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        [ListViewColumn]
        public string ActionURL { get; set; }

        [Display(Name = "Is Detail Button?")]
        [DatabaseField]
        [DetailViewItem]
        public bool IsDetailButton { get; set; }

        [Display(Name = "Command Type")]
        [DataLookUp]
        [DatabaseField(IsRequired =true,Name = "CommandTypeRefNo", RefModel = typeof(CommandTypeButton), RefField = "Description", RefAlias = "CT", RefTableAlias = "CType")]
        [DetailViewItem]
        public int CommandTypeRefNo { get; set; }

        [Display(Name = "Parent Menu")]
        [DataLookUp]
        [DatabaseField(Name = "MenuRefNo", RefModel = typeof(Menu), RefField = "Description", RefAlias = "MEN", RefTableAlias = "M")]
        [DetailViewItem]
        [ListViewColumn]
        public int ParentMenuRefNo { get; set; }

        [Display(Name = "Confirmation Message")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Properties")]
        public string ConfirmationMessage { get; set; }

        [Display(Name = "Ok Label")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Properties")]
        public string OkLabel { get; set; }

        [Display(Name = "Success Message")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Properties")]
        public string SuccessMessage { get; set; }

        [Display(Name = "Failed Message")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Properties")]
        public string FailedMessage { get; set; }

        [Display(Name = "Success")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Properties")]
        public string SuccessURL { get; set; }
    }
}