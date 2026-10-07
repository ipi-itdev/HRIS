using WCORE.Utility;
using WCORE.Utility.SQLBuilder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WCORE.Controllers
{
    // o--------------------------------------------------------------------------------------------------o
    // |                   Source Code Documentation
    // o--------------------------------------------------------------------------------------------------o
    // |Description: Used for universal method in the system. All reusable action should be place here
    // |GetList - Used to generate data for select box
    // |IsUnique - Used to validate data for duplicate entry
    // o--------------------------------------------------------------------------------------------------o
    public partial class ListViewController : BaseController
    {
        DBHelper dbh = new DBHelper();
        Common cmn = new Common();
        //public virtual ActionResult Index(ModelData data)
        //{
        //    string[] strparam = { "@mguid", "@User", "@UserRoles" };
        //    string[] strparamval = { data.Mguid, cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
        //    using (DataTable dtRoles = dbh.ExecuteQuery("SELECT * FROM dbo.fSysModuleUserRoles(@mguid,@User,@UserRoles)", CommandType.Text, strparam, strparamval))
        //    {
        //        if (dtRoles.Rows.Count > 0)
        //        {
        //            ViewBag.AllowInsert = bool.Parse(dtRoles.Rows[0]["HasNew"].ToString()) ? dtRoles.Rows[0]["AllowInsert"] : false;
        //            ViewBag.AllowDelete = bool.Parse(dtRoles.Rows[0]["HasDelete"].ToString()) ? dtRoles.Rows[0]["AllowDelete"] : false;
        //            ViewBag.DetailActionName = dtRoles.Rows[0]["DetailActionName"];
        //            ViewBag.DetailControllerName = dtRoles.Rows[0]["DetailControllerName"];
        //            ViewBag.wPopUp = bool.Parse(dtRoles.Rows[0]["wListPopUp"].ToString()) ? bool.Parse(dtRoles.Rows[0]["PopUpPrint"].ToString()) ? dtRoles.Rows[0]["AllowPrint"] : true : false;
        //            ViewBag.wPopUpIcon = dtRoles.Rows[0]["PopUpIcon"];
        //            ViewBag.wPopUpCtrl = dtRoles.Rows[0]["PopUpDetailViewController"];
        //            ViewBag.wPopUpAction = dtRoles.Rows[0]["PopUpDetailViewAction"];
        //            ViewBag.wPopUpSubAction = dtRoles.Rows[0]["PopUpSubAction"];
        //            ViewBag.wPopUp2 = bool.Parse(dtRoles.Rows[0]["wListPopUp2"].ToString()) ? bool.Parse(dtRoles.Rows[0]["PopUp2Print"].ToString()) ? dtRoles.Rows[0]["AllowPrint"] : true : false;
        //            ViewBag.wPopUpIcon2 = bool.Parse(dtRoles.Rows[0]["wListPopUp2"].ToString()) ? dtRoles.Rows[0]["PopUpIcon2"] : "print";
        //            ViewBag.wPopUpCtrl2 = dtRoles.Rows[0]["PopUpDetailViewController2"];
        //            ViewBag.wPopUpAction2 = dtRoles.Rows[0]["PopUpDetailViewAction2"];
        //            ViewBag.wPopUpSubAction2 = dtRoles.Rows[0]["PopUp2SubAction"];
        //            ViewBag.OrderBy = dtRoles.Rows[0]["OrderBy"];
        //            ViewBag.OrderByAs = dtRoles.Rows[0]["OrderByAs"];
        //            ViewBag.mName = dtRoles.Rows[0]["Code"].ToString();
        //            ViewBag.mCode = dtRoles.Rows[0]["Code"].ToString();
        //            ViewBag.mguid = data.Mguid;
        //            ViewBag.mNo = dtRoles.Rows[0]["MenuRefNo"].ToString();
        //            ViewBag.Description = dtRoles.Rows[0]["Description"];
        //            ViewBag.SubDescription = dtRoles.Rows[0]["SubDescription"];
        //            ViewBag.ViewId = dtRoles.Rows[0]["MenuRefNo"].ToString();
        //            ViewBag.Header = GetTableHeadersMain(dtRoles.Rows[0]["Code"].ToString());
        //            ViewBag.IsDisplayOnly = dtRoles.Rows[0]["IsDisplayOnly"].ToString();
        //        }
        //    }
        //    return PartialView(@"~\Views\LV\Index.cshtml");
        //}
        public virtual ActionResult ListIndex(ModelData data)
        {
            int fType = 1;
            string[] strparam = { "@mguid", "@User" };
            string[] strparamval = { data.Mguid, cmn.SessionUserRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spSysGenerateList", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read())
                {
                    ViewBag.mguid = data.Mguid;
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.Description = dr["Description"].ToString();
                    ViewBag.SubDescription = dr["SubDescription"];
                    ViewBag.DetailActionName = dr["DetailActionName"].ToString();
                    ViewBag.DetailControllerName = dr["DetailControllerName"];
                    ViewBag.ViewId = data.ParentModel != null ? dr["Code"].ToString() + "_ListView_" + data.ParentModel : dr["Code"].ToString() + "_ListView"; // used to determine the place of the list view
                    ViewBag.FormID = "mFrm" + dr["MenuRefNo"].ToString(); // used to determine the palce of the detail view of the list view
                    ViewBag.WithOpen = bool.Parse(dr["WithOpen"].ToString()); // used to identify if the table as a detail view
                    ViewBag.tFormat = dr["xFormat"].ToString(); // used to identify the column and settings of the table
                    ViewBag.tButtonHdr = dr["xButtonHeader"].ToString(); // used to identify the main buttons of the table
                    ViewBag.tButtonDtl = dr["xButtonDetail"].ToString(); // used to identify buttons that will display per row in the table
                    ViewBag.tFilter = dr["xFilter"].ToString(); // used to form filter view
                    fType = int.Parse(dr["FormType"].ToString()); // used to determine the list view design
                    ViewBag.tctr = dr["xCtr"].ToString(); // used to identify the total row count of the listdatasource
                    
                    ViewBag.FID = data.FKey; // for detail list to identify the foreign key of the parent table
                    ViewBag.FIDName = data.FKeyName; // for detail list to identify the foreign key of the parent table
                    ViewBag.tFilterValue = data.FKey > 0 ? "{'" + data.FKeyName +"':" + data.FKey + ",'IsDirty':true}" : "{}"; // used to filter child list value on load
                } 
            }
            return PartialView(@"~\Views\LV\" + (fType == 1 ? "ListIndex.cshtml" : "_Index.cshtml"));
        }

        public virtual ActionResult ChildListIndex(ModelData data)
        {
            string[] strparam = { "@mguid", "@User", "@UserRoles" };
            string[] strparamval = { data.Mguid, cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
            using (DataTable dtRoles = dbh.ExecuteQuery("SELECT * FROM dbo.fSysModuleUserRoles(@mguid,@User,@UserRoles)", CommandType.Text, strparam, strparamval))
            {
                if (dtRoles.Rows.Count > 0)
                {
                    // used to identify the module
                    ViewBag.mguid = dtRoles.Rows[0]["mguid"].ToString();
                    ViewBag.mCode = dtRoles.Rows[0]["Code"].ToString();
                    ViewBag.mNo = dtRoles.Rows[0]["MenuRefNo"].ToString();
                    ViewBag.Description = dtRoles.Rows[0]["Description"];
                    ViewBag.SubDescription = dtRoles.Rows[0]["SubDescription"];
                    //used to identify the parent of the module
                    ViewBag.FormID = "mFrm" + dtRoles.Rows[0]["MenuRefNo"].ToString();
                    ViewBag.ViewID = "myPrnt_" + dtRoles.Rows[0]["ParentModel"].ToString() + '_' + dtRoles.Rows[0]["MenuRefNo"].ToString();
                    ViewBag.ParentModel = dtRoles.Rows[0]["ParentModel"];
                    //used to determine if the module is child
                    ViewBag.IsAppendMode = bool.Parse(dtRoles.Rows[0]["IsAppendMode"].ToString());
                    //used to identify the style and form
                    List<Header> Headers = GetTableHeadersMain(dtRoles.Rows[0]["Code"].ToString());
                    ViewBag.tableFormat = "Format:[" + String.Join(",", Headers.Select(p => "{name: " + (p.RefColumn == null ? "'" + p.PropertyName + "'" : "'" + p.RefAlias + "'") +
                                            ",width:'" + (p.PropertyName == "ID" ? 50 : (int)(p.ColumnWidth)) + "px'" +
                                            ",visibility:'" + (p.IsVisible == false ? "none" : "") + "'" +
                                            ",caption:'" + p.Caption + "'" +
                                            ",align:'" + (p.PropertyName == "ID" ? Header.Align.center.ToString().ToLower() : p.Alignment.ToString().ToLower()) +
                                            "',type:" + (p.RefColumn == null ? "'" + p.PropertyType + "'" : "String") +
                                            (p.RefColumn != null ? ",RefColumn:'" + p.RefColumn + "'" : "") +
                                            ",isDisabled:" + p.isDisabled.ToString().ToLower() + "}"
                                            ).ToArray()) + "]";
                    ViewBag.DisplayName = dtRoles.Rows[0]["Description"].ToString();
                    //ViewBag.IsDetailPopUp = bool.Parse(dtRoles.Rows[0]["IsDetailPopUp"].ToString());
                    ViewBag.IsHalfDetailView = bool.Parse(dtRoles.Rows[0]["IsHalfDetailView"].ToString());
                    ViewBag.OrderBy = dtRoles.Rows[0]["OrderBy"];
                    ViewBag.OrderByAs = dtRoles.Rows[0]["OrderByAs"];
                    ViewBag.DetailActionName = dtRoles.Rows[0]["DetailActionName"];
                    ViewBag.DetailControllerName = dtRoles.Rows[0]["DetailControllerName"];
                    ViewBag.NewDetailActionName = dtRoles.Rows[0]["NewActionName"];
                    ViewBag.NewDetailControllerName = dtRoles.Rows[0]["NewControllerName"];
                    ViewBag.IsNewFormDifferent = bool.Parse(dtRoles.Rows[0]["IsNewFormDifferent"].ToString());
                    //used to identify the basic privilege of the user
                    //ViewBag.AllowInsert = bool.Parse(dtRoles.Rows[0]["AllowInsert"].ToString());
                    //used to get the value of the parent module.
                    ViewBag.FKey = data.FKey;
                    ViewBag.FKeyName = data.FKeyName;
                }
            }
            return data.IsAppendMode ? PartialView(@"~\Views\LV\_Index.cshtml") : PartialView(@"~\Views\LV\_DetailList.cshtml");
        }

        [HttpPost]
        public virtual JsonResult GetList(POSTData data)
        {
            string SQL = null;
            var modelType = GetModelType(data.Model);
            var dbTableAttr = (modelType.GetCustomAttributes(typeof(DatabaseTableAttribute), true) as DatabaseTableAttribute[])[0];
            var dbTable = dbTableAttr.ViewName ?? dbTableAttr.Name;
            var sqlBuilder = new SelectQueryBuilder();
            sqlBuilder.SelectFromTable(dbTable);
            List<Header> Headers = GetTableHeadersMain(data.Model);
            foreach (var col in Headers)
            {
                if (col.RefmName != null)
                {
                    var refdbTableAttr = (GetModelType(col.RefmName).GetCustomAttributes(typeof(DatabaseTableAttribute), true) as DatabaseTableAttribute[])[0];
                    var refdbTable = refdbTableAttr.ViewName ?? refdbTableAttr.Name;
                    sqlBuilder.AddColumnWithAlias(refdbTable, col.RefTblAlias, col.RefField);
                    sqlBuilder.AddJoin(col.RefTblAlias, JoinType.LeftJoin, refdbTable, col.RefColumn, Comparison.Equals, dbTable, col.PropertyName);
                }
                else { sqlBuilder.AddColumns(dbTable, (col.PropertyType == "DateTime" ? "CONVERT(VARCHAR(50)," + col.PropertyName + ",101)" : col.PropertyName)); }
            }
            SQL = sqlBuilder.BuildQuery();
            SQL = SQL.Replace("@Roles", Convert.ToString(cmn.SessionUserRolesRefNo()));
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual List<Header> GetTableHeadersMain(String mName)
        {
            var Headers = new List<Header>();
            var pInfos = GetTypePropertiesList(Common.GetModelType(mName));
            Header.Align ColumnAlign = Header.Align.left;
            foreach (PropertyInfo info in pInfos)
            {
                var LvItem = info.GetCustomAttribute<ListViewColumnAttribute>();
                int Width = 150;
                int sqNo = 0;
                if (LvItem != null)
                {
                    if (LvItem.IsVisible)
                    {
                        Width = LvItem.Width;
                        sqNo = LvItem.SeqNo;
                        switch (LvItem.Align)
                        {
                            case "L":
                                ColumnAlign = Header.Align.left;
                                break;
                            case "C":
                                ColumnAlign = Header.Align.center;
                                break;
                            case "R":
                                ColumnAlign = Header.Align.right;
                                break;
                            default:
                                break;
                        }
                    }
                    var dbField = info.GetCustomAttribute<DatabaseFieldAttribute>(true);
                    string refColumn = null;
                    string refmName = null;
                    string refField = null;
                    string refAlias = null;
                    string refTblAlias = null;
                    if (dbField.RefModel != null)
                    {
                        refColumn = dbField.Name;
                        refmName = dbField.RefModel.Name;
                        refField = dbField.RefField;
                        refAlias = dbField.RefAlias;
                        refTblAlias = dbField.RefTableAlias;
                    }
                    string caption = null;
                    var displayColumnAttr = info.GetCustomAttribute<DisplayAttribute>();
                    caption = displayColumnAttr != null ? displayColumnAttr.Name : info.Name;
                    Headers.Add(new Header(info.Name)
                    {
                        IsVisible = LvItem.IsVisible,
                        PropertyType = info.PropertyType.Name,
                        RefColumn = refColumn,
                        RefmName = refmName,
                        RefField = refField,
                        RefAlias = refAlias,
                        RefTblAlias = refTblAlias,
                        Caption = caption,
                        ColumnWidth = Width,
                        SeqNo = sqNo,
                        Alignment = ColumnAlign
                    });
                }
            }
            Headers = Headers.OrderBy(h => h.SeqNo).ToList();
            return Headers;
        }

        [HttpPost]
        public virtual JsonResult ListIndexRefresh(POSTData data)
        {
            string[] strparam = { "@mguid", "@PageNo", "@param", "@User" };
            string[] strparamval = { data.Mguid, data.TPageNo.ToString(),data.TdtParam.ToString(), cmn.SessionUserRefNo().ToString() };
            DataSet ds = new DBHelper().DSExecuteQuery("dbo.spSYSGenerateListdt", CommandType.StoredProcedure,strparam,strparamval);
            var JsonData = Common.ConvertDataTableToJSON(ds.Tables[0], true);
            var result = new { Result = JsonData, CNT = ds.Tables[1].Rows[0][0].ToString()};
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult Refresh(POSTData data)
        {
            var modelType = GetModelType(data.Model);
            var pInfos = GetTypeProperties(modelType);
            string SQL = null;
            var dbTableAttr = (modelType.GetCustomAttributes(typeof(DatabaseTableAttribute), true) as DatabaseTableAttribute[])[0];
            var sqlBuilder = new SelectQueryBuilder();
            var dbTable = dbTableAttr.ViewName ?? dbTableAttr.Name;
            sqlBuilder.SelectFromTable(dbTable);
            List<Header> Headers = GetTableHeadersMain(data.Model);
            foreach (var col in Headers)
            {
                if (col.RefmName != null)
                {
                    var refdbTable = ((GetModelType(col.RefmName).GetCustomAttributes(typeof(DatabaseTableAttribute), true) as DatabaseTableAttribute[])[0].Name).ToString();
                    sqlBuilder.AddColumnWithAlias(refdbTable, col.RefTblAlias, col.RefField + " AS " + col.RefAlias);
                    sqlBuilder.AddJoin(col.RefTblAlias, JoinType.LeftJoin, refdbTable, col.RefColumn, Comparison.Equals, dbTable, col.PropertyName);
                }
                else { sqlBuilder.AddColumns(dbTable, (col.PropertyType == "DateTime" ? "CONVERT(VARCHAR(50)," + col.PropertyName + ",101)" : col.PropertyName)); }
            }
            var MainTableAlias = sqlBuilder.getTableAlias(dbTable);
            bool hasDefault = (modelType.GetCustomAttributes(typeof(MenuDescriptionAttribute), true) as MenuDescriptionAttribute[])[0].HasDefault;
            if (data.ForeignFieldKey != null) { sqlBuilder.AddWhere(MainTableAlias + '.' + data.ForeignFieldKey, Comparison.Equals, data.ID_ParentKey); }
            sqlBuilder.AddWhere(MainTableAlias + '.' + "IsActive", Comparison.Equals, 1);
            SQL = sqlBuilder.BuildQuery();
            SQL = SQL.Replace("@Roles", Convert.ToString(cmn.SessionUserRolesRefNo()));
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }
    }

    public class ModelData
    {
        public String Mguid { get; set; }
        //public String ModelNo { get; set; }
        //public double ColumnsWidth { get; set; }
        public bool IsAppendMode { get; set; }
        public string ParentModel { get; set; }
        public bool AllowAddOth { get; set; }
        public string FKeyName { get; set; }
        public int FKey { get; set; }
    }

    //public class RptModel
    //{
    //    public String mguid { get; set; }
    //    public string[] strparam { get; set; }
    //    public string[] strparamval { get; set; }
    //}

    public class POSTData
    {
        public string Model { get; set; }
        public string Mguid { get; set; }
        public string ForeignFieldKey { get; set; }
        public int ID_ParentKey { get; set; }
        public bool IsJson { get; set; }
        public int TPageNo { get; set; }
        public string TdtParam { get; set; }
    }
}