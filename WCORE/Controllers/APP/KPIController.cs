using WCORE.Utility;
using System;
using System.Web.Mvc;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace WCORE.Controllers.APP
{
    public class KPIController : BaseController
    {
        Common cmn = new Common();
        DBHelper dbh = new DBHelper();

        //public ActionResult KPIList(int? pid,string mguid)
        //{
        //    ViewBag.pkey = pid;
        //    // get user privileges in the main module and sub modules
        //    string[] strparam = { "@mguid", "@User", "@UserRoles" };
        //    string[] strparamval = { mguid, cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
        //    using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetModuleAccess", CommandType.StoredProcedure, strparam, strparamval))
        //    {
        //        while (dr.Read())
        //        {
        //            ViewBag.mguid = mguid;
        //            ViewBag.mNo = dr["MenuRefNo"].ToString();
        //            ViewBag.mCode = dr["Code"].ToString();
        //            ViewBag.Description = dr["Description"].ToString();
        //            ViewBag.FormID = "mFrm" + dr["MenuRefNo"].ToString();
        //            ViewBag.AllowInsert = bool.Parse(dr["AllowInsert"].ToString());
        //            ViewBag.AllowUpdate = bool.Parse(dr["AllowUpdate"].ToString());
        //        }
        //    }
        //    return View("~/Views/APP/KPI/KPIList.cshtml");
        //}

        public ActionResult PerformanceIndicator(int pid)
        {
            ViewBag.pid = pid;
            return View("~/Views/APP/KPI/KPIList.cshtml");
        }

        public ActionResult PerformanceIndicator_Internal(int pid)
        {
            ViewBag.pid = pid;
            return View("~/Views/APP/KPI/AssignedTo.cshtml");
        }


        public ActionResult KPIMaintenance()
        {
            return View("~/Views/APP/KPI/KPIMaintenance.cshtml");
        }
                
        public virtual bool UpdateKPIAssignedTo(string id, int kpilistid)
        {
            DBHelper dbh = new DBHelper();
            string ids = id.Replace("\"", "'");
            string SQL = "EXEC dbo.pUpdateAssignedTo " + ids + ", " + kpilistid + ", " + Convert.ToString(cmn.SessionUserRefNo());
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual string UpdatingKPIList(int kpiAssigmentRefNo, int updateType, int JobPositionRefNo, int PerformanceIndicatorRefNo, int Type)
        {
            try
            {
                DBHelper dbh = new DBHelper();
                string SQL = "EXEC dbo.pUpdatingKPIList " + kpiAssigmentRefNo + ", " + updateType + ", " + JobPositionRefNo + ", " + PerformanceIndicatorRefNo + ", " + Convert.ToString(cmn.SessionUserRefNo()) + ", " + Type;
                dbh.ExecuteNonQuery(SQL, CommandType.Text);

                return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        //public virtual string UpdatingPerformanceIndicatorList(int updateType, int performanceIndicatorID, string perfDesc, int IsForManager, int scoreCardID)
        //{
        //    DBHelper dbh = new DBHelper();
        //    string SQL = "EXEC dbo.pUpdatingPerformanceIndicator " + updateType + ", " + performanceIndicatorID + ", '" + perfDesc + "', " + Convert.ToString(cmn.SessionUserRefNo()) + ", " + IsForManager + ", " + scoreCardID;
        //    return dbh.ExecuteNonReturnQuery(SQL, CommandType.Text);
        //}

        public virtual bool UpdatingPerformanceIndicatorDetails(int saveType, int id, int kpiListID, string kpiDesc, int kpiType, decimal weight, int categoryID)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pUpdatingPerformanceIndicatorDetails " + saveType + ", " + id + ", " + kpiListID + ", '" + kpiDesc + "', " + kpiType + ", " + weight + ", " + categoryID;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }

        [ValidateInput(false)]
        public virtual bool SetTarget(string saveType, int id, string kpi, int formula, decimal target, decimal weight, int KPIAssignmentRefNo)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pSetTarget " + saveType + ", " + id + ", '" + kpi + "', " + formula + ", " + target + ", " + weight + ", " + KPIAssignmentRefNo;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        [ValidateInput(false)]
        public virtual bool SetScorecardWeight(int id, decimal weight)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pSetScorecardWeight " + id + ", " + weight;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool UpdateKPIPerEmployee(int id)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pUpdateKPIperEployee " + id;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool SetActualScore(int id, string remarks, decimal actual)
        {
            if (actual <= decimal.MaxValue)
            {
                DBHelper dbh = new DBHelper();
                string SQL = "EXEC dbo.pSetActualScore " + id + ", " + actual + ", '" + remarks + "'";
                dbh.ExecuteNonQuery(SQL, CommandType.Text);
                return true;
            }
            else { return false; };
        }

        public virtual bool SetCompetencyScore(int kpiid, decimal score)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pSetCompetencyScore " + kpiid + ", " + score + ", " + Convert.ToString(cmn.SessionUserRefNo());
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool EvaluationDoneTrigger(int actionID, int kpiAssignmentRefNo, string remarks)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.EvaluationDoneTrigger " + actionID + ", " + kpiAssignmentRefNo + ", " + Convert.ToString(cmn.SessionUserRefNo()) + ", '" + remarks + "'";
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }

        public virtual bool RecordScores(int actionType, int KPIAssignmentDetailsRefNo, string coreRefNo, string coreDetailsRefNo, string setNo, string choiceID)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pRecordScores " + actionType + ", " + KPIAssignmentDetailsRefNo + ", " + coreRefNo + ", " + coreDetailsRefNo + ", " + setNo + ", " + choiceID;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool RecordScoreSummary(int actionType, int KPIAssignmentDetailsRefNo)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pRecordScoreSummary " + actionType + ", " + KPIAssignmentDetailsRefNo;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool UpdatepartThree(int KPIAssignmentDetailsRefNo, String coreStrengthsHighest, String coreStrengthsLowest,
            String actionPlanA, String specialAssignment, String objectives, String actionPlanB, int reasonForChangeRefNo, String parremarks)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.UpdateEvalPartThree " + KPIAssignmentDetailsRefNo + ", '" + coreStrengthsHighest + "', '" + coreStrengthsLowest + "', '" + actionPlanA + "', '" + specialAssignment + "', '" + objectives + "', '" + actionPlanB + "', " + reasonForChangeRefNo + ", '" + parremarks + "'";
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool ReplaceKPIList(int KPIAssignmentRefNo, int kpiListID)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pReplaceKPIList " + KPIAssignmentRefNo + ", " + kpiListID + ", " + Convert.ToString(cmn.SessionUserRefNo());
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool GetScoreForReview(int KPIAssignmentRefNo)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pGetScoreForReview " + KPIAssignmentRefNo;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool GetCoreCompeteScoreForReview(int KPIAssignmentRefNo)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pGetCoreCompeteScoreForReview " + KPIAssignmentRefNo;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool UpdatingDueDate(int KPIAssignmentRefNo)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pUpdatingDueDate " + KPIAssignmentRefNo;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool UpdatingKPIYear(string year)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pUpdatingKPIYear " + year;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool RemovePerfIncator(int PerfItemID)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pRemoveIndcator " + PerfItemID;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        public virtual bool UpdatingScorecard(int updateType, int ScorecardID, string desc)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pUpdatingScorecard " + updateType + ", " + ScorecardID + ", '" + desc + "', " + Convert.ToString(cmn.SessionUserRefNo());
            //return dbh.ExecuteNonReturnQuery(SQL, CommandType.Text);
            dbh.ExecuteNonQuery(SQL, CommandType.Text);
            return true;
        }

        ///--------------------------------------------


        [HttpPost]
        public virtual JsonResult GetEmployeeListHistory()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fEmployeeListForReview(@User) ORDER BY CreatedDate DESC";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetEmployeeListDisapproved()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fEmployeeListDisapproved(@User) ORDER BY CreatedDate DESC";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetEmployeeListForEvaluation()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fKPerformanceEvaluationListForEvaluation(@User) ORDER BY ID DESC";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public virtual JsonResult GetKPIIndicatorDetails(int KPIAssignmentRefNo)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetKPIListDetails(@KPIAssignmentRefNo) ORDER BY ID ASC";
            SQL = SQL.Replace("@KPIAssignmentRefNo", Convert.ToString(KPIAssignmentRefNo));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetKPIIndicatorDetailsToScore(int kpiAssignmentRefNo, int categoryID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetKPIDetailsToScore(@kpiAssignmentRefNo, @categoryID) ORDER BY ID ASC";
            SQL = SQL.Replace("@kpiAssignmentRefNo", Convert.ToString(kpiAssignmentRefNo));
            SQL = SQL.Replace("@categoryID", Convert.ToString(categoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetEmployeeAssignedTO(int JobPositionRefNo, string searchValue)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fKAssignedToSelected(@JobPositionRefNo, @User,'" + searchValue + "') ORDER BY Employee ASC";
            SQL = SQL.Replace("@JobPositionRefNo", Convert.ToString(JobPositionRefNo));
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetClientEmployeeAssignedTO(int JobPositionRefNo, string searchValue)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fKAssignedClientToSelected(@JobPositionRefNo,'" + searchValue + "') ORDER BY Employee ASC";
            SQL = SQL.Replace("@JobPositionRefNo", Convert.ToString(JobPositionRefNo));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult GetAssignedEmployeeUnSelected(int kpiAssignmentRefNo)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fKAssignedToUnSelected(@kpiAssignmentRefNo) ORDER BY FullName ASC";
            SQL = SQL.Replace("@kpiAssignmentRefNo", Convert.ToString(kpiAssignmentRefNo));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetKPIGroup(int kpiid)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetKPIGroup(@User, '" + kpiid + "') ORDER BY ID DESC";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult CheckTargets(int kpiid, int empRefNo)
        {
            string SQL = null;
            SQL = "SELECT * FROM fCheckTarget('" + kpiid + "', '" + empRefNo + "' )";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetWeightPercentage(int isForManager)
        {
            string SQL = null;
            SQL = "SELECT * FROM fGetWeightPercentage('" + isForManager + "')";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetManagerScorePartOne(int kpiid)
        {
            string SQL = null;
            SQL = "SELECT ISNULL(CCS.Score, 0.00) FROM dbo.KPI_CoreCompetencyScore CCS WHERE CCS.KPIAssignmentRefNo = '" + kpiid + "'";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult CheckScores(int kpiid)
        {
            string SQL = null;
            SQL = "SELECT CASE WHEN (SELECT COUNT(*) FROM dbo.PIS_KPIDetailsPerEmployee KDPE WHERE KDPE.KPIAssignmentDetailsRefNo = '" + kpiid + "' AND KDPE.Rating = 0) = 0 THEN 1 ELSE 0 END IsReady";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetEvalPurpose()
        {
            string SQL = null;
            SQL = "SELECT ID, Description FROM dbo.PIS_EvalPurpose WHERE IsActive = 1";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetCoreCompetency()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetCoreCompetency() ORDER BY ID ASC";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetCoreCompetencyDetails()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.PIS_CoreCompetenciesDetails ORDER BY CoreCompetencyRefNo ASC";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetRatings(int id) // CHECK
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetRatings(@id)";
            SQL = SQL.Replace("@id", Convert.ToString(id));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetPopupDetailsHighest(int KPIAssignmentDetailsRefNo)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetPopUpRatingsHighest(@KPIAssignmentDetailsRefNo)";
            SQL = SQL.Replace("@KPIAssignmentDetailsRefNo", Convert.ToString(KPIAssignmentDetailsRefNo));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetReasonForChange()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetReasonForChange(@User)";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetPopupDetailsLowest(int KPIAssignmentDetailsRefNo)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetPopUpRatingsLowest(@KPIAssignmentDetailsRefNo)";
            SQL = SQL.Replace("@KPIAssignmentDetailsRefNo", Convert.ToString(KPIAssignmentDetailsRefNo));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetKPILists()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetKPILists(@User)";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetKPIListsClient()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetKPIListsClient(@User)";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetPerformanceIndicatorList(int IsForManager)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetPerformanceIndicatorList(@IsForManager)";
            //SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            SQL = SQL.Replace("@IsForManager", Convert.ToString(IsForManager));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetScorecardList()
        {
            string SQL = null;
            SQL = "SELECT SP.ID, SP.Description, FORMAT (ISNULL(SP.ModifiedDate, SP.CreatedDate), 'MM-dd-yy') LastModifiedDate FROM dbo.ScorecardPercentage SP" +
                     " WHERE SP.IsActive = 1 AND SP.CreatedBy = '" + Convert.ToString(cmn.SessionUserRefNo()) + "' AND (SELECT COUNT(*) FROM dbo.ScorecardDetails SD WHERE SD.ScorecardPercentageRefNo = SP.ID AND SD.KPICategoryID = 5) = 0" +
                     " ORDER BY SP.ModifiedDate DESC";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetScorecardDetails(int ScorecardID)
        {
            string SQL = null;
            SQL = "SELECT SD.ID, C.Description, SD.Weight FROM dbo.ScorecardDetails SD INNER JOIN dbo.KPICategory C ON SD.KPICategoryID = C.ID WHERE SD.ScorecardPercentageRefNo = '" + ScorecardID + "'";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }


        public virtual JsonResult GetKPIYear()
        {
            string SQL = null;
            SQL = "SELECT SettingsRefNo, Description, [Value] FROM TMS_Settings_U WHERE TMS_Settings_U.SettingsRefNo = 32";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }


        public virtual JsonResult GetPerformanceIndicatorListDetails(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetPerformanceIndicatorListDetails(@PerfIndicatorID) ORDER BY ID ASC";
            SQL = SQL.Replace("@PerfIndicatorID", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);

        }

        public virtual JsonResult GetPerformanceIndicatorListDetails_2(int PerfIndicatorID, int CategoryID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetPerformanceIndicatorListDetails_2(@PerfIndicatorID,@CategoryID) ORDER BY ID ASC";
            SQL = SQL.Replace("@PerfIndicatorID", Convert.ToString(PerfIndicatorID));
            SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);

        }

        public virtual JsonResult GetEmplyeeHighestEducationDetails(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnEmployeeHighestEducation(@UserRefNo) ORDER BY ID ASC";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetEmployeeDependentsDetails(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnEmployeeDependents(@UserRefNo) ORDER BY ID ASC";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetEmployeeOffenseDetails(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnEmployeeOffense(@UserRefNo) ORDER BY ID ASC";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetEmployeeCost(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnEmployeeOtherCost(@UserRefNo) ORDER BY ID DESC";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetEmployeeBenefits(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnEmployeeOtherBenefits4(@UserRefNo) ORDER BY ID DESC";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetEmployeeTrainingDetails(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnEmployeeTraining(@UserRefNo) ORDER BY ID ASC";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetEmployeeAccountabilityDetails(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnEmployeeAccountability(@UserRefNo) ORDER BY ID ASC";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        

        public virtual JsonResult GetRegionList()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.View_Region";
            //SQL = SQL.Replace("@RegionRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetProvinceList_2()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.View_Province";
            //SQL = SQL.Replace("@RegionRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
           
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetProvinceList(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnGetProvince(@RegionRefNo) ORDER BY ID ASC";
            SQL = SQL.Replace("@RegionRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetMunicipalityList(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnGetMunicipality(@ProvinceRefNo) ORDER BY ID ASC";
            SQL = SQL.Replace("@ProvinceRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetBarangayList(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnGetBarangay(@MunicipalityRefNo) ORDER BY ID ASC";
            SQL = SQL.Replace("@MunicipalityRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }


        public virtual JsonResult GetEmployeeContacts(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fnGetEmployeeContacts(@UserRefNo) ORDER BY ID ASC";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetEmployeeInformationDetails(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "EXEC PIS_Computation @EmployeeID = @UserRefNo";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetApprovalLevel(int id)
        {
            string SQL = null;
            SQL = "SELECT ApprovalLevel, * FROM PAR_CurrentUser WHERE ID = @ID";
            SQL = SQL.Replace("@ID", Convert.ToString(id));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetPARInformationDetails(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "EXEC PAR_Computation @PARID = @UserRefNo";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }
        public virtual JsonResult GetKPIInformationDetails(int PerfIndicatorID)
        {
            string SQL = null;
            SQL = "SELECT * FROM fGetKPILisCategory(@UserRefNo)";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(PerfIndicatorID));
            //SQL = SQL.Replace("@CategoryID", Convert.ToString(CategoryID));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetPartOneResult(String PerfEvalID, int employeeRefNo)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetKPILists()";
            //SQL = SQL.Replace("@PerfEvalID", Convert.ToString("'" + PerfEvalID + "'"));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult AddEmployee()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fEmployeeSelect(@User)";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetScoreSummary(int KPIAssignmentDetailsRefNo)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetScoreSummary(@KPIAssignmentDetailsRefNo)";
            SQL = SQL.Replace("@KPIAssignmentDetailsRefNo", Convert.ToString(KPIAssignmentDetailsRefNo));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }
        
        public virtual JsonResult GETCoreResult(int kpiAssignmentDetailsID)
        {
            string SQL = null;
            SQL = "SELECT SequenceRefNo, CoreCompetencyRefNo, CoreDetailsRefNo, SetNo, ForGM  FROM dbo.PIS_CoreCompetencyResult WHERE KPIAssignmentDetailsRefNo = '" + kpiAssignmentDetailsID + "' ORDER BY CoreCompetencyRefNo, SetNo ASC";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        //public ActionResult TargetSetting(int pKey, string mName)
        //{
        //    ViewBag.PKey = pKey;
        //    ViewBag.mName = mName;
        //    Type modelType = GetModelType(mName);
        //    DataTable dtKPI;
        //    int seq = 0, status = 0, mr = 0, cuser = 0;
        //    if (pKey > 0)
        //    {
        //        dtKPI = Common.GetData("KPI_CurrentUser", "ID = '" + pKey + "' AND IsActive = 1");
        //        seq = int.Parse(dtKPI.Rows[0]["ApprovalLevel"].ToString());
        //        status = int.Parse(dtKPI.Rows[0]["FilingStatusRefNo"].ToString());
        //        mr = int.Parse(dtKPI.Rows[0]["CreatedBy"].ToString());
        //        cuser = int.Parse(dtKPI.Rows[0]["CurrentUser"].ToString());
        //        ViewBag.Action = dtKPI.Rows[0]["UserAction"].ToString();
        //        ViewBag.cuser = cuser;
        //    }

        //    DataTable dtRoles = Common.GetData("MenuUserRoles", "UserRolesRefno = " + cmn.SessionUserRolesRefNo() + " AND CODE = '" + mName + "'");
        //    ViewBag.AllowInsert = dtRoles.Rows[0]["AllowInsert"].ToString() == "True" && dtRoles.Rows[0]["HasNew"].ToString() == "True" ? true : false;
        //    ViewBag.AllowDelete = (mr == cmn.SessionUserRefNo() && status == 1) ? dtRoles.Rows[0]["AllowDelete"] : false;
        //    ViewBag.AllowUpdate = (mr == cmn.SessionUserRefNo() && status == 1) ? dtRoles.Rows[0]["AllowUpdate"] : false;
        //    ViewBag.AllowPrint = cuser == cmn.SessionUserRefNo() ? dtRoles.Rows[0]["AllowPrint"] : false;
        //    //ViewBag.AllowPrint = cuser == cmn.SessionUserRefNo() ? dtRoles.Rows[0]["AllowPrint"] : false;

        //    ViewBag.AllowApprove = dtRoles.Rows[0]["AllowApprove"];
        //    ViewBag.cuserPriv = Convert.ToString(cmn.SessionUserRolesRefNo());

        //    return View("~/Views/APP/KPI/TargetSetting.cshtml");
        //}

        public ActionResult TargetSetting(string mguid, int pid)
        {
            ViewBag.Pkey = pid;
  
            DataTable dtKPI;
               int seq = 0, status = 0, mr = 0, cuser = 0;
               if (ViewBag.Pkey > 0)
               {
                   dtKPI = Common.GetData("KPI_CurrentUser", "ID = '" + ViewBag.Pkey + "' AND IsActive = 1");
                   seq = int.Parse(dtKPI.Rows[0]["ApprovalLevel"].ToString());
                   status = int.Parse(dtKPI.Rows[0]["FilingStatusRefNo"].ToString());
                   mr = int.Parse(dtKPI.Rows[0]["CreatedBy"].ToString());
                   cuser = int.Parse(dtKPI.Rows[0]["CurrentUser"].ToString());
                   ViewBag.Action = dtKPI.Rows[0]["UserAction"].ToString();
                   ViewBag.cuser = cuser;
               }

               DataTable dtRoles = Common.GetData("MenuUserRoles", "UserRolesRefno = " + cmn.SessionUserRolesRefNo() + " AND CODE = 'TargetSettingRev'");
               ViewBag.AllowInsert = dtRoles.Rows[0]["AllowInsert"].ToString() == "True" && dtRoles.Rows[0]["HasNew"].ToString() == "True" ? true : false;
               ViewBag.AllowDelete = (mr == cmn.SessionUserRefNo() && status == 1) ? dtRoles.Rows[0]["AllowDelete"] : false;
               ViewBag.AllowUpdate = (mr == cmn.SessionUserRefNo() && status == 1) ? dtRoles.Rows[0]["AllowUpdate"] : false;
               ViewBag.AllowPrint = cuser == cmn.SessionUserRefNo() ? dtRoles.Rows[0]["AllowPrint"] : false;

               ViewBag.AllowApprove = dtRoles.Rows[0]["AllowApprove"];
               ViewBag.cuserPriv = Convert.ToString(cmn.SessionUserRolesRefNo());

            return View("~/Views/APP/KPI/TargetSetting.cshtml");
        }


        public virtual JsonResult KPIActiveEmployee(int EvalPurposeRefNo)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fKPISelectEmployee(@User, @EvalPurposeRefNo)";
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            SQL = SQL.Replace("@EvalPurposeRefNo", Convert.ToString(EvalPurposeRefNo));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetKPIScoreResult(int KPIAssignmentDetailsRefNo)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fKPIGetKPIScoreResult(@KPIAssignmentDetailsRefNo)";
            SQL = SQL.Replace("@KPIAssignmentDetailsRefNo", Convert.ToString(KPIAssignmentDetailsRefNo));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetSpecialComments(int KPIAssignmentDetailsRefNo)
        {
            string SQL = null;
            SQL = "SELECT * FROM fGetSpecialAssignments(" + KPIAssignmentDetailsRefNo + ")";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetProbyDate(int KPIAssignmentDetailsRefNo)
        {
            string SQL = null;
            SQL = "SELECT DATEADD(MONTH, 5, eu.DateProbationary) FROM dbo.PIS_KPIAssigmentDetails kad " +
                  "INNER JOIN PIS_EmploymentInfo_U eu ON kad.EmployeeRefNo = eu.EmployeeRefNo WHERE kad.ID =  '" + KPIAssignmentDetailsRefNo + "'";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public ActionResult EvaluationReport(int KPIAssignmentDetailsID, string status, string report)
        {
            ReportDocument rd = new ReportDocument();
            DataTable dataTable = new DataTable();
            DataTable sub1 = new DataTable();
            DataTable sub2 = new DataTable();
            DataTable sub3 = new DataTable();

            string reportName = report + ".rpt";

            dataTable = new DBHelper().ExecuteQuery("SELECT * FROM fKPIGenerateReportHeader('" + KPIAssignmentDetailsID + "', '" + status + "') ", CommandType.Text);
            sub1 = new DBHelper().ExecuteQuery("SELECT * FROM dbo.fKPIGenerateReportPartONE('" + KPIAssignmentDetailsID + "')  ORDER BY ID ASC", CommandType.Text);
            sub2 = new DBHelper().ExecuteQuery("SELECT * FROM dbo.fKPIGenerateReportPartTWO('" + KPIAssignmentDetailsID + "', '" + status + "') ORDER BY ID, SetNo ASC", CommandType.Text);
            sub3 = new DBHelper().ExecuteQuery("SELECT * FROM dbo.fKPIGenerateReportPartTHREE('" + KPIAssignmentDetailsID + "')", CommandType.Text);
            rd.Load(Path.Combine(Server.MapPath("~/Report/KPI"), reportName));
            rd.SetDataSource(dataTable);

            rd.OpenSubreport("KPIReportPartOne").SetDataSource(sub1);
            rd.OpenSubreport("KPIPartTwo").SetDataSource(sub2);
            rd.OpenSubreport("KPIReportPartThree").SetDataSource(sub3);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf");
            }
            catch (Exception)
            {
                throw;
            }
            finally { rd.Close(); rd.Dispose(); }
        }

        public ActionResult KPIEvaluationReport(int KPIAssignmentDetailsID, string status, string report)
        {
            ReportDocument rd = new ReportDocument();
            DataTable dataTable = new DataTable();
            DataTable sub1 = new DataTable();

            string reportName = report + ".rpt";
            dataTable = new DBHelper().ExecuteQuery("SELECT * FROM fKPIGenerateReportHeader('" + KPIAssignmentDetailsID + "', '" + status + "') ", CommandType.Text);
            sub1 = new DBHelper().ExecuteQuery("SELECT * FROM dbo.fKPIGenerateReportPartONE('" + KPIAssignmentDetailsID + "') ORDER BY ID ASC", CommandType.Text);
            rd.Load(Path.Combine(Server.MapPath("~/Report/KPI"), reportName));
            rd.SetDataSource(dataTable);

            rd.OpenSubreport("KPIReportPartOne").SetDataSource(sub1);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf");
            }
            catch (Exception)
            {
                throw;
            }
            finally { rd.Close(); rd.Dispose(); }
        }

        public ActionResult KPIReport(int KPIAssignmentDetailsID, string status, string reportName)
        {
            ViewBag.reportStatus = status;
            ViewBag.finalReport = reportName;
            ViewBag.id = KPIAssignmentDetailsID;
            return View("~/Views/APP/KPI/KPIReport.cshtml");
        }

        public ActionResult PartialKPIReport(int KPIAssignmentDetailsID, string status, string reportName)
        {
            ViewBag.reportStatus = status;
            ViewBag.reportName = reportName;
            ViewBag.id = KPIAssignmentDetailsID;
            ViewBag.finalReport = reportName;
            //return View();
            // added for clarification 
            return View("~/Views/APP/KPI/PartialKPIReport.cshtml");
        }

        public virtual JsonResult GetKPICategory(int PerfID)
        {
            string SQL = null;
            SQL = "SELECT * FROM fGetKPILisCategory('" + PerfID + "')";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetKPICategoryHeader(int kpiid)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetKPIListHeader('" + kpiid + "')";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetKPICategoryHeaderTargetSetting(int kpiid)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetKPIListHeaderTargetSetting('" + kpiid + "')";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }


        public virtual JsonResult GetScorecards()
        {
            string SQL = null;
            SQL = "SELECT SP.ID, SP.Description FROM dbo.ScorecardPercentage SP WHERE SP.CreatedBy = '" + Convert.ToString(cmn.SessionUserRefNo()) + "' AND SP.IsActive = 1 AND SP.Description NOT LIKE '%RFSC-%' AND" +
                  " (SELECT SUM(SD.Weight) FROM dbo.ScorecardDetails SD WHERE SD.ScorecardPercentageRefNo = SP.ID) = 100";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        //public virtual JsonResult GetKPICategoryDetails(int kpiid, int categoryID)
        public virtual JsonResult GetKPICategoryDetails(int kpiid)// remove parameter category id due to user priviliges is only at 74 
        {
            string SQL = null;
            SQL = "SELECT KDPE.ID, KDPE.KPIIndicator, CASE WHEN KDPE.KPIType = 1 THEN 'A = P / T x 100' WHEN KDPE.KPIType = 2 THEN 'A = T / P x 100' WHEN KDPE.KPIType = 3 THEN 'Budget Bracket' END Formula, KDPE.KPIWeight, KDPE.KPITarget FROM dbo.PIS_KPIDetailsPerEmployee KDPE WHERE KDPE.KPIAssignmentDetailsRefNo = '" + kpiid + "'";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public ActionResult KPIModal()
        {
            return View("~/Views/APP/KPI/KPIModal.cshtml");
        }

        public ActionResult AssignedEmployee()
        {
            return View("~/Views/APP/KPI/AssignedEmployee.cshtml");
        }

        public ActionResult EvaluationMain()
        {
            ViewBag.cuserPriv = Convert.ToString(cmn.SessionUserRolesRefNo());
            return View("~/Views/APP/KPI/EvaluationMain.cshtml");
        }

        public ActionResult Evaluation()
        {
            return View("~/Views/APP/KPI/Evaluation.cshtml");
        }

        public ActionResult KPIScore()
        {
            return View("~/Views/APP/KPI/KPIScore.cshtml");
        }

        public ActionResult SpecialAssignment()
        {
            return View("~/Views/APP/KPI/SpecialAssignment.cshtml");
        }

        public ActionResult KPISummary()
        {
            return View("~/Views/APP/KPI/KPISummary.cshtml");
        }

        public ActionResult KPIAssignment()
        {
            return View("~/Views/APP/KPI/KPIAssignment.cshtml");
        }

        public ActionResult AssignedTo()
        {
            return View("~/Views/APP/KPI/AssignedTo.cshtml");
        }

        public ActionResult KPIHistory()
        {
            return View("~/Views/APP/KPI/KPIHistory.cshtml");
        }

        public ActionResult EmployeeSelect()
        {
            return View("~/Views/APP/KPI/EmployeeSelect.cshtml");
        }

        public ActionResult TargetsForReview()
        {
            return View("~/Views/APP/KPI/TargetsForReview.cshtml");
        }

        public ActionResult CoreCompetencies()
        {
            return View("~/Views/APP/KPI/CoreCompetencies.cshtml");
        }

        
        public ActionResult CoreCompetenciesRev()
        {
            return View("~/Views/APP/KPI/CoreCompetenciesRev.cshtml");
        }

        
        public ActionResult KPIListPopup()
        {
            return View("~/Views/APP/KPI/KPIListPopup.cshtml");
        }

        public ActionResult KPIYear()
        {
            return View("~/Views/APP/KPI/KPIYear.cshtml");
        }

        public ActionResult KPIListManager()
        {
            return View("~/Views/APP/KPI/KPIListManager.cshtml");
        }

        public ActionResult KPIDetailsManagers()
        {
            return View("~/Views/APP/KPI/KPIDetailsManagers.cshtml");
        }

        public ActionResult TargetDetails()
        {
            return View("~/Views/APP/KPI/TargetDetails.cshtml");
        }

        public ActionResult KPIScorePerCategory()
        {
            return View("~/Views/APP/KPI/KPIScorePerCategory.cshtml");
        }

        public ActionResult ScoreCardPercentage()
        {
            return View("~/Views/APP/KPI/ScoreCardPercentage.cshtml");
        }

        public ActionResult ManagersScore()
        {
            return View("~/Views/APP/KPI/ManagersScore.cshtml");
        }

        public ActionResult KPIListExternal()
        {
            return View("~/Views/APP/KPI/KPIListExternal.cshtml");
        }

        public ActionResult AssignedToExternal()
        {
            return View("~/Views/APP/KPI/AssignedToExternal.cshtml");
        }
        public ActionResult KPIListRev()
        {
            return View("~/Views/APP/KPI/KPIListRev.cshtml");
        }
    }

}
