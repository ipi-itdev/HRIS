using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Utility
{
    [System.AttributeUsage( System.AttributeTargets.Class |
                       System.AttributeTargets.Struct )]
    public class DataSourceAttribute : Attribute
    {
        public string Name = null;
        public DataSourceAttribute() { }
        public DataSourceAttribute(String Name)
        {
            this.Name = Name;
        }
    }
}