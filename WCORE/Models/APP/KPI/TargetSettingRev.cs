using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;
using DocumentFormat.OpenXml.Office2013.Excel;

namespace WCORE.Models
{
    [MenuDescription(Name = "Target Setting")]
    //[DatabaseTable(Name = "dbo.PIS_KPIAssigmentDetails", ViewName = "dbo.fKPI_InternalRequest_TargetSetting(@User)", PKeyName = "ID")]
    [DatabaseTable(Name = "View_PIS_KPIAssigmentDetails")]
    public class TargetSettingRev : BaseObject
    {

        [DataLookUp]
        [Display(Name = "Purpose")]
        [DatabaseField(Name = "ID", RefModel = typeof(EvaluationPurpose), RefField = "Description", RefAlias = "ep", RefTableAlias = "epi", IsRequired = true)]
        [DetailViewItem]
        public int EvalPurposeRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "Employee Name")]
        [DatabaseField(Name = "EmployeeRefNo", RefModel = typeof(KPIActiveEmployee), RefField = "Description", RefAlias = "es", RefTableAlias = "ooi", IsRequired = true)]
        [DetailViewItem]
        public int EmployeeRefNo { get; set; }

        [DataLookUp]
        [Display(Name = "% Weight")]
        [DatabaseField(Name = "PerformancePercentageID", RefModel = typeof(PerformancePercentage), RefField = "Description", RefAlias = "en", RefTableAlias = "ei", IsRequired = true)]
        [DetailViewItem]
        public int PerformancePercentageID { get; set; }

        [Display(Name = "Start of Period")]
        [DetailViewItem()]
        [DatabaseField(IsRequired = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End of Period")]
        [DetailViewItem()]
        [DatabaseField(IsRequired = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Due Date")]
        [DetailViewItem()]
        [DatabaseField(IsRequired = true)]
        public DateTime SubmissionDate { get; set; }

        [Display(Name = "Remarks")]
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField]
        public string Remarks { get; set; }

        //// TO FOLLOW NA LANG 
        //[DetailViewItem(TabName = "ADD CHANGE KPI")]
        //[DBCollection(ForeignKey = "MenuRefNo", ForeignKeyValue = "MenuRefNo", ModelNo = "1121")]
        //public List<KPIAddChange> KPIAddChange { get; set; }

        //[Display(Name = "ID2")]
        //[DetailViewItem(IsTextArea = true, Column = 2, TabName = "Properties",IsEnabled = false)]
        //[DatabaseField(Name = "ID2", RefModel = typeof(KPIAddChange), RefField = "Description")]
        //public int ID2 { get; set; }

        [Display(Name = "KPI Category")]
        [DataLookUp]
        [DatabaseField(Name = "ID2", RefModel = typeof(KPIAddChange), RefField = "Decription", RefAlias = "E", RefTableAlias = "E",
            IsRequired = false, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true, Column = 2, TabName = "KPI Details", IsEnabled = false)]
        public int ID2 { get; set; }

        [Display(Name = "Total Weight %")]
        [DataLookUp]
        [DatabaseField(Name = "ID3", RefModel = typeof(KPIAddChange2), RefField = "Description", RefAlias = "E", RefTableAlias = "E",
            IsRequired = false,AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true, Column = 2, TabName = "KPI Details", IsEnabled = false)]
        public int ID3 { get; set; }

        [Display(Name = "Status")]
        [DataLookUp]
        [DatabaseField(Name = "ID4", RefModel = typeof(KPIAddChange3), RefField = "Description", RefAlias = "E", RefTableAlias = "E", IsRequired = false, AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea = true, Column = 2, TabName = "KPI Details", IsEnabled = false)]
        public int ID4 { get; set; }


        //[Display(Name = "Employee Number")]
        //[ListViewColumn]
        //[DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        //public string EmployeeNumber { get; set; }

        //[Display(Name = "Employee Name")]
        //[DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        //[ListViewColumn]
        //public string Fullname { get; set; }

        //[Display(Name = "Department")]
        //[DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        //[ListViewColumn]
        //public string Department { get; set; }

        //[Display(Name = "Job Title")]
        //[DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        //[ListViewColumn]
        //public string JobDesc { get; set; }

        //[Display(Name = "Job Grade")]
        //[DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        //[ListViewColumn]
        //public string JobBand { get; set; }

        //[Display(Name = "Purpose of Evaluation")]
        //[DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        //[ListViewColumn]
        //public string Purpose { get; set; }

        //[Display(Name = "Period Covered")]
        //[DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        //[ListViewColumn]
        //public string PeriodCovered { get; set; }

        //[Display(Name = "Status")]
        //[DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false)]
        //[ListViewColumn]
        //public string FilingStatus { get; set; }








    }
}