using System;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Data;
using WCORE.Utility;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Configuration;
using ClosedXML.Excel;

namespace WCORE.Controllers
{
    public class RVController : Controller
    {
        DBHelper dbh = new DBHelper();
        Common cmn = new Common();

        public ActionResult Index(ModelData data)
        {
            string[] strparam = { "@mguid" };
            string[] strparamval = { data.mguid };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spSysReport", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read()) { 
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.Description = dr["Description"].ToString();
                    ViewBag.SubDescription = dr["SubDescription"].ToString();
                    ViewBag.Directory = dr["Directory"].ToString();
                    ViewBag.mguid = data.mguid;
                    ViewBag.rptsrc = "../Report/" + data.mguid + cmn.SessionUserRefNo().ToString() + ".pdf";
                }
                dr.NextResult();
                while (dr.Read()) { ViewBag.FilterView = dr[0].ToString(); }
                dr.NextResult();
                while (dr.Read()) { ViewBag.FilterDefaultValue = dr[0].ToString(); }
            }
            return View();
        }

        public ActionResult RptSource(string mguid,string param)
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string[] strparam = { "@mguid", "@param", "@UserRefNo" };
                string[] strparamval = { mguid, param, cmn.SessionUserRefNo().ToString() };
                using (SqlDataReader dr = dbh.ExecuteReader("dbo.spSysReportdt", CommandType.StoredProcedure, strparam, strparamval))
                {
                    while (dr.Read())
                    {
                        rd.Load(Server.MapPath(dr["RptPath"].ToString()));
                        DataTable dt = new DBHelper().ExecuteQuery(dr["RptSource"].ToString(), CommandType.Text);
                        rd.SetDataSource(dt);
                    }
                    dr.NextResult();
                    while (dr.Read())
                    {
                        DataTable dt = new DBHelper().ExecuteQuery(dr["DataSource"].ToString(), CommandType.Text);
                        rd.Subreports[dr["Description"].ToString()].SetDataSource(dt);
                    }

                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    try
                    {
                        Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                        stream.Seek(0, SeekOrigin.Begin);
                        rd.Close();
                        rd.Dispose();
                        return File(stream, "application/pdf");
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }


        public ActionResult ExportReportPARFORM(int pkey)
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string SQL = null;
                SQL = "SELECT * FROM PAR_Report(" + pkey + ")";
                DataTable dt = new DBHelper().ExecuteQuery(SQL, CommandType.Text);
                if (bool.Parse(dt.Rows[0]["PrintContract"].ToString()))
                {
                    //rd.Load(Path.Combine(Server.MapPath("~/Report/PAR/EXT"), dt.Rows[0]["ContractTemplate"].ToString()));
                    rd.Load(Server.MapPath("~/Report/PAR/EXT/" + dt.Rows[0]["ContractTemplate"].ToString()));
                    rd.SetDataSource(dt);
                    if (rd.Subreports.Count > 0)
                    {
                        string SQLOB = null;
                        SQLOB = "SELECT * FROM fGetEmployeePARRequest_Benefits(" + pkey + ")";
                        DataTable dtBenefits = new DBHelper().ExecuteQuery(SQLOB, CommandType.Text);
                        rd.Subreports["OtherBenefits"].SetDataSource(dtBenefits);
                    }
                }
                else
                {
                    //rd.Load(Path.Combine(Server.MapPath("~/Report/PAR/EXT"), "ParReport.rpt"));
                    rd.Load(Server.MapPath("~/Report/PAR/EXT/ParReport.rpt"));
                    string SQLHistory = null;
                    SQLHistory = "SELECT * FROM fnEmploymentHistory_PAR(" + pkey + ")";
                    DataTable dtHistory = new DBHelper().ExecuteQuery(SQLHistory, CommandType.Text);
                    string SQLChanges = null;
                    SQLChanges = "SELECT * FROM fnPAR_CHANGES(" + pkey + ")";
                    DataTable dtChanges = new DBHelper().ExecuteQuery(SQLChanges, CommandType.Text);

                    rd.SetDataSource(dt);
                    rd.Subreports["History"].SetDataSource(dtHistory);
                    rd.Subreports["CHANGES"].SetDataSource(dtChanges);
                }
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    rd.Close();
                    rd.Dispose();
                    return File(stream, "application/pdf");
                }
                catch
                {
                    throw;
                }
            }
        }

        public ActionResult ParReport(int pkey)
        {
            ViewBag.reportID = pkey;
            return View("~/Views/APP/PAR/ParReport.cshtml");
        }


        public ActionResult RenderRpt(string mguid, string arr)
        {
            ViewBag.mguid = mguid;
            ViewBag.arr = arr;
            return View();
        }

        public ActionResult RenderPDF(string url) {
            ViewBag.url = url;
            return View();
        }

        public FileResult Download(string fname)
        {
            string filePath = Common.GetDataFN("dbo.fGetSettingsValue(31)").ToString() + "\\PISJD\\" + fname;

            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath(filePath));

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fname);
        }

        public ActionResult IndexDate(string v,DateTime sdate, DateTime edate)
        {
            ViewBag.EDate = edate;
            ViewBag.SDate = sdate;
            ViewBag.vDisplay = v;
            return View();
        }

        public ActionResult DOLEContractorsSemiannual(DateTime sdate, DateTime edate)
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string SQL = null;
                SQL = "SELECT * FROM fnDOLEContractorsSemiAnnual('" + sdate + "','" + edate + "'," + cmn.SessionUserRefNo() + ")";
                DataTable dt = new DBHelper().ExecuteQuery(SQL, CommandType.Text);
                rd.Load(Server.MapPath("~/Report/PIS/DOLEContracttorsSemiAnnual.rpt"));

                rd.SetDataSource(dt);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                string pdfFile = Server.MapPath("~/Report/sample.xls");


                ExportOptions exportOpts = new ExportOptions();
                ExcelFormatOptions excelFormatOpts = new ExcelFormatOptions();
                DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
                exportOpts = rd.ExportOptions;

                // Set the excel format options.
                excelFormatOpts.ExcelUseConstantColumnWidth = true;
                excelFormatOpts.ExcelTabHasColumnHeadings = true;
                exportOpts.ExportFormatType = ExportFormatType.Excel;
                exportOpts.FormatOptions = excelFormatOpts;

                // Set the disk file options and export.
                exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
                diskOpts.DiskFileName = pdfFile;
                exportOpts.DestinationOptions = diskOpts;

                rd.Export();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    rd.Close();
                    rd.Dispose();
                    return File(stream, "application/pdf");
                }
                catch
                {
                    throw;
                }
            }
        }

        public ActionResult COE(int pkey)
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string SQL = null;
                SQL = "SELECT * FROM fCOE(" + pkey + ")";
                DataTable dt = new DBHelper().ExecuteQuery(SQL, CommandType.Text);

                rd.Load(Path.Combine(Server.MapPath("~/Report/PIS"), dt.Rows[0]["COETemplate"].ToString()));
                rd.SetDataSource(dt);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    rd.Close();
                    rd.Dispose();
                    return File(stream, "application/pdf");
                }
                catch
                {
                    throw;
                }
            }
        }

        public ActionResult Verification(int pkey)
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string SQL = null;
                SQL = "SELECT * FROM fVerification(" + pkey + ")";
                DataTable dt = new DBHelper().ExecuteQuery(SQL, CommandType.Text);

                rd.Load(Path.Combine(Server.MapPath("~/Report/PIS"), dt.Rows[0]["VerificationTemplate"].ToString()));
                rd.SetDataSource(dt);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    rd.Close();
                    rd.Dispose();
                    return File(stream, "application/pdf");
                }
                catch
                {
                    throw;
                }
            }
        }

        public ActionResult DOLEContractorsSemiannuals(DateTime sdate, DateTime edate)
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string SQL = null;
                SQL = "SELECT * FROM fnDOLEContractorsSemiAnnual('" + sdate + "','" + edate + "','" + cmn.SessionUserRefNo() + "')";
                DataTable dt = new DBHelper().ExecuteQuery(SQL, CommandType.Text);
                rd.Load(Server.MapPath("~/Report/PIS/DOLEContracttorsSemiAnnual.rpt"));

                rd.SetDataSource(dt);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                string pdfFile = Server.MapPath("~/Report/sample.xls");

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = pdfFile;
                CrExportOptions = rd.ExportOptions;
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.Excel;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
                rd.Export();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    rd.Close();
                    rd.Dispose();
                    return File(stream, "application/pdf");
                }
                catch
                {
                    throw;
                }
            }
        }
        
        public ActionResult ExportEmployeeProfile(int pkey)
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string SQL = null;
                SQL = "SELECT * FROM dbo.PIS_FN_EmployeeProfileRpt(" + pkey + ")";
                DataTable dt = new DBHelper().ExecuteQuery(SQL, CommandType.Text);
                rd.Load(Server.MapPath("~/Report/PIS/EmployeeProfile.rpt"));
                string SQLCareer = null, SQLEducationTraining = null, SQLPerformanceEvaluation = null, SQLDisciplinaryAction = null;
                DataTable dtCareer = null, dtEducationTraining = null, dtPerformanceEvaluation = null, dtDisciplinaryAction = null;
                // Career
                SQLCareer = "SELECT * FROM PIS_CAREER(" + pkey + ")";
                dtCareer = new DBHelper().ExecuteQuery(SQLCareer, CommandType.Text);
                // Educational and Training
                SQLEducationTraining = "SELECT * FROM PIS_EducationTrainingFN(" + pkey + ")";
                dtEducationTraining = new DBHelper().ExecuteQuery(SQLEducationTraining, CommandType.Text);
                // Performance Evalution
                SQLPerformanceEvaluation = "SELECT * FROM PIS_EmployeeEvaluationFN(" + pkey + ")";
                dtPerformanceEvaluation = new DBHelper().ExecuteQuery(SQLPerformanceEvaluation, CommandType.Text);
                // Disciplinary Action
                SQLDisciplinaryAction = "SELECT * FROM PIS_DisciplinaryActionFN(" + pkey + ")";
                dtDisciplinaryAction = new DBHelper().ExecuteQuery(SQLDisciplinaryAction, CommandType.Text);

                rd.SetDataSource(dt);
                rd.Subreports["Career"].SetDataSource(dtCareer);
                rd.Subreports["EducationTraining"].SetDataSource(dtEducationTraining);
                rd.Subreports["PerformanceEvaluation"].SetDataSource(dtPerformanceEvaluation);
                rd.Subreports["DisciplinaryAction"].SetDataSource(dtDisciplinaryAction);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    rd.Close();
                    rd.Dispose();
                    return File(stream, "application/pdf");
                }
                catch
                {
                    throw;
                }
            }
        }

        public ActionResult ItemMasterlistReport()
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string SQL = null;
                SQL = "SELECT * FROM ItemList";
                DataTable dt = new DBHelper().ExecuteQuery(SQL, CommandType.Text);
                rd.Load(Server.MapPath("~/Report/PIS/ItemMasterlist.rpt"));
                rd.SetDataSource(dt);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    rd.Close();
                    rd.Dispose();
                    return File(stream, "application/pdf");
                }
                catch
                {
                    throw;
                }
            }
        }

        public ActionResult AccountabilityList()
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string SQL = null;
                SQL = "SELECT * FROM AccountabilityList";
                DataTable dt = new DBHelper().ExecuteQuery(SQL, CommandType.Text);
                rd.Load(Server.MapPath("~/Report/PIS/AccountabilityList.rpt"));
                rd.SetDataSource(dt);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    rd.Close();
                    rd.Dispose();
                    return File(stream, "application/pdf");
                }
                catch
                {
                    throw;
                }
            }
        }


        public ActionResult EmployeeProfileAudit(int pkey)
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string SQL = null;
                SQL = "SELECT * FROM fEmployeeAuditReport(" + pkey + ")";
                DataTable dt = new DBHelper().ExecuteQuery(SQL, CommandType.Text);
                rd.Load(Server.MapPath("~/Report/PIS/EmployeeProfileAudit.rpt"));
                string SQLEducation = null, SQLChanges = null; 
                DataTable dtSQLEducation = null, dtSQLChanges = null;
                
                SQLEducation = "SELECT * FROM dbo.fEmployeeAuditEducationReport(" + pkey + ")";
                dtSQLEducation = new DBHelper().ExecuteQuery(SQLEducation, CommandType.Text);

                SQLChanges = "SELECT * FROM fEmployeeInfoChanges(" + pkey + ")";
                dtSQLChanges = new DBHelper().ExecuteQuery(SQLChanges, CommandType.Text);

                rd.SetDataSource(dt);
                rd.Subreports["EducationTraining"].SetDataSource(dtSQLEducation);
                rd.Subreports["Changes"].SetDataSource(dtSQLChanges);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    rd.Close();
                    rd.Dispose();
                    return File(stream, "application/pdf");
                }
                catch
                {
                    throw;
                }
            }
        }

        public ActionResult EmployeeAccountability(int pkey)
        {
            using (ReportDocument rd = new ReportDocument())
            {
                string SQL = null;
                SQL = "SELECT * FROM dbo.fINVEmployeeAccountability(" + pkey + ")";
                DataTable dt = new DBHelper().ExecuteQuery(SQL, CommandType.Text);
                rd.Load(Server.MapPath("~/Report/PIS/EmployeeAccountability.rpt"));
                rd.SetDataSource(dt);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    rd.Close();
                    rd.Dispose();
                    return File(stream, "application/pdf");
                }
                catch
                {
                    throw;
                }
            }
        }

       

       
    }
}
