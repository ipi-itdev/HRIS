using WCORE.Utility;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.IO;
using System;

namespace WCORE.Controllers
{
    public class PISController : BaseController
    {
        Common cmn = new Common();
        DBHelper dbh = new DBHelper();

        /// This action result is used in employee module (external an internal)
        /// <param name="pid">ID in PIS_Employee_U</param>
        /// <param name="mguid">mguid of Menu</param>
        public ActionResult Employee(int pid, string mguid)
        {
            //int egroup = 0;
            ViewBag.pid = pid;
            ViewBag.EmploymentID = -1; // Initial value for insert

            // get user privileges in the main module and sub modules
            string[] strparam = { "@mguid", "@User", "@UserRoles" };
            string[] strparamval = { mguid, cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetModuleAccess", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read()) {
                    ViewBag.mguid = mguid;
                    ViewBag.mNo = dr["MenuRefNo"].ToString();
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.mTitle = dr["Description"].ToString();
                    ViewBag.FormID = "mFrm" + dr["MenuRefNo"].ToString();
                    ViewBag.mName = dr["Code"].ToString();
                    ViewBag.AllowInsert = bool.Parse(dr["AllowInsert"].ToString())  && bool.Parse(dr["HasNew"].ToString()) ? true : false;
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                } dr.NextResult();
                while (dr.Read()) {
                    if (dr["Code"].ToString() == "OtherBenefits") { ViewBag.OtherBenefits = dr["mguid"].ToString();  }
                    if (dr["Code"].ToString() == "OtherCost") { ViewBag.OtherCost = dr["mguid"].ToString(); }
                    if (dr["Code"].ToString() == "HighestEducation") { ViewBag.AllowHighestEducation = bool.Parse(dr["AllowView"].ToString()); ViewBag.HighestEducation = dr["mguid"].ToString(); }
                    if (dr["Code"].ToString() == "EmploymentInfo") { ViewBag.AllowEmploymentInfo = bool.Parse(dr["AllowView"].ToString()); ViewBag.EmploymentInfo = dr["mguid"].ToString(); ViewBag.AllowEditEmploymentInfo = dr["AllowUpdate"].ToString(); }
                    if (dr["Code"].ToString() == "EmployeeOffense") { ViewBag.AllowDisciplinaryAction = bool.Parse(dr["AllowView"].ToString()); ViewBag.DisciplinaryAction = dr["mguid"].ToString(); }
                    if (dr["Code"].ToString() == "Performance") { ViewBag.AllowPerformanceEvaluation = bool.Parse(dr["AllowView"].ToString()); ViewBag.PerformanceEvaluation = dr["mguid"].ToString(); }
                    if (dr["Code"].ToString() == "Training") { ViewBag.AllowTraining = bool.Parse(dr["AllowView"].ToString()); ViewBag.Training = dr["mguid"].ToString(); }
                    if (dr["Code"].ToString() == "EmpHistory") { ViewBag.AllowMovement = bool.Parse(dr["AllowView"].ToString()); ViewBag.Movement = dr["mguid"].ToString(); }
                    if (dr["Code"].ToString() == "Accountability") { ViewBag.AllowAccountability = bool.Parse(dr["AllowView"].ToString()); ViewBag.Accountability = dr["mguid"].ToString(); }
                    if (dr["Code"].ToString() == "PreRequirements") { ViewBag.AllowPreDocuments = bool.Parse(dr["AllowView"].ToString()); ViewBag.PreDocuments = dr["mguid"].ToString(); }
                }
                // get employee ids in all employee info related tables
                //string[] strparamIDs = { "@eID" };
                //string[] strparamvalIDs = { pid.ToString() };
                //using (DataTable dtIDs = dbh.ExecuteQuery("SELECT * FROM dbo.fEmployeeInfoID(@eID)", CommandType.Text, strparamIDs, strparamvalIDs))
                //{
                //    if (dtIDs.Rows.Count > 0)
                //    {
                //        ViewBag.EmpImage = dtIDs.Rows.Count > 0 && dtIDs.Rows[0]["ImagePath"].ToString() != "" ? dtIDs.Rows[0]["ImagePath"].ToString().Trim() : Common.GetDataFN("dbo.fGetSettingsValue(31)").ToString() + "\\PISID\\user-default.png";
                //        ViewBag.EmploymentID = dtIDs.Rows.Count > 0 ? dtIDs.Rows[0]["EmploymentID"] : 0;
                //        ViewBag.SubDescription = dtIDs.Rows.Count > 0 ? dtIDs.Rows[0]["Description"] : "";
                //        egroup = int.Parse(dtIDs.Rows[0]["EmployeeGroupRefNo"].ToString());
                //        ViewBag.IsJDAttachment = bool.Parse(dtIDs.Rows[0]["IsJDAttachment"].ToString());
                //    }
                //}
            }
            return View(@"~\Views\APP\PIS\Employee.cshtml");
        }

