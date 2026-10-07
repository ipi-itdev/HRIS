using WCORE.Utility;
using WCORE.Utility.SQLBuilder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Data;

namespace WCORE.Controllers
{
    public partial class ListViewController : BaseController
    {
        Common cmn = new Common();
        public virtual ActionResult Index(ModelData data)
        {
            using (DataTable dtRoles = Common.GetData("MenuUserRoles", "(UserRolesRefno = " + cmn.SessionUserRolesRefNo() + " OR UserRefno = " + cmn.SessionUserRefNo() + ")  AND MenuRefNo = " + data.ModelNo))
            {
                ViewBag.AllowInsert = bool.Parse(dtRoles.Rows[0]["HasNew"].ToString()) ? dtRoles.Rows[0]["AllowInsert"] : false;
                ViewBag.AllowDelete = bool.Parse(dtRoles.Rows[0]["HasDelete"].ToString()) ? dtRoles.Rows[0]["AllowDelete"] : false;
                ViewBag.DetailActionName = dtRoles.Rows[0]["DetailActionName"];
                ViewBag.DetailControllerName = dtRoles.Rows[0]["DetailControllerName"];
                ViewBag.wPopUp = bool.Parse(dtRoles.Rows[0]["wListPopUp"].ToString()) ? bool.Parse(dtRoles.Rows[0]["PopUpPrint"].ToString()) ? dtRoles.Rows[0]["AllowPrint"] : true : false;
                ViewBag.wPopUpIcon = dtRoles.Rows[0]["PopUpIcon"];
                ViewBag.wPopUpCtrl = dtRoles.Rows[0]["PopUpDetailViewController"];
                ViewBag.wPopUpAction = dtRoles.Rows[0]["PopUpDetailViewAction"];
                ViewBag.wPopUpSubAction = dtRoles.Rows[0]["PopUpSubAction"];
                ViewBag.wPopUp2 = bool.Parse(dtRoles.Rows[0]["wListPopUp2"].ToString()) ? bool.Parse(dtRoles.Rows[0]["PopUp2Print"].ToString()) ? dtRoles.Rows[0]["AllowPrint"] : true : false;
                ViewBag.wPopUpIcon2 = bool.Parse(dtRoles.Rows[0]["wListPopUp2"].ToString()) ? dtRoles.Rows[0]["PopUpIcon2"] : "print";
                ViewBag.wPopUpCtrl2 = dtRoles.Rows[0]["PopUpDetailViewController2"];
                ViewBag.wPopUpAction2 = dtRoles.Rows[0]["PopUpDetailViewAction2"];
                ViewBag.wPopUpSubAction2 = dtRoles.Rows[0]["PopUp2SubAction"];
                ViewBag.OrderBy = dtRoles.Rows[0]["OrderBy"];
                ViewBag.OrderByAs = dtRoles.Rows[0]["OrderByAs"];
                ViewBag.mName = dtRoles.Rows[0]["Code"].ToString();
                ViewBag.mNo = dtRoles.Rows[0]["MenuRefNo"].ToString();
                ViewBag.Description = dtRoles.Rows[0]["Description"];
                ViewBag.SubDescription = dtRoles.Rows[0]["SubDescription"];
                ViewBag.ViewId = dtRoles.Rows[0]["MenuRefNo"].ToString();
                ViewBag.Header = GetTableHeadersMain(dtRoles.Rows[0]["Code"].ToString());
                ViewBag.IsDisplayOnly = dtRoles.Rows[0]["IsDisplayOnly"].ToString(); ;
            }
            return PartialView(@"~\Views\ListView\Index.cshtml");
        }

