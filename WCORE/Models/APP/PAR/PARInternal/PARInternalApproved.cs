using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Personnel Action Request", SubName = "Internal")]
    [DatabaseTable(Name = "PIS_PAR", ViewName = "dbo.fSelectPAR_Internal(@User,@Roles,7,1)")]
    public partial class PARInternalApproved : BaseObject
    {
        [DataLookUp]
        [Display(Name = "Employee")]
        [DatabaseField(IsRequired = true, Name = "EmployeeRefNo", RefModel = typeof(AllEmployee), RefField = "Description", RefAlias = "EMP", RefTableAlias = "EMP")]
        [DetailViewItem]
        [ListViewColumn]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "Date Submitted")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn]
        public DateTime SubmittedDate { get; set; }

        [ListViewColumn]
        [DatabaseField(AllowInsert = false, AllowUpdate = false, NotInTable = true)]
        public string Reason { get; set; }

        [DataLookUp]
        [Display(Name = "Reason for Change")]
        [DatabaseField(Name = "ReasonForChangeRefNo", RefModel = typeof(ReasonForChange), RefField = "Description", RefAlias = "RC", RefTableAlias = "RC")]
        [DetailViewItem]
        public int ReasonForChangeRefNo { get; set; }

        [Display(Name = "Other Reason")]
        [DatabaseField]
        [DetailViewItem]
        public string OtherReason { get; set; }

        [Display(Name = "Justification")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        public string Justification { get; set; }

        [Display(Name = "Effectivity Date")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(strFormat = "mm/dd/yyyy")]
        [ListViewColumn]
        public DateTime EffectivityDate { get; set; }

        [DataLookUp]
        [Display(Name = "Contract Template")]
        [DetailViewItem]
        [ListViewColumn]
        [DatabaseField(IsRequired = true, Name = "ContractTemplateRefNo", RefModel = typeof(ContractTemplate_INT), RefField = "Description", RefAlias = "ContractTemplate", RefTableAlias = "CT")]
        public int ContractTemplateRefNo { get; set; }

        [DatabaseField]
        [DetailViewItem(IsTextArea = true)]
        public string Remarks { get; set; }

        [DataLookUp]
        [Display(Name = "Rank Level")]
        [DetailViewItem(IsTextArea = true, TabName = "Employment Information")]
        [DatabaseField(IsRequired = true, Name = "EmployeeTypeRefNo", RefModel = typeof(EmployeeType), RefField = "Description", RefAlias = "EType", RefTableAlias = "ET")]
        public int EmployeeTypeRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Employment Status")]
        [DetailViewItem(IsTextArea = true, TabName = "Employment Information")]
        [DatabaseField(IsRequired = true, Name = "EmploymentStatusRefNo", RefModel = typeof(EmploymentStatus), RefField = "Description", RefAlias = "ESM", RefTableAlias = "ESM")]
        public int EmploymentStatusRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Department")]
        [DetailViewItem(TabName = "Employment Information")]
        [DatabaseField(IsRequired = true, Name = "DepartmentRefNo", RefModel = typeof(Department), RefField = "Description", RefAlias = "Department", RefTableAlias = "Dep")]
        public int DepartmentRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Job Band")]
        [DetailViewItem(TabName = "Employment Information")]
        [DatabaseField(IsRequired = true, Name = "JobBandRefNo", RefModel = typeof(JobBand), RefField = "Description", RefAlias = "JobBand", RefTableAlias = "JB")]
        public int JobBandRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Job Band")]
        [DetailViewItem(TabName = "Employment Information")]
        [DatabaseField(IsRequired = true, Name = "JobPositionRefNo", RefModel = typeof(JobPosition), RefField = "Description", RefAlias = "JobPosition", RefTableAlias = "JP")]
        public int JobPositionRefNo { get; set; }

        [Display(Name = "Hiring Date")]
        [DatabaseField]
        [DetailViewItem(TabName = "Employment Information", Column = 2, strFormat = "mm/dd/yyyy")]
        public DateTime DateHired { get; set; }

        [Display(Name = "Start Date")]
        [DatabaseField]
        [DetailViewItem(TabName = "Employment Information", Column = 2, strFormat = "mm/dd/yyyy")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DatabaseField]
        [DetailViewItem(TabName = "Employment Information", Column = 2, strFormat = "mm/dd/yyyy")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Contractual Date")]
        [DatabaseField]
        [DetailViewItem(TabName = "Employment Information", Column = 2, strFormat = "mm/dd/yyyy")]
        public DateTime ContractualDate { get; set; }

        [Display(Name = "Date Probationary")]
        [DatabaseField]
        [DetailViewItem(TabName = "Employment Information", Column = 2, strFormat = "mm/dd/yyyy")]
        public DateTime DateProbationary { get; set; }

        [Display(Name = "Date Regularized")]
        [DatabaseField]
        [DetailViewItem(TabName = "Employment Information", Column = 2, strFormat = "mm/dd/yyyy")]
        public DateTime DateRegularized { get; set; }

        [DataLookUp]
        [Display(Name = "Payroll Rate")]
        [DetailViewItem(TabName = "Payroll Information")]
        [DatabaseField(IsRequired = true, Name = "PayrollRateRefNo", RefModel = typeof(PayrollRate), RefField = "Description", RefAlias = "PR", RefTableAlias = "PR")]
        public int PayrollRateRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Pay Basis")]
        [DetailViewItem(TabName = "Payroll Information")]
        [DatabaseField(IsRequired = true, Name = "PayBasisRefNo", RefModel = typeof(PayBasis), RefField = "Description", RefAlias = "PB", RefTableAlias = "PB")]
        public int PayBasisRefNo { get; set; }

        [Display(Name = "Basic Rate")]
        [DetailViewItem(TabName = "Payroll Information", Column = 2)]
        [DatabaseField(IsRequired = true)]
        public Decimal BasicRate { get; set; }

        [Display(Name = "Non-Tax Allowance")]
        [DetailViewItem(TabName = "Payroll Information", Column = 2)]
        [DatabaseField(IsRequired = true)]
        public Decimal NonTaxAllowance { get; set; }

        [DataLookUp]
        [Display(Name = "Ecola Computation")]
        [DetailViewItem(TabName = "Payroll Information")]
        [DatabaseField(Name = "EcolaComputationRefNo", RefModel = typeof(ECOLAComputation), RefField = "Description", RefAlias = "ECOM", RefTableAlias = "ECOM")]
        public int EcolaComputationRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "ECOLA Rate")]
        [DetailViewItem(TabName = "Payroll Information", Column = 2)]
        [DatabaseField(Name = "EcolaRateRefNo", RefModel = typeof(EcolaRate), RefField = "Description", RefAlias = "ER", RefTableAlias = "ER")]
        public int EcolaRateRefNo { get; set; }

        [Display(Name = "Job Description")]
        [DatabaseField]
        [DetailViewItem(IsTextEditor = true, TabName = "Job Description")]
        public string JobDescription { get; set; }


        [Display(Name = "Separation Pay")]
        [DatabaseField(DefaultValue = "0")]
        [DetailViewItem(TabName = "Benefits")]
        public bool SeparationPay { get; set; }

        [Display(Name = "13th Month")]
        [DatabaseField(DefaultValue = "0")]
        [DetailViewItem(TabName = "Benefits")]
        public bool T13ThMonth { get; set; }

        [Display(Name = "Holiday Pay")]
        [DatabaseField(DefaultValue = "0")]
        [DetailViewItem(TabName = "Benefits")]
        public bool HolidayPay { get; set; }

        [Display(Name = "HMO DC (Annual)")]
        [DetailViewItem(TabName = "Benefits")]
        [DatabaseField(DefaultValue = "12000")]
        public Decimal HMODC { get; set; }

        [Display(Name = "HMO Cov (Annual)")]
        [DetailViewItem(TabName = "Benefits")]
        [DatabaseField(DefaultValue = "60000")]
        public Decimal HMOAmount { get; set; }

        [Display(Name = "SIL")]
        [DetailViewItem(TabName = "Benefits")]
        [DatabaseField(DefaultValue = "5")]
        public Decimal SIL { get; set; }

        [Display(Name = "Additional Paid Leaves")]
        [DetailViewItem(TabName = "Benefits")]
        [DatabaseField]
        public Decimal AddtlPaidLeaves { get; set; }

        [Display(Name = "Pro Rata?")]
        [DatabaseField(DefaultValue = "0")]
        [DetailViewItem(TabName = "Benefits")]
        public bool APLProRata { get; set; }

        [Display(Name = "OT Assumption")]
        [DetailViewItem(TabName = "Benefits")]
        [DatabaseField]
        public Decimal OTAssumption { get; set; }

        [DatabaseField(DefaultValue = "1")]
        public int FilingStatusRefNo { get; set; }

        [DetailViewItem(TabName = "Benefits", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "11030")]
        public List<OtherBenefits> otherbenefits { get; set; }
    }
}
