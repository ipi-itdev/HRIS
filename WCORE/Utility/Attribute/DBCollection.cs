using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Utility
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DBCollection : Attribute
    {
        public string ModelNo = null;
        public string ForeignKey = null;
        public string ForeignKeyValue  = null;
        public bool IsAggregated = true;
        public bool IsForm = false;
        public bool HasNew = true;
        public bool HasDelete = true;
    }
}