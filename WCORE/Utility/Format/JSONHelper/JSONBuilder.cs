using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Utility {
    public class JsonBuilder {

        public static string ConvertDataTabletoString( DataTable dt ) {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            List<Dictionary<string ,object>> rows = new List<Dictionary<string ,object>>();
            Dictionary<string ,object> row;
            foreach (DataRow dr in dt.Rows) {
                row = new Dictionary<string ,object>();
                foreach (DataColumn col in dt.Columns) {
                    Object ObjValue = null;
                    if (dr[col].GetType() == typeof(DateTime)) {
                        ObjValue = ((DateTime)dr[col]).ToString();
                    } else {
                        ObjValue = dr[col];
                    }
                    row.Add(col.ColumnName ,ObjValue);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }
    }
}
