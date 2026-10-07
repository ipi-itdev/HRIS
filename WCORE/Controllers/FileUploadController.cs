using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCORE.Utility;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace WCORE.Controllers
{
    
    public class FileUploadController : BaseController
    {
        Common cmn = new Common();
        SqlConnection connect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db_9b2ff8_hristest;User ID=sa;Password=Password1234;Multiple Active Result Sets=True;Encrypt=False;Application Name=EntityFramework");
        public ActionResult FileUpload()
        {
            return View();
        }

        public virtual JsonResult GetFileUploadLists()
        {
            String SQL = "SELECT * FROM fGetFileUploadList(" + Convert.ToString(cmn.SessionUserRefNo()) + ")";
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual bool UploadFile(int ID, string Description, int FileTypeRefNo, int EmployeeRefNo, int ClientAccountRefNo, HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(Server.MapPath("~/Uploads/FileUpload/" + ID + '/'))));
                    string _path = Path.Combine(Server.MapPath("~/Uploads/FileUpload/" + ID), _FileName);
                    file.SaveAs(_path);

                    DBHelper dbh = new DBHelper();
                    string SQL = "EXEC dbo.pUploadFile " + ID + ", '" + Description + "', "  + FileTypeRefNo + ", " + EmployeeRefNo + ", " + ClientAccountRefNo + ", '" + _FileName + "', " + Convert.ToString(cmn.SessionUserRefNo());
                    dbh.ExecuteNonQuery(SQL, CommandType.Text);

                    return true;
                }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }

        public virtual int FileType(int FileType)
        {
            DBHelper dbh = new DBHelper();

            try
            {
                SqlCommand command = new SqlCommand("SELECT TypeRefNo FROM FileType WHERE FileTypeRefNo = " + FileType, connect);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return int.Parse(String.Format("{0}", reader["TypeRefNo"]));
                    }
                }
            }
            catch (SqlException error)
            {
                Response.Write(error.ToString());
            }

            return 0;

        // -- try to change the code due to changes of namespaces -- noel april 1
        //return int.Parse(dbh.ExecuteNonQuery("SELECT TypeRefNo FROM FileType WHERE FileTypeRefNo = " + FileType, CommandType.Text));

        }
    }
}