        public ActionResult Internal(int pkey, string mName)
        {
            ViewBag.EmployeeID = pkey;
            ViewBag.mName = mName;
            using (DataTable dtRoles = Common.GetData("MenuUserRoles", "(UserRolesRefno = " + cmn.SessionUserRolesRefNo() + " OR UserRefno = " + cmn.SessionUserRefNo() + ") AND Code = '" + mName + "'"))
            {
                ViewBag.AllowInsert = dtRoles.Rows[0]["AllowInsert"].ToString() == "True" && dtRoles.Rows[0]["HasNew"].ToString() == "True" ? true : false;
                ViewBag.AllowDelete = dtRoles.Rows[0]["AllowDelete"];
                ViewBag.AllowUpdate = dtRoles.Rows[0]["AllowUpdate"];
                ViewBag.AllowPrint = dtRoles.Rows[0]["AllowPrint"];
                ViewBag.AllowApprove = dtRoles.Rows[0]["AllowApprove"];
                ViewBag.mNo = dtRoles.Rows[0]["MenuRefNo"];
            }

            using (DataTable dtIDs = Common.GetData("PIS_View_EmployeeID", "EmployeeID = " + pkey))
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
            return View();
        }

        public ActionResult PersonalInformation(int pid, string mguid)
        {
            ViewBag.pid = pid;
            ViewBag.EmploymentID = -1; // Initial value for insert

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
                    ViewBag.FormID = "mFrm" + dr["MenuRefNo"].ToString();
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                }
            }

            return View(@"~\Views\APP\PIS\PersonalInformation.cshtml");
        }

        public ActionResult PARTransactions(int pid, string mguid)
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
                    ViewBag.mName = dr["Code"].ToString();
                    ViewBag.FormID = "mFrm" + dr["MenuRefNo"].ToString();
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                }
            }

            return View(@"~\Views\APP\PAR\PARTransactions.cshtml");
        }

        public virtual JsonResult GetEmployeeListReport()
        {
            string SQL = null;
            SQL = "SELECT * FROM fGetEmployeeListReport('" + cmn.SessionUserRefNo() + "')";
            SQL = SQL.Replace("@Roles", Convert.ToString(cmn.SessionUserRolesRefNo()));
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public ActionResult EmploymentInformation(int pid, string mguid)
        {
            ViewBag.pid = pid;
            ViewBag.EmploymentID = -1; // Initial value for insert

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
                    ViewBag.FormID = "mFrm" + dr["MenuRefNo"].ToString();
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                }
            }
            return View(@"~\Views\APP\PIS\EmploymentInformation.cshtml");
        }

        [HttpPost]
        public virtual JsonResult GetAttritionlist(DateTime sdate, DateTime edate)
        {
            string SQL = null;
            SQL = "SELECT * FROM fAttrition('" + cmn.SessionUserRefNo() + "','" + sdate + "','" + edate + "')";
            SQL = SQL.Replace("@Roles", Convert.ToString(cmn.SessionUserRolesRefNo()));
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetAttritionlist2(DateTime sdate, DateTime edate)
        {
            string SQL = null;
            SQL = "SELECT * FROM fAttrition2('" + cmn.SessionUserRefNo() + "','" + sdate + "','" + edate + "')";
            SQL = SQL.Replace("@Roles", Convert.ToString(cmn.SessionUserRolesRefNo()));
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public virtual JsonResult GetLoadinglist(DateTime sdate, DateTime edate)
        {
            string SQL = null;
            SQL = "SELECT * FROM fLoadingReport('" + cmn.SessionUserRefNo() + "','" + sdate + "','" + edate + "')";
            SQL = SQL.Replace("@Roles", Convert.ToString(cmn.SessionUserRolesRefNo()));
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetAllemployeeList(POSTData data)
        {
            var JsonData = new DBHelper().GetJSONData("SELECT EmployeeRefNo,DESCRIPTION FROM dbo.fSelectEmployeeAll()", CommandType.Text, false);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetdirectCost(int empno)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fgetDC(" + empno + ")";
            SQL = SQL.Replace("@Roles", Convert.ToString(cmn.SessionUserRolesRefNo()));
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetdirectCostSM(int empno)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fgetDCSM(" + empno + ")";
            SQL = SQL.Replace("@Roles", Convert.ToString(cmn.SessionUserRolesRefNo()));
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetLoadingSummary()
        {
            string SQL = null;
            SQL = "SELECT * FROM fLoadingSummary('" + cmn.SessionUserRefNo() + "')";
            SQL = SQL.Replace("@Roles", Convert.ToString(cmn.SessionUserRolesRefNo()));
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetClientDefaultAddress(int crefno)
        {
            string[] strparam = { "@cRefNo" };
            string[] strparamval = { crefno.ToString() };
            var JsonData = dbh.GetJSONData("SELECT dbo.fGetClientAddress(@cRefNo)", CommandType.Text, true, strparam, strparamval);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual bool UploadImage(int pkey, HttpPostedFileBase file)
        {
            if (file != null)
            {
                FileInfo fi = new FileInfo(file.FileName);
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Common.GetDataFN("dbo.fGetSettingsValue(31)").ToString() + "\\PISID\\ID" + pkey + fi.Extension;
                Common.ExecuteNonQuery("UPDATE PIS_Employee_U SET ImagePath = 'ID" + pkey + fi.Extension + "' WHERE EmployeeRefNo = " + pkey);
                file.SaveAs(Server.MapPath(filePath));
            }
            return true;
        }

        [HttpPost]
        public virtual bool UploadJD(int pkey, HttpPostedFileBase file)
        {
            if (file != null)
            {
                FileInfo fi = new FileInfo(file.FileName);
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Common.GetDataFN("dbo.fGetSettingsValue(31)").ToString() + "\\PISJD\\JD" + pkey + fi.Extension;
                Common.ExecuteNonQuery("UPDATE PIS_EmploymentInfo_U SET JobDescriptionPath = 'JD" + pkey + fi.Extension + "' WHERE IsActive = 1 AND EmployeeRefNo = " + pkey);
                file.SaveAs(Server.MapPath(filePath));
            }
            return true;
        }

        [HttpPost]
        public virtual bool DownloadJD(int pkey, HttpPostedFileBase file)
        {
            if (file != null)
            {
                FileInfo fi = new FileInfo(file.FileName);
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Common.GetDataFN("dbo.fGetSettingsValue(31)").ToString() + "\\PISJD\\JD" + pkey + fi.Extension;
                Common.ExecuteNonQuery("UPDATE PIS_EmploymentInfo_U SET JobDescriptionPath = 'JD" + pkey + fi.Extension + "' WHERE IsActive = 1 AND EmployeeRefNo = " + pkey);
                file.SaveAs(Server.MapPath(filePath));
            }
            return true;
        }

        public ActionResult EmployeeAudit(int pid, string mguid)
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
                }
            }
                return View(@"~\Views\APP\PIS\EmployeeAudit.cshtml");
        }

        [HttpPost]
        public virtual bool ApplyAudit(int pid)
        {
            bool ret = false;
            string[] strparam = { "@ID", "@UserRefNo" };
            string[] strparamval = { pid.ToString() , cmn.SessionUserRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.PIS_SP_EmployeeAudit", CommandType.StoredProcedure, strparam, strparamval))
            { ret = true; }
            return ret;
        }

        [HttpPost]
        public virtual bool ReturnAudit(int pid,string remarks)
        {
            bool ret = false;
            string[] strparam = { "@ID", "@remarks", "@UserRefNo" };
            string[] strparamval = { pid.ToString(),remarks, cmn.SessionUserRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.PIS_SP_ReturnEmployeeAudit", CommandType.StoredProcedure, strparam, strparamval))
            { ret = true; }
            return ret;
        }
    }
}
