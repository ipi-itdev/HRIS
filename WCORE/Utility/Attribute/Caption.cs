using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Utility
{
    [System.AttributeUsage( System.AttributeTargets.Class |
                       System.AttributeTargets.Struct )]
    public class CaptionAttribute : Attribute
    {
        public string Name = null;
        public CaptionAttribute() { }
        public CaptionAttribute( String Name ) {
            this.Name = Name;
        }
    }
}