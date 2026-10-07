using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;
using System.Web.Mvc;

namespace WCORE.Models
{
    [MenuDescription(Name="Employment Information")]
    [DatabaseTable(Name = "PIS_EmploymentInfo_U")]
    public class InactiveEmploymentInfoInternal : BaseObject
    {
        [DatabaseField(AllowUpdate=false)]
        public int EmployeeRefNo { get; set; }

        [DatabaseField(AllowUpdate = false, DefaultValue = "0")]
        public string EmployeeNumber { get; set; }

        [DataLookUp]
        [Display(Name = "Rank Level")]
        [DetailViewItem(TabName = "Employment")]
        [DatabaseField(Name = "EmployeeTypeRefNo", IsRequired = true, RefModel = typeof(EmployeeType), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET")]
        public int EmployeeTypeRefNo { get; set; }

        [DatabaseField(DefaultValue = "1", AllowUpdate = false)]
        public int EmployeeGroupRefNo { get; set; }

        [DatabaseField(DefaultValue = "1", AllowUpdate = false)]
        public int EmployeeStatusRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Job Band")]
        [DetailViewItem(TabName = "Employment")]
        [DatabaseField(IsRequired = true, Name = "JobBandRefNo", RefModel = typeof(JobBand), RefField = "Description", RefAlias = "JB", RefTableAlias = "JB")]
        public int JobBandRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Job Position")]
        [DetailViewItem(TabName = "Employment")]
        [DatabaseField(IsRequired = true, Name = "JobPositionRefNo", RefModel = typeof(JobPosition), RefField = "Description", RefAlias = "JP", RefTableAlias = "JP")]
        public int JobPositionRefNo { get; set; }

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        public string Skills { get; set; }

        [DataLookUp]
        [Display(Name = "Employment Status")]
        [DetailViewItem(IsTextArea = true, TabName = "Employment")]
        [DatabaseField(IsRequired = true, Name = "EmploymentStatusRefNo", RefModel = typeof(EmploymentStatus), RefField = "Description", RefAlias = "ESM", RefTableAlias = "ESM")]
        public int EmploymentStatusRefNo { get; set; }

        [DataLookUp(WithAdd = true)]
        [Display(Name = "Department")]
        [DetailViewItem(TabName = "Employment")]
        [DatabaseField(IsRequired = true, Name = "DepartmentRefNo", RefModel = typeof(Department), RefField = "Description", RefAlias = "DEP", RefTableAlias = "DEP")]
        public int DepartmentRefNo { get; set; }

        [Display(Name = "Date Hired")]
        [DetailViewItem(Column = 2, TabName = "Employment", strFormat = "mm/dd/yyyy")]
        [DatabaseField(IsRequired = true)]
        public DateTime DateHired { get; set; }

        [Display(Name = "Start Date")]
        [DetailViewItem(TabName = "Employment", strFormat = "mm/dd/yyyy")]
        [DatabaseField]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DetailViewItem(TabName = "Employment", strFormat = "mm/dd/yyyy")]
        [DatabaseField]
        public DateTime EndDate { get; set; }

        [Display(Name = "Contractual Date")]
        [DetailViewItem(Column = 2, TabName = "Employment", strFormat = "mm/dd/yyyy")]
        [DatabaseField(IsRequired = true)]
        public DateTime ContractualDate { get; set; }

        [Display(Name = "Date Probationary")]
        [DetailViewItem(Column = 2, TabName = "Employment", strFormat = "mm/dd/yyyy")]
        [DatabaseField]
        public DateTime DateProbationary { get; set; }

        [Display(Name = "Date Regularized")]
        [DetailViewItem(Column = 2, TabName = "Employment", strFormat = "mm/dd/yyyy")]
        [DatabaseField]
        public DateTime DateRegularized { get; set; }

        [Display(Name = "Last Day of Employment")]
        [DetailViewItem(Column = 2, TabName = "Separation Information", strFormat = "mm/dd/yyyy")]
        [DatabaseField]
        public DateTime LastDateOfEmployment { get; set; }

        [DataLookUp]
        [Display(Name = "Reason Of Seperation")]
        [DatabaseField(Name = "ReasonForSeparationRefNo", RefModel = typeof(ReasonForSeperation), RefField = "Description", RefAlias = "R", RefTableAlias = "R")]
        [DetailViewItem(Column = 2, TabName = "Separation Information")]
        public int ReasonForSeperationRefNo { get; set; }

        [Display(Name = "Other Reason")]
        [DetailViewItem(Column = 2, IsTextArea = true, TabName = "Separation Information")]
        [DatabaseField]
        public string ReasonForSeparation { get; set; }

        [Display(Name = "Is With Clearance?")]
        [DatabaseField]
        [DetailViewItem(Column = 2, TabName = "Separation Information")]
        public bool IsWithClearance { get; set; }

        [Display(Name = "Is For Re-Hire?")]
        [DatabaseField]
        [DetailViewItem(Column = 2, TabName = "Separation Information")]
        public bool IsForReHire { get; set; } 

        [DataLookUp]
        [Display(Name = "Work Schedule")]
        [DetailViewItem(TabName = "Payroll")]
        [DatabaseField(Name = "WorkScheduleRefNo", IsRequired = true, RefModel = typeof(WorkSchedule), RefField = "Description", RefAlias = "WS", RefTableAlias = "WS")]
        public int WorkScheduleRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Payroll Parameter")]
        [DetailViewItem(TabName = "Payroll")]
        [DatabaseField(Name = "PayrollParameterRefNo", IsRequired = true, RefModel = typeof(PayrollParameter), RefField = "Description", RefAlias = "PM", RefTableAlias = "PM")]
        public int PayrollParameterRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Payroll Rate")]
        [DetailViewItem(TabName = "Payroll")]
        [DatabaseField(Name = "PayrollRateRefNo", IsRequired = true, RefModel = typeof(PayrollRate), RefField = "Description", RefAlias = "PR", RefTableAlias = "PR")]
        public int PayrollRateRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Frequency")]
        [DetailViewItem(TabName = "Payroll")]
        [DatabaseField(Name = "FrequencyRefNo", IsRequired = true, RefModel = typeof(Frequency), RefField = "Description", RefAlias = "FR", RefTableAlias = "FR")]
        public int PayFrequencyRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Pay Basis")]
        [DetailViewItem(TabName = "Payroll")]
        [DatabaseField(Name = "PayBasisRefNo", IsRequired = true, RefModel = typeof(PayBasis), RefField = "Description", RefAlias = "PB", RefTableAlias = "PB")]
        public int PayBasisRefNo { get; set; }

        [Display(Name = "Basic Rate")]
        [DetailViewItem(TabName = "Payroll", Column = 2)]
        [DatabaseField(IsRequired = true)]
        public Decimal BasicRate { get; set; }

        [Display(Name = "Non-Tax Allowance")]
        [DetailViewItem(TabName = "Payroll", Column = 2)]
        [DatabaseField(IsRequired = true)]
        public Decimal NonTaxAllowance { get; set; }

        [DataLookUp(IsJson = true)]
        [Display(Name = "Tax Status")]
        [DetailViewItem(TabName = "Payroll")]
        [DatabaseField(Name = "TaxStatusRefNo", IsRequired = true, RefModel = typeof(TaxStatus), RefField = "Description", RefAlias = "TS", RefTableAlias = "TS")]
        public int TaxStatusRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Ecola Computation")]
        [DetailViewItem(TabName = "Payroll", Column = 2)]
        [DatabaseField(Name = "EcolaComputationRefNo", RefModel = typeof(ECOLAComputation), RefField = "Description", RefAlias = "ECOM", RefTableAlias = "ECOM")]
        public int EcolaComputationRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "ECOLA Rate")]
        [DetailViewItem(TabName = "Payroll", Column = 2)]
        [DatabaseField(Name = "EcolaRateRefNo", RefModel = typeof(EcolaRate), RefField = "Description", RefAlias = "ER", RefTableAlias = "ER")]
        public int EcolaRateRefNo { get; set; }


