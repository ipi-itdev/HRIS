using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Serialization;
using Utility;
using System.Web.Mvc;
using WCORE.Utility.Database;
using System.Reflection;

namespace WCORE.Utility
{
    public class Common
    {
        UnitOfWork uow = new UnitOfWork();
        static Random _random = new Random();
        public static String GenerateName()
        {
            string returnString = "";
            for (int i = 0; i < 5; i++)
            {
                int num = _random.Next(0, 26); // Zero to 25
                char let = (char)('a' + num);
                returnString += let;
            }
            return returnString;
        }

        public static SqlConnection GetSqlConnection()
        {
            string conString = ConfigurationManager.ConnectionStrings["IPICORE_DTSEntities"].ConnectionString;
            string nconString = new System.Data.EntityClient.EntityConnectionStringBuilder(conString).ProviderConnectionString;
            return new SqlConnection(nconString);
        }

        public static String ConvertDataTableToJSON(DataTable dt, bool IsTable)
        {
            if (dt.Rows.Count == 0) return "[]";
            String mResult = JsonBuilder.ConvertDataTabletoString(dt);
            JavaScriptSerializer json = new JavaScriptSerializer()
            {
                MaxJsonLength = Int32.MaxValue
            };
            List<Dictionary<string, object>> unpacked = json.Deserialize<List<Dictionary<string, object>>>(mResult);
            String Original = json.Serialize(JSONH.pack(unpacked, 0, IsTable));
            return Original;
        }

        public static Type GetModelType(String mName)
        {
            return Type.GetType("WCORE.Models." + mName);
        }

        public bool IsSuperApprover(int UserRefNo)
        {
            DBHelper dbh = new DBHelper();
            return bool.Parse(dbh.ExecuteReader("SELECT SuperApprover FROM SYS_WebUser WHERE ID = " + UserRefNo, CommandType.Text).ToString());

        }


        public static int GetObjID(string ObjTbl, string ObjID, string Obj)
        {
            DBHelper dbh = new DBHelper();
            return int.Parse(dbh.ExecuteReader("SELECT " + ObjID + " FROM " + ObjTbl + " WHERE " + Obj, CommandType.Text)[0].ToString());
        }


        public static DataTable GetData(string ObjTbl, string Obj)
        {
            DBHelper dbh = new DBHelper();
            return dbh.ExecuteQuery("SELECT * FROM " + ObjTbl + " WHERE " + Obj, CommandType.Text);
        }

        public static string GetDataFN(string ObjTbl)
        {
            DBHelper dbh = new DBHelper();
            return dbh.ExecuteQuery("SELECT " + ObjTbl, CommandType.Text).Rows[0][0].ToString();
        }

        public int SessionUserRefNo()
        {
            return HttpContext.Current.Session["UserRefNo"] == null ? int.Parse(GetSession().Rows[0]["UserRefNo"].ToString()) : int.Parse(HttpContext.Current.Session["UserRefNo"].ToString());
        }

        public int SessionUserRolesRefNo()
        {
            return HttpContext.Current.Session["UserRolesRefNo"] == null ? int.Parse(GetSession().Rows[0]["UserRolesRefNo"].ToString()) : int.Parse(HttpContext.Current.Session["UserRolesRefNo"].ToString());
        }

        public DataTable GetSession()
        {
            DBHelper dbh = new DBHelper();
            using (DataTable dt = dbh.ExecuteQuery("SELECT * FROM vSession WHERE SessionID = '" + HttpContext.Current.Session.SessionID + "'", CommandType.Text))
            { //AND IPAddress = '" + HttpContext.Current.Request.UserHostAddress + "'
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Session["FullName"] = dt.Rows[0]["EmployeeName"];
                    HttpContext.Current.Session["UserRoles"] = dt.Rows[0]["UserRoles"];
                    HttpContext.Current.Session["IsAdmin"] = dt.Rows[0]["IsAdmin"];
                    HttpContext.Current.Session["UserRefNo"] = int.Parse(dt.Rows[0]["UserRefNo"].ToString());
                    HttpContext.Current.Session["UserRolesRefno"] = int.Parse(dt.Rows[0]["UserRolesRefno"].ToString());
                    HttpContext.Current.Session["IsOpenSurvey"] = dt.Rows[0]["IsOpenSurvey"];
                }
                return dt;
            }
        }

        public void InsertSession(int UserRefNo, int UserRolesRefNo)
        {
            if (UserRefNo > 0)
            {
                DBHelper dbh = new DBHelper();
                string SQL = "INSERT INTO dbo.SYS_Session_C ( SessionID ,IPAddress ,UserRolesRefNo ,UserRefNo)VALUES  ( '" + HttpContext.Current.Session.SessionID + "' ,'" + HttpContext.Current.Request.UserHostAddress + "' ," + UserRolesRefNo + " , " + UserRefNo + ")";
                dbh.ExecuteNonQuery(SQL, CommandType.Text);
            }
        }

