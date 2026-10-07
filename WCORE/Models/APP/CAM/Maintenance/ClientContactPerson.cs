using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Contact Person")]
    [DatabaseTable(Name = "CAM_ContactPerson", PKeyName = "ID")]
    public class ClientContactPerson : BaseObject
    {
        [DatabaseField]
        public int ClientAccountRefNo { get; set; }

        [DataLookUp(WithAdd = true)]
        [Display(Name = "Branch")]
        [DetailViewItem]
        [ListViewColumn(Width = 50)]
        [DatabaseField(IsRequired = true, RefModel = typeof(Branch), RefField = "Description", RefTableAlias = "B", Name = "ID", RefAlias = "B")]
        public int BranchRefNo { get; set; }

        [Display(Name = "Contact Name")]
        [DetailViewItem]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn(Width=200)]
        public string ContactName { get; set; }

        [Display(Name = "Contact Position")]
        [DetailViewItem]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn(Width =200)]
        public string ContactPosition { get; set; }

        [Display(Name = "Mobile No.")]
        [DetailViewItem(Column=2)]
        [DatabaseField]
        [ListViewColumn(Width = 150)]
        public string MobileNumber { get; set; }

        [Display(Name = "Telephone No.")]
        [DetailViewItem(Column = 2)]
        [DatabaseField]
        [ListViewColumn(Width = 150)]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Email")]
        [DetailViewItem(Column = 2)]
        [DatabaseField]
        [ListViewColumn(Width = 150)]
        public string Email { get; set; }

        [Display(Name = "Main Contact")]
        [DetailViewItem(Column = 2)]
        [DatabaseField]
        [ListViewColumn(Width = 150)]
        public bool IsMaincontact  { get; set; }
    }
}