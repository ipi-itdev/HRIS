using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Controllers
{
    public class ModelData
    {
        public String ModelNo { get; set; }
        public String mName { get; set; }
        public double ColumnsWidth { get; set; }
        public bool IsAppendMode { get; set; }
        public string ParentModel { get; set; }
        public bool AllowAddOth { get; set; }
    }

    public class ModelData1
    {
        public string mguid { get; set; }
        public bool IsAppendMode { get; set; }
        public int ParentMenuRefNo { get; set; }
        public string ParentModel { get; set; }
        public string FKeyName { get; set; }
        public int FKey { get; set; }
    }
}