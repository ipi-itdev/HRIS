using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCORE.Models.Maintenance.Covid
{
    public class DHSMonitor
    {
        public int ID {get; set;}
		public string Employee {get; set;}
        public string Client {get; set;}
        public string CreatedDate {get; set;}
        public string Recommendation {get; set;}
        public string NotifyEmp {get; set;}
        public string DoneNotifyEmp {get; set;}
        public string ValidateCI {get; set;}
        public string NotifyEmpBy {get; set;}
        public string NotifyClient {get; set;}
        public string DoneNotifyClient {get; set;}
        public string NotifyClientBy {get; set;}
        public int RiskRefNo { get; set; }
    }
}