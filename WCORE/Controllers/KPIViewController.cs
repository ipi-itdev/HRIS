using WCORE.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Data;
using WCORE.Models;
using WCORE.Report;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

namespace WCORE.Controllers
{
    public partial class KPIViewController : BaseController
    {
        Common cmn = new Common();
        DBHelper dbh = new DBHelper();

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

        public virtual bool UpdatingPerformanceIndicatorList(int updateType, int performanceIndicatorID, string perfDesc, int IsForManager, int scoreCardID)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pUpdatingPerformanceIndicator " + updateType + ", " + performanceIndicatorID + ", '" + perfDesc + "', " + Convert.ToString(cmn.SessionUserRefNo()) + ", " + IsForManager + ", " + scoreCardID;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }

        public virtual bool UpdatingPerformanceIndicatorDetails(int saveType, int id, int kpiListID, string kpiDesc, int kpiType, decimal weight, int categoryID = 5)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pUpdatingPerformanceIndicatorDetails " + saveType + ", " + id + ", " + kpiListID + ", '" + kpiDesc + "', " + kpiType + ", " + weight + ", " + categoryID;
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }
        public virtual bool UpdatingPermanentAddress(int saveType, int employeerefno, string permanentregion, string permanentprovince, string permanentmunicipality, string permanentbarangay)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.UpdatePermanentAddress @saveType=" + saveType + ", @employeerefno=" + employeerefno + ", @permanentregion=" + permanentregion + ", @permanentprovince=" + permanentprovince + ", @permanentmunicipality=" + permanentmunicipality + ", @permanentbarangay=" + permanentbarangay + ",@ModifiedBy=" + Convert.ToString(cmn.SessionUserRefNo());
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }

        public virtual bool UpdatingPermanentAddress2(int saveType, int employeerefno, string region, string province, string municipality, string barangay)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.UpdatePermanentAddress2 @saveType=" + saveType + ", @employeerefno=" + employeerefno + ", @region=" + region + ", @province=" + province + ", @municipality=" + municipality + ", @barangay=" + barangay + ",@ModifiedBy=" + Convert.ToString(cmn.SessionUserRefNo());
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }

        public virtual bool UpdatingHighestEducation(int saveType, int employeerefno, int id, string school, string course, string year)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.UpdateHighestEducation @saveType=" + saveType + ", @employeerefno=" + employeerefno + ", @id=" + id + ", @School=" + school + ", @Course=" + course + ", @Year=" + year + ", @CreatedBy=" + Convert.ToString(cmn.SessionUserRefNo()) + ", @ModifiedBy=" + Convert.ToString(cmn.SessionUserRefNo());
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }

        public virtual bool UpdatingDependents(int saveType, int employeerefno, int id, string dependentsname, string relationship, string dependentsbirthdate, int ispwd)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.UpdateDependents @saveType=" + saveType + ", @employeerefno=" + employeerefno + ", @id=" + id + ", @DependentsName=" + dependentsname + ", @Relationship=" + relationship + ", @DependentsBirthDate=" + dependentsbirthdate + ", @IsPWD=" + ispwd + ", @CreatedBy=" + Convert.ToString(cmn.SessionUserRefNo()) + ", @ModifiedBy=" + Convert.ToString(cmn.SessionUserRefNo());
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }

        public virtual bool UpdatingOffense(int saveType, int employeerefno, int id, string offense, string disciplinaryaction, string datecommitted, string remarks,string summary)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.UpdatingOffense @saveType=" + saveType + ", @employeerefno=" + employeerefno + ", @id=" + id + ", @Offense=" + offense + ", @DisciplinaryAction=" + disciplinaryaction + ", @DateCommitted=" + datecommitted + ", @Remarks=" + remarks + ", @Summary=" + summary + ", @CreatedBy=" + Convert.ToString(cmn.SessionUserRefNo()) + ", @ModifiedBy=" + Convert.ToString(cmn.SessionUserRefNo());
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }

        public virtual bool UpdatingCost(int saveType, string employeerefno,  int id,   string description, string cost, string termsrefno, string startdate, string enddate)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.UpdatingCost @saveType=" + saveType + ", @employeerefno=" + employeerefno + ", @id=" + id + ", @Cost="+ cost + ", @Description=" + description + ", @TermsRefNo=" + termsrefno + ", @StartDate=" + startdate + ", @EndDate=" + enddate + ", @CreatedBy=" + Convert.ToString(cmn.SessionUserRefNo()) + ", @ModifiedBy=" + Convert.ToString(cmn.SessionUserRefNo());
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }

        public virtual bool UpdatingBenefits(int saveType, string employeerefno, int id, string description, string amount, string termsrefno, string startdate, string enddate)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.UpdatingBenefits @saveType=" + saveType + ", @employeerefno=" + employeerefno + ", @id=" + id + ", @Amount=" + amount + ", @Description=" + description + ", @TermsRefNo=" + termsrefno + ", @StartDate=" + startdate + ", @EndDate=" + enddate + ", @PreviousAmount = NULL, @PreviousTermsRefNo = NULL, @PreviousStartDate = NULL, @PreviousEndDate = NULL" + ", @CreatedBy=" + Convert.ToString(cmn.SessionUserRefNo()) + ", @ModifiedBy=" + Convert.ToString(cmn.SessionUserRefNo());
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }

        public virtual bool UpdatingTraining(int saveType, int employeerefno, int id, string programname, string trainingprovider, string resourcespeaker, string trainingdate)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.UpdateTraining @saveType=" + saveType + ", @employeerefno=" + employeerefno + ", @id=" + id + ", @ProgramName=" + programname + ", @TrainingProvider=" + trainingprovider + ", @ResourceSpeaker=" + resourcespeaker + ", @TrainingDate=" + trainingdate + ", @CreatedBy=" + Convert.ToString(cmn.SessionUserRefNo()) + ", @ModifiedBy=" + Convert.ToString(cmn.SessionUserRefNo());
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }

        public virtual bool UpdatingAccountability(int saveType, int employeerefno, int id, string description, string dateissued, string datereturned, string remarks)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.UpdatingAccountability @saveType=" + saveType + ", @employeerefno=" + employeerefno + ", @id=" + id + ", @Description=" + description + ", @DateIssued=" + dateissued + ", @DateReturned=" + datereturned + ", @Remarks=" + remarks + ", @CreatedBy=" + Convert.ToString(cmn.SessionUserRefNo()) + ", @ModifiedBy=" + Convert.ToString(cmn.SessionUserRefNo());
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }

        public virtual bool UpdatingKPIDetails(int saveType, int perfrefno, int id, string kpi, string kpicategoryid, string formula, string weight)
        {
            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.UpdatingKPIDetails @saveType=" + saveType + ", @perfrefno=" + perfrefno + ", @id=" + id + ", @kpi=" + kpi + ",@kpicategoryid=" + kpicategoryid +  ", @formula=" + formula + ", @weight=" + weight + ", @ModifiedBy=" + Convert.ToString(cmn.SessionUserRefNo());
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
            dbh.ExecuteNonQuery(SQL, CommandType.Text);

            return true;
        }
    }
}
