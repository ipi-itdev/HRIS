using System;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "External Employee", SubName = "Active")]
    [DatabaseTable(Name = "PIS_Employee_U", PKeyName = "EmployeeRefNo")]
    public class Employee : BaseObject
    {
        [DatabaseField(AllowUpdate=false)]
        public int EmployeeRefNo { get; set; }

        [DatabaseField(AllowUpdate = false)]
        public string EmployeeNumber { get; set; }

        // Personal Information
        [DatabaseField(IsRequired = true, IsProperCase = true)]
        public string Description { get; set; }

        [DatabaseField(IsRequired = true,IsProperCase = true)]
        public string LastName { get; set; }

        [DatabaseField(IsRequired = true, IsProperCase = true)]
        public string FirstName { get; set; }

        [DatabaseField(IsProperCase = true)]
        public string MiddleName { get; set; }

        [DatabaseField]
        public string Suffix { get; set; }

        [DatabaseField(IsProperCase = true)]
        public string NickName { get; set; }

        [DatabaseField(IsRequired = true)]
        public DateTime Birthdate { get; set; }

        [DatabaseField(AllowInsert=false,AllowUpdate=false)]
        public int Age { get; set; }

        [DatabaseField(IsProperCase = true)]
        public string BirthPlace { get; set; }

        [DataLookUp(IsJson = true)]
        [DatabaseField(IsRequired = true, Name = "GenderRefNo", RefModel = typeof(Gender), RefField = "Description", RefAlias = "Gender", RefTableAlias = "GEN")]
        public int GenderRefNo { get; set; }

        [DataLookUp(IsJson = true)]
        [DatabaseField(DefaultValue = "1", IsRequired = true, Name = "CivilStatusRefNo", RefModel = typeof(CivilStatus), RefField = "Description", RefAlias = "CivilStatus", RefTableAlias = "CS")]
        public int CivilStatusRefNo { get; set; }

        [DataLookUp(IsJson = true)]
        [DatabaseField(DefaultValue = "1" ,Name = "NationalityRefNo", RefModel = typeof(Nationality), RefField = "Description", RefAlias = "Nationality", RefTableAlias = "NAT")]
        public int NationalityRefNo { get; set; }

        [DataLookUp(IsJson = true)]
        [DatabaseField(DefaultValue="1", Name = "ReligionRefNo", RefModel = typeof(Religion), RefField = "Description", RefAlias = "Religion", RefTableAlias = "Rel")]
        public int ReligionRefNo { get; set; }

        [Display(Name="Height(ft.)")]
        [DatabaseField]
        [DetailViewItem(Column = 2)]
        public string Height { get; set; }

        [Display(Name = "Weight(kg.)")]
        [DatabaseField]
        [DetailViewItem(Column = 2)]
        public string Weight { get; set; }

        [DataLookUp(IsJson=true)]
        [Display(Name = "Blood Type")]
        [DatabaseField(Name = "BloodtypeRefNo", RefModel = typeof(BloodType), RefField = "Description", RefAlias = "BloodType", RefTableAlias = "BT")]
        [DetailViewItem(Column = 2)]
        public int BloodtypeRefNo { get; set; }

        [DatabaseField]
        [DetailViewItem(Column = 2,IsTextArea=true)]
        public string Allergies { get; set; }
        // End Personal Information

        // Contact Information
        [Display(Name = "Personal Email Address")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact", Column = 2)]
        public string PersonalEmailAddress { get; set; }

        [Display(Name = "Work Email Address")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact")]
        public string WorkEmailAddress { get; set; }

        [Display(Name = "Social Media")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact", Column = 2)]
        public string SocialMedia { get; set; }

        [Display(Name = "Telephone")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact", Column = 2, strFormat = "data-inputmask=`~mask~: ~999-9999~` data-mask")]
        public string LandLineNumber { get; set; }

        [Display(Name = "Mobile")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Contact",strFormat="data-inputmask=`~mask~: ~9999-999-9999~` data-mask")]
        public string PrimaryMobileNumber { get; set; }

        [Display(Name = "Mobile 2")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Contact", Column = 2, strFormat = "data-inputmask=`~mask~: ~9999-999-9999~` data-mask")]
        public string SecondaryMobileNumber { get; set; }
        // End Contact Information

        // Address Information
        [DatabaseField]
        public int RegionRefNo { get; set; }

        [DatabaseField]
        public int ProvinceRefNo { get; set; }

        [DatabaseField]
        public int MunicipalityRefNo { get; set; }

        [DatabaseField]
        public int BrgyRefNo { get; set; }

        [DatabaseField]
        public string PresentAddress { get; set; }

        [DatabaseField]
        public int PermanentRegionRefNo { get; set; }

        [DatabaseField]
        public int PermanentProvinceRefNo { get; set; }

        [DatabaseField]
        public int PermanentMunicipalityRefNo { get; set; }

        [DatabaseField]
        public int PermanentBrgyRefNo { get; set; }

        [DatabaseField]
        public string PermanentAddress { get; set; }
        //End Address Information

        //Emergency Contact
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
        //End Emergency Contact

        //Government ID
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
    }
}