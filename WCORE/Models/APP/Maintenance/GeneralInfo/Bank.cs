using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name="Bank")]
    [DatabaseTable(Name = "GEN_Bank_M", PKeyName = "BankRefNo")]
    public class Bank : BaseObject
    {
        [DatabaseField(IsRequired = true)]
        [ListViewColumn]
        [DetailViewItem]
        public string Code { get; set; }

        [DatabaseField(IsRequired=true, IsUnique = true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea=true)]
        public string Description { get; set; }

        [Display(Name = "Initial Bank Name")]
        [DatabaseField]
        [DetailViewItem]
        public string InitialBankName { get; set; }

        [Display(Name = "Account Format")]
        [DatabaseField(IsRequired =true)]
        [ListViewColumn]
        [DetailViewItem]
        public string AccountFormat { get; set; }

        [Display(Name = "Employee Account Format")]
        [DatabaseField(IsRequired =true)]
        [DetailViewItem]
        public string EmployeeAccountFormat { get; set; }

        [Display(Name= "Format Value")]
        [DatabaseField]
        [DetailViewItem]
        public string FormatValue { get; set; }

        [Display(Name = "Transmital Zero Value?")]
        [DatabaseField]
        [DetailViewItem]
        public bool TransmitalZeroValue { get; set; }
    }
}

