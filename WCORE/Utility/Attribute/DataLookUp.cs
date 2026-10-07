using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Utility
{

    [System.AttributeUsage( System.AttributeTargets.Property )]
    public class DataLookUpAttribute : Attribute
    {
        public string ViewId = null;
        public string ColumnValue = "ID";
        public string DisplayColumnValue = "Description";
        public bool WithAdd = false;
        public bool IsJson = false;
        public DataLookUpAttribute() { }
        public DataLookUpAttribute( String ViewId ) {
            this.ViewId = ViewId;
        }
        

    }
}