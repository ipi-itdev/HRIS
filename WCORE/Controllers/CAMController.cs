using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCORE.Utility;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace WCORE.Controllers
{
    public class CAMController : BaseController
    {
        Common cmn = new Common();
        
        //Client Account
        public ActionResult ClientAccount(int pkey)
        {
            ViewBag.PKey = pkey;
            ViewBag.AllowUpdate = Common.GetData("MenuUserRoles", "(UserRolesRefno = " + cmn.SessionUserRolesRefNo() + " OR UserRefno = " + cmn.SessionUserRefNo() + ")  AND CODE = 'ClientAccount'").Rows[0]["AllowUpdate"];
            return View();
        }
    }
}