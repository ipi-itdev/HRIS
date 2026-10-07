using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using WCORE.Utility;


namespace WCORE.Controllers.APP
{
    public class PISInternalEmployeeActiveController : Controller
    {
        //
        // GET: /PISInternalEmployee/

        Common cmn = new Common();
        DBHelper dbh = new DBHelper();

        public ActionResult Index(string mguid, int pid)
        {
            ViewBag.pid = pid;
            ViewBag.EmployeeID = pid;

            string[] strparam = { "@mguid", "@User", "@UserRoles" };
            string[] strparamval = { mguid, cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetModuleAccess", CommandType.StoredProcedure, strparam, strparamval))
            {
                if (dr.Read())
                {
                    ViewBag.mNo = dr["MenuRefNo"].ToString();
                    ViewBag.mguid = mguid;
                    ViewBag.mName = dr["Code"].ToString();
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.Description = dr["Description"].ToString();
                    ViewBag.FormID = "mFrm" + dr["MenuRefNo"].ToString();
                    ViewBag.FKeyName = "ItemsRefNo";

                    ViewBag.AllowInsert = bool.Parse(dr["AllowInsert"].ToString()) && bool.Parse(dr["HasNew"].ToString()) ? true : false;
                    ViewBag.AllowDelete = bool.Parse(dr["AllowDelete"].ToString());
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    ViewBag.AllowExport = bool.Parse(dr["AllowExport"].ToString());
                }
            }

            using (DataTable dtIDs = Common.GetData("PIS_View_EmployeeID", "EmployeeID = " + ViewBag.pid))
            {
                ViewBag.EmpImage = dtIDs.Rows.Count > 0 && dtIDs.Rows[0]["ImagePath"].ToString() != "" ? dtIDs.Rows[0]["ImagePath"].ToString().Trim() : Common.GetDataFN("dbo.fGetSettingsValue(31)").ToString() + "\\PISID\\user-default.png";
                ViewBag.EmploymentID = dtIDs.Rows.Count > 0 ? dtIDs.Rows[0]["EmploymentID"] : 0;
                ViewBag.PreRequirementsID = dtIDs.Rows.Count > 0 ? dtIDs.Rows[0]["RequirementsID"] : 0;
                ViewBag.SubDescription = dtIDs.Rows.Count > 0 ? dtIDs.Rows[0]["Description"] : "";
            }

            using (DataTable dtSubRoles = Common.GetData("SubMenuUserRoles", "MenuParentRefNo = 10500 AND UserRolesRefno = " + cmn.SessionUserRolesRefNo()))
            {
                ViewBag.AllowEmploymentInfo = dtSubRoles.Select("Code = 'EmploymentInfoInternal'")[0]["AllowView"];
                ViewBag.AllowEditEmploymentInfo = dtSubRoles.Select("Code = 'EmploymentInfoInternal'")[0]["AllowUpdate"];
                ViewBag.AllowDependents = dtSubRoles.Select("Code = 'Dependents'")[0]["AllowView"];
                ViewBag.AllowDisciplinaryAction = dtSubRoles.Select("Code = 'EmployeeOffense'")[0]["AllowView"];
                ViewBag.AllowPerformanceEvaluation = dtSubRoles.Select("Code = 'Performance'")[0]["AllowView"];
                ViewBag.AllowTraining = dtSubRoles.Select("Code = 'Training'")[0]["AllowView"];
                ViewBag.AllowMovement = dtSubRoles.Select("Code = 'EmpHistoryInternal'")[0]["AllowView"];
                ViewBag.AllowAccountability = dtSubRoles.Select("Code = 'Accountability'")[0]["AllowView"];
                ViewBag.AllowPreDocuments = dtSubRoles.Select("Code = 'PreRequirements'")[0]["AllowView"];
                ViewBag.AllowEditPreDocuments = dtSubRoles.Select("Code = 'PreRequirements'")[0]["AllowUpdate"];
            }

            return View("~/Views/APP/PIS/Internal.cshtml");
        }

    }
}
