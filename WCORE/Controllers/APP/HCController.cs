using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using WCORE.Utility;

namespace WCORE.Controllers
{
    public class HCController : BaseController
    {
        Common cmn = new Common();
        DBHelper dbh = new DBHelper();
        // Start import employee module
        public ActionResult Index(string mguid,int pid = 0) {
            string nURL = "";
            ViewBag.pkey = pid;
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
                    ViewBag.mName = dr["Code"].ToString();
                    ViewBag.AllowInsert = bool.Parse(dr["AllowInsert"].ToString()) && bool.Parse(dr["HasNew"].ToString()) ? true : false;
                    ViewBag.AllowDelete = bool.Parse(dr["AllowDelete"].ToString());
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    nURL = dr["ViewPage"].ToString();
                    ViewBag.APIUrl = dr["APIUrl"].ToString();
                }
            }
            return PartialView(nURL);
        }

        public ActionResult ContractInfo(int pid)
        {
            ViewBag.pkey = pid;
            return View(@"~\Views\APP\HC\ContractInfo.cshtml");
        }
    }
}
