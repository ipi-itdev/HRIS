using System;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "User")]
    [DatabaseTable(Name ="SYS_WebUser",PKeyName="ID",ViewName ="UserInfo")]
    public class User : BaseObject
    {
        [DatabaseField(NotInTable = false, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string Description { get; set; }

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
        [DatabaseField(IsRequired = true, IsUnique = true)]
        public string Username { get; set; }

        [DatabaseField(DefaultValue = " dbo.fEncrypt(12345) ", AllowUpdate = false)]
        public string Password { get; set; }

        [DetailViewItem(IsEmail=true)]
        [DatabaseField(IsRequired = true)]
        public string Email { get; set; }

        [DataLookUp]
        [DetailViewItem]
        [Display(Name = "User Roles")]
        [ListViewColumn]
        [DatabaseField(IsRequired=true, Name = "ID", RefModel = typeof(UserRoles), RefField = "Description", RefAlias = "UserRoles", RefTableAlias = "UR")]
        public int UserPrivilegesRefNo { get; set; }

        [DataLookUp]
        [DetailViewItem]
        [Display(Name = "MR")]
        [DatabaseField(Name = "ID", RefModel = typeof(MarketingRep), RefField = "Description", RefAlias = "MR", RefTableAlias = "MR")]
        public int MRRefNo { get; set; }

        public string UserRoles { get; set; }

        [DatabaseField(NotInTable = true, AllowInsert = false)]
        public string GoogleAuthKey { get; set; }

        [DatabaseField(NotInTable = true,AllowInsert =false)]
        public string Message { get; set; }

        [DatabaseField(NotInTable = true, AllowInsert = false)]
        public string OldPassword { get; set; }

        [DatabaseField(NotInTable = true, AllowInsert = false)]
        public string CPassword { get; set; }

        [DatabaseField(NotInTable = true, AllowInsert = false)]
        public string Status { get; set; }

        [DatabaseField(NotInTable = true, AllowInsert = false)]
        public int CompanyRefNo { get; set; }

        [DatabaseField(DefaultValue = "0")]
        public Boolean IsOpenSurvey { get; set; }

        [DatabaseField(DefaultValue = "0")]
        public Boolean IsReset { get; set; }

        [DatabaseField(AllowUpdate =false,AllowInsert =false)]
        public string mguid { get; set; }

        [DatabaseField(AllowUpdate = false, AllowInsert = false)]
        public int rpExpiry { get; set; }
        
        
    }
}