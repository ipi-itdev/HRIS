using WCORE.Utility;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data;
using System.Collections.Generic;
using WCORE.Models;
using WCORE.Report;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace WCORE.Controllers
{
    public class MiscController : BaseController
    {
        private IPICORE_DTSEntities db = new IPICORE_DTSEntities();
        Common cmn = new Common();

        // -- RETRIEVE QUERIES

        public ActionResult ActiveDocument()
        {
            return View();
        }

        public ActionResult InactiveDocument()
        {
            return View();
        }

        public virtual JsonResult GetDocuments()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetDocuments(@UserRefNo) ORDER BY ID DESC";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetDocumentsDone()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetDocumentsDone(@UserRefNo) ORDER BY ID DESC";
            SQL = SQL.Replace("@UserRefNo", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetDocumentsDetails(int documentID)
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetDocumentsDetails('" + documentID + "') ORDER BY ID DESC";
            //SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetDocumentsStatus()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetDocumentStatus() ORDER BY Description ASC";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetDocumentsDetailStatus()
        {
            string SQL = null;
            SQL = "SELECT * FROM dbo.fGetDocumentDetailsStatus() ORDER BY Description ASC";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public ActionResult DocumentDetails()
        {
            return View();
        }

        //----- INJECT QUERIES 

        public virtual bool UpdateDocumentProgress(int actionType, int documentID, string documentName, string from, string to, int statusID, string date, string remarks, int detailsID)
        {

            DBHelper dbh = new DBHelper();
            string SQL = "EXEC dbo.pUpdateDocumentDetailsProgress " + actionType + ", " + documentID + ", " + "'" + documentName + "'" + ", " + "'" + from + "'" + ", " + "'" + to + "'" + ", " + statusID + ", " + "'" + date + "'" + ", " + "'" + remarks + "'" + ", " + Convert.ToString(cmn.SessionUserRefNo()) + ", " + detailsID;
            dbh.ExecuteNonQuery(SQL, CommandType.Text); 
            return true;
        }

    }
}
