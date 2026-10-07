using System;
using System.Collections.Generic;
using System.Linq;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;


namespace WCORE.Models
{
    [MenuDescription(Name = "External Employee", SubName = "Floating")]
    [DatabaseTable(Name = "View_ExternalEmployee_Floating")]
    public class ExtFloatingEmployee : BaseObject
    {
        [DatabaseField(AllowUpdate = false)]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "Employee #")]
        [DatabaseField(AllowUpdate = false)]
        [ListViewColumn(Width = 100)]
        [DetailViewItem(IsEnabled = false, Column = 2)]
        public string EmployeeNumber { get; set; }

        [Display(Name = "Biometric ID")]
        [DatabaseField]
        [DetailViewItem(Column = 2)]
        public string BiometricID { get; set; }

        [Display(Name = "Employee Name")]
        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        [DetailViewItem(Column = 2)]
        public string Description { get; set; }

        //[Display(Name = "Status")]
        //[DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false, Name = "EmploymentStatusRefNo", RefModel = typeof(EmploymentStatus), RefField = "Description", RefAlias = "ES", RefTableAlias = "E")]
        //[ListViewColumn(Width=150)]
        //public int EmploymentStatusRefNo { get; set; }

        [Display(Name = "Position")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn(Width = 150)]
        public int JobPosition { get; set; }

        [Display(Name = "Job Band")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn(Width = 150)]
        public int JobBand { get; set; }

        //[DataLookUp]
        //[Display(Name = "Department")]
        //[ListViewColumn(Width=300)]
        //[DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false, Name = "DepartmentRefNo", RefModel = typeof(Department), RefField = "Description", RefAlias = "DEP", RefTableAlias = "DP")]
        //public int DepartmentRefNo { get; set; }

        //[Display(Name = "Date Hired")]
        //[ListViewColumn(Width=100)]
        //[DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        //public DateTime DateHired { get; set; }

        //[Display(Name = "Gross")]
        //[DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        //[ListViewColumn(Width = 150)]
        //public int BasicRate { get; set; }

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
        [DatabaseField(IsRequired = true, Name = "CivilStatusRefNo", RefModel = typeof(CivilStatus), RefField = "Description", RefAlias = "CivilStatus", RefTableAlias = "CS")]
        [DetailViewItem(Column = 2)]
        public int CivilStatusRefNo { get; set; }

        [Display(Name = "Birth Date")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem]
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
        [DatabaseField(Name = "NationalityRefNo", RefModel = typeof(Nationality), RefField = "Description", RefAlias = "Nationality", RefTableAlias = "NAT")]
        [DetailViewItem(Column = 2)]
        public int NationalityRefNo { get; set; }

        [DataLookUp(IsJson = true)]
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

        [DataLookUp(IsJson = true)]
        [Display(Name = "Blood Type")]
        [DatabaseField(Name = "BloodtypeRefNo", RefModel = typeof(BloodType), RefField = "Description", RefAlias = "BloodType", RefTableAlias = "BT")]
        [DetailViewItem(Column = 2)]
        public int BloodtypeRefNo { get; set; }

        [DatabaseField]
        [DetailViewItem(Column = 2, IsTextArea = true)]
        public string Allergies { get; set; }

        [Display(Name = "Primary Email")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact")]
        public string  PersonalEmailAddress { get; set; }

        [Display(Name = "Secondary Email")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact")]
        public string WorkEmailAddress { get; set; }

        [Display(Name = "Primary Mobile")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Contact")]
        public string MobileNumber { get; set; }

        [Display(Name = "Secondary Mobile")]
        [DatabaseField]
        [DetailViewItem(TabName = "Contact")]
        public string MobileNumber2 { get; set; }

        [Display(Name = "Permanent Address - Lt No/Blk/Rm/House/St")]
        [DatabaseField(IsProperCase = true, IsRequired = true)]
        [DetailViewItem(TabName = "Contact", IsTextArea = true)]
        public string PermanentAddress { get; set; }

        //[DataLookUp]
        //[Display(Name = "Permanent Region")]
        //[DatabaseField(Name = "PermanentRegionRefNo", IsRequired = true, RefModel = typeof(Region), RefField = "Description", RefAlias = "City", RefTableAlias = "Cit")]
        //[DetailViewItem(TabName = "Contact")]
        //public int PermanentRegionRefNo { get; set; }

        [Display(Name = "Permanent Region")]
        [DatabaseField(IsProperCase = true, IsRequired = true)]
        [DetailViewItem(TabName = "Contact", IsEnabled = false)]
        public string PermanentRegion { get; set; }

        //[DataLookUp]
        //[Display(Name = "Permanent Province")]
        //[DatabaseField(Name = "PermanentProvinceRefNo", IsRequired = true, RefModel = typeof(Province), RefField = "Description", RefAlias = "City", RefTableAlias = "Cit")]
        //[DetailViewItem(TabName = "Contact")]
        //public int PermanentProvinceRefNo { get; set; }

        [Display(Name = "Permanent Province")]
        [DatabaseField(IsProperCase = true, IsRequired = true)]
        [DetailViewItem(TabName = "Contact", IsEnabled = false)]
        public string PermanentProvince { get; set; }

        //[DataLookUp]
        //[Display(Name = "Permanent Municipality")]
        //[DatabaseField(Name = "PermanentMunicipalityRefNo", IsRequired = true, RefModel = typeof(City), RefField = "Description", RefAlias = "City", RefTableAlias = "Cit")]
        //[DetailViewItem(TabName = "Contact")]
        //public int PermanentMunicipalityRefNo { get; set; }

        [Display(Name = "Permanent Municipality")]
        [DatabaseField(IsProperCase = true, IsRequired = true)]
        [DetailViewItem(TabName = "Contact", IsEnabled = false)]
        public string PermanentMunicipality { get; set; }

        //[DataLookUp]
        //[Display(Name = "Permanent Barangay")]
        //[DatabaseField(Name = "PermanentBrgyRefNo", IsRequired = true, RefModel = typeof(Barangay), RefField = "Description", RefAlias = "City", RefTableAlias = "Cit")]
        //[DetailViewItem(TabName = "Contact")]
        //public int PermanentBrgyRefNo { get; set; }

        [Display(Name = "Permanent Barangay")]
        [DatabaseField(IsProperCase = true, IsRequired = true)]
        [DetailViewItem(TabName = "Contact", IsEnabled = false)]
        public string PermanentBarangay { get; set; }


        [Display(Name = "Present Address - Lt No/Blk/Rm/House/St")]
        [DatabaseField(IsRequired = true, IsProperCase = true)]
        [DetailViewItem(TabName = "Contact")]
        public string CurrentAddress { get; set; }

        //[DataLookUp]
        //[Display(Name = "Present Region")]
        //[DatabaseField(Name = "RegionRefNo", IsRequired = true, RefModel = typeof(Region), RefField = "Description", RefAlias = "City", RefTableAlias = "Cit")]
        //[DetailViewItem(TabName = "Contact")]
        //public int RegionRefNo { get; set; }

        [Display(Name = "Present Region")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "Contact", IsEnabled = false)]
        public string Region { get; set; }

        //[DataLookUp]
        //[Display(Name = "Present Province")]
        //[DatabaseField(Name = "ProvinceRefNo", IsRequired = true, RefModel = typeof(Province), RefField = "Description", RefAlias = "City", RefTableAlias = "Cit")]
        //[DetailViewItem(TabName = "Contact")]
        //public int ProvinceRefNo { get; set; }

        [Display(Name = "Present Province")]
        [DatabaseField(IsProperCase = true, IsRequired = true)]
        [DetailViewItem(TabName = "Contact", IsEnabled = false)]
        public string Province { get; set; }

        //[DataLookUp]
        //[Display(Name = "Present Municipality")]
        //[DatabaseField(Name = "MunicipalityRefNo", IsRequired = true, RefModel = typeof(City), RefField = "Description", RefAlias = "City", RefTableAlias = "Cit")]
        //[DetailViewItem(TabName = "Contact")]
        //public int MunicipalityRefNo { get; set; }

        [Display(Name = "Present Municipality")]
        [DatabaseField(IsProperCase = true, IsRequired = true)]
        [DetailViewItem(TabName = "Contact", IsEnabled = false)]
        public string Municipality { get; set; }

        //[DataLookUp]
        //[Display(Name = "Present Barangay")]
        //[DatabaseField(Name = "BrgyRefNo", IsRequired = true, RefModel = typeof(Barangay), RefField = "Description", RefAlias = "City", RefTableAlias = "Cit")]
        //[DetailViewItem(TabName = "Contact")]
        //public int BrgyRefNo { get; set; }

        [Display(Name = "Present Barangay")]
        [DatabaseField(IsProperCase = true, IsRequired = true)]
        [DetailViewItem(TabName = "Contact", IsEnabled = false)]
        public string Barangay { get; set; }

        //[Display(Name = "Complete Present Address")]
        //[DatabaseField(AllowUpdate = false)]
        //[DetailViewItem(TabName = "Contact", IsEnabled = false)]
        //public string PresentCompleteAddress { get; set; }

        [Display(Name = "Emergency Name")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "Emergency Contact")]
        public string EmergencyName1 { get; set; }

        [Display(Name = "Emergency Address")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "Emergency Contact")]
        public string EmergencyAddress1 { get; set; }

        [Display(Name = "Emergency Contact")]
        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact")]
        public string EmergencyContactNo1 { get; set; }

        [Display(Name = "Relationship")]
        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact")]
        public string EmergencyRelationship1 { get; set; }

        [Display(Name = "Emergency Name 2")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "Emergency Contact 2", Column = 2)]
        public string EmergencyName2 { get; set; }

        [Display(Name = "Emergency Address 2")]
        [DatabaseField(IsProperCase = true)]
        [DetailViewItem(TabName = "Emergency Contact 2", Column = 2)]
        public string EmergencyAddress2 { get; set; }

        [Display(Name = "Emergency Contact 2")]
        [DatabaseField]
        [DetailViewItem(TabName = "Emergency Contact 2", Column = 2)]
        public string EmergencyContactNo2 { get; set; }

        [Display(Name = "Relationship 2")]
        [DetailViewItem(TabName = "Emergency Contact 2", Column = 2)]
        [DatabaseField(IsProperCase = true)]
        public string EmergencyRelationship2 { get; set; }

        [Display(Name = "TIN")]
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
        [Display(Name = "Field of Work")]
        [DatabaseField(Name = "FOWRefNo", AllowUpdate = false, RefModel = typeof(FOW), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET", IsRequired = true)]
        [DetailViewItem(TabName = "Employment", IsEnabled = false)]
        public int FOWRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Employee Type")]
        [DatabaseField(Name = "EmployeeTypeRefNo", AllowUpdate = false, RefModel = typeof(EmployeeType), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET", IsRequired = true)]
        [DetailViewItem(TabName = "Employment", IsEnabled = false)]
        public int EmployeeTypeRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Employement Status")]
        [DatabaseField(Name = "EmploymentStatusRefNo", AllowUpdate = false, RefModel = typeof(EmploymentStatus), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET", IsRequired = true)]
        [DetailViewItem(TabName = "Employment", IsEnabled = false)]
        public int EmploymentStatusRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Department")]
        [DatabaseField(Name = "DepartmentRefNo", AllowUpdate = false, RefModel = typeof(Department), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET")]
        [DetailViewItem(TabName = "Employment", IsEnabled = false)]
        public int DepartmentRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Job Band")]
        [DatabaseField(Name = "JobBandRefNo", AllowUpdate = false, RefModel = typeof(JobBand), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET")]
        [DetailViewItem(TabName = "Employment", IsEnabled = false)]
        public int JobBandRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Job Position")]
        [DatabaseField(Name = "JobPositionRefNo", AllowUpdate = false, RefModel = typeof(JobPosition), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET", IsRequired = true)]
        [DetailViewItem(TabName = "Employment", IsEnabled = false)]
        public int JobPositionRefNo { get; set; }

        [Display(Name = "Technical Skills")]
        [DatabaseField(AllowUpdate = false)]
        [DetailViewItem(TabName = "Employment", IsEnabled = false)]
        public string Skills { get; set; }

        [Display(Name = "Date Hired")]
        [ListViewColumn(Width = 100)]
        [DatabaseField(AllowUpdate = false, IsRequired = true)]
        [DetailViewItem(TabName = "Employment", IsEnabled = false)]
        public DateTime DateHired { get; set; }

        [Display(Name = "Remarks")]
        [DatabaseField]
        [ListViewColumn(Width = 100)]
        [DetailViewItem(TabName = "Employment")]
        public string Remarks { get; set; }

        [Display(Name = "Start Date")]
        [ListViewColumn(Width = 100)]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Employment")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [ListViewColumn(Width = 100)]
        [DatabaseField]
        [DetailViewItem(TabName = "Employment")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Contractual Date")]
        [ListViewColumn(Width = 100)]
        [DatabaseField]
        [DetailViewItem(TabName = "Employment")]
        public DateTime ContractualDate { get; set; }

        [Display(Name = "Probationary Start Date")]
        [ListViewColumn(Width = 100)]
        [DatabaseField]
        [DetailViewItem(TabName = "Employment")]
        public DateTime DateProbationary { get; set; }

        [Display(Name = "Date Regularized")]
        [ListViewColumn(Width = 100)]
        [DatabaseField]
        [DetailViewItem(TabName = "Employment")]
        public DateTime DateRegularized { get; set; }

        [Display(Name = "Last Day of Employment")]
        [ListViewColumn(Width = 100)]
        [DatabaseField]
        [DetailViewItem(TabName = "Employment")]
        public DateTime LastDateofEmployment { get; set; }

        [DataLookUp]
        [Display(Name = "Reason Seperation")]
        [DatabaseField(Name = "ReasonForSeperationRefNo", RefModel = typeof(ReasonForSeperation), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET")]
        [DetailViewItem(TabName = "Employment")]
        public int ReasonForSeperationRefNo { get; set; }

        [Display(Name = "Other Reason")]
        [DatabaseField]
        [ListViewColumn(Width = 100)]
        [DetailViewItem(TabName = "Employment")]
        public string ReasonForSeparation { get; set; }

        [Display(Name = "Is With Clearance?")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false, TabName = "Employment")]
        public bool IsWithClearance { get; set; }

        [Display(Name = "Is For Re-Hire?")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false, TabName = "Employment")]
        public bool IsForReHire { get; set; }


        [Display(Name = "Job Description")]
        [DatabaseField]
        [ListViewColumn(Width = 200)]
        [DetailViewItem(TabName = "Job Description", IsTextEditor = true)]
        public string JobDescription { get; set; }

        [DataLookUp]
        [Display(Name = "Work Schedule")]
        [DatabaseField(Name = "WorkScheduleRefNo", RefModel = typeof(WorkSchedule), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET")]
        [DetailViewItem(TabName = "Payroll", IsEnabled = false)]
        public int WorkScheduleRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Payroll Parameter")]
        [DatabaseField(Name = "PayrollParameterRefNo", RefModel = typeof(PayrollParameter), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET",IsRequired = true)]
        [DetailViewItem(TabName = "Payroll", IsEnabled = false)]
        public int PayrollParameterRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Payroll Rate")]
        [DatabaseField(Name = "PayrollRateRefNo", RefModel = typeof(PayrollRate), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET", IsRequired = true)]
        [DetailViewItem(TabName = "Payroll", IsEnabled = false)]
        public int PayrollRateRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Frequency")]
        [DatabaseField(Name = "PayFrequencyRefNo", RefModel = typeof(Frequency), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET", IsRequired = true)]
        [DetailViewItem(TabName = "Payroll", IsEnabled = false)]
        public int PayFrequencyRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Pay Basis")]
        [DatabaseField(Name = "PayBasisRefNo", RefModel = typeof(PayBasis), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET", IsRequired = true)]
        [DetailViewItem(TabName = "Payroll", IsEnabled = false)]
        public int PayBasisRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Tax Status")]
        [DatabaseField(Name = "TaxStatusRefNo", RefModel = typeof(TaxStatus), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET", IsRequired = true)]
        [DetailViewItem(TabName = "Payroll", IsEnabled = false)]
        public int TaxStatusRefNo { get; set; }

        [Display(Name = "Basic Rate")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn(Width = 200)]
        [DetailViewItem(TabName = "Payroll", IsEnabled = false)]
        public int BasicRate { get; set; }

        [Display(Name = "Client Rate")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn(Width = 200)]
        [DetailViewItem(TabName = "Payroll", IsEnabled = false)]
        public int ClientRate { get; set; }

        [Display(Name = "Non-Tax Allowance")]
        [DatabaseField]
        [ListViewColumn(Width = 200)]
        [DetailViewItem(TabName = "Payroll", IsEnabled = false)]
        public int NonTaxAllowance { get; set; }

        [DataLookUp]
        [Display(Name = "Ecola Computation")]
        [DatabaseField(Name = "EcolaComputationRefNo", RefModel = typeof(ECOLAComputation), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET")]
        [DetailViewItem(TabName = "Payroll", IsEnabled = false)]
        public int EcolaComputationRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Ecola Rate")]
        [DatabaseField(Name = "EcolaRateRefNo", RefModel = typeof(EcolaRate), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET")]
        [DetailViewItem(TabName = "Payroll", IsEnabled = false)]
        public int EcolaRateRefNo { get; set; }

        [Display(Name = "HDMF Personal Contribution")]
        [DatabaseField]
        [ListViewColumn(Width = 200)]
        [DetailViewItem(TabName = "Payroll", IsEnabled = false)]
        public int HDMFAddCont { get; set; }

        [DataLookUp]
        [Display(Name = "Bank")]
        [DatabaseField(Name = "BankRefNo", RefModel = typeof(Bank), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET", IsRequired = true)]
        [DetailViewItem(TabName = "Payroll")]
        public int BankRefNo { get; set; }

        [Display(Name = "Account #")]
        [DatabaseField(IsRequired = true)]
        [ListViewColumn(Width = 200)]
        [DetailViewItem(TabName = "Payroll")]
        public string AccountNo { get; set; }

        [DataLookUp]
        [Display(Name = "Group life Coverage")]
        [DatabaseField(Name = "MalayanCoverageRefNo", RefModel = typeof(GroupInsurance), RefField = "Description", RefAlias = "GI", RefTableAlias = "GI")]
        [DetailViewItem(TabName = "Insurance & HMO")]
        public int MalayanCoverageRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Maxicare Coverage")]
        [DatabaseField(Name = "MalayanCoverageRefNo", RefModel = typeof(MaxicareCoverage), RefField = "Description", RefAlias = "MC", RefTableAlias = "MC")]
        [DetailViewItem(TabName = "Insurance & HMO")]
        public int MaxicareRefNo { get; set; }

        [Display(Name = "Maxicare Card #")]
        [DatabaseField]
        [DetailViewItem(TabName = "Insurance & HMO")]
        public string MaxicareCardNo { get; set; }

        [DetailViewItem(TabName = "Highest Education", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "10335")]
        public List<HighestEducation> employeehighesteducation { get; set; }

        [DetailViewItem(TabName = "Dependents", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "10330")]
        public List<Dependents> employeedependents { get; set; }

        [DetailViewItem(TabName = "Disciplinary Action", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "10380")]
        public List<EmployeeOffense> employeeoffense { get; set; }


        [DetailViewItem(TabName = "Employee Training", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "11036")]
        public List<Training> training { get; set; }

        [DetailViewItem(TabName = "Benefits", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "10320")]
        public List<OtherBenefits> otherbenefits { get; set; }

        [DetailViewItem(TabName = "Other Benefits", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "11020")]
        public List<OtherBenefits2> otherbenefits2 { get; set; }

        [DetailViewItem(TabName = "Cost", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "10425")]
        public List<OtherCost> OtherCost { get; set; }

        [DetailViewItem(TabName = "Employment Movement", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "10390")]
        public List<EmpHistoryInternal> emphistory { get; set; }

        //[DetailViewItem(TabName = "Disciplinary Action", IsDiffSave = true)]
        //[DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "11035")]
        //public List<DisciplinaryAction> diciplinaryaction { get; set; }

    }
}