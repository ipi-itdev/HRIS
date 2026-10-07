using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Utility
{
    [System.AttributeUsage( System.AttributeTargets.Class |
                       System.AttributeTargets.Struct )]
    public class ListViewFormatAttribute : Attribute
    {
        public string ViewId = null;
        public bool IsEditable = true;
        public string[] Format;
        public ListViewFormatAttribute() {
        }
        public ListViewFormatAttribute( String ViewId ) {
            this.ViewId = ViewId;
        }
    }

}