using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "Target Setting")]
    [DatabaseTable(Name = "dbo.PIS_KPIAssigmentDetails", ViewName = "dbo.fKPI_InternalRequest_TargetSettingExternal(@User)", PKeyName = "ID")]
    public class TargetSettingExternal : BaseObject
    {

        [DataLookUp]
        [Display(Name = "Purpose")]
        [DatabaseField(Name = "ID", RefModel = typeof(EvaluationPurpose), RefField = "Description", RefAlias = "ep", RefTableAlias = "epi", IsRequired = true)]
        [DetailViewItem]
        public int EvalPurposeRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Employee Name")]
        [DatabaseField(Name = "EmployeeRefNo", RefModel = typeof(KPIActiveEmployee), RefField = "Description", RefAlias = "en", RefTableAlias = "ei", IsRequired = true)]
        [DetailViewItem]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "Employee Number")]
        [ListViewColumn]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        public string EmployeeNumber { get; set; }

        [Display(Name = "Employee Name")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string Fullname { get; set; }

        [Display(Name = "Department")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string Department { get; set; }

        [Display(Name = "Job Title")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string JobDesc { get; set; }

        [Display(Name = "Job Grade")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string JobBand { get; set; }

        [Display(Name = "Purpose of Evaluation")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string Purpose { get; set; }

        [Display(Name = "Period Covered")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string PeriodCovered { get; set; }

        [Display(Name = "Status")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        public string FilingStatus { get; set; }

        [Display(Name = "Start Date")]
        [DetailViewItem()]
        [DatabaseField(IsRequired = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DetailViewItem()]
        [DatabaseField(IsRequired = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Submission Date")]
        [DetailViewItem()]
        [DatabaseField(IsRequired = true)]
        public DateTime SubmissionDate { get; set; }

        [Display(Name = "Remarks")]
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true)]
        public string Remarks { get; set; }

    }
}