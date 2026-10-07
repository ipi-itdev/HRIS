using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "External Employee", SubName = "Active")]
    [DatabaseTable(Name = "PIS_Employee_U", ViewName = "vPISEmployeeAuditNC", PKeyName = "EmployeeRefNo")]
    public class AuditEmployeeNC : BaseObject
    {
        [DatabaseField(AllowUpdate = false)]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "Employee #")]
        [DatabaseField(AllowUpdate = false)]
        [ListViewColumn(Width = 100)]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public string EmployeeNumber { get; set; }

        [Display(Name = "Last Name")]
        [DatabaseField(IsRequired = true, IsProperCase = true)]
        [DetailViewItem]
        [ListViewColumn(Width = 100)]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [DatabaseField(IsRequired = true, IsProperCase = true)]
        [DetailViewItem]
        [ListViewColumn(Width = 100)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem]
        [ListViewColumn(Width = 100)]
        public string MiddleName { get; set; }

        [DatabaseField]
        [DetailViewItem]
        public string Suffix { get; set; }

        [Display(Name = "Nick Name")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem]
        public string NickName { get; set; }

        [DataLookUp(IsJson = true)]
        [Display(Name = "Gender")]
        [DatabaseField(IsRequired = true, Name = "GenderRefNo", RefModel = typeof(Gender), RefField = "Description", RefAlias = "Gender", RefTableAlias = "GEN")]
        [DetailViewItem]
        public int GenderRefNo { get; set; }

        [DataLookUp(IsJson = true)]
        [Display(Name = "Civil Status")]
        [DatabaseField(DefaultValue = "1", IsRequired = true, Name = "CivilStatusRefNo", RefModel = typeof(CivilStatus), RefField = "Description", RefAlias = "CivilStatus", RefTableAlias = "CS")]
        [DetailViewItem(Column = 2)]
        public int CivilStatusRefNo { get; set; }

        [Display(Name = "Birth Date")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(strFormat = "mm/dd/yyyy")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Age")]
        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [DetailViewItem(IsEnabled = false)]
        public int Age { get; set; }

        [Display(Name = "Birth Place")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem]
        public string BirthPlace { get; set; }

        [DataLookUp(IsJson = true)]
        [Display(Name = "Nationality")]
        [DatabaseField(DefaultValue = "1", Name = "NationalityRefNo", RefModel = typeof(Nationality), RefField = "Description", RefAlias = "Nationality", RefTableAlias = "NAT")]
        [DetailViewItem(Column = 2)]
        public int NationalityRefNo { get; set; }

        [DataLookUp(IsJson = true)]
        [Display(Name = "Religion")]
        [DatabaseField(DefaultValue = "1", Name = "ReligionRefNo", RefModel = typeof(Religion), RefField = "Description", RefAlias = "Religion", RefTableAlias = "Rel")]
        [DetailViewItem(Column = 2)]
        public int ReligionRefNo { get; set; }

        [Display(Name = "Height(ft.)")]
        [DatabaseField]
        [DetailViewItem(Column = 2)]
        public string Height { get; set; }

        [Display(Name = "Weight(kg.)")]
        [DatabaseField]
        [DetailViewItem(Column = 2)]
        public string Weight { get; set; }

        [DataLookUp(IsJson = true)]
        [Display(Name = "Blood Type")]
        [DatabaseField(Name = "BloodtypeRefNo", RefModel = typeof(BloodType), RefField = "Description", RefAlias = "BloodType", RefTableAlias = "BT")]
        [DetailViewItem(Column = 2)]
        public int BloodtypeRefNo { get; set; }

        [DatabaseField]
        [DetailViewItem(Column = 2, IsTextArea = true)]
        public string Allergies { get; set; }

        [Display(Name = "Telephone")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact", Column = 2, strFormat = "data-inputmask=`~mask~: ~999-9999~` data-mask")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Mobile")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Contact", strFormat = "data-inputmask=`~mask~: ~9999-999-9999~` data-mask")]
        [ListViewColumn(Width = 100)]
        public string MobileNumber { get; set; }

        [Display(Name = "Mobile 2")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Contact", Column = 2, strFormat = "data-inputmask=`~mask~: ~9999-999-9999~` data-mask")]
        [ListViewColumn(Width = 100)]
        public string MobileNumber2 { get; set; }

        [Display(Name = "Personal Email Address")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact", Column = 2)]
        [ListViewColumn(Width = 100)]
        public string PersonalEmailAddress { get; set; }

        [Display(Name = "Work Email Address")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact")]
        [ListViewColumn(Width = 100)]
        public string WorkEmailAddress { get; set; }

        [Display(Name = "Current Address")]
        [DatabaseField(IsRequired = true, IsProperCase = true)]
        [DetailViewItem(TabName = "Contact", IsTextArea = true)]
        [ListViewColumn(Width = 200)]
        public string CurrentAddress { get; set; }

        [Display(Name = "Permanent Address")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "Contact", IsTextArea = true, Column = 2)]
        public string ProvinceAddress { get; set; }

        [DataLookUp]
        [Display(Name = "City")]
        [DatabaseField(Name = "CityRefNo", RefModel = typeof(City), RefField = "Description", RefAlias = "City", RefTableAlias = "Cit")]
        [DetailViewItem(TabName = "Contact")]
        public int CityRefNo { get; set; }

        [Display(Name = "Social Media")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact", Column = 2)]
        public string SocialMedia { get; set; }

        [Display(Name = "Name")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "ContactEmergency")]
        public string EmergencyName1 { get; set; }

        [Display(Name = "Address")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "ContactEmergency")]
        public string EmergencyAddress1 { get; set; }

        [Display(Name = "Contact No.")]
        [DatabaseField]
        [DetailViewItem(TabName = "ContactEmergency")]
        public string EmergencyContactNo1 { get; set; }

        [Display(Name = "Relationship")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "ContactEmergency")]
        public string EmergencyRelationship1 { get; set; }

        [Display(Name = "Name 2")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "ContactEmergency", Column = 2)]
        public string EmergencyName2 { get; set; }

        [Display(Name = "Address 2")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "ContactEmergency", Column = 2)]
        public string EmergencyAddress2 { get; set; }

        [Display(Name = "Contact No. 2")]
        [DatabaseField]
        [DetailViewItem(TabName = "ContactEmergency", Column = 2)]
        public string EmergencyContactNo2 { get; set; }

        [Display(Name = "Relationship 2")]
        [DetailViewItem(TabName = "ContactEmergency", Column = 2)]
        [DatabaseField(IsProperCase = true)]
        public string EmergencyRelationship2 { get; set; }

        [Display(Name = "TIN")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "AffiliationNo")]
        public string TinNumber { get; set; }

        [Display(Name = "PHILHEALTH No.")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "AffiliationNo")]
        public string PhilHealthNumber { get; set; }

        [Display(Name = "SSS No.")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "AffiliationNo")]
        public string SSSNumber { get; set; }

        [Display(Name = "PAGIBIG No.")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "AffiliationNo")]
        public string PagibigNumber { get; set; }

        [DetailViewItem(TabName = "Dependents", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo", ModelNo = "10230")]
        public List<Dependents> EmployeeDependents { get; set; }

    }
}