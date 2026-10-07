using WCORE.Utility;
using System;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Web;

namespace WCORE.Controllers
{
    public class PARController : BaseController
    {

        private IPICORE_DTSEntities db = new IPICORE_DTSEntities();
        Common cmn = new Common();

        public ActionResult PARInternal(int pKey, string mName)
        {
            ViewBag.PKey = pKey;
            ViewBag.mName = mName;
            Type modelType = GetModelType(mName);
            DataTable dtPAR = null;
            int seq = 0, status = 0, mr = 0, cuser = 0, ct = 0;
            bool cprint = false, cupdatedtl = false;
            if (pKey > 0)
            {
                dtPAR = Common.GetData("PAR_CurrentUser", "ID = '" + pKey + "' AND IsActive = 1");
                seq = int.Parse(dtPAR.Rows[0]["ApprovalLevel"].ToString());
                status = int.Parse(dtPAR.Rows[0]["FilingStatusRefNo"].ToString());
                mr = int.Parse(dtPAR.Rows[0]["CreatedBy"].ToString());
                cuser = int.Parse(dtPAR.Rows[0]["CurrentUser"].ToString());
                ViewBag.Action = dtPAR.Rows[0]["UserAction"].ToString();
                ViewBag.AL = int.Parse(dtPAR.Rows[0]["ApprovalLevel"].ToString());
                ct = int.Parse(dtPAR.Rows[0]["ContractTemplateRefNo"].ToString());
                cprint = bool.Parse(dtPAR.Rows[0]["PrintContract"].ToString());
                cupdatedtl = bool.Parse(dtPAR.Rows[0]["AllowUpdate"].ToString());
            }
            DataTable dtRoles = Common.GetData("ModuleUserRoles", "(UserRolesRefno = " + cmn.SessionUserRolesRefNo() + " OR UserRefno = " + cmn.SessionUserRefNo() + ")  AND CODE = '" + mName + "'");
            ViewBag.AllowInsert = dtRoles.Rows[0]["AllowInsert"].ToString() == "True" && dtRoles.Rows[0]["HasNew"].ToString() == "True" ? true : false;
            ViewBag.AllowDelete = (mr == cmn.SessionUserRefNo() && status == 1) ? dtRoles.Rows[0]["AllowDelete"] : false;
            ViewBag.AllowUpdate = (cupdatedtl && status > 1) ? dtRoles.Rows[0]["AllowUpdate"] : false;
            ViewBag.AllowPrint = dtRoles.Rows[0]["AllowPrint"];
            ViewBag.PrintContract = cprint;
            ViewBag.CStatus = status;
            ViewBag.AllowApprove = cmn.IsSuperApprover(cmn.SessionUserRefNo()) ? true : cuser != cmn.SessionUserRefNo() ? false : dtRoles.Rows[0]["AllowApprove"];
            ViewBag.DisAllowApprove = cmn.IsSuperApprover(cmn.SessionUserRefNo()) ? true : (cuser != cmn.SessionUserRefNo() || cuser == mr) ? false : dtRoles.Rows[0]["AllowApprove"];

            return View();
        }

       
        public ActionResult PARExternal(int pKey, string mName)
        {
            ViewBag.PKey = pKey;
            ViewBag.mName = mName;
            Type modelType = GetModelType(mName);   
            DataTable dtPAR = null;
            int seq = 0, status = 0, mr = 0, cuser = 0, ct = 0;
            bool cprint = false;
            if (pKey > 0)
            {
                dtPAR = Common.GetData("PAR_CurrentUser", "ID = '" + pKey + "' AND IsActive = 1");
                seq = int.Parse(dtPAR.Rows[0]["ApprovalLevel"].ToString());
                status = int.Parse(dtPAR.Rows[0]["FilingStatusRefNo"].ToString());
                mr = int.Parse(dtPAR.Rows[0]["CreatedBy"].ToString());
                cuser = int.Parse(dtPAR.Rows[0]["CurrentUser"].ToString());
                ViewBag.Action = dtPAR.Rows[0]["UserAction"].ToString();
                ViewBag.AL = int.Parse(dtPAR.Rows[0]["ApprovalLevel"].ToString());
                ct = int.Parse(dtPAR.Rows[0]["ContractTemplateRefNo"].ToString());
                cprint = bool.Parse(dtPAR.Rows[0]["PrintContract"].ToString());
            }
            DataTable dtRoles = Common.GetData("ModuleUserRoles", "(UserRolesRefno = " + cmn.SessionUserRolesRefNo() + " OR UserRefno = " + cmn.SessionUserRefNo() + ")  AND CODE = '" + mName + "'");
            ViewBag.AllowInsert = dtRoles.Rows[0]["AllowInsert"].ToString() == "True" && dtRoles.Rows[0]["HasNew"].ToString() == "True" ? true : false;
            ViewBag.AllowDelete = (mr == cmn.SessionUserRefNo() && status == 1) ? dtRoles.Rows[0]["AllowDelete"] : false;
            ViewBag.AllowUpdate = (mr == cmn.SessionUserRefNo() && status == 1) ? dtRoles.Rows[0]["AllowUpdate"] : false;
            ViewBag.AllowPrint = dtRoles.Rows[0]["AllowPrint"];
            ViewBag.PrintContract = cprint;
            ViewBag.AllowApprove = cmn.IsSuperApprover(cmn.SessionUserRefNo()) ? true : cuser != cmn.SessionUserRefNo() ? false : dtRoles.Rows[0]["AllowApprove"];
            ViewBag.DisAllowApprove = cmn.IsSuperApprover(cmn.SessionUserRefNo()) ? true : (cuser != cmn.SessionUserRefNo() || cuser == mr) ? false : dtRoles.Rows[0]["AllowApprove"];

            return View();
        }
        


