using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;
using System.Web.Mvc;

namespace WCORE.Models
{
    [Caption(Name="Employment History")]
    [MenuDescription(Name = "Employment History")]
    [DatabaseTable(Name = "PIS_EmploymentInfo_U", ViewName = "VIEW_PIS_EmploymentHistory")]
    public class EmpHistoryInternal : BaseObject
    {
        [Display(Name = "Effectivity Date")]
        [DatabaseField(IsRequired = true)]
        [DetailViewItem(strFormat = "mm/dd/yyyy")]
        [ListViewColumn]
        public DateTime EffectivityDate { get; set; }

        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string Reason { get; set; }

        [DataLookUp]
        [Display(Name = "Contract Template")]
        [DetailViewItem]
        [ListViewColumn(Width = 200)]
        [DatabaseField(IsRequired = true, Name = "ContractTemplateRefNo", RefModel = typeof(ContractTemplate_INT), RefField = "Description", RefAlias = "ContractTemplate", RefTableAlias = "CT")]
        public int ContractTemplateRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Rank Level")]
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, Name = "EmployeeTypeRefNo", RefModel = typeof(EmployeeType), RefField = "Description", RefAlias = "EType", RefTableAlias = "ET")]
        public int EmployeeTypeRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Emp. Status")]
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, Name = "EmploymentStatusRefNo", RefModel = typeof(EmploymentStatus), RefField = "Description", RefAlias = "ESM", RefTableAlias = "ESM")]
        public int EmploymentStatusRefNo { get; set; }

        //[DataLookUp]
        //[Display(Name = "Client")]
        //[ListViewColumn]
        //[DetailViewItem]
        //[DatabaseField(IsRequired = true, Name = "ClientAccountRefNo", RefModel = typeof(ClientAccount), RefField = "Description", RefAlias = "Client", RefTableAlias = "CL")]
        //public int ClientAccountRefNo { get; set; }

        [Display(Name = "Hiring Date")]
        [DatabaseField]
        [DetailViewItem(Column = 2, strFormat = "mm/dd/yyyy")]
        public DateTime DateHired { get; set; }

        [Display(Name = "Date Probationary")]
        [DatabaseField]
        [DetailViewItem(Column = 2, strFormat = "mm/dd/yyyy")]
        public DateTime DateProbationary { get; set; }

        [Display(Name = "Date Regularized")]
        [DatabaseField]
        [DetailViewItem(Column = 2, strFormat = "mm/dd/yyyy")]
        public DateTime DateRegularized { get; set; }

        [DataLookUp]
        [Display(Name = "Position")]
        [DetailViewItem(IsTextArea = true, Column = 2)]
        [DatabaseField(IsRequired = true)]
        public string JobPosition { get; set; }

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
        [ListViewColumn]
        [DetailViewItem(TabName = "Payroll Information", Column = 2)]
        [DatabaseField(IsRequired = true)]
        public Decimal BasicRate { get; set; }

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

    }
}