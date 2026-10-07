using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCORE.Utility;

namespace WCORE.Controllers
{
    public class POSTData
    {
        //public string ViewId { get; set; }
        public string Model { get; set; }
        public string ForeignFieldKey { get; set; }
        public int ID_ParentKey { get; set; }
        public bool IsJson { get; set; }
        public int ctrPage { get; set; }
        public string odrPage { get; set; }
    }

    public class PostData
    {
        public string Model { get; set; }
        public string mguid { get; set; }
        public string ForeignFieldKey { get; set; }
        public int ID_ParentKey { get; set; }
        public bool IsJson { get; set; }
        public int TPageNo { get; set; }
        public string TdtParam { get; set; }
    }
}