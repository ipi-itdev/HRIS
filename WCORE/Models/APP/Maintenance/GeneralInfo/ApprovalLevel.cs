using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Approval Level")]
    [DatabaseTable(Name = "TMS_ApprovalLevel")]
    public class ApprovalLevel : BaseObject
    {
        [Display(Name = "Approval Code")]
        [DatabaseField(IsRequired =true)]
        [DetailViewItem]
        public string ApprovalCode { get; set; }

        [DataLookUp]
        [Display(Name = "Menu")]
        [DatabaseField(IsRequired = true, Name = "MenuRefNo", RefModel = typeof(Menu), RefField = "MenuTitle", RefAlias = "menu", RefTableAlias = "menu")]
        [ListViewColumn]
        [DetailViewItem]
        public int MenuRefNo { get; set; }

        [Display(Name = "Level")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        public int Sequence { get; set; }

        [Display(Name="Action")]
        [DatabaseField(IsRequired =true)]
        [ListViewColumn]
        [DetailViewItem]
        public string UserAction { get; set; }

        [Display(Name = "Status Action")]
        [DatabaseField(IsRequired =true)]
        [DetailViewItem]
        public string UserActionStatus { get; set; }

        [Display(Name = "Is External?")]
        [DatabaseField]
        [DetailViewItem]
        public bool IsExternal { get; set; }

        [Display(Name = "Allow Update?")]
        [DatabaseField]
        [DetailViewItem]
        public bool AllowUpdate { get; set; }

        [Display(Name = "Display Contract")]
        [DatabaseField]
        [DetailViewItem]
        public bool PrintContract { get; set; }

        [DataLookUp]
        [Display(Name = "User Privileges")]
        [DatabaseField(Name = "ID", RefModel = typeof(UserRoles), RefField = "Description", RefAlias = "upr", RefTableAlias = "upr")]
        [DetailViewItem(TabName ="Approver")]
        public int UserPrivilegesRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "User")]
        [DatabaseField(Name = "ID", RefModel = typeof(User), RefField = "Username", RefAlias = "ur", RefTableAlias = "u")]
        [DetailViewItem(TabName = "Approver")]
        public int UserRefNo { get; set; }

        [Display(Name = "Is MR?")]
        [DatabaseField]
        [DetailViewItem(TabName = "Approver")]
        public bool IsMR { get; set; }

        [Display(Name = "Is Dept. Manager?")]
        [DatabaseField]
        [DetailViewItem(TabName = "Approver")]
        public bool IsDeptManager { get; set; }

        [Display(Name = "Is MR Manager?")]
        [DatabaseField]
        [DetailViewItem(TabName = "Approver")]
        public bool IsMRManager { get; set; }

        [Display(Name = "Is Super Approver?")]
        [DatabaseField]
        [DetailViewItem(TabName = "Approver")]
        public bool IsSuperApprover { get; set; }

        [Display(Name = "User Alias")]
        [DatabaseField]
        [DetailViewItem(TabName = "Approver")]
        public string UserAlias { get; set; }

    }
}