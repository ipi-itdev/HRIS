using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;
using System.ComponentModel.DataAnnotations;

namespace WCORE.Models
{
    [MenuDescription(Name="FileUpload")]
    [DatabaseTable(Name = "GEN_FileUpload_C")]
    public class FileUpload : BaseObject
    {
        [DatabaseField(IsRequired=true)]
        [ListViewColumn]
        [DetailViewItem(IsTextArea=true)]
        public string Description { get; set; }

        [Display(Name = "File Type")]
        [DetailViewItem]
        [ListViewColumn]
        [DatabaseField(IsRequired = true, RefModel = typeof(FileType), RefField = "Description", RefTableAlias = "F", Name = "FileTypeRefNo", RefAlias = "FT")]
        public int FileTypeRefNo { get; set; }

        [Display(Name = "Employee")]
        [DetailViewItem]
        [ListViewColumn]
        [DatabaseField(IsRequired = true, RefModel = typeof(AllEmployee), RefField = "Description", RefTableAlias = "E", Name = "EmployeeRefNo", RefAlias = "ER")]
        public int EmployeeRefNo { get; set; }

        [Display(Name = "Client Account")]
        [DetailViewItem]
        [ListViewColumn]
        [DatabaseField(IsRequired = true, RefModel = typeof(ClientAccount), RefField = "Description", RefTableAlias = "C", Name = "ClientAccountRefNo", RefAlias = "CA")]
        public int ClientAccountRefNo { get; set; }
    }
}