using System;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;
using System.Web.Mvc;

namespace WCORE.Models
{
    [MenuDescription(Name="Employment Information")]
    [DatabaseTable(Name = "PIS_EmploymentInfo_U")]
    public class EIActiveEmployee : BaseObject
    {
       [DatabaseField(AllowUpdate=false)]
       public int EmployeeRefNo {get; set;}


       [DatabaseField(AllowUpdate = false, DefaultValue = "0")]
       public string EmployeeNumber { get; set; }

       [DataLookUp]
       [Display(Name = "Rank Level")]
       [DetailViewItem(TabName = "Employment")]
       [DatabaseField(DefaultValue = "5", Name = "EmployeeTypeRefNo", IsRequired = true, RefModel = typeof(EmployeeType), RefField = "Description", RefAlias = "ET", RefTableAlias = "ET")]
       public int EmployeeTypeRefNo { get; set; }

       [DatabaseField(DefaultValue = "2", AllowUpdate = false)]
       public int EmployeeGroupRefNo { get; set; }

       [DatabaseField(DefaultValue = "1", AllowUpdate = false)]
       public int EmployeeStatusRefNo { get; set; }

       [DataLookUp]
       [Display(Name = "Client")]
       [DetailViewItem(TabName = "Employment")]
       [DatabaseField(IsRequired = true, Name = "ClientAccountRefNo", RefModel = typeof(ClientAccount), RefField = "Description", RefAlias = "Client", RefTableAlias = "CL")]
       public int ClientAccountRefNo { get; set; }

       [DataLookUp]
       [Display(Name = "Field of Work")]
       [DetailViewItem(TabName = "Employment")]
       [DatabaseField(DefaultValue = "1", IsRequired = true, Name = "FOWRefNo", RefModel = typeof(FOW), RefField = "Description", RefAlias = "FW", RefTableAlias = "FOW")]
       public int FOWRefNo { get; set; }

       [Display(Name = "Client Address")]
       [DetailViewItem(TabName = "Employment")]
       [DatabaseField(IsRequired = true)]
       public string ClientAddress { get; set; }

       [Display(Name = "Position")]
       [DetailViewItem(TabName = "Employment")]
       [DatabaseField(IsRequired = true)]
       public string JobPosition { get; set; }

       [DatabaseField(IsRequired = true)]
       [DetailViewItem(IsTextArea = true)]
       public string Skills { get; set; }

       [DataLookUp]
       [Display(Name = "Employment Status")]
       [DetailViewItem(IsTextArea = true,TabName="Employment")]
       [DatabaseField(DefaultValue = "1", IsRequired = true, Name = "EmploymentStatusRefNo", RefModel = typeof(EmploymentStatus), RefField = "Description", RefAlias = "ESM", RefTableAlias = "ESM")]
       public int EmploymentStatusRefNo { get; set; }

       [Display(Name = "Date Hired")]
       [DetailViewItem(Column = 2, TabName = "Employment", strFormat = "mm/dd/yyyy")]
       [DatabaseField(IsRequired = true)]
       public DateTime DateHired { get; set; }

       [Display(Name = "Start Date")]
       [DetailViewItem(TabName = "Employment",strFormat="mm/dd/yyyy")]
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
       [DatabaseField(Name = "ReasonForSeperationRefNo", RefModel = typeof(ReasonForSeperation), RefField = "Description", RefAlias = "R", RefTableAlias = "R")]
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

       [DetailViewItem(TabName = "Payroll")]
       [DatabaseField(IsRequired = true)]
       public string WorkSchedule { get; set; }

       [DataLookUp]
       [Display(Name = "Payroll Parameter")]
       [DetailViewItem(TabName = "Payroll")]
       [DatabaseField(DefaultValue = "2", Name = "PayrollParameterRefNo", IsRequired = true, RefModel = typeof(PayrollParameter), RefField = "Description", RefAlias = "PM", RefTableAlias = "PM")]
       public int PayrollParameterRefNo { get; set; }

       [DataLookUp]
       [Display(Name = "Payroll Rate")]
       [DetailViewItem(TabName = "Payroll")]
       [DatabaseField(DefaultValue = "2", Name = "PayrollRateRefNo", IsRequired = true, RefModel = typeof(PayrollRate), RefField = "Description", RefAlias = "PR", RefTableAlias = "PR")]
       public int PayrollRateRefNo { get; set; }

