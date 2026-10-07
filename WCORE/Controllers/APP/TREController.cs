using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using WCORE.Utility;

namespace WCORE.Controllers
{
    public class TREController : Controller
    {
        Common cmn = new Common();
        DBHelper dbh = new DBHelper();

        // start TRE application
        public ActionResult TREApplication(string mguid, int pid)
        {
            ViewBag.Pkey = pid;
            string[] strparam = { "@mguid", "@TMSType", "@RefNo", "@UserRefNo", "@UserRoles" };
            string[] strparamval = { mguid, "4", pid.ToString(), cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetEmployeeTRE", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read())
                {
                    ViewBag.mguid = mguid;
                    ViewBag.pkey = dr["ID"].ToString();
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.Caption = dr["Caption"].ToString();
                    ViewBag.EmployeeName = dr["EmployeeName"].ToString();
                    ViewBag.Department = dr["Department"].ToString();
                    ViewBag.DateFiled = dr["DateFiled"].ToString();
                    ViewBag.Remarks = dr["Remarks"].ToString();
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                }
            }
            return View("~/Views/APP/TRE/TREApplication.cshtml");
        }

        // Used to display the list of logs per cut off per employee
        [HttpPost]
        public ActionResult TREData(int pkey)
        {
            var JsonData = new DBHelper().GetJSONData("SELECT ID,WorkDate,ClientAccount,Entry,Amount,AttachmentFile,Remarks FROM fnTREApplicationDtl(" + pkey + ")", CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }
        // end leave application

        // used in adding remarks to TRE application
        [HttpPost]
        public virtual bool TREApplicationRemarks(int tmstype, int pkey, string rmarks)
        {
            bool ret = false;
            string[] strparam = { "@TMSType", "@ID", "@Remarks" };
            string[] strparamval = { tmstype.ToString(), pkey.ToString(), rmarks };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spTMSApplicationRemarks", CommandType.StoredProcedure, strparam, strparamval))
            { ret = true; }
            return ret;
        }

        // used in approval process of TRE application
        [HttpPost]
        public virtual bool TREApplicationApproval(int tmstype, int pkey, int status, string remarks = "")
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
