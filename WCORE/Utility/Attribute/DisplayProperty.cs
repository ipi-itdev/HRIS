using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Utility
{
    [System.AttributeUsage( System.AttributeTargets.Class |
                    System.AttributeTargets.Struct )]
    public class DisplayPropertyAttribute : Attribute
    {
        public DisplayPropertyAttribute(string name) {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}