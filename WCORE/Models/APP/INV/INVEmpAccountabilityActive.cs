using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name="Employee Accountability")]
    [DatabaseTable(Name = "INV_EmpAccountability_U",ViewName = "dbo.fEmpAccountability(@User)")]
    public class INVEmpAccountabilityActive : BaseObject
    {
        [Display(Name ="MR/Manager")]
        [DatabaseField(NotInTable = true)]
        [ListViewColumn]
        public string MR { get; set; }

        [Display(Name = "Client/Department")]
        [DatabaseField(NotInTable = true)]
        [ListViewColumn]
        public string Client { get; set; }

        [DataLookUp]
        [Display(Name = "Employee")]
        [DatabaseField(AllowUpdate = false,IsRequired = true, RefModel = typeof(INVEmployeeMasterlist), RefField = "Description", RefTableAlias = "emp", Name = "EmployeeRefNo", RefAlias = "emp")]
        [DetailViewItem]
        [ListViewColumn]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "Issued Date")]
        [DatabaseField]
        [DetailViewItem]
        [ListViewColumn]
        public string DeployedDate { get; set; }

        [DataLookUp]
        [Display(Name = "Issued By")]
        [DetailViewItem(IsEnabled = false)]
        [DatabaseField(AllowInsert = false, AllowUpdate = false, RefModel = typeof(User), RefField = "Description", RefAlias = "[Issued By]", RefTableAlias = "IB",Name ="ID")]
        [ListViewColumn]
        public int DeployedBy { get; set; }


        [DatabaseField]
        [DetailViewItem(IsTextArea =true)]
        [ListViewColumn]
        public string Remarks { get; set; }

        [Display(Name = "Filing Status")]
        [DatabaseField(NotInTable =true)]
        [ListViewColumn]
        public string FilingStatus { get; set; }

        [Display(Name = "Item Details")]
        [DetailViewItem(TabName = "INVEmpAccountabilityDetails", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmpAccountabilityRefNo", ForeignKeyValue = "ID", ModelNo = "30210")]
        public List<INVEmpAccountabilityDetails> INVEmpAccountabilityDetails { get; set; }
    }
}