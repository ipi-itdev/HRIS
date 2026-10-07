using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Mvc;
using WCORE.Models;
using WCORE.Utility;

namespace WCORE.Controllers
{
    public class INVController : Controller
    {
        Common cmn = new Common();
        DBHelper dbh = new DBHelper();
        public ActionResult Items(int pid, string mguid)
        {
            ViewBag.pid = pid;
            // get user privileges in the main module and sub modules
            string[] strparam = { "@mguid", "@User", "@UserRoles" };
            string[] strparamval = { mguid, cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetModuleAccess", CommandType.StoredProcedure, strparam, strparamval))
            {
                if(dr.Read())
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
                    ViewBag.AllowAddOth = bool.Parse(dr["AllowAddOth"].ToString());
                    ViewBag.AllowExport = bool.Parse(dr["AllowExport"].ToString());
                }
            }
            // item status info for button status
            string[] strparamIDs = { "@iID" };
            string[] strparamvalIDs = { pid.ToString() };
            using (DataTable dtitem = dbh.ExecuteQuery("SELECT * FROM dbo.Items WHERE ID = @iID", CommandType.Text, strparamIDs, strparamvalIDs))
            {
                if (dtitem.Rows.Count > 0)
                {
                    ViewBag.IStatus = dtitem.Rows[0]["ItemStatusRefNo"];
                    ViewBag.Status = dtitem.Rows[0]["ItemStatus"];
                }
            }
            return View("~/Views/APP/INV/Items.cshtml");
        }

        public ActionResult ItemPartsStatus(DetailViewModelData modeldata)
        {
            ViewBag.pid = modeldata.pid;
            return View("~/Views/APP/INV/ItemPartsStatus.cshtml");
        }

        public virtual bool ItemStatus(int pid, int status, string remarks, int IsItemParts = 0)
        {
            string[] strparam = { "@pkey", "@status", "@user", "@remarks", "@IsItemParts" };
            string[] strparamval = { pid.ToString(), status.ToString(), cmn.SessionUserRefNo().ToString(), remarks, IsItemParts.ToString() };
            dbh.ExecuteNonQuery("dbo.spINVItemStatus", CommandType.StoredProcedure, strparam, strparamval);
            return true;
        }

        // START Accountability
        public ActionResult EmployeeAccountability(int pid, string mguid)
        {
            ViewBag.pid = pid;
            // get user privileges in the main module and sub modules
            string[] strparam = { "@mguid", "@User", "@UserRoles" };
            string[] strparamval = { mguid, cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetModuleAccess", CommandType.StoredProcedure, strparam, strparamval))
            {
                if(dr.Read())
                {
                    ViewBag.mNo = dr["MenuRefNo"].ToString();
                    ViewBag.mguid = mguid;
                    ViewBag.mName = dr["Code"].ToString();
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.Description = dr["Description"].ToString();
                    ViewBag.FormID = "mFrm" + dr["MenuRefNo"].ToString();
                    ViewBag.FKeyName = "EmpAccountabilityRefNo";

                    ViewBag.AllowInsert = bool.Parse(dr["AllowInsert"].ToString()) && bool.Parse(dr["HasNew"].ToString()) ? true : false;
                    ViewBag.AllowDelete = bool.Parse(dr["AllowDelete"].ToString());
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    ViewBag.AllowAddOth = bool.Parse(dr["AllowAddOth"].ToString());
                    ViewBag.AllowExport = bool.Parse(dr["AllowExport"].ToString());
                }
            }
            // item status info for button status
            string[] strparamIDs = { "@aID" };
            string[] strparamvalIDs = { pid.ToString() };
            using (DataTable dtitem = dbh.ExecuteQuery("SELECT * FROM dbo.INV_EmpAccountability_U WHERE ID = @aID", CommandType.Text, strparamIDs, strparamvalIDs))
            {
                if (dtitem.Rows.Count > 0)
                {
                    ViewBag.IStatus = dtitem.Rows[0]["FilingStatusRefNo"];
                    ViewBag.IStatus = dtitem.Rows[0]["FilingStatusRefNo"];
                    if (dtitem.Rows[0]["FilingStatusRefNo"].ToString() != "1" && dtitem.Rows[0]["FilingStatusRefNo"].ToString() != "7")
                    { ViewBag.AllowApprove = false; }
                }
            }
            return View("~/Views/APP/INV/EmployeeAccountability.cshtml");
        }

        public ActionResult ExtEmployeeAccountability(int pid, string mguid)
        {
            ViewBag.pid = pid;
            // get user privileges in the main module and sub modules
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
                    ViewBag.FKeyName = "EmpAccountabilityRefNo";

                    ViewBag.AllowInsert = bool.Parse(dr["AllowInsert"].ToString()) && bool.Parse(dr["HasNew"].ToString()) ? true : false;
                    ViewBag.AllowDelete = bool.Parse(dr["AllowDelete"].ToString());
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    ViewBag.AllowAddOth = bool.Parse(dr["AllowAddOth"].ToString());
                    ViewBag.AllowExport = bool.Parse(dr["AllowExport"].ToString());
                }
            }
            // item status info for button status
            string[] strparamIDs = { "@aID" };
            string[] strparamvalIDs = { pid.ToString() };
            using (DataTable dtitem = dbh.ExecuteQuery("SELECT * FROM dbo.INV_EmpAccountability_U WHERE ID = @aID", CommandType.Text, strparamIDs, strparamvalIDs))
            {
                if (dtitem.Rows.Count > 0)
                {
                    ViewBag.IStatus = dtitem.Rows[0]["FilingStatusRefNo"];
                    ViewBag.IStatus = dtitem.Rows[0]["FilingStatusRefNo"];
                    if (dtitem.Rows[0]["FilingStatusRefNo"].ToString() != "1" && dtitem.Rows[0]["FilingStatusRefNo"].ToString() != "7")
                    { ViewBag.AllowApprove = false; }
                }
            }
            return View("~/Views/APP/INV/ExtEmployeeAccountability.cshtml");
        }

       