       [DataLookUp]
       [Display(Name = "Frequency")]
       [DetailViewItem(TabName = "Payroll")]
       [DatabaseField(DefaultValue = "1", Name = "FrequencyRefNo", IsRequired = true, RefModel = typeof(Frequency), RefField = "Description", RefAlias = "FR", RefTableAlias = "FR")]
       public int PayFrequencyRefNo { get; set; }

       [DataLookUp]
       [Display(Name = "Pay Basis")]
       [DetailViewItem(TabName = "Payroll")]
       [DatabaseField(DefaultValue = "2", Name = "PayBasisRefNo", IsRequired = true, RefModel = typeof(PayBasis), RefField = "Description", RefAlias = "PB", RefTableAlias = "PB")]
       public int PayBasisRefNo { get; set; }

       [Display(Name = "Basic Rate")]
       [DetailViewItem(TabName = "Payroll", Column = 2)]
       [DatabaseField(IsRequired=true)]
       public Decimal BasicRate { get; set; }

       [Display(Name = "Client Rate")]
       [DetailViewItem(TabName = "Payroll", Column = 2)]
       [DatabaseField(IsRequired=true)]
       public Decimal ClientRate { get; set; }

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
       [DetailViewItem(TabName = "Payroll",Column=2)]
       [DatabaseField(Name = "EcolaRateRefNo", RefModel = typeof(EcolaRate), RefField = "Description", RefAlias = "ER", RefTableAlias = "ER")]
       public int EcolaRateRefNo { get; set; }

       
       [Display(Name = "HDMF Personal Contribution")]
       [DetailViewItem(TabName = "Payroll", Column = 2)]
       [DatabaseField]
       public Decimal HDMFAddCont { get; set; }

       [DataLookUp(WithAdd = true)]
       [Display(Name = "Bank")]
       [DetailViewItem(TabName = "Payroll", Column = 2)]
       [DatabaseField(DefaultValue = "3", Name = "BankRefNo", IsRequired = true, RefModel = typeof(Bank), RefField = "Description", RefAlias = "BNK", RefTableAlias = "BNK")]
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
       [DatabaseField(DefaultValue = "true")]
       public Boolean W13thMonth { get; set; }

       [Display(Name = "Holiday")]
       [DatabaseField(IsRequired = true, DefaultValue = "true")]
       [DetailViewItem(TabName = "Benefits")]
       public Boolean HOLTag { get; set; }

       [Display(Name = "Tax")]
       [DatabaseField(IsRequired = true, DefaultValue = "true")]
       [DetailViewItem(TabName = "Benefits", Column = 2)]
       public Boolean TaxTag { get; set; }

             [DatabaseField(DefaultValue = "0")]
       public Boolean PagibigPercent { get; set; }

       [DatabaseField]
       [DetailViewItem(TabName = "Benefits", IsEnabled = false)]
       public Decimal SIL { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Benefits", IsEnabled = false)]
        public Decimal AddtlPaidLeaves { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "Benefits", IsEnabled = false)]
        public bool APLProRata { get; set; }

       [DetailViewItem(TabName = "Benefits")]
       [DatabaseField(DefaultValue = "0")]
       public Decimal HMODC { get; set; }

       [DatabaseField(DefaultValue="0")]
       [DetailViewItem(TabName = "Benefits")]
       public Decimal HMOAmount { get; set; }

       [DatabaseField(DefaultValue="0")]
       [DetailViewItem]
       public Decimal OTAssumption { get; set; }

        [DatabaseField]
        [DetailViewItem(TabName = "ProjectName")]
        public string ProjectName { get; set; }

        [DatabaseField]
        [DetailViewItem(IsTextEditor = true, TabName = "ProjectName")]
        public string JobDescriptionPath { get; set; }

       [AllowHtml]
       [DatabaseField]
       [DetailViewItem(IsTextEditor = true, TabName = "JobDescription")]
       public string JobDescription { get; set; }

        [AllowHtml]
        [DatabaseField]
        [DetailViewItem(IsTextEditor = true, TabName = "Clause")]
        public string sclause { get; set; }
    }
}