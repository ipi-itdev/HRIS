using System.Web.Mvc;
using WCORE.Utility;
using System.Data;
using System.Data.SqlClient;

namespace WCORE.Controllers
{
    public class CSController : Controller
    {
        Common cmn = new Common();
        DBHelper dbh = new DBHelper();

        public ActionResult Index() { return View(); }

        public ActionResult YTDPerformance(string mguid, int pid)
        {
            ViewBag.pid = pid;
            // get user privileges in the main module and sub modules
            string[] strparam = { "@mguid", "@User", "@UserRoles" };
            string[] strparamval = { mguid, cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetModuleAccess", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read())
                {
                    ViewBag.mguid = mguid;
                    ViewBag.mNo = dr["MenuRefNo"].ToString();
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.mTitle = dr["Description"].ToString();
                    ViewBag.FormID = "mFrm" + dr["MenuRefNo"].ToString();
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    ViewBag.AllowExport = bool.Parse(dr["AllowExport"].ToString());
                }
            }
            return View("~/Views/APP/CS/YTDPerformance.cshtml");
        }

        public ActionResult Commission(string mguid, int pid)
        {
            ViewBag.pid = pid;
            // get user privileges in the main module and sub modules
            string[] strparam = { "@mguid", "@User", "@UserRoles" };
            string[] strparamval = { mguid, cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetModuleAccess", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read())
                {
                    ViewBag.mguid = mguid;
                    ViewBag.mNo = dr["MenuRefNo"].ToString();
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.mTitle = dr["Description"].ToString();
                    ViewBag.FormID = "mFrm" + dr["MenuRefNo"].ToString();
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    ViewBag.AllowExport = bool.Parse(dr["AllowExport"].ToString());
             
                }
            }

            return View("~/Views/APP/CS/Commission.cshtml");
        }

        public ActionResult CommissionDetails()
        {
            return View("~/Views/APP/CS/CommissionDetails.cshtml");
        }
        

        [HttpPost]
        public ActionResult CollectionData(int pkey)
        {
            var JsonData = new DBHelper().GetJSONData("SELECT ID,CompanyCode,Client,ORNo,CollectionDate,NetAmount,IsActive FROM fnCollection(" + pkey + ")", CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DirectCostData(int pkey)
        {
            var JsonData = new DBHelper().GetJSONData("SELECT Description,Amount FROM fnDirectCost(" + pkey + ")", CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NewAccountIncentive(int pkey)
        {
            var JsonData = new DBHelper().GetJSONData("SELECT Description,Amount FROM CS_MRIncentives_U", CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public bool Compute(int pkey)
        {
            bool ret = false;
            string[] strparam = { "@ID" };
            string[] strparamval = { pkey.ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spComputeCommission", CommandType.StoredProcedure, strparam, strparamval))
            { ret = true; }
            return ret;
        }
    }
}
