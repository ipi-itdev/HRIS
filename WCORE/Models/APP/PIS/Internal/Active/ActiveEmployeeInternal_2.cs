using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "Internal Employee",SubName="Active")]
    // Remove DUV = true
    [DatabaseTable(Name = "PIS_Employee_U", ViewName = "dbo.fSelectEmployee(@User,1,1)", PKeyName = "EmployeeRefNo")]
    public class ActiveEmployeeInternal_2 : BaseObject
    {
        [DatabaseField()]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "Employee #")]
        [DatabaseField]
        [ListViewColumn(Width=100)]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public string EmployeeNumber { get; set; }

        [Display(Name = "Biometric ID")]
        [DatabaseField]
        [DetailViewItem(Column = 2)]
        public string BiometricID { get; set; }

        [Display(Name = "Employee Name")]
        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn(Width=250)]
        public string Description { get; set; }
   
        [Display(Name = "Status")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false, Name = "EmploymentStatusRefNo", RefModel = typeof(EmploymentStatus), RefField = "Description", RefAlias = "ES", RefTableAlias = "E")]
        [ListViewColumn(Width=150)]
        public int EmploymentStatusRefNo { get; set; }

        [Display(Name = "Position")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false, Name = "JobPositionRefNo", RefModel = typeof(JobPosition), RefField = "Description", RefAlias = "JOB", RefTableAlias = "JOB")]
        [ListViewColumn(Width = 150)]
        public int JobPositionRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Department")]
        [ListViewColumn(Width=300)]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false, Name = "DepartmentRefNo", RefModel = typeof(Department), RefField = "Description", RefAlias = "DEP", RefTableAlias = "DP")]
        public int DepartmentRefNo { get; set; }

        [Display(Name = "Date Hired")]
        [ListViewColumn(Width=100)]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        public DateTime DateHired { get; set; }

        [Display(Name = "Remarks")]
        [DatabaseField]
        [ListViewColumn(Width = 100)]
        [DetailViewItem(TabName = "Employment")]
        public string Remarks { get; set; }

        [Display(Name = "Last Name")]
        [DatabaseField(IsRequired = true,IsProperCase=true)]
        [DetailViewItem]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [DatabaseField(IsRequired = true,IsProperCase=true)]
        [DetailViewItem]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem]
        public string MiddleName { get; set; }

        [DatabaseField]
        [DetailViewItem]
        public string Suffix { get; set; }

        [Display(Name = "Nick Name")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem]
        public string NickName { get; set; }

        [DataLookUp]
        [Display(Name = "Gender")]
        [DatabaseField(IsRequired = true, Name = "GenderRefNo", RefModel = typeof(Gender), RefField = "Description", RefAlias = "Gender", RefTableAlias = "GEN")]
        [DetailViewItem]
        public int GenderRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Civil Status")]
        [DatabaseField(IsRequired = true, Name = "CivilStatusRefNo", RefModel = typeof(CivilStatus), RefField = "Description", RefAlias = "CivilStatus", RefTableAlias = "CS")]
        [DetailViewItem(Column = 2)]
        public int CivilStatusRefNo { get; set; }

        [Display(Name = "Birth Date")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Age")]
        [DatabaseField(AllowInsert=false,AllowUpdate=false)]
        [DetailViewItem(IsEnabled = false)]
        public int Age { get; set; }

        [Display(Name = "Birth Place")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem]
        public string BirthPlace { get; set; }

        [DataLookUp]
        [Display(Name = "Nationality")]
        [DatabaseField(Name = "NationalityRefNo", RefModel = typeof(Nationality), RefField = "Description", RefAlias = "Nationality", RefTableAlias = "NAT")]
        [DetailViewItem(Column = 2)]
        public int NationalityRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Religion")]
        [DatabaseField(Name = "ReligionRefNo", RefModel = typeof(Religion), RefField = "Description", RefAlias = "Religion", RefTableAlias = "Rel")]
        [DetailViewItem(Column = 2)]
        public int ReligionRefNo { get; set; }

        [DatabaseField]
        [DetailViewItem(Column = 2)]
        public string Height { get; set; }

        [DatabaseField]
        [DetailViewItem(Column = 2)]
        public string Weight { get; set; }

        [DataLookUp]
        [Display(Name = "Blood Type")]
        [DatabaseField(Name = "BloodtypeRefNo", RefModel = typeof(BloodType), RefField = "Description", RefAlias = "BloodType", RefTableAlias = "BT")]
        [DetailViewItem(Column = 2)]
        public int BloodtypeRefNo { get; set; }

        [DatabaseField]
        [DetailViewItem(Column = 2,IsTextArea=true)]
        public string Allergies { get; set; }

        [DataLookUp]
        [Display(Name = "School")]
        [DatabaseField]
        [DetailViewItem(IsTextArea = true, TabName = "Education")]
        public string School { get; set; }

        [DataLookUp]
        [Display(Name = "Course")]
        [DatabaseField]
        [DetailViewItem(IsTextArea = true, TabName = "Education")]
        public string Course { get; set; }

        [Display(Name = "Year Graduated")]
        [DatabaseField]
        [DetailViewItem(TabName = "Education")]
        public string YearGraduated { get; set; }

        [Display(Name = "Work Email")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact")]
        public string WorkEmailAddress { get; set; }

        [Display(Name = "Personal Email")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact", Column = 2)]
        public string PersonalEmailAddress { get; set; }

        [Display(Name = "Social Media")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact", Column = 2)]
        public string SocialMedia { get; set; }

        [Display(Name = "Telephone")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact", Column = 2)]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Mobile")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Contact")]
        public string MobileNumber { get; set; }

        [Display(Name = "Mobile 2")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Contact")]
        public string MobileNumber2 { get; set; }

        [Display(Name = "Current Address")]
        [DatabaseField(IsRequired = true,IsProperCase=true)]
        [DetailViewItem(TabName = "Contact", IsTextArea = true)]
        public string CurrentAddress { get; set; }

        [DataLookUp(WithAdd=true)]
        [Display(Name = "City")]
        [DatabaseField(Name = "CityRefNo", RefModel = typeof(City), RefField = "Description", RefAlias = "City", RefTableAlias = "Cit")]
        [DetailViewItem(TabName = "Contact")]
        public int CityRefNo { get; set; }

        [Display(Name = "Permanent Address")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "Contact", IsTextArea = true, Column = 2)]
        public string ProvinceAddress { get; set; }

        [Display(Name = "Emergency Name")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "Contact")]
        public string EmergencyName1 { get; set; }

        [Display(Name = "Emergency Address")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "Contact")]
        public string EmergencyAddress1 { get; set; }

        [Display(Name = "Emergency Contact")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact")]
        public string EmergencyContactNo1 { get; set; }

        [Display(Name = "Relationship")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact")]
        public string EmergencyRelationship1 { get; set; }

        [Display(Name = "Emergency Name")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "Contact", Column = 2)]
        public string EmergencyName2 { get; set; }

        [Display(Name = "Emergency Address")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "Contact", Column = 2)]
        public string EmergencyAddress2 { get; set; }

        [Display(Name = "Emergency Contact")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact", Column = 2)]
        public string EmergencyContactNo2 { get; set; }

        [Display(Name = "Relationship")]
        [DetailViewItem(TabName = "Contact", Column = 2)]
        [DatabaseField(IsProperCase = true)]
        public string EmergencyRelationship2 { get; set; }

        [Display(Name = "TIN No.")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Government ID")]
        public string TinNumber { get; set; }

        [Display(Name = "PHILHEALTH No.")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Government ID")]
        public string PhilHealthNumber { get; set; }

        [Display(Name = "SSS No.")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Government ID")]
        public string SSSNumber { get; set; }

        [Display(Name = "PAGIBIG No.")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Government ID")]
        public string PagibigNumber { get; set; }

        [DataLookUp]
        [Display(Name = "Malayan Coverage")]
        [DatabaseField(Name = "MalayanCoverageRefNo", RefModel = typeof(GroupInsurance), RefField = "Description", RefAlias = "MC", RefTableAlias = "MC")]
        [DetailViewItem(TabName = "Government ID")]
        public int MalayanCoverageRefNo { get; set; }

        [Display(Name = "Maxicare Policy")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Government ID")]
        public string MaxicarePolicyNo { get; set; }

        [Display(Name = "Maxicare Card")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Government ID")]
        public string MaxicareCardNo { get; set; }

        [DatabaseField(AllowInsert = false,DefaultValue="0")]
        public bool IsNew { get; set; }

        [DetailViewItem(TabName = "Dependents", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo")]
        public List<Dependents> EmployeeDependents { get; set; }

        [DetailViewItem(TabName = "Offense", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo")]
        public List<EmployeeOffense> EmployeeOffense { get; set; }

        [DetailViewItem(TabName = "Benefits", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo")]
        public List<OtherBenefits> OtherBenefits { get; set; }

        [DetailViewItem(TabName = "Employment History", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo")]
        public List<EmpHistoryInternal> EmpHistory { get; set; }
        
    }
}