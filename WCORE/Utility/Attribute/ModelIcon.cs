using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Utility
{
    [System.AttributeUsage( System.AttributeTargets.Class)]
    public class ModelIconAttribute : Attribute
    {
        public string Name = null;
        public ModelIconAttribute( String Name ) {
            this.Name = Name;
        }
    }
}