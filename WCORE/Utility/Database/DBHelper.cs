using CrystalDecisions.ReportAppServer.CubeDefModel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace WCORE.Utility
{
    public class DBHelper
    {
        SqlConnection SqlConn = null;
        string Hostname = System.Net.Dns.GetHostName();
        string MacAddress = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[0].ToString();
        Common cmn = new Common();
        public DBHelper()
        {
            this.SqlConn = Common.GetSqlConnection();
        }

        public DBHelper(SqlConnection SqlConn)
        {
            this.SqlConn = SqlConn;
        }

        public int ExecuteNonQuery(string SQL, CommandType cmdType, string[] sqlparam = null, string[] sqlparamval = null)
        {
            using (SqlConnection conn = new SqlConnection(SqlConn.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(SQL, conn))
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandTimeout = 180;
                    if (sqlparam != null)
                    {
                        for (int i = 0; i < sqlparam.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(sqlparam[i], sqlparamval[i]);
                        }
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        public DataSet DSExecuteQuery(string SQL, CommandType cmdType, string[] sqlparam = null, string[] sqlparamval = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConn.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(SQL, conn))
                    {
                        DataSet ds = new DataSet();
                        cmd.CommandType = cmdType;
                        cmd.CommandTimeout = 180;
                        if (sqlparam != null)
                        {
                            for (int i = 0; i < sqlparam.Length; i++)
                            {
                                cmd.Parameters.AddWithValue(sqlparam[i], sqlparamval[i]);
                            }
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            finally { }
        }

        public DataTable ExecuteQuery(string SQL, CommandType cmdType, string[] sqlparam = null, string[] sqlparamval = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlConn.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(SQL, conn))
                    {
                        DataTable dt = new DataTable();
                        cmd.CommandType = cmdType;
                        cmd.CommandTimeout = 180;
                        if (sqlparam != null)
                        {
                            for (int i = 0; i < sqlparam.Length; i++)
                            {
                                cmd.Parameters.AddWithValue(sqlparam[i], sqlparamval[i]);
                            }
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            finally { }
        }

        public SqlDataReader ExecuteReader(string SQL, CommandType cmdType, string[] sqlparam = null, string[] sqlparamval = null)
        {
            try
            {
                SqlConnection conn = new SqlConnection(SqlConn.ConnectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SQL, conn))
                {
                    if (sqlparam != null)
                    {
                        for (int i = 0; i < sqlparam.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(sqlparam[i], sqlparamval[i]);
                        }
                    }
                    cmd.CommandType = cmdType;
                    cmd.CommandTimeout = 180;
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            finally { }
        }


        public String GetJSONData(String SQL, CommandType ct, bool IsTable, string[] sqlparam = null, string[] sqlparamval = null)
        {
            
            String JSONData = "";
            try
            {
                Common cmn = new Common();
                JSONData = Common.ConvertDataTableToJSON(ExecuteQuery(SQL, ct, sqlparam, sqlparamval), IsTable);
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            finally { }
            return JSONData;
        }

        public List<BaseObject> GetCollection(String mName, String SQL)
        {
            try
            {
                Type Paramertype = Common.GetModelType(mName);
                using (DataTable dataTable = ExecuteQuery(SQL, CommandType.Text))
                {
                    if (dataTable.Rows.Count == 0)
                        return null;
                    List<BaseObject> mList = new List<BaseObject>();
                    foreach (DataRow R in dataTable.Rows)
                    {
                        BaseObject newObject = (BaseObject)Activator.CreateInstance(Paramertype);
                        foreach (PropertyInfo f in Paramertype.GetProperties())
                        {
                            DatabaseFieldAttribute dbField = f.GetCustomAttribute<DatabaseFieldAttribute>();
                            if (dbField == null)
                                continue;
                            String FieldName = dbField.Name == null ? f.Name : dbField.Name;
                            Object Value = R[FieldName];
                            if (Value == null)
                                continue;
                            if (Value.GetType() == typeof(DBNull))
                                continue;
                            f.SetValue(newObject, Value);
                        }
                        mList.Add(newObject);
                    }
                    return mList;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                SqlConn.Close();
            }

        }
    }
}