        [Display(Name = "HDMF Personal Contribution")]
        [DetailViewItem(TabName = "Payroll", Column = 2)]
        [DatabaseField]
        public Decimal HDMFAddCont { get; set; }

        [DataLookUp(WithAdd = true)]
        [Display(Name = "Bank")]
        [DetailViewItem(TabName = "Payroll", Column = 2)]
        [DatabaseField(Name = "BankRefNo", IsRequired = true, RefModel = typeof(Bank), RefField = "Description", RefAlias = "BNK", RefTableAlias = "BNK")]
        public int BankRefNo { get; set; }

        [Display(Name = "Account")]
        [DetailViewItem(TabName = "Payroll", Column = 2)]
        [DatabaseField]
        public string AccountNo { get; set; }

        [Display(Name = "Separation Pay")]
        [DetailViewItem(TabName = "Benefits")]
        [DatabaseField]
        public Boolean SEPTag { get; set; }

        [Display(Name = "13th Month")]
        [DetailViewItem(TabName = "Benefits", Column = 2)]
        [DatabaseField]
        public Boolean W13thMonth { get; set; }

        [Display(Name = "Holiday")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Benefits")]
        public Boolean HOLTag { get; set; }

        [Display(Name = "Tax")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Benefits", Column = 2)]
        public Boolean TaxTag { get; set; }

        [Display(Name = "PHILHEALTH")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Benefits", Column = 2)]
        public Boolean PHICTag { get; set; }

        [Display(Name = "SSS")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Benefits", Column = 2)]
        public Boolean SSSGSISTag { get; set; }

        [Display(Name = "PAGIBIG")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Benefits", Column = 2)]
        public Boolean PAGIBIGTag { get; set; }

        [DatabaseField(DefaultValue = "0", AllowUpdate = false)]
        public Boolean PagibigPercent { get; set; }

        [DatabaseField(DefaultValue = "0", AllowUpdate = false)]
        public Decimal SIL { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Benefits", IsEnabled = false)]
        public Decimal AddtlPaidLeaves { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Benefits", IsEnabled = false)]
        public bool APLProRata { get; set; }

        [DatabaseField(DefaultValue = "0", AllowUpdate = false)]
        public Decimal HMOAmount { get; set; }

        [DatabaseField(DefaultValue = "0", AllowUpdate = false)]
        public Decimal HMODC { get; set; }

        [AllowHtml]
        [Display(Name = "Job Description")]
        [DatabaseField]
        [ListViewColumn]
        [DetailViewItem(IsTextEditor = true, TabName = "JobDescription")]
        public string JobDescription { get; set; }
    }
}