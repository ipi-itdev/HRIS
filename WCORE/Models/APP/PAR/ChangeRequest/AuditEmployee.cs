using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "External Employee", SubName = "Active")]
    [DatabaseTable(Name = "dbo.PIS_FN_EmployeeAuditDetails()", PKeyName = "EmployeeRefNo")]
    public class AuditEmployee : BaseObject
    {
        [Display(Name = "Employee Number")]
        [DatabaseField]
        [DetailViewItem]
        public string EmployeeNumber { get; set; }

        [Display(Name = "Employee Name")]
        [DatabaseField]
        [DetailViewItem]
        public string EmployeeName { get; set; }

        [Display(Name = "Last Name")]
        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information")]
        public string LastName { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information")]
        public string FirstName { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information")]
        public string MiddleName { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information")]
        public string Suffix { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information")]
        public string NickName { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information")]
        public string Birthdate { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information")]
        public string Age { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information")]
        public string BirthPlace { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information", Column = 2)]
        public string Gender { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information",Column = 2)]
        public string CivilStatus { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information", Column = 2)]
        public string Nationality { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information", Column = 2)]
        public string Religion { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information", Column = 2)]
        public string Height { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information", Column = 2)]
        public string Weight { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information", Column = 2)]
        public string Bloodtype { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Personal Information", Column = 2)]
        public string Allergies { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Contact Information")]
        public string MobileNumber { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Contact Information")]
        public string MobileNumber2 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Contact Information")]
        public string TelephoneNumber { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Contact Information")]
        public string PersonalEmailAddress { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Contact Information")]
        public string WorkEmailAddress { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Contact Information")]
        public string SocialMedia { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Address")]
        public string PresentRegion { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Address")]
        public string PresentProvince { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Address")]
        public string PresentCity { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Address")]
        public string PresentBarangay { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Address", IsTextArea = true)]
        public string CurrentAddress { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Address",Column = 2)]
        public string PermanentRegion { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Address", Column = 2)]
        public string PermanentProvince { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Address", Column = 2)]
        public string PermanentCity { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Address", Column = 2)]
        public string PermanentBarangay { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Address", Column = 2, IsTextArea = true)]
        public string ProvinceAddress { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact")]
        public string EmergencyName1 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact", IsTextArea = true)]
        public string EmergencyAddress1 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact")]
        public string EmergencyContactNo1 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact")]
        public string EmergencySecondaryContact1 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact")]
        public string EmergencyEmail1 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact")]
        public string EmergencyRelationship1 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact",Column = 2)]
        public string EmergencyName2 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact", Column = 2, IsTextArea = true)]
        public string EmergencyAddress2 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact", Column = 2)]
        public string EmergencyContactNo2 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact", Column = 2)]
        public string EmergencySecondaryContact2 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact", Column = 2)]
        public string EmergencyEmail2 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact", Column = 2)]
        public string EmergencyRelationship2 { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Statutory")]
        public string TinNumber { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Statutory")]
        public string PhilHealthNumber { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Statutory")]
        public string SSSNumber { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Statutory")]
        public string PagibigNumber { get; set; }
    }
}