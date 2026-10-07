using WCORE.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using WCORE.Utility.Database;
using Newtonsoft.Json;
using WCORE.Utility.SQLBuilder;
using System.Dynamic;
using System.Data.SqlClient;
using System.Web.Security;

namespace WCORE.Controllers
{
    // o------------------------------------------------------------------------------------------o
    // |                   Source Code Documentation
    // o------------------------------------------------------------------------------------------o
    // |            Document: DetailViewController
    // o------------------------------------------------------------------------------------------o
    public partial class DetailViewController : BaseController
    {
        DBHelper dbh = new DBHelper();
        Common cmn = new Common();

        public virtual ActionResult Index(DetailViewModelData modeldata)
        {
            string mName = ""; 
            string mPage = ""; int ftype = 1; string menurefno = "";
            string[] strparam = { "@mguid", "@User", "@UserRoles" };
            string[] strparamval = { modeldata.mguid, cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (DataTable dtRoles = dbh.ExecuteQuery("SELECT * FROM dbo.fSysModuleUserRoles(@mguid,@User,@UserRoles)", CommandType.Text, strparam, strparamval))
            {
                mPage = dtRoles.Rows[0]["ViewPage"].ToString();
                mName = dtRoles.Rows[0]["Code"].ToString();
                ViewBag.mguid = dtRoles.Rows[0]["mguid"];
                ViewBag.mCode = dtRoles.Rows[0]["Code"];
                ViewBag.mNo = dtRoles.Rows[0]["MenuRefNo"];
                ViewBag.mNo2 = dtRoles.Rows[0]["MenuRefNo"].ToString();
                menurefno = dtRoles.Rows[0]["MenuRefNo"].ToString();
                ViewBag.Description = dtRoles.Rows[0]["Description"];
                ViewBag.SubDescription = dtRoles.Rows[0]["SubDescription"];

                ViewBag.AllowInsert = dtRoles.Rows[0]["AllowInsert"];
                ViewBag.AllowUpdate = dtRoles.Rows[0]["AllowUpdate"];
                ViewBag.AllowDelete = dtRoles.Rows[0]["AllowDelete"];
                ViewBag.AllowPrint = dtRoles.Rows[0]["AllowPrint"];
                ViewBag.AllowExport = dtRoles.Rows[0]["AllowExport"];
                ViewBag.AllowApprove = dtRoles.Rows[0]["AllowApprove"];

                //used to identify the parent of the module
                ViewBag.FormID = "mFrm" + dtRoles.Rows[0]["MenuRefNo"].ToString();
                ViewBag.ParentModel = dtRoles.Rows[0]["ParentModel"];
                ftype = int.Parse(dtRoles.Rows[0]["FormType"].ToString());
                // used to specify the detail controller and action 
                ViewBag.DetailControllerName = dtRoles.Rows[0]["DetailControllerName"];
                ViewBag.DetailActionName = dtRoles.Rows[0]["DetailActionName"];

                Session["MenuRefNo"] = ViewBag.mNo;

                if (dtRoles.Rows[0]["MenuRefNo"].ToString() == "70001" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "70003" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "60001" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "60002" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "60003" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "60004" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "1113" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "1" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "4005" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "4000" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "4014" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "4018" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "4024" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "4028" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "4034" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "4038" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "4044" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "4048" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "4008" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "30102" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "4044" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "4044" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "4044" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "4044" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "4048" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "4008" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "30102" ||dtRoles.Rows[0]["MenuRefNo"].ToString() == "30104" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "30216" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "30212" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "30214" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "31100" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "31200" ||dtRoles.Rows[0]["MenuRefNo"].ToString() == "855" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "860" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "60" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "70" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "90" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "50000" ||dtRoles.Rows[0]["MenuRefNo"].ToString() == "50100" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "1105" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "1097" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "1100" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "1106" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "903" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "740" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "960" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "1000" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "70002" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "11000" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "10635" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "10630" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "10680" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "10620" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "11000" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "10690" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "10625" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "10435" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "10335" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "10330" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "10380" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "10320" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "10390" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "10704" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "10706" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "10700" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "59" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "57" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "58" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "56" || 
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "53" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "51" ||
                    dtRoles.Rows[0]["MenuRefNo"].ToString() == "54" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "1131" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "1132" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "1133" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "1134" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "1135" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "1136" || dtRoles.Rows[0]["MenuRefNo"].ToString() == "10691" ) 
                {
                    Session.Remove("PID");
                    Session["PID"] = modeldata.pid;
                }
                else
                {
                    Session.Remove("PID");
                    Session["PID"] = 0;
                }
            }


            if ((modeldata.pid != -1 && modeldata.pid != 0) && menurefno == "56")
            {
                using (DataTable dtRoles2 = dbh.ExecuteQuery("SELECT * FROM dbo.PAR_CurrentUser WHERE ID = " + Session["PID"] + " AND IsActive = 1", CommandType.Text))
                {
                    ViewBag.UserAction = dtRoles2.Rows[0]["UserAction"].ToString();
                    ViewBag.CurrentUser = dtRoles2.Rows[0]["CurrentUser"].ToString();
                    ViewBag.ApprovalLevel = dtRoles2.Rows[0]["ApprovalLevel"].ToString();
                    ViewBag.Remarks = dtRoles2.Rows[0]["Remarks"].ToString();
                    Session["Remarks"] = dtRoles2.Rows[0]["Remarks"].ToString();
                }
            }

            if ((modeldata.pid != -1 && modeldata.pid != 0) && menurefno == "53")
            {
                using (DataTable dtRoles3 = dbh.ExecuteQuery("SELECT * FROM dbo.PAR_CurrentUser WHERE ID = " + Session["PID"] + " AND IsActive = 1", CommandType.Text))
                {
                    ViewBag.UserAction = dtRoles3.Rows[0]["UserAction"].ToString();
                    ViewBag.CurrentUser = dtRoles3.Rows[0]["CurrentUser"].ToString();
                    ViewBag.ApprovalLevel = dtRoles3.Rows[0]["ApprovalLevel"].ToString();
                    ViewBag.Remarks = dtRoles3.Rows[0]["Remarks"].ToString();
                    Session["Remarks"] = dtRoles3.Rows[0]["Remarks"].ToString();
                }
            }



            ViewBag.Session = Session["PID"]; 
            ViewBag.pid = modeldata.pid;
            ViewBag.FKeyName = modeldata.FKeyName;
            ViewBag.FKey = modeldata.FKey;
            ViewBag.IsCombo = modeldata.IsComboBox;
            ViewBag.userrefno = cmn.SessionUserRefNo().ToString();
            ViewBag.userrolesrefno = cmn.SessionUserRolesRefNo().ToString();
            
            if (ftype != 3)
            {
                if (ftype == 2)
                {
                    Session.Remove("PID");
                    Session["PID"] = 0;
                }
                if (ftype == 2 && ViewBag.mNo2 == "53")
                {
                    Session.Remove("PID");
                    Session["PID"] = modeldata.pid;
                }
                ViewBag.DetailViewFormat = DetailViewFormat(mName);
                PropertyInfo[] pInfos = getDetailViewProperties(mName);
                PropertyInfo[] controlTabs = pInfos.Where(p => p.PropertyType.Name != @"List`1").ToArray();
                PropertyInfo[] ListViewTabs = pInfos.Where(p => p.PropertyType.Name == @"List`1").ToArray();
                var TabsControl = controlTabs.Where(p => p.GetCustomAttribute<DetailViewItemAttribute>().TabName != "Other").Select(p => p.GetCustomAttribute<DetailViewItemAttribute>().TabName).Distinct().ToArray();
                ListViewTabs = ListViewTabs.OrderBy(p => p.GetCustomAttribute<DetailViewItemAttribute>().TabIndex).ToArray();
                var TabsListView = ListViewTabs.Select(p => (p.GetCustomAttribute<DetailViewItemAttribute>().TabName ?? p.Name)).ToArray();
                List<DetailTab> detailTab = new List<DetailTab>();
                foreach (string tab in TabsControl)
                {
                    if (tab == "Details" && mPage == "DV/Index.cshtml") { }
                    else
                    {
                        detailTab.Add(new DetailTab(tab.Replace(" ", "").Replace(".", "").Replace("&", ""), false, tab, false));
                    }
                }
                foreach (string tab in TabsListView)
                {
                    detailTab.Add(new DetailTab(tab.Replace(" ", "").Replace(".", "").Replace("&", ""), true, tab, false));
                }
                detailTab.Add(new DetailTab("Other", false, "Other", false));
                ViewBag.Tabs = detailTab;
                var ListProperties = GetTypeProperties(Common.GetModelType(mName)).Select(p => (p.GetCustomAttribute<DatabaseFieldAttribute>().Name ?? p.Name) + ":null").ToList();
                ListProperties.AddRange(ListViewTabs.Select(p => (p.Name + ":[]")));
                ViewBag.ObjectProperties = String.Join(",", ListProperties);
            }
            return PartialView(@"~\Views\" + mPage);
        }


        public virtual ActionResult KPIListDetails(int pid, string mguid)
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

            return View("~/Views/APP/KPI/KPIList.cshtml");
        }

        public virtual ActionResult HardCodeIndex(DetailViewModelData modeldata)
        {
            ViewBag.pid = modeldata.pid;
            // get user privileges in the main module and sub modules
            string vpage = "";
            string[] strparam = { "@mguid", "@User", "@UserRoles" };
            string[] strparamval = { modeldata.mguid, cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spGetModuleAccess", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read())
                {
                    ViewBag.mguid = modeldata.mguid;
                    ViewBag.mNo = dr["MenuRefNo"].ToString();
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.mTitle = dr["Description"].ToString();
                    ViewBag.FormID = "mFrm" + dr["MenuRefNo"].ToString();
                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString());
                    ViewBag.AllowInsert = bool.Parse(dr["AllowInsert"].ToString());
                    ViewBag.AllowApprove = bool.Parse(dr["AllowApprove"].ToString());
                    ViewBag.AllowExport = bool.Parse(dr["AllowExport"].ToString());
                    vpage = dr["ViewPage"].ToString();
                }
            }
            return View(@"~\Views\" + vpage);
        }

        public virtual ActionResult ModalIndex(DetailViewModelData modeldata)
        {
            ViewBag.mUrl = modeldata.mUrl;
            return PartialView(@"~\Views\Home\Modal.cshtml");
        }
        [HttpPost]
        public virtual JsonResult GetBaseObject(string model, int? pid)
        {
            Type tModel = GetModelType(model);
            if (!pid.HasValue || pid == -1) return Json(JsonConvert.SerializeObject(newObject(tModel)), JsonRequestBehavior.AllowGet);
            var modelType = GetModelType(model);
            var pInfos = GetTypeProperties(Common.GetModelType(model));
            var dbTableAttr = (modelType.GetCustomAttributes(typeof(DatabaseTableAttribute), true) as DatabaseTableAttribute[])[0];
            var sqlBuilder = new SelectQueryBuilder();
            var dbTable = dbTableAttr.Name;
            sqlBuilder.SelectFromTable(dbTable);
            string[] databasefields = pInfos.Where(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false).Select(p => p.Name).ToArray();
            sqlBuilder.AddColumns(dbTable, databasefields);
            sqlBuilder.AddWhere(sqlBuilder.getTableAlias(dbTable) + ".ID", Comparison.Equals, pid);
            var SQL = sqlBuilder.BuildQuery();
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, false);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        protected virtual object newObject(Type tModel)
        {
            BaseObject CurrentObject = (BaseObject)Activator.CreateInstance(tModel);
            dynamic myobject = new ExpandoObject();
            IDictionary<string, object> myUnderlyingObject = myobject;
            PropertyInfo[] pInfos = GetTypeProperties(tModel);
            foreach (PropertyInfo p in pInfos)
            {
                var fieldName = p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DataLookUpAttribute>() == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name;
                if (p.PropertyType == typeof(DateTime))
                {
                    DateTime currentDate = (DateTime)p.GetValue(CurrentObject);
                    myUnderlyingObject.Add(fieldName, (currentDate != DateTime.MinValue ? p.GetValue(CurrentObject) : null));
                }
                else
                {
                    myUnderlyingObject.Add(fieldName, p.GetValue(CurrentObject));
                }
            }
            return myobject;
        }

        public string DetailViewFormat(string mName)
        {
            Type type = GetModelType(mName);
            List<string> Tabs = new List<string>();
            PropertyInfo[] pInfos = getDetailViewProperties(mName);
            var pInfosByTab = pInfos.Where(p => p.GetCustomAttribute<DetailViewItemAttribute>().IsTextEditor == false).Select(p => p.GetCustomAttribute<DetailViewItemAttribute>().TabName).Distinct();
            foreach (string tabName in pInfosByTab)
            {
                var ControlList = new List<string>();
                var Infocontrols = pInfos.Where(p => p.PropertyType.Name != @"List`1" && p.GetCustomAttribute<DetailViewItemAttribute>().IsTextEditor == false && p.GetCustomAttribute<DetailViewItemAttribute>() != null && p.GetCustomAttribute<DetailViewItemAttribute>().TabName == tabName).ToArray();
                foreach (PropertyInfo info in Infocontrols)
                {
                    string[] strArrays = getControlProperties(info, mName);
                    ControlList.Add("{" + String.Join(",", strArrays.Where(s => s != null).ToArray()) + "}");
                }

                Tabs.Add("{Name:'" + tabName.Replace(" ", "").Replace(".", "").Replace("&", "") + "',Controls:[" + String.Join(",", ControlList.ToArray()) + "]}");
            }

            var pInfosByTabTextEditor = pInfos.Where(p => p.GetCustomAttribute<DetailViewItemAttribute>().IsTextEditor == true).Select(p => p.GetCustomAttribute<DetailViewItemAttribute>().TabName).Distinct();
            foreach (string tabName in pInfosByTabTextEditor)
            {
                var ControlList = new List<string>();
                var Infocontrols = pInfos.Where(p => p.PropertyType.Name != @"List`1" && p.GetCustomAttribute<DetailViewItemAttribute>().IsTextEditor == true && p.GetCustomAttribute<DetailViewItemAttribute>() != null && p.GetCustomAttribute<DetailViewItemAttribute>().TabName == tabName).ToArray();
                foreach (PropertyInfo info in Infocontrols)
                {
                    string[] strArrays = getControlProperties(info, mName);
                    ControlList.Add("{" + String.Join(",", strArrays.Where(s => s != null).ToArray()) + "}");
                }
                Tabs.Add("{ Name:'" + tabName.Replace(" ", "").Replace(".", "").Replace("&", "") + "',Controls:[" + String.Join(",", ControlList.ToArray()) + "],IsTextEditor:true}");
            }

            PropertyInfo[] pInfoList = type.GetProperties().Where(p => (p.PropertyType.Name == @"List`1") && (p.GetCustomAttribute<DetailViewItemAttribute>() != null)).ToArray();
            foreach (PropertyInfo p in pInfoList)
            {
                DetailViewItemAttribute detailItemAttr = p.GetCustomAttribute<DetailViewItemAttribute>();
                DBCollection dbCollection = p.GetCustomAttribute<DBCollection>();
                string Name = "Name:'" + (detailItemAttr.TabName != null ? detailItemAttr.TabName.Replace(" ", "") : p.Name) + "'";
                string ListType = "Type:'" + dbCollection.ModelNo + "'";
                string ViewId = detailItemAttr.ViewId != null ? "ViewId:'" + detailItemAttr.ViewId + "'" : null;
                string foreignKeySetting = dbCollection.ForeignKey != null ? ("FKey:'" + dbCollection.ForeignKey + "'") : null;
                string foreignKeyValueSetting = dbCollection.ForeignKeyValue != null ? ("FKeyValue:'" + dbCollection.ForeignKeyValue + "'") : null;
                string IsForm = dbCollection.IsForm != false ? "IsForm:true" : null;
                //string mguid = dbCollection.mguid;
                string[] settings = { Name, ListType, ViewId, foreignKeySetting, foreignKeyValueSetting, IsForm };
                Tabs.Add("{" + String.Join(",", settings.Where(s => s != null).ToArray()) + ",IsListView:true,PropertyName:'" + p.Name + "',ParentmName: '" + mName + "'}");
            }
            return "[" + String.Join(",", Tabs.ToArray()) + "]";
        }

        protected PropertyInfo[] getDetailViewProperties(String mName)
        {
            return GetModelType(mName).GetProperties().Where(pr => pr.IsDefined(typeof(DetailViewItemAttribute), true)).ToArray()
                    .OrderBy(p => (p.GetCustomAttribute<SeqNoAttribute>() == null ? 0 : p.GetCustomAttribute<SeqNoAttribute>().Index)).ToArray();
        }

        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult Save()
        {
            string mName = Request["mName"];
            dynamic dynamicObject = null;
            dynamicObject = JObject.Parse(Request.Unvalidated["JSONObject"]);
            var baseObject = ConvertJSONToBaseOBject(mName, dynamicObject);
            UnitOfWork uow = new UnitOfWork();
            baseObject.Save(uow);
            var sr = new SavingResponseMessage
            {
                ID = baseObject.ID,
                msg = "Ok"
            };
            var json = new JavaScriptSerializer().Serialize(sr);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult Delete()
        {
            string mName = Request["mName"];
            JArray jarray = JArray.Parse(Request.Unvalidated["JSONObject"]);
            for (int i = 0; i < jarray.Count; i++)
            {
                dynamic dynamicObject = JObject.Parse(jarray[i].ToString());
                BaseObject baseObject = ConvertJSONToBaseOBject(mName, dynamicObject);
                UnitOfWork uow = new UnitOfWork();
                baseObject.Delete(uow);
            }
            return Json("{Result:1}", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult Approve_2()
        {
            string mName = Request["mName"];
            JArray jarray = JArray.Parse(Request.Unvalidated["JSONObject"]);
            for (int i = 0; i < jarray.Count; i++)
            {
                dynamic dynamicObject = JObject.Parse(jarray[i].ToString());
                BaseObject baseObject = ConvertJSONToBaseOBject(mName, dynamicObject);
                UnitOfWork uow = new UnitOfWork();
                baseObject.Approve(uow);
            }
            return Json("{Result:1}", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult Disapprove_2()
        {
            string mName = Request["mName"];
            JArray jarray = JArray.Parse(Request.Unvalidated["JSONObject"]);
            for (int i = 0; i < jarray.Count; i++)
            {
                dynamic dynamicObject = JObject.Parse(jarray[i].ToString());
                BaseObject baseObject = ConvertJSONToBaseOBject(mName, dynamicObject);
                UnitOfWork uow = new UnitOfWork();
                baseObject.Disapprove(uow);
            }
            return Json("{Result:1}", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult Printed()
        {
            string mName = Request["mName"];
            JArray jarray = JArray.Parse(Request.Unvalidated["JSONObject"]);
            for (int i = 0; i < jarray.Count; i++)
            {
                dynamic dynamicObject = JObject.Parse(jarray[i].ToString());
                BaseObject baseObject = ConvertJSONToBaseOBject(mName, dynamicObject);
                UnitOfWork uow = new UnitOfWork();
                baseObject.Printed(uow);
            }
            return Json("{Result:1}", JsonRequestBehavior.AllowGet);
        }
    }

    public class SavingResponseMessage
    {
        public int ID { get; set; }
        public string msg { get; set; }
    }

    public class DetailViewModelData
    {
        public string mName { get; set; }
        public string mguid { get; set; } // used to determine the menu mguid
        public int pid { get; set; } // used to determine the primary key of the table
        public int FKey { get; set; } // used to determine the foreign key of the table
        public string FKeyName { get; set; } // used to determine the foreign key field name of the table
        public bool IsComboBox { get; set; } // used to determine if the detail view form is for combo box
        public bool IsDetailList { get; set; }
        public string mUrl { get; set; }
    }
}


