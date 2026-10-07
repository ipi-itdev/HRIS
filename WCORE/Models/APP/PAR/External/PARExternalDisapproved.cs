using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;
using System.Web.Mvc;

namespace WCORE.Models
{
    [MenuDescription(Name = "Personnel Action Request", SubName = "External")]
    //ViewName = "dbo.fSelectPAR_ExternalRequest(@User,@Roles)"
    [DatabaseTable(Name = "PIS_PAR")]
    public partial class PARExternalDisapproved : BaseObject
    {
        //[DatabaseField(NotInTable=true,AllowInsert=false,AllowUpdate=false)]
        //[ListViewColumn(Width=10)]
        //public string MR { get; set; }

        [DataLookUp]
        [Display(Name = "Employee")]
        [DatabaseField(IsRequired = true, Name = "EmployeeRefNo", RefModel = typeof(ActiveFloatingEmployee), RefField = "Description", RefAlias = "EMP", RefTableAlias = "EMP")]
        [DetailViewItem]
        [ListViewColumn(Width = 200)]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "Date Submitted")]
        [DatabaseField]
        [DetailViewItem(IsEnabled = false)]
        [ListViewColumn(Width = 100)]
        public DateTime SubmittedDate { get; set; }

        [ListViewColumn(Width = 150)]
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

        [DatabaseField(IsRequired = true)]
        [DetailViewItem(IsTextArea = true)]
        public string Justification { get; set; }

        [Display(Name = "Effectivity Date")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(strFormat = "mm/dd/yyyy")]
        [ListViewColumn(Width = 100)]
        public DateTime EffectivityDate { get; set; }

        [DataLookUp]
        [Display(Name = "Contract Template")]
        [DetailViewItem]
        [ListViewColumn(Width = 200)]
        [DatabaseField(IsRequired = true, Name = "ContractTemplateRefNo", RefModel = typeof(ContractTemplate_EXT), RefField = "Description", RefAlias = "ContractTemplate", RefTableAlias = "CT")]
        public int ContractTemplateRefNo { get; set; }

        [Display(Name = "Status")]
        [ListViewColumn(Width = 150)]
        [DatabaseField(AllowInsert = false, AllowUpdate = false, NotInTable = true)]
        public string FilingStatus { get; set; }

        [DatabaseField]
        [DetailViewItem(IsTextArea = true)]
        public string Remarks { get; set; }

        [DataLookUp]
        [Display(Name = "Field of Work")]
        [DetailViewItem(IsTextArea = true, TabName = "Employment Information")]
        [DatabaseField(IsRequired = true, Name = "FOWRefNo", RefModel = typeof(FOW), RefField = "Description", RefAlias = "FOW", RefTableAlias = "F")]
        public int FOWRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Rank Level")]
        [DetailViewItem(IsTextArea = true, TabName = "Employment Information")]
        [DatabaseField(IsRequired = true, Name = "EmployeeTypeRefNo", RefModel = typeof(EmployeeType), RefField = "Description", RefAlias = "EType", RefTableAlias = "ET")]
        public int EmployeeTypeRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Emp. Status")]
        [DetailViewItem(IsTextArea = true, TabName = "Employment Information")]
        [DatabaseField(IsRequired = true, Name = "EmploymentStatusRefNo", RefModel = typeof(EmploymentStatus), RefField = "Description", RefAlias = "ESM", RefTableAlias = "ESM")]
        public int EmploymentStatusRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Client")]
        [DetailViewItem(TabName = "Employment Information")]
        [DatabaseField(IsRequired = true, Name = "ClientAccountRefNo", RefModel = typeof(ClientAccount), RefField = "Description", RefAlias = "Client", RefTableAlias = "CL")]
        public int ClientAccountRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Client Address")]
        [DetailViewItem(TabName = "Employment Information", IsTextArea = true)]
        [DatabaseField(IsRequired = true)]
        public string ClientAddress { get; set; }

        [DataLookUp]
        [Display(Name = "Position")]
        [DetailViewItem(TabName = "Employment Information", IsTextArea = true)]
        [DatabaseField(IsRequired = true)]
        public string JobPosition { get; set; }

        [Display(Name = "Hiring Date")]
        [DatabaseField]
        [DetailViewItem(TabName = "Employment Information", Column = 2, strFormat = "mm/dd/yyyy")]
        public DateTime DateHired { get; set; }

        [Display(Name = "Start Date")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Employment Information", strFormat = "mm/dd/yyyy")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(TabName = "Employment Information", strFormat = "mm/dd/yyyy")]
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

        [Display(Name = "Client Rate")]
        [DetailViewItem(TabName = "Payroll Information", Column = 2)]
        [DatabaseField(IsRequired = true)]
        public Decimal ClientRate { get; set; }

        [DataLookUp]
        [Display(Name = "ECOLA Rate")]
        [DetailViewItem(TabName = "Payroll Information", Column = 2)]
        [DatabaseField(Name = "EcolaRateRefNo", RefModel = typeof(EcolaRate), RefField = "Description", RefAlias = "ER", RefTableAlias = "ER")]
        public int EcolaRateRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Ecola Computation")]
        [DetailViewItem(TabName = "Payroll Information")]
        [DatabaseField(Name = "EcolaComputationRefNo", RefModel = typeof(ECOLAComputation), RefField = "Description", RefAlias = "ECOM", RefTableAlias = "ECOM")]
        public int EcolaComputationRefNo { get; set; }

        [Display(Name = "Project Name")]
        [DatabaseField]
        [DetailViewItem(TabName = "Job Description")]
        public string ProjectName { get; set; }

        [Display(Name = "Job Description Path")]
        [DatabaseField]
        [DetailViewItem(TabName = "Job Description", IsEnabled = false)]
        public string JobDescriptionPath { get; set; }

        [Display(Name = "Is Update SOW?")]
        [DatabaseField(DefaultValue = "0")]
        [DetailViewItem(TabName = "Job Description")]
        public bool IsUpdateSOW { get; set; }

        [AllowHtml]
        [Display(Name = "Job Description")]
        [DatabaseField]
        [DetailViewItem(IsTextEditor = true, TabName = "Job Description")]
        public string JobDescription { get; set; }


        //[AllowHtml]
        //[Display(Name = "Additional Clause")]
        //[DatabaseField]
        //[DetailViewItem(IsTextEditor = true, TabName = "Clause")]
        //public string sclause { get; set; }


        [DatabaseField(DefaultValue = "1")]
        public int FilingStatusRefNo { get; set; }

        //[Display(Name = "Other Benefits")]
        //[DetailViewItem(TabName = "Other Benefits", IsDiffSave = true)]
        //[DBCollection(ForeignKey = "PARRefNo", ForeignKeyValue = "ID", ModelNo = "350")]
        //public List<PARBenefits> OtherBenefits { get; set; }

        [DetailViewItem(TabName = "Benefits", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "11030")]
        public List<OtherBenefits> otherbenefits { get; set; }

        [DetailViewItem(TabName = "Other Benefits", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "11000")]
        public List<OtherBenefits2> otherbenefits2 { get; set; }


        [DetailViewItem(TabName = "Cost", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "10625")]
        public List<OtherCost> OtherCost { get; set; }

        [DetailViewItem(TabName = "Employment Movement", IsDiffSave = true)]
        [DBCollection(ForeignKey = "employeerefno", ForeignKeyValue = "employeerefno", ModelNo = "10690")]
        public List<EmpHistoryInternal> emphistory { get; set; }

        //[Display(Name = "Other Cost")]
        //[DetailViewItem(TabName = "Other Cost", IsDiffSave = true)]
        //[DBCollection(ForeignKey = "PARRefNo", ForeignKeyValue = "ID", ModelNo = "351")]
        //public List<PARCost> OtherCost { get; set; }
    }
}
