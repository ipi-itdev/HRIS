using System.ComponentModel.DataAnnotations;
using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name = "WAIR Report")]
    [DatabaseTable(Name = "PORTAL_WAIRREPORT_U",ViewName = "vWAIRREPORT", PKeyName = "ID")]
    public class DHSReport : BaseObject
    {
        [DataLookUp]
        [DetailViewItem]
        [Display(Name = "Month")]
        [DatabaseField(Name = "MonthRefNo", RefModel = typeof(Month), RefField = "Description", RefAlias = "M", RefTableAlias = "M")]
        [ListViewColumn(Width = 100)]
        public int MonthRefNo { get; set; }

        [DetailViewItem]
        [ListViewColumn(Width = 100)]
        [DatabaseField]
        public string Year { get; set; }

        [DetailViewItem]
        [ListViewColumn(Width = 100)]
        [DatabaseField]
        public string Duration { get; set; }

        [Display(Name ="Male")]
        [DetailViewItem]
        [DatabaseField]
        [ListViewColumn(Width = 100)]
        public int PrincipalMale { get; set; }

        [Display(Name = "Female")]
        [DetailViewItem]
        [DatabaseField]
        [ListViewColumn(Width = 100)]
        public int PrincipalFemale { get; set; }

        [DetailViewItem]
        [DatabaseField]
        [ListViewColumn(Width = 100)]
        public int Screened { get; set; }

        [Display(Name = "Denied")]
        [DetailViewItem]
        [DatabaseField]
        [ListViewColumn(Width = 100)]
        public int DeniedEntry { get; set; }

        [DetailViewItem]
        [DatabaseField]
        public int Referred { get; set; }

        [DetailViewItem]
        [DatabaseField]
        public int Death { get; set; }

        [DetailViewItem(TabName = "Referred")]
        [DatabaseField]
        public bool BHERT { get; set; }

        [DetailViewItem(TabName = "Referred")]
        [DatabaseField]
        public bool HealthFacility { get; set; }

        [DetailViewItem(TabName = "Referred")]
        [DatabaseField]
        public string HFacility { get; set; }

        [DetailViewItem(TabName = "Referred")]
        [DatabaseField]
        public bool OtherFacility { get; set; }

        [DetailViewItem(TabName = "Referred")]
        [DatabaseField]
        public string OthFacility { get; set; }

        [DetailViewItem(TabName = "Referred")]
        [DatabaseField]
        public bool DiagnosticTest { get; set; }

        [DetailViewItem(TabName = "RTPC")]
        [DatabaseField]
        public bool RTPRC { get; set; }

        [DetailViewItem(TabName = "RTPC")]
        [DatabaseField]
        public int RTPRCNoTest { get; set; }

        [DetailViewItem(TabName = "RTPC")]
        [DatabaseField]
        public int RTPCPositive { get; set; }

        [DetailViewItem(TabName = "GENEXPERT")]
        [DatabaseField]
        public bool GENEXPERT { get; set; }

        [DetailViewItem(TabName = "GENEXPERT")]
        [DatabaseField]
        public int GENEXPERTNoTest { get; set; }

        [DetailViewItem(TabName = "GENEXPERT")]
        [DatabaseField]
        public int GENEXPERTPositive { get; set; }

        [DetailViewItem(TabName = "Rapid")]
        [DatabaseField]
        public bool Rapid { get; set; }

        [DetailViewItem(TabName = "Rapid")]
        [DatabaseField]
        public int RapidTest { get; set; }

        [DetailViewItem(TabName = "Rapid")]
        [DatabaseField]
        public int RapidPositive { get; set; }

        [DetailViewItem(TabName = "OtherTest")]
        [DatabaseField]
        public bool OtherTesting { get; set; }

        [DetailViewItem(TabName = "OtherTest")]
        [DatabaseField]
        public string OtherType { get; set; }

        [DetailViewItem(TabName = "OtherTest")]
        [DatabaseField]
        public string OtherTest { get; set; }

        [DetailViewItem(TabName = "OtherTest")]
        [DatabaseField]
        public int OtherPositive { get; set; }

        [DetailViewItem(TabName = "OtherTest")]
        [DatabaseField]
        public string TotalCostTesting { get; set; }

        [DatabaseField(NotInTable =true)]
        [ListViewColumn]
        public decimal FilingStatus { get; set; }

        [DetailViewItem(TabName = "Attachment")]
        [DatabaseField]
        public string AttachmentPath { get; set; }

    }
}