        public void DeleteSession(int UserRefNo)
        {
            if (UserRefNo > 0)
            {
                DBHelper dbh = new DBHelper();
                string SQL = "DELETE FROM dbo.SYS_Session_C WHERE (UserRefNo = '" + UserRefNo + "' OR SessionID = '" + HttpContext.Current.Session.SessionID + "')";
                dbh.ExecuteNonQuery(SQL, CommandType.Text);
            }
        }


        public static int ExecuteNonQuery(string strQuery)
        {
            DBHelper dbh = new DBHelper();
            return dbh.ExecuteNonQuery(strQuery, CommandType.Text);
        }

        string NavDataList = "";
        public string CreateTreeView(DataTable dt)
        {
            foreach (DataRow row in dt.Select("MenuParentRefNo = 0", "SeqNo ASC"))
            {
                UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
                if (row["FormType"].ToString() == "0")
                {
                    NavDataList += "<li id='" + row["MenuRefNo"] + "' name='" + row["Description"].ToString().Trim() + "'>";
                    NavDataList += "<a><i id='nav_" +  row["MenuRefNo"] + "' class='fa " + row["ImageFile"] + "'></i><span>      " + row["Description"] + "</span>";
                    CreateTreeViewMenu(int.Parse(row["MenuRefNo"].ToString()), dt);
                }
                else
                {
                   
                    NavDataList += "<li class='modnav' ng-click=" + "addTab('" + row["MenuRefNo"] + "','" + row["ImageFile"].ToString() + "','" + row["MenuTitle"].ToString().Replace(" ", "~") + "')" + " id='" + row["MenuRefNo"] + "' name='" +  row["MenuRefNo"].ToString().Trim() + "' url='" + url.Action(row["ActionName"].ToString(), row["ControllerName"].ToString(), new { mguid = row["mguid"].ToString().Trim() }) + "'>";
                    NavDataList += "<a><i id='nav_" +  row["MenuRefNo"] + "' class='fa " + row["ImageFile"] + "'></i><span>      " + row["Description"] + "</span></a>";
                }
                NavDataList += "</li>";
            }
            return NavDataList;
        }

        private string CreateTreeViewMenu(int ParentNumber, DataTable dt)
        {
            if (dt.Select("MenuParentRefNo = " + ParentNumber).Length > 0)
            {
                NavDataList = NavDataList.Replace("<li id='" + ParentNumber, "<li class='treeview' id='" + ParentNumber);
                NavDataList += "<span class='pull-right-container'><i class='fa fa-angle-left pull-right'></i></span></a>";
                NavDataList += "<ul class='treeview-menu'>";
                foreach (DataRow row in dt.Select("MenuParentRefNo= " + ParentNumber, "SeqNo ASC"))
                {
                    UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
                    if (row["FormType"].ToString() == "0")
                    {
                        NavDataList += "<li id='" + row["MenuRefNo"] + "' name='" +  row["MenuRefNo"].ToString().Trim() + "'>";
                        NavDataList += "<a><i id='nav_" +  row["MenuRefNo"] + "' class='fa " + row["ImageFile"] + "'></i><span>      " + row["Description"] + "</span>";
                        CreateTreeViewMenu(int.Parse(row["MenuRefNo"].ToString()), dt);
                    }
                    else
                    {
                        NavDataList += "<li class='modnav' ng-click=" + "addTab('" + row["MenuRefNo"] + "','" + row["ImageFile"].ToString() + "','" + row["MenuTitle"].ToString().Replace(" ", "~") + "')" + " id='" + row["MenuRefNo"] + "' name='" +  row["MenuRefNo"].ToString().Trim() + "' url='" + url.Action(row["ActionName"].ToString(), row["ControllerName"].ToString(), new { mguid = row["mguid"].ToString().Trim() }) + "'>";
                        NavDataList += "<a><i id='nav_" +  row["MenuRefNo"] + "' class='fa " + row["ImageFile"] + "'></i><span>      " + row["Description"] + "</span></a>";
                    }
                    NavDataList += "</li>";
                }
                NavDataList += "</ul>";
            }
            return NavDataList;
        }

        public DataTable GetModuleAccess(CommandType ct, string[] strparam, string[] strparamval)
        {
            DBHelper dbh = new DBHelper();
            DataTable dt = new DataTable();
            dt = dbh.ExecuteQuery("dbo.spGetModuleAccess", ct , strparam, strparamval);
            return dt;
        }
    }

    public class DetailTab
    {
        public DetailTab(string Name)
        {
            this.Name = Name;
        }
        public DetailTab(string Name, bool IsListView, string Desc, bool IsTextEditor)
        {
            this.Name = Name;
            this.IsListView = IsListView;
            this.Desc = Desc;
            this.IsTextEditor = IsTextEditor;
        }
        public string Name { get; set; }
        public bool IsListView { get; set; }
        public string Desc { get; set; }
        public bool IsTextEditor { get; set; }

    }
}