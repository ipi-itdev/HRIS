using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;
    
namespace WCORE.Models
{
    [MenuDescription(Name = "Client Account")]
    [DatabaseTable(Name = "GEN_ClientAccount_M", PKeyName = "ClientAccountRefNo", ViewName = "dbo.fSelectClients(@User)")]
    public class ClientAccount : BaseObject
    {
        [DatabaseField]
        public int ClientAccountRefNo { get; set; }

        [DataLookUp(WithAdd = true)]
        [Display(Name = "MR")]
        [DetailViewItem]
        [ListViewColumn(Width = 50)]
        [DatabaseField(IsRequired = true, RefModel = typeof(MarketingRep), RefField = "Description", RefTableAlias = "M", Name = "MRRefNo", RefAlias = "MR")]
        public int MRRefNo { get; set; }

        [DetailViewItem]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn(Width = 80)]
        public string Code { get; set; }

        [Display(Name="Name")]
        [DetailViewItem(IsTextArea=true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn(Width = 300)]
        public string Description { get; set; }

        [Display(Name = "Address")]
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = true)]
        [ListViewColumn(Width = 300)]
        public string ClientAddress { get; set; }


        [Display(Name = "Business Nature")]
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = false)]
        [ListViewColumn(Width = 200)]
        public string BusinessNature { get; set; }

        [Display(Name = "Contract Tenure")]
        [DetailViewItem(IsTextArea = true)]
        [DatabaseField(IsRequired = true, IsUnique = false)]
        public int ContractTenure { get; set; }

        //[Display(Name = "Service/Product Offered")]
        //[DetailViewItem(IsTextArea = true)]
        //[DatabaseField(IsRequired = true, IsUnique = false)]
        //[ListViewColumn(Width = 200)]
        //public string ServiceOffered { get; set; }

        [Display(Name = "Service Offered")]
        [DatabaseField(NotInTable = true, AllowInsert = false, AllowUpdate = false, Name = "ID", RefModel = typeof(ServiceOffered), RefField = "Description", RefAlias = "SO", RefTableAlias = "SO")]
        [ListViewColumn(Width = 150)]
        public int ServiceOfferedRefNo { get; set; }

        [Display(Name = "Contact Person")]
        [DetailViewItem(Column=2)]
        [DatabaseField(IsRequired = true, IsUnique = false)]
        public string ContactPerson { get; set; }

        [Display(Name = "Contact Position")]
        [DetailViewItem(Column = 2)]
        [DatabaseField(IsRequired = false, IsUnique = false)]
        public string ContactPosition { get; set; }

        [Display(Name = "Contact Number")]
        [DetailViewItem(Column = 2)]
        [DatabaseField(IsRequired = false, IsUnique = false)]
        public string ContactNumber { get; set; }

        [Display(Name = "Email Address")]
        [DetailViewItem(Column = 2)]
        [DatabaseField(IsRequired = false, IsUnique = false)]
        public string EmailAddress { get; set; }

    }
}