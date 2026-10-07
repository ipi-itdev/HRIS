using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Utility;
using WCORE.Models;
using WCORE.Utility;

namespace WCORE.Controllers
{
    // o--------------------------------------------------------------------------------------------------o
    // |                   Source Code Documentation
    // o--------------------------------------------------------------------------------------------------o
    // |Description: Used for universal method in the system. All reusable action should be place here
    // |GetList - Used to generate data for select box
    // |IsUnique - Used to validate data for duplicate entry
    // o--------------------------------------------------------------------------------------------------o

    public class AppSetController : BaseController
    {
       Common cmn = new Common();

       [HttpPost]
       public virtual JsonResult GetList(PostData data)
       {
           var modelType = GetModelType(data.Model);
           var dbTableAttr = (modelType.GetCustomAttributes(typeof(DatabaseTableAttribute), true) as DatabaseTableAttribute[])[0];
           var dbTable = dbTableAttr.ViewName ?? dbTableAttr.Name;
           if (data.IsJson == true)
           {
               String JsonData = System.IO.File.ReadAllText(Server.MapPath("/Json/" + dbTable + ".txt"));
               JavaScriptSerializer json = new JavaScriptSerializer()
               { MaxJsonLength = Int32.MaxValue
               };
               List<Dictionary<string, object>> unpacked = json.Deserialize<List<Dictionary<string, object>>>(JsonData);
               JsonData = json.Serialize(JSONH.pack(unpacked, 0, false));
               return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
           }
           else
           {
               string SQL = "SELECT " + dbTableAttr.PKeyName + ",DESCRIPTION FROM " + dbTable + " WHERE IsActive = 1 " + (data.ForeignFieldKey != "" && data.ForeignFieldKey != null ? " AND " + data.ForeignFieldKey + " = " + data.ID_ParentKey : "") + " ORDER BY " + dbTableAttr.SeqBy;
               var JsonData = new DBHelper().GetJSONData(SQL.Replace("@User",cmn.SessionUserRefNo().ToString()), CommandType.Text, true);
               return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
           }
       }

        public virtual JsonResult GetDataLookUpList(POSTData data)
        {
            var modelType = GetModelType(data.Model);
            var dbTableAttr = (modelType.GetCustomAttributes(typeof(DatabaseTableAttribute), true) as DatabaseTableAttribute[])[0];
            var dbTable = dbTableAttr.DataLookupSource != null ? dbTableAttr.DataLookupSource : dbTableAttr.Name;
            if (data.IsJson == true)
            {
                String JsonData = System.IO.File.ReadAllText(Server.MapPath("/Json/" + dbTable + ".txt"));
                JavaScriptSerializer json = new JavaScriptSerializer()
                {
                    MaxJsonLength = Int32.MaxValue
                };
                List<Dictionary<string, object>> unpacked = json.Deserialize<List<Dictionary<string, object>>>(JsonData);
                JsonData = json.Serialize(JSONH.pack(unpacked, 0, false));
                return Json(JsonData != null ? JsonData : "[]", JsonRequestBehavior.AllowGet);
            }
            else
            {
                string SQL = "SELECT " + dbTableAttr.PKeyName + ",DESCRIPTION FROM " + dbTable + " WHERE IsActive = 1  ORDER BY " + dbTableAttr.SeqBy;
                var JsonData = new DBHelper().GetJSONData(SQL.Replace("@User", cmn.SessionUserRefNo().ToString()), CommandType.Text, true);
                return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);


        
            }
        }


        [HttpPost]
       public virtual JsonResult IsUnique()
       {
           string mName = Request["mName"];
           string dynamicObject = Request["Obj"];
           string dynamicObjectVal = Request["ObjVal"];
           string dynamicObjectID = Request["ObjID"];
           var modelType = GetModelType(mName);
           var dbTableAttr = (modelType.GetCustomAttributes(typeof(DatabaseTableAttribute), true) as DatabaseTableAttribute[])[0];
           var dbTable = dbTableAttr.Name ?? modelType.Name;
           var JsonData = new DBHelper().GetJSONData("SELECT ID FROM " + dbTable + " WHERE " + dynamicObject + "='" + dynamicObjectVal + "' AND ID <> " + dynamicObjectID, CommandType.Text, true);
           return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
       }

    }
}
