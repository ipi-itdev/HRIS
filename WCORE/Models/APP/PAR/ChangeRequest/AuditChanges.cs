using WCORE.Utility;

namespace WCORE.Models
{
    [MenuDescription(Name= "Audit Changes")]
    [DatabaseTable(ViewName = "dbo.vEmployeeInfoChanges")]
    public class AuditChanges : BaseObject
    {
        [DatabaseField(NotInTable = true)]
        public int EmployeeRefNo { get; set; }

        [DatabaseField(NotInTable = true)]
        [ListViewColumn]
        public int Field { get; set;}

        [DatabaseField(NotInTable = true)]
        [ListViewColumn]
        public int OldValue { get; set; }

        [DatabaseField(NotInTable = true)]
        [ListViewColumn]
        public int NewValue { get; set; }

        [DatabaseField(NotInTable = true)]
        [ListViewColumn]
        public string IStatus { get; set; }
    }
}