        public ActionResult AccountabilityItemStatusForm(DetailViewModelData modeldata)
        {
            ViewBag.pid = modeldata.pid;
            return View("~/Views/APP/INV/AccountabilityItemStatus.cshtml");
        }

        public ActionResult AccountabilityItemStatusPage(DetailViewModelData modeldata)
        {
            ViewBag.pid = modeldata.pid;
            return View("~/Views/APP/INV/AccountabilityItemStatusChange.cshtml");
        }

        [HttpPost]
        public virtual JsonResult AccountabilityStatus(int pid,int status)
        {
            string[] strparam = { "@pkey", "@status", "@user" };
            string[] strparamval = { pid.ToString(), status.ToString(), cmn.SessionUserRefNo().ToString() };
            var JsonData = dbh.GetJSONData("dbo.spINVAccountabilityStatus", CommandType.StoredProcedure, true, strparam, strparamval);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult AccountabilityItemStatus(int pid, int status,string remarks,int itemstatus)
        {
            string[] strparam = { "@pkey", "@status", "@user", "@remarks" };
            string[] strparamval = { pid.ToString(), status.ToString(), cmn.SessionUserRefNo().ToString(), remarks };
            var JsonData = dbh.GetJSONData("dbo.spINVAccountabilityItemStatus", CommandType.StoredProcedure, true, strparam, strparamval);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }


        //Change Emp Item Status to Repair
        public ActionResult AccountabilityItemStatusChangetoRepair(int pid, int status)
        {
            ViewBag.pid = pid;
            ViewBag.status = status;
            return View("~/Views/APP/INV/AccountabilityItemStatusChangetoRepair.cshtml");
        }

        //Save Change Emp Item Status to Repair
        [HttpPost]
        public virtual bool AccountabilityItemStatustoRepairSave(int pid, int status, string remarks)
        {
            bool ret = false;
            string[] strparam = { "@pkey", "@status", "@user", "@remarks" };
            string[] strparamval = { pid.ToString(), status.ToString(), cmn.SessionUserRefNo().ToString(), remarks };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.INV_SP_AccountabilityItemStatusSavetoRepair", CommandType.StoredProcedure, strparam, strparamval))
           { ret = true; }
            return ret;
        }
        
        //Change Emp Item Status to Return
        public ActionResult AccountabilityItemStatusChangetoReturn(int pid, int status)
        {
            ViewBag.pid = pid;
            ViewBag.status = status;
            return View("~/Views/APP/INV/AccountabilityItemStatusChangetoReturn.cshtml");
        }


        //Save Change Emp Item Status to Return
        [HttpPost]
        public virtual bool AccountabilityItemStatustoReturnSave(int pid, int status, string remarks)
        {
            bool ret = false;
            string[] strparam = { "@pkey", "@status", "@user", "@remarks" };
            string[] strparamval = { pid.ToString(), status.ToString(), cmn.SessionUserRefNo().ToString(), remarks };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.INV_SP_AccountabilityItemStatusSavetoReturn", CommandType.StoredProcedure, strparam, strparamval))
            { ret = true; }
            return ret;
        }



        //Change Emp Item Status to Active
        public ActionResult AccountabilityItemStatusChangetoActive(int pid, int status)
        {
            ViewBag.pid = pid;
            ViewBag.status = status;
            return View("~/Views/APP/INV/AccountabilityItemStatusChangetoActive.cshtml");
        }


        //Save Change Emp Item Status to Active
        [HttpPost]
        //public virtual bool AccountabilityItemStatustoActiveSave(int pid, int status, string remarks)
        public virtual bool AccountabilityItemStatustoActiveSave(int pid, int status, string remarks)
        {
            bool ret = false;
            string[] strparam = { "@pkey", "@status", "@user", "@remarks" };
            string[] strparamval = { pid.ToString(), status.ToString(), cmn.SessionUserRefNo().ToString(), remarks };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.INV_SP_AccountabilityItemStatusSavetoActive", CommandType.StoredProcedure, strparam, strparamval))
            { ret = true; }
            return ret;
        }

        //Employee Accountability History
        public ActionResult EmployeeAccountabilityHistory(int pid, string mguid)
        {
            ViewBag.pid = pid;
            // get user privileges in the main module and sub modules
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
                    ViewBag.FKeyName = "EmpAccountabilityRefNo";

                    ViewBag.AllowInsert = bool.Parse(dr["AllowInsert"].ToString()) && bool.Parse(dr["HasNew"].ToString()) ? true : false;
                    ViewBag.AllowDelete = bool.Parse(dr["AllowDelete"].ToString());
                    ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    ViewBag.AllowAddOth = bool.Parse(dr["AllowAddOth"].ToString());
                    ViewBag.AllowExport = bool.Parse(dr["AllowExport"].ToString());
                }
            }
            // item status info for button status
            string[] strparamIDs = { "@aID" };
            string[] strparamvalIDs = { pid.ToString() };
            using (DataTable dtitem = dbh.ExecuteQuery("SELECT * FROM dbo.INV_EmpAccountability_U WHERE ID = @aID", CommandType.Text, strparamIDs, strparamvalIDs))
            {
                if (dtitem.Rows.Count > 0)
                {


                    ViewBag.ID = dtitem.Rows[0]["ID"];
                    ViewBag.IStatus = dtitem.Rows[0]["FilingStatusRefNo"];
                    ViewBag.IStatus = dtitem.Rows[0]["FilingStatusRefNo"];
                    if (dtitem.Rows[0]["FilingStatusRefNo"].ToString() != "1" && dtitem.Rows[0]["FilingStatusRefNo"].ToString() != "7")
                    { ViewBag.AllowApprove = false; }


                }
            }
            string[] strparamIDsx = { "@aID" };
            string[] strparamvalIDsx = { pid.ToString() };
            using (DataTable dtitemx = dbh.ExecuteQuery("SELECT * FROM VIEW_INV_EmpAccountabilityDetailsHist WHERE EmpAccountabilityRefNo = @aID", CommandType.Text, strparamIDsx, strparamvalIDsx))
            {
                if (dtitemx.Rows.Count > 0)
                {
                    ViewBag.RowsCount = dtitemx.Rows.Count;
                    ViewBag.ColumnsCount = dtitemx.Columns.Count;
                    ViewBag.dtitemx = dtitemx;

                }
            }

            string[] strparamIDsy = { "@aID" };
            string[] strparamvalIDsy = { pid.ToString() };
            using (DataTable dtitemy = dbh.ExecuteQuery("SELECT * FROM VIEW_INV_EmpAccountabilityAll WHERE ID = @aID", CommandType.Text, strparamIDsy, strparamvalIDsy))
            {
                if (dtitemy.Rows.Count > 0)
                {
  
                    ViewBag.dtitemy = dtitemy;

                }
            }


            return View("~/Views/APP/INV/EmployeeAccountabilityHistory.cshtml");
        }


        [HttpGet]
        public JsonResult EmpDetails()
        {
            //Creating List
            List<INVExtEmpAccountabilityDetails> ObjEmp = new List<INVExtEmpAccountabilityDetails>()
            {

            };
            //return list as Json
            return Json(ObjEmp, JsonRequestBehavior.AllowGet);
        }



        // END Accountability
    }
}
