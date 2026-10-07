using WCORE.Utility;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WCORE.Controllers
{
    // o--------------------------------------------------------------------------------------------------o
    // |                   Source Code Documentation
    // o--------------------------------------------------------------------------------------------------o
    // | This Controller is responsible in setting up list view of HRIS. It caters 3 types of list view.
    // | 1. Main Grid - this type of list is usually used in modules that consists of many fields and 
    // |                functions. It can also used for displaying list without detail view for summary reports.
    // | 2. List and Details  - this type of list is usually used in maintenance modules. It displays the list 
    // |                and details at the same time.
    // | 3. Child List  - this type of list is used in child modules.
    // o--------------------------------------------------------------------------------------------------o
    public partial class ListViewController : BaseController
    {
        DBHelper dbh = new DBHelper();
        Common cmn = new Common();

        public virtual ActionResult ListIndex(ModelData data)
        {
            int fType = 1; string ListViewPage = "";
            string[] strparam = { "@mguid", "@User", "@FKey", "@FKeyName", "@ParentMenuRefNo" };
            string[] strparamval = { data.mguid, cmn.SessionUserRefNo().ToString(), data.FKey.ToString(), data.FKeyName, data.ParentMenuRefNo.ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spSysGenerateList", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read())
                {
                    //if ((dr["MenuRefNo"].ToString() != "70001") && (data.ParentMenuRefNo.ToString() != "70001"))
                    //{
                    //    Session["PID"] = 0;
                    //}else if (Session["PID"] == null)
                    //{
                    //    Session["PID"] = 0;
                    //}
                    if (Session["PID"] == null)
                    {
                        Session["PID"] = 0;

                    }else if (Session["PID"] != null && 
                        (
                        dr["MenuRefNo"].ToString() == "70001" || dr["MenuRefNo"].ToString() == "70002" || dr["MenuRefNo"].ToString() == "70003" || 
                        dr["MenuRefNo"].ToString() == "60001" || dr["MenuRefNo"].ToString() == "60002" || dr["MenuRefNo"].ToString() == "60003" || 
                        dr["MenuRefNo"].ToString() == "60004" || dr["MenuRefNo"].ToString() == "1113" || dr["MenuRefNo"].ToString() == "1" || 
                        dr["MenuRefNo"].ToString() == "4005" || dr["MenuRefNo"].ToString() == "4000" || dr["MenuRefNo"].ToString() == "4014" || 
                        dr["MenuRefNo"].ToString() == "4018" || dr["MenuRefNo"].ToString() == "4024" || dr["MenuRefNo"].ToString() == "4028" || 
                        dr["MenuRefNo"].ToString() == "4034" || dr["MenuRefNo"].ToString() == "4038" || dr["MenuRefNo"].ToString() == "4044" || 
                        dr["MenuRefNo"].ToString() == "4048" || dr["MenuRefNo"].ToString() == "4008" || dr["MenuRefNo"].ToString() == "30102" || 
                        dr["MenuRefNo"].ToString() == "30104" || dr["MenuRefNo"].ToString() == "30216" || dr["MenuRefNo"].ToString() == "30212" || 
                        dr["MenuRefNo"].ToString() == "30214" || dr["MenuRefNo"].ToString() == "31100" || dr["MenuRefNo"].ToString() == "31200" || 
                        dr["MenuRefNo"].ToString() == "855" || dr["MenuRefNo"].ToString() == "860" || dr["MenuRefNo"].ToString() == "60" || 
                        dr["MenuRefNo"].ToString() == "70" || dr["MenuRefNo"].ToString() == "90" || dr["MenuRefNo"].ToString() == "50000" || 
                        dr["MenuRefNo"].ToString() == "50100" || dr["MenuRefNo"].ToString() == "1105" || dr["MenuRefNo"].ToString() == "1097" || 
                        dr["MenuRefNo"].ToString() == "1100" || dr["MenuRefNo"].ToString() == "1106" || dr["MenuRefNo"].ToString() == "903" || 
                        dr["MenuRefNo"].ToString() == "740" || dr["MenuRefNo"].ToString() == "960" || dr["MenuRefNo"].ToString() == "1000" || 
                        dr["MenuRefNo"].ToString() == "10700" || dr["MenuRefNo"].ToString() == "56" || dr["MenuRefNo"].ToString() == "59" || 
                        dr["MenuRefNo"].ToString() == "52" || dr["MenuRefNo"].ToString() == "57" || dr["MenuRefNo"].ToString() == "58" || 
                        dr["MenuRefNo"].ToString() == "53" || dr["MenuRefNo"].ToString() == "54" || dr["MenuRefNo"].ToString() == "51" || 
                        dr["MenuRefNo"].ToString() == "1131" || dr["MenuRefNo"].ToString() == "1132" || dr["MenuRefNo"].ToString() == "1133" || dr["MenuRefNo"].ToString() == "1134" || dr["MenuRefNo"].ToString() == "1135" || dr["MenuRefNo"].ToString() == "1136")
                        )
                    {
                        Session["PID"] = 0;

                    }



                    ViewBag.mguid = data.mguid;
                    ViewBag.mNo = dr["MenuRefNo"].ToString();
                    ViewBag.mCode = dr["Code"].ToString();
                    ViewBag.Description = dr["Description"].ToString();
                    ViewBag.SubDescription = dr["SubDescription"];
                    ViewBag.DetailActionName = dr["DetailActionName"].ToString();
                    ViewBag.DetailControllerName = dr["DetailControllerName"];
                    ViewBag.ViewId = data.ParentMenuRefNo != 0 ? dr["MenuRefNo"].ToString() + "_ListView_" + data.ParentMenuRefNo : dr["MenuRefNo"].ToString() + "_ListView"; // used to determine the place of the list view
                    ViewBag.ModalFormID = "mFrm" + data.ParentMenuRefNo; // used to determine the place of the detail view of the list view
                    ViewBag.FormID = "mFrm" + dr["MenuRefNo"].ToString(); // used to determine the place of the detail view of the list view
                    ViewBag.WithOpen = bool.Parse(dr["WithOpen"].ToString()); // used to identify if the table has a detail view
                    ViewBag.AllowInsert = bool.Parse(dr["AllowInsert"].ToString()); // used to identify if the menu has a insert feature
                    fType = int.Parse(dr["FormType"].ToString()); // used to determine the list view design 
                    ViewBag.fType = int.Parse(dr["FormType"].ToString()); // used to determine the list view design

                    ViewBag.AllowPrint = bool.Parse(dr["AllowPrint"].ToString()); // Used to determine if the table has export buttons
                    ViewBag.AllowExport = bool.Parse(dr["AllowExport"].ToString());

                    ViewBag.tFormat = dr["xFormat"].ToString(); // used to identify the column and settings of the table
                    ViewBag.tButtonHdr = dr["xButtonHeader"].ToString(); // used to identify the main buttons of the table
                    ViewBag.tButtonDtl = dr["xButtonDetail"].ToString(); // used to identify buttons that will display per row in the table
                    ViewBag.tFilter = dr["xFilter"].ToString(); // used to form filter view

                    ViewBag.FID = data.FKey; // for detail list to identify the foreign key of the parent table
                    ViewBag.FIDName = data.FKeyName; // for detail list to identify the foreign key of the parent table

                    ViewBag.LimitLoad = bool.Parse(dr["IsLimitedList"].ToString()); // used to identify if paging must be applied to data loading in list

                    ViewBag.OrderBy = dr["OrderBy"].ToString(); // used to identify the column index for sorting
                    ViewBag.OrderByAs = dr["OrderByAs"].ToString(); // used to identify if ASC or DESC

                    ViewBag.ListDataSource = dr["ListDataSource"].ToString(); // used to identify listview datasource
                    ViewBag.IsAPIUrl = bool.Parse(dr["IsAPIUrl"].ToString()); // used to define if the datasource is an api

                    ViewBag.Icon = bool.Parse(dr["IsAPIUrl"].ToString()); // used to define if the datasource is an api

                    switch (fType)
                    {
                        case 1:
                            ViewBag.tFilterValue = "{" + dr["xFilterValue"].ToString() + "'IsDirty':true}"; // used to filter child list value on load
                            ListViewPage = "ListIndex.cshtml"; // main list view 
                            break;
                        case 2:
                        case 10:
                            ListViewPage = "_DetailList.cshtml"; // list and details view
                            break;
                        //case 10:
                        //    ListViewPage = "_DetailList.cshtml"; // list and details view
                        //    break;
                        default:
                            ViewBag.tFilterValue = "{'" + data.FKeyName + "':" + data.FKey + ",'IsDirty':true}"; // used to filter child list value on load
                            ListViewPage = "_Index.cshtml"; // child list view
                            break;
                    }
                }
            }
            return PartialView(@"~\Views\LV\" + ListViewPage);
        }

        // This method is used to provide data in list view
        [HttpGet]
        public JsonResult ListIndexRefresh(PostData data)
        {
            string[] strparam = { "@mguid", "@PageNo", "@param", "@User", "@PID"}; // add parameter @PID due to sudden changes in employee detail - june 20 ,2024 noel
            string[] strparamval = { data.mguid, data.TPageNo.ToString(), data.TdtParam.ToString(), cmn.SessionUserRefNo().ToString(), Session["PID"].ToString()};
            DataSet ds = new DBHelper().DSExecuteQuery("dbo.spSYSGenerateListdt", CommandType.StoredProcedure, strparam, strparamval);
            var JsonData = Common.ConvertDataTableToJSON(ds.Tables[0], true);
            var result = new { Result = JsonData, CNT = ds.Tables[1].Rows[0][0].ToString() };
            ds.Dispose();
            // added new code for the error of json javascript serializer - april 5, 2024 noel
            var json_result = Json(result, JsonRequestBehavior.AllowGet);
            json_result.MaxJsonLength = int.MaxValue;
            return json_result;
            //return Json(result, JsonRequestBehavior.AllowGet);
        }
    }

    public class ModelData
    {
        public string mguid { get; set; }
        public bool IsAppendMode { get; set; }
        public int ParentMenuRefNo { get; set; }
        public string ParentModel { get; set; }
        public string FKeyName { get; set; }
        public int FKey { get; set; }
    }

    public class PostData
    {
        public string Model { get; set; }
        public string mguid { get; set; }
        public string ForeignFieldKey { get; set; }
        public int ID_ParentKey { get; set; }
        public bool IsJson { get; set; }
        public int TPageNo { get; set; }
        public string TdtParam { get; set; }

        public int pid { get; set; }

        public bool IsEnum { get; set; }
    }

    public class POSTData
    {
        //public string ViewId { get; set; }
        public string Model { get; set; }
        public string ForeignFieldKey { get; set; }
        public int ID_ParentKey { get; set; }
        public bool IsJson { get; set; }
        public int ctrPage { get; set; }
        public string odrPage { get; set; }
    }
}