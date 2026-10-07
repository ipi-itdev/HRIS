using WCORE.Utility;
using System;
using System.Web.Mvc;
using System.Data;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Web;

namespace WCORE.Controllers
{
    public class CovidController : Controller
    {
        Common cmn = new Common();
        DBHelper dbh = new DBHelper();

        public ActionResult DashboardDHS()
        {
            ViewBag.Description = "Daily Health Survey";
            return View("~/Views/APP/Covid/DashboardDHS.cshtml");
        }

        // start WAIR REPORT modules
        public ActionResult DHSReport(int pid, string mguid)
        {
            ViewBag.PKey = pid;
            int fstatus = 1, cuser = 0;
            DataTable dtCOVIDReport = null;
            if (pid > 0)
            {
                // used to get the current approver of the report
                using (dtCOVIDReport = Common.GetData("COVID_CurrentUser", "ID = '" + pid + "' AND IsActive = 1"))
                {
                    ViewBag.Action = dtCOVIDReport.Rows[0]["UserAction"].ToString();
                    fstatus = int.Parse(dtCOVIDReport.Rows[0]["FilingStatusRefNo"].ToString());
                    cuser = int.Parse(dtCOVIDReport.Rows[0]["CurrentUser"].ToString());
                    ViewBag.AttachmentPath = dtCOVIDReport.Rows[0]["AttachmentPath"].ToString();
                }
            }
            // used to get the user privilege
            string[] strparam = { "@mguid", "@User", "@UserRoles" };
            string[] strparamval = { mguid, cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (DataTable dtRoles = dbh.ExecuteQuery("SELECT * FROM dbo.fSysModuleUserRoles(@mguid,@User,@UserRoles)", CommandType.Text, strparam, strparamval))
            {
                if (dtRoles.Rows.Count > 0)
                {
                    ViewBag.AllowUpdate = cuser != cmn.SessionUserRefNo() ? dtRoles.Rows[0]["IsAdmin"] : dtRoles.Rows[0]["AllowUpdate"];
                    ViewBag.AllowPrint = dtRoles.Rows[0]["AllowPrint"];
                    ViewBag.AllowApprove = fstatus == 7 ? false : cuser != cmn.SessionUserRefNo() ? false : dtRoles.Rows[0]["AllowApprove"];
                }
            }
            return View("~/Views/APP/Covid/DHSReport.cshtml");   
        }

        // used to upload supporting documents
        [HttpPost]
        public virtual bool UploadAttachment(int pkey, HttpPostedFileBase file) 
        {
            if (file != null)
            {
                FileInfo fi = new FileInfo(file.FileName);
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Common.GetDataFN("dbo.fGetSettingsValue(31)").ToString() + "\\COVID\\" + fileName;
                Common.ExecuteNonQuery("UPDATE PORTAL_WAIRREPORT_U SET AttachmentPath = '" + fileName + "' WHERE IsActive = 1 AND ID = " + pkey);
                file.SaveAs(Server.MapPath(filePath));
            }
            return true;
        }
        
        // used to processed the wair report
        public bool DHSReportApproved(int pkey)
        {
            string[] param = { "@ID", "@UserRefNo" };
            string[] paramval = { pkey.ToString(), cmn.SessionUserRefNo().ToString() };
            dbh.ExecuteNonQuery("dbo.pApproveDHSReport", CommandType.StoredProcedure,param,paramval);
            return true;
        }

        // end WAIR REPORT modules

        [HttpPost]
        public virtual JsonResult GetDailyDHS(string sdate, string edate)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fDailyDHS('" + sdate + "','" + edate + "')";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetALT1Report(string sdate,string edate)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fALTReport('" + sdate + "','" + edate + "')";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult DHSMonitoring(int pkey, string moduleName)
        {  // <--- button call on ALERT LIST 1, 2 AND UNDER OBSERVATION 
            ViewBag.PKey = pkey;
            int nby = 0;
            nby = int.Parse(Common.GetData("PORTAL_DHS_U", "ID =" + pkey).Rows[0]["NotifyEmpBy"].ToString());
            using (DataTable dtRoles = Common.GetData("SubMenuUserRoles", "UserRolesRefno = " + cmn.SessionUserRolesRefNo() + " AND CODE = '" + moduleName + "'"))
            {
                if (dtRoles.Rows.Count > 0)
                {
                    ViewBag.AllowUpdate = dtRoles.Rows[0]["AllowUpdate"];
                    ViewBag.AllowApprove = dtRoles.Rows[0]["AllowApprove"];
                    ViewBag.AllowPrint = dtRoles.Rows[0]["AllowPrint"];
                    ViewBag.SuperApprover = dtRoles.Rows[0]["AllowPrint"];

                    ViewBag.CanModify = true;
                    if (((nby == 0) || (nby == cmn.SessionUserRefNo())) && ViewBag.AllowApprove == true && ViewBag.AllowUpdate == true)
                    {
                        if (nby == 0)
                        {
                            DBHelper dbh = new DBHelper();
                            string SQL = "UPDATE dbo.PORTAL_DHS_U SET NotifyEmpBy = " + cmn.SessionUserRefNo() + " WHERE ID =" + pkey;
                            dbh.ExecuteNonQuery(SQL, CommandType.Text);
                        }
                    }
                    else
                    {
                        ViewBag.CanModify = false;
                        ViewBag.AllowUpdate = false;
                        ViewBag.AllowApprove = false;
                    }
                }
                ViewBag.ModuleNameID = moduleName;
                
            }
            return View();
        }
        
        public ActionResult ContactInfo(string pkey, string moduleName)
        {
            ViewBag.PKey = pkey;
            int nby = 0;
            nby = int.Parse(Common.GetData("PORTAL_COVIDDHS_U", "ID =" + pkey).Rows[0]["CIUValidateBy"].ToString());

            using (DataTable dtRoles = Common.GetData("SubMenuUserRoles", "UserRolesRefno = " + cmn.SessionUserRolesRefNo() + " AND CODE = '" + moduleName + "'"))
            {
                if (dtRoles.Rows.Count > 0)
                {
                    ViewBag.AllowUpdate = dtRoles.Rows[0]["AllowUpdate"];
                    ViewBag.AllowApprove = dtRoles.Rows[0]["AllowApprove"];
                    ViewBag.CanModify = true;
                }
                if (((nby == 0) || (nby == cmn.SessionUserRefNo())) && ViewBag.AllowUpdate == true && ViewBag.AllowApprove == true)
                {
                    if (nby == 0)
                    {
                        DBHelper dbh = new DBHelper();
                        string SQL = "UPDATE dbo.PORTAL_COVIDDHS_U SET CIUValidateBy = " + cmn.SessionUserRefNo() + " WHERE ID =" + pkey;
                        dbh.ExecuteNonQuery(SQL, CommandType.Text);
                    }
                }
                else
                {
                    ViewBag.CanModify = false;
                    ViewBag.AllowUpdate = false;
                    ViewBag.AllowApprove = false;
                }
                ViewBag.ModuleNameID = moduleName;
                ViewBag.SuperApprover = true;
            }
            return View();
        }

        // GET: /Covid/
        [HttpPost]
        public virtual JsonResult GetOLT()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetOTL(@User)";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetNoDHS()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetNoDHS(@User)";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetALT1()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetCovidAlert1(@User)";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetALT2()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetCovidAlert2(@User)";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetUOL()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetCovidUOR(@User)";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public virtual JsonResult GetUCI()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetUCI(@User)";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

     
        [HttpPost]
        public virtual JsonResult GetFLE()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetFLE(@User)";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetEmployeeSurvey(string pkey)
        {
            var JsonData = new DBHelper().GetJSONData("SELECT * FROM dbo.fGetEmployeeDHS(" + pkey + ")", CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCity()
        {
            var JsonData = new DBHelper().GetJSONData("SELECT CityRefNo, Description FROM dbo.GEN_City_M WHERE IsActive = 1", CommandType.Text, false);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetEmployeeContactInfo(string pkey)
        {
            var JsonData = new DBHelper().GetJSONData("SELECT * FROM dbo.fGetEmployeeContactInfo(" + pkey + ")", CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExportWAIRReport(int pkey)
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string SQL = null;
                SQL = "SELECT * FROM dbo.fnDHS_WairReport(" + pkey + ")";
                using (DataTable dt = new DBHelper().ExecuteQuery(SQL, CommandType.Text))
                {
                    rd.Load(Path.Combine(Server.MapPath("~/Report/PIS"), "DHSWairReport.rpt"));
                    rd.SetDataSource(dt);
                }
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                rd.Close();
                rd.Dispose();
                return File(stream, "application/pdf");
            }
        }

        public ActionResult ExportCovidResponse(int pkey)
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string SQL = null;
                SQL = "SELECT * FROM dbo.fDHS(" + pkey + ")";
                using (DataTable dt = new DBHelper().ExecuteQuery(SQL, CommandType.Text))
                {
                    rd.Load(Path.Combine(Server.MapPath("~/Report/PIS"), "DHSSummary.rpt"));
                    rd.SetDataSource(dt);
                }
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                rd.Close();
                rd.Dispose();
                return File(stream, "application/pdf");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public virtual bool DHSAction()
        {
            dynamic dynamicObject = null;
            dynamicObject = JObject.Parse(Request.Unvalidated["JSONObject"]);
            try
            {
                using (SqlConnection con = new SqlConnection(Common.GetSqlConnection().ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("pDHSAction", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Type", SqlDbType.Int).Value = int.Parse(dynamicObject["Type"].ToString());
                        cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = int.Parse(dynamicObject["ID"].ToString());
                        cmd.Parameters.AddWithValue("@RecommendationRefNo", SqlDbType.Int).Value = int.Parse(dynamicObject["RecommendationRefNo"].ToString());
                        cmd.Parameters.AddWithValue("@Recommendation", SqlDbType.VarChar).Value = dynamicObject["Recommendation"].ToString();
                        cmd.Parameters.AddWithValue("@OtherRecommendation", SqlDbType.VarChar).Value = dynamicObject["OtherRecommendation"].ToString();
                        cmd.Parameters.AddWithValue("@Remarks", SqlDbType.VarChar).Value = dynamicObject["Remarks"].ToString();
                        cmd.Parameters.AddWithValue("@User", SqlDbType.Int).Value = cmn.SessionUserRefNo();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                return true;
            }
            catch  { return false; }

        }

        [HttpPost]
        [ValidateInput(false)]
        public virtual bool UpdateDHSContact()
        {
            dynamic dynamicObject = null;
            dynamicObject = JObject.Parse(Request.Unvalidated["JSONObject"]);
            try
            {
                using (SqlConnection con = new SqlConnection(Common.GetSqlConnection().ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("pUpdateDHSContactInfo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = int.Parse(dynamicObject["ID"].ToString());
                        cmd.Parameters.AddWithValue("@CityRefNo", SqlDbType.Int).Value = int.Parse(dynamicObject["CityRefNo"].ToString());
                        cmd.Parameters.AddWithValue("@CurrentAddress", SqlDbType.VarChar).Value = dynamicObject["CurrentAddress"].ToString();
                        cmd.Parameters.AddWithValue("@PrimaryMobileNumber", SqlDbType.VarChar).Value = dynamicObject["PrimaryMobileNumber"].ToString();
                        cmd.Parameters.AddWithValue("@SecondaryMobileNumber", SqlDbType.VarChar).Value = dynamicObject["SecondaryMobileNumber"].ToString();
                        cmd.Parameters.AddWithValue("@LandLineNumber", SqlDbType.VarChar).Value = dynamicObject["LandLineNumber"].ToString();
                        cmd.Parameters.AddWithValue("@PrimaryEmailAddress", SqlDbType.VarChar).Value = dynamicObject["PrimaryEmailAddress"].ToString();
                        cmd.Parameters.AddWithValue("@SecondaryEmailAddress", SqlDbType.VarChar).Value = dynamicObject["SecondaryEmailAddress"].ToString();
                        cmd.Parameters.AddWithValue("@EmergencyContact", SqlDbType.VarChar).Value = dynamicObject["EmergencyContact"].ToString();
                        cmd.Parameters.AddWithValue("@EmergencyContactRelationship", SqlDbType.VarChar).Value = dynamicObject["EmergencyContactRelationship"].ToString();
                        cmd.Parameters.AddWithValue("@EmergencyContactAddress", SqlDbType.VarChar).Value = dynamicObject["EmergencyContactAddress"].ToString();
                        cmd.Parameters.AddWithValue("@EmergencyContactMobileNumber", SqlDbType.VarChar).Value = dynamicObject["EmergencyContactMobileNumber"].ToString();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                return true;
            }
            catch { return false; }
        }
    }
}
