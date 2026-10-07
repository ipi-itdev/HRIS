using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using WCORE.Utility;

namespace WCORE.Controllers
{
    public class TMSController : Controller
    {
        Common cmn = new Common();
        DBHelper dbh = new DBHelper();

        /// start DTR application  module
        public ActionResult DTRApplication(string mguid,int pid)
        {
            ViewBag.Pkey = pid;
            string[] strparam = { "@mguid","@TMSType","@RefNo", "@UserRefNo", "@UserRoles" };
            string[] strparamval = { mguid,"1", pid.ToString(),cmn.SessionUserRefNo().ToString(),cmn.SessionUserRolesRefNo().ToString()  };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetEmployeeTMS", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read()) {
                    ViewBag.mguid = mguid;
                    ViewBag.pkey = dr["ID"].ToString();
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.EmployeeName = dr["EmployeeName"].ToString();
                    ViewBag.Department = dr["Department"].ToString();
                    ViewBag.PayrollDate = dr["PayrollDate"].ToString();
                    ViewBag.PayrollPeriod = dr["PayrollPeriod"].ToString();
                    ViewBag.Remarks = dr["Remarks"].ToString();
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                }
            }
            
            return View("~/Views/APP/TMS/DTRApplication.cshtml");
        }

        // Used to display the list of logs per cut off per employee
        [HttpPost]
        public ActionResult DTRData(int pkey)
        {
            var JsonData = new DBHelper().GetJSONData("SELECT * FROM fnDTRApplicationDtl(" + pkey + ")", CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DTRDataAttachment(int pkey)
        {
            var JsonData = new DBHelper().GetJSONData("SELECT * FROM fnDTRApplicationDtlAttachment(" + pkey + ")", CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }
        /// end DTR application module

        // start leave application
        public ActionResult LeaveApplication(string mguid, int pid)
        {
            ViewBag.Pkey = pid;
            string[] strparam = { "@mguid", "@TMSType", "@RefNo", "@UserRefNo", "@UserRoles" };
            string[] strparamval = { mguid, "2", pid.ToString(), cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetEmployeeTMS", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read())
                {
                    ViewBag.mguid = mguid;
                    ViewBag.pkey = dr["ID"].ToString();
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.EmployeeName = dr["EmployeeName"].ToString();
                    ViewBag.Department = dr["Department"].ToString();
                    ViewBag.DateFiled = dr["DateFiled"].ToString();
                    ViewBag.Remarks = dr["Remarks"].ToString();
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                }
            }
            return View("~/Views/APP/TMS/LeaveApplication.cshtml");
        }

        // Used to display the list of logs per cut off per employee
        [HttpPost]
        public ActionResult LeaveData(int pkey)
        {
            var JsonData = new DBHelper().GetJSONData("SELECT * FROM fnLeaveApplicationDtl(" + pkey + ")", CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }
        // end leave application

        // start ot application
        public ActionResult OTApplication(string mguid, int pid)
        {
            ViewBag.Pkey = pid;
            string[] strparam = { "@mguid", "@TMSType", "@RefNo", "@UserRefNo", "@UserRoles" };
            string[] strparamval = { mguid, "3", pid.ToString(), cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetEmployeeTMS", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read())
                {
                    ViewBag.mguid = mguid;
                    ViewBag.pkey = dr["ID"].ToString();
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.EmployeeName = dr["EmployeeName"].ToString();
                    ViewBag.Department = dr["Department"].ToString();
                    ViewBag.DateFiled = dr["DateFiled"].ToString();
                    ViewBag.Remarks = dr["Remarks"].ToString();
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                }
            }
            return View("~/Views/APP/TMS/OTApplication.cshtml");
        }

        // Used to display the list of logs per cut off per employee
        [HttpPost]
        public ActionResult OTData(int pkey)
        {
            var JsonData = new DBHelper().GetJSONData("SELECT * FROM fnOTApplicationDtl(" + pkey + ")", CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }
        // end leave application

        // start ob application
        public ActionResult OBApplication(string mguid, int pid)
        {
            ViewBag.Pkey = pid;
            string[] strparam = { "@mguid", "@TMSType", "@RefNo", "@UserRefNo", "@UserRoles" };
            string[] strparamval = { mguid, "4", pid.ToString(), cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetEmployeeTMS", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read())
                {
                    ViewBag.mguid = mguid;
                    ViewBag.pkey = dr["ID"].ToString();
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.EmployeeName = dr["EmployeeName"].ToString();
                    ViewBag.Department = dr["Department"].ToString();
                    ViewBag.DateFiled = dr["DateFiled"].ToString();
                    ViewBag.Remarks = dr["Remarks"].ToString();
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                }
            }
            return View("~/Views/APP/TMS/OBApplication.cshtml");
        }

        // Used to display the list of logs per cut off per employee
        [HttpPost]
        public ActionResult OBData(int pkey)
        {
            var JsonData = new DBHelper().GetJSONData("SELECT * FROM fnOBApplicationDtl(" + pkey + ")", CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }
        // end leave application


        // used in adding remarks to TMS application
        [HttpPost]
        public virtual bool TMSApplicationRemarks(int tmstype, int pkey, string rmarks)
        {
            bool ret = false;
            string[] strparam = { "@TMSType", "@ID", "@Remarks" };
            string[] strparamval = { tmstype.ToString(), pkey.ToString(), rmarks };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spTMSApplicationRemarks", CommandType.StoredProcedure, strparam, strparamval))
            { ret = true; }
            return ret;
        }

        // used in approval process of TMS application
        [HttpPost]
        public virtual bool TMSApplicationApproval(int tmstype, int pkey, int status, string remarks = "")
        {
            bool ret = false;
            string[] strparam = { "@TMSType", "@ID", "@UserRefNo", "@Status", "@Remarks" };
            string[] strparamval = { tmstype.ToString(), pkey.ToString(), cmn.SessionUserRefNo().ToString(), status.ToString(), remarks };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.pTMSApplicationApproval", CommandType.StoredProcedure, strparam, strparamval))
            { ret = true; }
            return ret;
        }
    }
}
