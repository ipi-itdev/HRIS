using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name="Contract Template")]
    [DatabaseTable(Name = "SYS_ContractTemplate_F", PKeyName = "ContractTemplateRefNo", ViewName = "VIEW_PAR_ContractTemplate_INT")]
    public class ContractTemplate_INT : BaseObject
    {
        [DatabaseField(IsRequired=true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea=true)]
        public string Description { get; set; }
    }
}