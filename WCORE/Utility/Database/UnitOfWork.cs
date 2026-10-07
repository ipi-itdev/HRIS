using System;
using System.Data.SqlClient;

namespace WCORE.Utility.Database
{
    public class UnitOfWork {
        
        public SqlConnection SqlConn = null;

        public UnitOfWork() {
            this.SqlConn = Common.GetSqlConnection();
        }

        public int ExecuteNonQuery(string SQL)
        {
            decimal returnValue = 0;
            using (SqlConnection conn = new SqlConnection(SqlConn.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandText = SQL;
                    cmd.CommandTimeout = 180;
                    if (SQL.Contains("INSERT"))
                    {
                        SQL = SQL + ";SELECT SCOPE_IDENTITY()";
                        cmd.CommandText = SQL;
                        returnValue = (decimal)cmd.ExecuteScalar();
                    }
                    else
                    {
                        returnValue = cmd.ExecuteNonQuery();
                    }
                    return Convert.ToInt32(returnValue);
                }
            }
        }
    }
}