        [HttpPost]
        public virtual JsonResult GetListBenefits(int empno)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fSelectContractCronus()";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult CheckDuplicatePAR(int empno)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnParExternalsDuplicateRequest(" + empno + ")";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult CheckDuplicateGLobeEmployee(int empno)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.PORTAL_GlobeEmployees_U WHERE EmployeeRefNo = " + empno + " ";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public virtual JsonResult CheckKPI(int empno, int reason)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnCheckKPI_PAR(" + empno + "," + reason + ")";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }


        public virtual JsonResult GetEmployeeMovement(int pkey)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetEmployeeMovement(" + pkey + ")";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetEmployeeMovement2(int pkey)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetEmployeeMovement2(" + pkey + ")";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetEmployeeReasonForChage(int pkey)
        {
            string SQL = null;
            SQL = "EXEC dbo.p_GetEmployeeReasonForChange @EmployeeRefNo =" + pkey;
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult ComputePARDetails(int pKey)
        {
            string SQL = null;
            SQL = "EXEC dbo.PAR_Computation @PARID=" + pKey;
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Computation(int pKey)
        {
            ViewBag.PARID = pKey;
            return View();
        }

        public virtual JsonResult ComputePAR(int empno, int prate, int pbasis, int ecola, decimal basic, decimal crate, int ecolarate, decimal sil, decimal hmo, decimal hmoamnt, int pkey, bool sss, bool pagibig, bool phic, bool hol, bool sep, bool tmonth)
        {
            string SQL = null;
            SQL = "EXEC dbo.PIS_PARComputation @EmployeeRefNo=" + empno + ",@PayrollRateRefNo=" + prate + ",@PayBasisRefNo=" + pbasis
                + ",@EcolaComputationRefNo=" + ecola + ",@BasicRate='" + basic + "',@ClientRate='" + crate + "',@EcolaRateRefNo=" + ecolarate
                + ",@SIL='" + sil + "',@HMO='" + hmo + "',@HMOAmount='" + hmoamnt + "',@PARRefNo=" + pkey + ",@SSS='" + sss + "',@PAGIBIG='" + pagibig + "',@PHIC='" + phic
                + "',@HOLPAY='" + hol + "',@SEPPAY='" + sep + "',@13TH='" + tmonth + "'";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual bool UploadJD(int pkey, HttpPostedFileBase file)
        {
            if (file != null)
            {
                FileInfo fi = new FileInfo(file.FileName);
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Common.GetDataFN("dbo.fGetSettingsValue(31)").ToString() + "\\PISJD\\PARJD" + pkey + fi.Extension;
                Common.ExecuteNonQuery("UPDATE PIS_PAR SET JobDescriptionPath = 'PARJD" + pkey + fi.Extension + "' WHERE IsActive = 1 AND ID = " + pkey);
                file.SaveAs(Server.MapPath(filePath));
            }
            return true;
        }

        public virtual bool Approve(int id, POSTData data, int ApprovalRefNo, int IsExternal, string rmk, int MenuRefNo)
        {
            DBHelper dbh = new DBHelper();
            var modelType = GetModelType(data.Model);
            var dbTableAttr = (modelType.GetCustomAttributes(typeof(DatabaseTableAttribute), true) as DatabaseTableAttribute[])[0];
            var dbTable = dbTableAttr.Name;
            string SQL = "EXEC('EXEC dbo.PIS_Approvals " + id + ",''" + dbTable + "'', " + cmn.SessionUserRefNo() + ", " + ApprovalRefNo.ToString() + "," + IsExternal + ",''" + rmk + "''," + MenuRefNo + "')";
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool DeletePAR(int ID)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "DELETE FROM PIS_PAR WHERE ID = " + ID + "; DELETE FROM PIS_PAR_Benefits WHERE PARRefNo = " + ID;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public ActionResult PARAccept(int pkey)
        {
            ViewBag.PKey = pkey;
            return View();
        }

        public ActionResult COE(int pkey)
        {
            ViewBag.PKey = pkey;
            DataTable dtRoles = Common.GetData("ModuleUserRoles", "(UserRolesRefno = " + cmn.SessionUserRolesRefNo() + " OR UserRefno = " + cmn.SessionUserRefNo() + ")  AND CODE = 'COE'");
            ViewBag.AllowInsert = bool.Parse(dtRoles.Rows[0]["AllowInsert"].ToString());
            ViewBag.AllowDelete = bool.Parse(dtRoles.Rows[0]["AllowDelete"].ToString());
            ViewBag.AllowUpdate = bool.Parse(dtRoles.Rows[0]["AllowUpdate"].ToString());
            return View();
        }

        public ActionResult Verification(int pkey)
        {
            ViewBag.PKey = pkey;
            DataTable dtRoles = Common.GetData("ModuleUserRoles", "(UserRolesRefno = " + cmn.SessionUserRolesRefNo() + " OR UserRefno = " + cmn.SessionUserRefNo() + ")  AND CODE = 'Verification'");
            ViewBag.AllowInsert = bool.Parse(dtRoles.Rows[0]["AllowInsert"].ToString());
            ViewBag.AllowDelete = bool.Parse(dtRoles.Rows[0]["AllowDelete"].ToString());
            ViewBag.AllowUpdate = bool.Parse(dtRoles.Rows[0]["AllowUpdate"].ToString());
            ViewBag.AllowApprove = bool.Parse(dtRoles.Rows[0]["AllowApprove"].ToString());
            return View();
        }

    }
}
