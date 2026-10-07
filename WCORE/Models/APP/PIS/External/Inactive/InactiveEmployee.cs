using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name = "External Employee (Inactive)")]
    [DatabaseTable(Name = "PIS_Employee_U", ViewName = "dbo.fSelectEmployeeInactive()")]
    public class InactiveEmployee : BaseObject
    {
        [DatabaseField(AllowUpdate = false)]
        public int EmployeeRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "MR")]
        [ListViewColumn(Width = 25, Align = "C")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false, Name = "MRRefNo", RefModel = typeof(MarketingRep), RefField = "Description", RefAlias = "MR", RefTableAlias = "M")]
        public int MRRefNo { get; set; }

        [Display(Name = "Employee #")]
        [DatabaseField(AllowUpdate = false)]
        [ListViewColumn(Width = 70, Align = "C")]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public string EmployeeNumber { get; set; }

        [Display(Name = "Employee Name")]
        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn(Width = 150)]
        public string Description { get; set; }

        [Display(Name = "Status")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn(Width = 100, Align = "C")]
        public string EmploymentStatus { get; set; }

        [ListViewColumn(Width = 30, Align = "C")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        public string Type { get; set; }

        [Display(Name = "Position")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn(Width = 170)]
        public int JobPosition { get; set; }

        [DataLookUp]
        [Display(Name = "Client Account")]
        [ListViewColumn(Width = 230)]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false, Name = "ClientAccountRefNo", RefModel = typeof(ClientAccount), RefField = "Description", RefAlias = "CA", RefTableAlias = "C")]
        public int ClientAccountRefNo { get; set; }

        [Display(Name = "Hired Date")]
        [ListViewColumn(Align = "C", Width = 55)]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        public DateTime DateHired { get; set; }

        [Display(Name = "Start Date")]
        [ListViewColumn(Align = "C", Width = 55)]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [ListViewColumn(Align = "C", Width = 55)]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Last Name")]
        [DatabaseField(IsRequired = true, IsProperCase = true)]
        [DetailViewItem]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [DatabaseField(IsRequired = true, IsProperCase = true)]
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
        public string MobileNumber { get; set; }

        [Display(Name = "Mobile 2")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Contact", Column = 2, strFormat = "data-inputmask=`~mask~: ~9999-999-9999~` data-mask")]
        public string MobileNumber2 { get; set; }

        [Display(Name = "Personal Email Address")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact", Column = 2)]
        public string PersonalEmailAddress { get; set; }

        [Display(Name = "Work Email Address")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact")]
        public string WorkEmailAddress { get; set; }

        [Display(Name = "Current Address")]
        [DatabaseField(IsRequired = true, IsProperCase = true)]
        [DetailViewItem(TabName = "Contact", IsTextArea = true)]
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

        [Display(Name = "UCPB Policy")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "HealthCard")]
        public String UCPBPolicyNo { get; set; }

        [Display(Name = "UCPB Card")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "HealthCard")]
        public string UCPBCardNo { get; set; }

        [Display(Name = "Is Cleared")]
        [ListViewColumn(Align = "C", Width = 55)]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        public bool IsWithClearance { get; set; }

        [Display(Name = "For Re-Hire")]
        [ListViewColumn(Align = "C", Width = 55)]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        public bool IsForReHire { get; set; }

        [DetailViewItem(TabName = "Dependents", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo", ModelNo = "10230")]
        public List<Dependents> EmployeeDependents { get; set; }

        [DetailViewItem(TabName = "Offense", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo", ModelNo = "10280")]
        public List<EmployeeOffense> EmployeeOffense { get; set; }

        [DetailViewItem(TabName = "Benefits", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo", ModelNo = "10220")]
        public List<OtherBenefits> OtherBenefits { get; set; }

        [DetailViewItem(TabName = "Cost", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo", ModelNo = "10225")]
        public List<OtherCost> OtherCost { get; set; }

        [DetailViewItem(TabName = "Performance Evaluation", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo", ModelNo = "10270")]
        public List<Performance> EmployeePerformance { get; set; }

        [DetailViewItem(TabName = "Training", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo", ModelNo = "10260")]
        public List<Training> EmployeeTraining { get; set; }

        [DetailViewItem(TabName = "Accountability", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo", ModelNo = "10240")]
        public List<Accountability> EmployeeAccountability { get; set; }

        [DetailViewItem(TabName = "EmpRequirements", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo", ModelNo = "10250")]
        public List<PreRequirements> EmployeePreRequirements { get; set; }

        [DetailViewItem(TabName = "Employment Movement", IsDiffSave = true)]
        [DBCollection(ForeignKey = "EmployeeRefNo", ForeignKeyValue = "EmployeeRefNo", ModelNo = "10290")]
        public List<EmpHistory> EmpHistory { get; set; }

    }
}