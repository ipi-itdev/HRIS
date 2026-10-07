using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "User")]
    [DatabaseTable(Name ="SYS_WebUser",PKeyName="ID",ViewName ="UserInfo")]
    public class DifficultyLevel : BaseObject
    {
        [DatabaseField(NotInTable = false, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string Description { get; set; }

        [DataLookUp]
        [DetailViewItem]
        [Display(Name = "Employee")]
        [DatabaseField(Name = "EmployeeRefNo", RefModel = typeof(ActiveEmployeeInternal), RefField = "Description", RefAlias = "E", RefTableAlias = "E")]
        public int EmployeeRefNo { get; set; }

        [Display(Name="Name")]
        [DetailViewItem]
        [DatabaseField]
        public string EmployeeName { get; set; }

        [DataLookUp]
        [DetailViewItem]
        [ListViewColumn]
        [Display(Name = "Department")]
        [DatabaseField(Name = "ID", RefModel = typeof(Department), RefField = "Description", RefAlias = "Dep", RefTableAlias = "Dep")]
        public int DepartmentRefNo { get; set; }

        [DetailViewItem]
        [DatabaseField(IsRequired = true,IsUnique = true)]
        public string Username { get; set; }

        [DatabaseField(DefaultValue = " dbo.fEncrypt(12345) ", AllowUpdate = false)]
        public string Password { get; set; }

        [DetailViewItem(IsEmail=true)]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        public string Email { get; set; }

        [DataLookUp]
        [DetailViewItem]
        [Display(Name = "User Roles")]
        [ListViewColumn]
        [DatabaseField(IsRequired=true, Name = "ID", RefModel = typeof(UserRoles), RefField = "Description", RefAlias = "UserRoles", RefTableAlias = "UR")]
        public int UserPrivilegesRefNo { get; set; }

        [DetailViewItem(Name="Is Admin")]
        [DatabaseField]
        public bool IsAdmin { get; set; }

        [DetailViewItem(Name = "Is Approver")]
        [DatabaseField]
        public bool IsApprover { get; set; }

        [DetailViewItem(Name = "Super Approver")]
        [DatabaseField]
        public bool SuperApprover { get; set; }
    }
}