        public virtual ActionResult ChildListIndex(ModelData data)
        {
            using (DataTable dtRoles = Common.GetData("SubMenuUserRoles", "UserRolesRefno = " + cmn.SessionUserRolesRefNo() + " AND MenuRefNo =" + data.ModelNo))
            {
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
                ViewBag.ViewId = data.ParentModel != null ? dtRoles.Rows[0]["Code"].ToString() + "_ListView_" + data.ParentModel : dtRoles.Rows[0]["Code"].ToString() + "_ListView";
                ViewBag.mName = dtRoles.Rows[0]["Code"].ToString();
                ViewBag.mNo = data.ModelNo;
                ViewBag.FormID = data.ParentModel != null ? "myParent_" + data.ParentModel + '_' + dtRoles.Rows[0]["Code"].ToString() : "myParent_" + dtRoles.Rows[0]["Code"].ToString();
                ViewBag.ParentModel = data.ParentModel;
                ViewBag.IsAppendMode = data.IsAppendMode.ToString().ToLower();
                ViewBag.HasNew = bool.Parse(dtRoles.Rows[0]["AllowInsert"].ToString()) && (data.ParentModel != null ? data.AllowAddOth : true) ? true : false;
                ViewBag.HasDelete = dtRoles.Rows[0]["AllowDelete"];
                ViewBag.AllowUpdate = data.AllowAddOth ? dtRoles.Rows[0]["AllowUpdate"] : false;
                ViewBag.OrderBy = dtRoles.Rows[0]["OrderBy"];
                ViewBag.OrderByAs = dtRoles.Rows[0]["OrderByAs"];
            }
            return data.ParentModel != null ? PartialView(@"~\Views\ListView\_Index.cshtml") : PartialView(@"~\Views\ListView\_DetailList.cshtml");
        }


        [HttpPost]
        public virtual JsonResult GetList(POSTData data)
        {      
            string SQL = null;
            var modelType = GetModelType(data.Model);
            var dbTableAttr = (modelType.GetCustomAttributes(typeof(DatabaseTableAttribute), true) as DatabaseTableAttribute[])[0];
            var dbTable = dbTableAttr.ViewName != null ? dbTableAttr.ViewName : dbTableAttr.Name;
            var sqlBuilder = new SelectQueryBuilder();
            sqlBuilder.SelectFromTable(dbTable);
            List<Header> Headers = GetTableHeadersMain(data.Model);
            foreach (var col in Headers)
            {
                if (col.RefmName != null)
                {
                    var refdbTableAttr = (GetModelType(col.RefmName).GetCustomAttributes(typeof(DatabaseTableAttribute), true) as DatabaseTableAttribute[])[0];
                    var refdbTable = refdbTableAttr.ViewName != null ? refdbTableAttr.ViewName : refdbTableAttr.Name;
                    sqlBuilder.AddColumnWithAlias(refdbTable,col.RefTblAlias, col.RefField);
                    sqlBuilder.AddJoin(col.RefTblAlias, JoinType.LeftJoin, refdbTable, col.RefColumn, Comparison.Equals, dbTable, col.PropertyName);
                }
                else { sqlBuilder.AddColumns(dbTable, (col.PropertyType == "DateTime" ? "CONVERT(VARCHAR(50)," + col.PropertyName + ",101)" : col.PropertyName)); }
            }
            SQL = sqlBuilder.BuildQuery();
            SQL = SQL.Replace("@Roles", Convert.ToString(cmn.SessionUserRolesRefNo()));
            SQL = SQL.Replace("@User", Convert.ToString(cmn.SessionUserRefNo()));
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, true);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }

        public virtual List<Header> GetTableHeadersMain(String mName)
        {
            var Headers = new List<Header>();
            var pInfos = GetTypePropertiesList(mName);
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
        public virtual JsonResult Refresh(POSTData data)
        {
            var modelType = GetModelType(data.Model);
            var pInfos = GetTypeProperties(data.Model);
            string SQL = null;
            var dbTableAttr = (modelType.GetCustomAttributes(typeof(DatabaseTableAttribute), true) as DatabaseTableAttribute[])[0];      
            var sqlBuilder = new SelectQueryBuilder();
            var dbTable = dbTableAttr.ViewName != null ? dbTableAttr.ViewName : dbTableAttr.Name;
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
            var JsonData = new DBHelper().GetJSONData(SQL, CommandType.Text, false);
            return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
        }
    }
}