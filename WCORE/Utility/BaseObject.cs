using WCORE.Utility.Database;
using System;
using System.Linq;
using System.Reflection;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WCORE.Models;
using System.Diagnostics;
using WCORE.Controllers;
using System.Web.Mvc;

namespace WCORE.Utility
{
    public abstract class BaseObject
    {
        Common cmn = new Common();
        DetailViewController dvc = new DetailViewController();
        
        private string Hostname = System.Net.Dns.GetHostName();
        private string MacAddress = HttpContext.Current.Request.UserHostAddress;

        public BaseObject()
        {
            this.ID = -1;
            this.IsActive = true;
        }

        [DatabaseField(AllowInsert = false, AllowUpdate = false)]
        [ListViewColumn(SeqNo =-1, Width = 0)]
        [DetailViewItem(IsEnabled = false)]
        [SeqNo(Index = -1000)]
        public int ID { get; set; }

        [DataLookUp]
        [Display(Name = "Created By")]
        [DetailViewItem(IsEnabled = false, TabName = "Other")]
        [DatabaseField(Name = "ID", AllowInsert =false,AllowUpdate=false, RefModel = typeof(User), RefField = "Description", RefAlias = "[Created By]", RefTableAlias = "UCB")]
        public int CreatedBy { get; set; }

        [Display(Name = "Created Date")]
        [DetailViewItem(IsEnabled = false, TabName = "Other")]
        [DatabaseField(AllowInsert=false,AllowUpdate=false)]
        public string CreatedDate { get; set; }

        [DataLookUp]
        [Display(Name = "Last Modified By")]
        [DetailViewItem(IsEnabled = false, TabName = "Other",Column=2)]
        [DatabaseField(Name="ID", AllowInsert = false, AllowUpdate = false, RefModel = typeof(User), RefField = "Description", RefAlias = "[Modified By]", RefTableAlias = "UMB")]
        public int ModifiedBy { get; set; }

        [Display(Name = "Last Modified Date")]
        [DetailViewItem(IsEnabled = false, TabName = "Other", Column = 2)]
        [DatabaseField(AllowUpdate = false,AllowInsert = false)]
        public string ModifiedDate { get; set; }

        [Display(Name = "Is Active?")]
        [DetailViewItem(IsEnabled = false, TabName = "Other", Column = 2)]
        [DatabaseField(AllowUpdate = false,DefaultValue="1")]
        public bool IsActive { get; set; }

        public virtual void Save(UnitOfWork uow)
        {       
            string SQL = null;
            string[] Columns = null;
            string[] Values = null;
            string[] UpdatesValues = null;
            string[] UpdatesValuesAT = null; 
            PropertyInfo[] pInfos = null;
            var tableName = getTableName();
            var table_name = tableName.ToString();

            if (tableName == "View_InternalEmployee_Active")
            {
                pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowInsert == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                Columns = pInfos.Select(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false && p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name).ToArray();
                Values = pInfos.Select(p => getPropertyStringValue(p)).ToArray();
                UpdatesValuesAT = Values;
                string value_1 = String.Join("|", Values);

                if (this.ID < 0)
                {

                    SQL = "EXEC Ins_View_InternalEmployee_Active @Columns ='" + String.Join(",", Columns) + "', @Values ='" + value_1.Replace("'", "''") + "', @UserRefNo ='" + cmn.SessionUserRefNo().ToString() + "'";
                    uow.ExecuteNonQuery(SQL);
                    string Cols = String.Join(" => ", Columns);
                    //SQL = "SELECT " + value_1.Replace("'", "''") + " AS VALUES, " + String.Join(",", Columns) + " AS Columns";

                    uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','" + String.Join("=>", Cols.Replace("'", "")) + "','',''," + this.ID + ",'INS'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");

                }
                else
                {
                    SQL = "EXEC Update_View_InternalEmployee_Active @Columns ='" + String.Join(",", Columns) + "', @Values ='" + value_1.Replace("'", "") + "', @UserID ='" + ID + "'";

                    string Cols = String.Join(" => ", Columns);
                    uow.ExecuteNonQuery(SQL);
                    uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','" + String.Join("=>", Cols.Replace("'", "")) + "','',''," + this.ID + ",'EDIT'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");

                }



            }
            else if (tableName == "View_InternalEmployee_Inactive" && this.ID > 0)
            {
                pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowInsert == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                Columns = pInfos.Select(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false && p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name).ToArray();
                Values = pInfos.Select(p => getPropertyStringValue(p)).ToArray();
                UpdatesValuesAT = Values;
                string value_1 = String.Join("|", Values);

                SQL = "EXEC Update_View_InternalEmployee_Active @Columns ='" + String.Join(",", Columns) + "', @Values ='" + value_1.Replace("'", "") + "', @UserID ='" + ID + "'";

                string Cols = String.Join(" => ", Columns);
                uow.ExecuteNonQuery(SQL);
                uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','" + String.Join("=>", Cols.Replace("'", "")) + "','',''," + this.ID + ",'EDIT'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");


            }
            else if (tableName == "View_ExternalEmployee_Active" && this.ID > 0)
            {
                pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowInsert == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                Columns = pInfos.Select(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false && p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name).ToArray();
                Values = pInfos.Select(p => getPropertyStringValue(p)).ToArray();
                UpdatesValuesAT = Values;
                string value_1 = String.Join("|", Values);

                SQL = "EXEC Update_View_InternalEmployee_Active @Columns ='" + String.Join(",", Columns) + "', @Values ='" + value_1.Replace("'", "") + "', @UserID ='" + ID + "'";

                string Cols = String.Join(" => ", Columns);
                uow.ExecuteNonQuery(SQL);
                uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','" + String.Join("=>", Cols.Replace("'", "")) + "','',''," + this.ID + ",'EDIT'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");


            }
            else if (tableName == "View_ExternalEmployee_Inactive" && this.ID > 0)
            {
                pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowInsert == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                Columns = pInfos.Select(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false && p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name).ToArray();
                Values = pInfos.Select(p => getPropertyStringValue(p)).ToArray();
                UpdatesValuesAT = Values;
                string value_1 = String.Join("|", Values);

                SQL = "EXEC Update_View_InternalEmployee_Active @Columns ='" + String.Join(",", Columns) + "', @Values ='" + value_1.Replace("'", "") + "', @UserID ='" + ID + "'";

                string Cols = String.Join(" => ", Columns);
                uow.ExecuteNonQuery(SQL);
                uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','" + String.Join("=>", Cols.Replace("'", "")) + "','',''," + this.ID + ",'EDIT'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");


            }
            else if (tableName == "View_ExternalEmployee_Floating" && this.ID > 0)
            {
                pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowInsert == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                Columns = pInfos.Select(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false && p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name).ToArray();
                Values = pInfos.Select(p => getPropertyStringValue(p)).ToArray();
                UpdatesValuesAT = Values;
                string value_1 = String.Join("|", Values);

                SQL = "EXEC Update_View_InternalEmployee_Active @Columns ='" + String.Join(",", Columns) + "', @Values ='" + value_1.Replace("'", "") + "', @UserID ='" + ID + "'";

                string Cols = String.Join(" => ", Columns);
                uow.ExecuteNonQuery(SQL);
                uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','" + String.Join("=>", Cols.Replace("'", "")) + "','',''," + this.ID + ",'EDIT'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");


            }
            else if (tableName == "View_ExternalEmployee_Loading" && this.ID > 0)
            {
                pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowInsert == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                Columns = pInfos.Select(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false && p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name).ToArray();
                Values = pInfos.Select(p => getPropertyStringValue(p)).ToArray();
                UpdatesValuesAT = Values;
                string value_1 = String.Join("|", Values);

                SQL = "EXEC Update_View_InternalEmployee_Active @Columns ='" + String.Join(",", Columns) + "', @Values ='" + value_1.Replace("'", "") + "', @UserID ='" + ID + "'";

                string Cols = String.Join(" => ", Columns);
                uow.ExecuteNonQuery(SQL);
                uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','" + String.Join("=>", Cols.Replace("'", "")) + "','',''," + this.ID + ",'EDIT'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");


            }
            //else if (tableName == "View_PIS_KPIAssigmentDetails")
            //{

            //    if (this.ID <= 0)
            //    {
            //        pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowInsert == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
            //        Columns = pInfos.Select(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false && p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name).ToArray();
            //        Values = pInfos.Select(p => getPropertyStringValue(p)).ToArray();
            //        SQL = "INSERT dbo.PIS_KPIAssigmentDetails (" + String.Join(",", Columns) + ",CreatedBy,CreatedDate,ModifiedDate,ModifiedBy,DateSubmitted,DateApproved,SubmissionDate,FinalScore,ScoreValue,EmploymentStatusRefNo) VALUES (" + String.Join(",", Values) + "," + cmn.SessionUserRefNo().ToString() + ",DATEADD(HOUR,8,GETUTCDATE()),DATEADD(HOUR,8,GETUTCDATE())," + cmn.SessionUserRefNo().ToString() + ")";
            //    }
            //    else
            //    {
            //        pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowUpdate == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
            //        UpdatesValues = pInfos.Select(p => GetDatabaseFieldName(p) + " = " + (getPropertyStringValue(p))).ToArray();
            //        UpdatesValuesAT = UpdatesValues;
            //        SQL = "UPDATE " + tableName + " SET " + String.Join(",", UpdatesValues) + ",ModifiedDate = DATEADD(HOUR,8,GETUTCDATE()) , ModifiedBy = " + cmn.SessionUserRefNo() + " WHERE ID = " + this.ID.ToString();
            //    }

            //    if (this.ID <= 0)
            //    {
            //        this.ID = uow.ExecuteNonQuery(SQL);
            //        uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','','','','" + this.ID + "','ADD'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");
            //    }
            //    else
            //    {

            //        string Cols = String.Join(" => ", UpdatesValuesAT);
            //        uow.ExecuteNonQuery(SQL);
            //        uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','" + String.Join("=>", Cols.Replace("'", "")) + "','',''," + this.ID + ",'EDIT'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");


            //    }
            //}
            else if (tableName == "View_DepartmentGlobe")
            {

                if (this.ID <= 0)
                {
                    pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowInsert == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                    Columns = pInfos.Select(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false && p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name).ToArray();
                    Values = pInfos.Select(p => getPropertyStringValue(p)).ToArray();
                    UpdatesValuesAT = Values;
                    string value_1 = String.Join(",", Values);

                    //SQL = "EXEC Insert_View_DepartmentGlobe @Columns ='" + String.Join(",", Columns) + "', @Values ='" + value_1.Replace("'", "") + "'";

                    SQL = "INSERT INTO  PORTAL_GlobeEmployees_U (" + String.Join(",", Columns) + ",CreatedBy,ModifiedBy,CreatedDate,ModifiedDate) VALUES( " + value_1.Replace("'", "") + "," + cmn.SessionUserRefNo().ToString() + ", " + cmn.SessionUserRefNo().ToString() + ",GETDATE(),GETDATE())";

                    //SQL = "SELECT " + value_1.Replace("'", "");

                    string Cols = String.Join(" => ", Columns);
                    uow.ExecuteNonQuery(SQL);
                    uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','" + String.Join("=>", Cols.Replace("'", "")) + "','',''," + this.ID + ",'EDIT'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");
                }
                else
                {
                    pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowInsert == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                    Columns = pInfos.Select(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false && p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name).ToArray();
                    Values = pInfos.Select(p => getPropertyStringValue(p)).ToArray();
                    UpdatesValuesAT = Values;
                    string value_1 = String.Join("|", Values);

                    SQL = "EXEC Update_View_DepartmentGlobe @Columns ='" + String.Join(",", Columns) + "', @Values ='" + value_1.Replace("'", "") + "', @UserRefNo='" + cmn.SessionUserRefNo().ToString() + "' ";

                    //SQL = "SELECT " + String.Join(",", Columns) + " FROM " + tableName.ToString();

                    //SQL = "SELECT " + value_1.Replace("'", "");

                    string Cols = String.Join(" => ", Columns);
                    uow.ExecuteNonQuery(SQL);
                    uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','" + String.Join("=>", Cols.Replace("'", "")) + "','',''," + this.ID + ",'EDIT'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");

                }
            }
            else if (tableName == "PIS_PerfIndicatorList")
            {
                if (this.ID <= 0)
                {
                    pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowInsert == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                    Columns = pInfos.Select(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false && p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name).ToArray();
                    Values = pInfos.Select(p => getPropertyStringValue(p)).ToArray();
                    SQL = "INSERT " + tableName + " (" + String.Join(",", Columns) + ",CreatedBy,CreatedDate,ModifiedDate) VALUES (" + String.Join(",", Values) + "," + cmn.SessionUserRefNo().ToString() + ",DATEADD(HOUR,8,GETUTCDATE()),DATEADD(HOUR,8,GETUTCDATE()))";

                }
                else
                {
                    pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowInsert == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                    Columns = pInfos.Select(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false && p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name).ToArray();
                    Values = pInfos.Select(p => getPropertyStringValue(p)).Where(value => value != "1").ToArray();
                    SQL = "EXEC dbo.pUpdatingPerformanceIndicator " + 0 + ", " + this.ID + ", " + String.Join(",", Values) + ", " + Convert.ToString(cmn.SessionUserRefNo()) + ", " + 0 + ", " + 5;
                    uow.ExecuteNonQuery(SQL);

                  
                }

                if (this.ID <= 0)
                {
                    this.ID = uow.ExecuteNonQuery(SQL);
                    uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','','','','" + this.ID + "','ADD'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");
                }
                else
                {
                    pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowUpdate == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                    UpdatesValues = pInfos.Select(p => GetDatabaseFieldName(p) + " = " + (getPropertyStringValue(p))).ToArray();
                    UpdatesValuesAT = UpdatesValues;

                    string Cols = String.Join(" => ", UpdatesValuesAT);
                    uow.ExecuteNonQuery(SQL);
                    uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','" + String.Join("=>", Cols.Replace("'", "")) + "','',''," + this.ID + ",'EDIT'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");


                }
            }
            else
            {
                if (this.ID <= 0)
                {
                    pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowInsert == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                    Columns = pInfos.Select(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false && p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name).ToArray();
                    Values = pInfos.Select(p => getPropertyStringValue(p)).ToArray();
                    SQL = "INSERT " + tableName + " (" + String.Join(",", Columns) + ",CreatedBy,CreatedDate,ModifiedDate) VALUES (" + String.Join(",", Values) + "," + cmn.SessionUserRefNo().ToString() + ",DATEADD(HOUR,8,GETUTCDATE()),DATEADD(HOUR,8,GETUTCDATE()))";
                }
                else
                {
                    pInfos = GetType().GetProperties().Where(p => p.IsDefined(typeof(DatabaseFieldAttribute), true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().AllowUpdate == true) && (p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false)).ToArray();
                    UpdatesValues = pInfos.Select(p => GetDatabaseFieldName(p) + " = " + (getPropertyStringValue(p))).ToArray();
                    UpdatesValuesAT = UpdatesValues;
                    SQL = "UPDATE " + tableName + " SET " + String.Join(",", UpdatesValues) + ",ModifiedDate = DATEADD(HOUR,8,GETUTCDATE()) , ModifiedBy = " + cmn.SessionUserRefNo() + " WHERE ID = " + this.ID.ToString();
                }

                if (this.ID <= 0)
                {
                    this.ID = uow.ExecuteNonQuery(SQL);
                    uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','','','','" + this.ID + "','ADD'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");
                }
                else
                {

                    string Cols = String.Join(" => ", UpdatesValuesAT);
                    uow.ExecuteNonQuery(SQL);
                    uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','" + tableName.ToString() + "','" + String.Join("=>", Cols.Replace("'", "")) + "','',''," + this.ID + ",'EDIT'," + cmn.SessionUserRefNo().ToString() + ",'" + MacAddress + "','" + Hostname + "' ");


                }
            }

        }

        public virtual void Delete(UnitOfWork uow)
        {
            var tableName = getTableName();
            var table_name = tableName.ToString();
          


            if (tableName == "View_DepartmentGlobe")
            {
                uow.ExecuteNonQuery("DELETE FROM PORTAL_GlobeEmployees_U WHERE EmployeeRefNo = " + this.ID.ToString());
                uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','','','',''," + this.ID + ",'DELETE','1','" + MacAddress + "','" + Hostname + "' ");
            }
            else if (tableName == "PIS_Attrition_U") 
            {
                //uow.ExecuteNonQuery("INSERT INTO SYS_Emails_C VALUES (NULL,NULL,DATEADD(HOUR,8,GETUTCDATE()),DATEADD(HOUR,8,GETUTCDATE()),1,(SELECT a.email FROM SYS_WebUser a LEFT JOIN PIS_Attrition_U b ON a.id = b.createdby WHERE b.createdby =" + cmn.SessionUserRefNo() + " AND b.id = " + this.ID.ToString() + "),'hrc@ipiphil.com','Cancellation of Attrition','This is to inform that attrition of ' + (SELECT a.description FROM PIS_Employee_U a LEFT JOIN PIS_Attrition_U b ON a.employeerefno = b.employeerefno WHERE b.id =" + this.ID.ToString() + ") + ' has been cancelled',1,'','',0,0)");

                uow.ExecuteNonQuery("UPDATE " + getTableName() + " SET IsActive = 0 WHERE ID = " + this.ID.ToString());
                uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','','','',''," + this.ID + ",'DELETE','1','" + MacAddress + "','" + Hostname + "' ");
            }
            else
            {

                uow.ExecuteNonQuery("UPDATE " + getTableName() + " SET IsActive = 0 WHERE ID = " + this.ID.ToString());
                uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','','','',''," + this.ID + ",'DELETE','1','" + MacAddress + "','" + Hostname + "' ");
            }
      
        }

        // july 17 2024 - noel
        public virtual void Approve(UnitOfWork uow)
        {
            var tableName = getTableName();
            var sessionValue = HttpContext.Current.Session["MenuRefNo"];

            if (tableName == "PIS_PAR" && sessionValue.ToString() == "56")
            {
                uow.ExecuteNonQuery("EXEC dbo.PIS_Approvals '" + this.ID + "' , '" + getTableName() + "', '" + cmn.SessionUserRefNo().ToString() + "', 2, 0,'NULL',56 ");
                uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','','','',''," + this.ID + ",'APPROVE','1','" + MacAddress + "','" + Hostname + "' ");
            }
            else if(tableName == "PIS_PAR" && sessionValue.ToString() == "53")
            {
                uow.ExecuteNonQuery("EXEC dbo.PIS_Approvals '" + this.ID + "' , '" + getTableName() + "', '" + cmn.SessionUserRefNo().ToString() + "', 2, 1,'NULL',53 ");
                uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','','','',''," + this.ID + ",'APPROVE','1','" + MacAddress + "','" + Hostname + "' ");
            }
         
        }

        // july 18, 2024 - noel
        public virtual void Disapprove(UnitOfWork uow)
        {
            var tableName = getTableName();

            if (tableName == "PIS_PAR")
            {
                uow.ExecuteNonQuery("EXEC dbo.PIS_Approvals '" + this.ID + "' , '" + getTableName() + "', '" + cmn.SessionUserRefNo().ToString() + "', 8, 0,NULL,56 ");
                uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','','','',''," + this.ID + ",'APPROVE','1','" + MacAddress + "','" + Hostname + "' ");
            }
           
        }

        public virtual void Printed(UnitOfWork uow)
        {
            var tableName = getTableName();

            if (tableName == "PIS_PAR")
            {
                uow.ExecuteNonQuery("EXEC dbo.UpdateParPrint '" + this.ID + "' ");
                uow.ExecuteNonQuery("EXEC dbo.SYS_SP_AuditTrail '" + getMenuName() + "','','','',''," + this.ID + ",'APPROVE','1','" + MacAddress + "','" + Hostname + "' ");
            }

        }

        private string getTableName()
        {
            return getTableName(GetType());
        }

        private string getTableName(Type t)
        {
            return t.GetCustomAttribute<DatabaseTableAttribute>().Name != null ? t.GetCustomAttribute<DatabaseTableAttribute>().Name : t.Name;
        }

        private string getMenuName()
        {
            return getMenuName(GetType());
        }

        private string getMenuName(Type t)
        {
            return t.GetCustomAttribute<MenuDescriptionAttribute>() != null ? t.GetCustomAttribute<MenuDescriptionAttribute>().Name : t.Name;
        }


        private string GetDatabaseFieldName(PropertyInfo p)
        {
            return p.GetCustomAttribute<DatabaseFieldAttribute>().Name != null && p.GetCustomAttribute<DatabaseFieldAttribute>().RefModel == null ? p.GetCustomAttribute<DatabaseFieldAttribute>().Name : p.Name;
        }

        private string getValue(PropertyInfo p)
        {
            if (p.PropertyType == typeof(Boolean))
            {
                return p.GetValue(this).ToString() == "False" || p.GetValue(this) == null || p.GetValue(this).ToString().ToLower() == "null" ? "0" : "1";
            }
            else
            {
                return p.GetValue(this).ToString() == "" || p.GetValue(this) == null || p.GetValue(this).ToString().ToLower() == "null" ? null : p.GetValue(this).ToString().Replace("'", "`");
            }
        }

        private string getPropertyStringValue(PropertyInfo p)
        {
            object obj = p.GetValue(this);
            if (obj == null && p.GetCustomAttribute<DatabaseFieldAttribute>().DefaultValue == null) return "NULL";
            if (p.PropertyType == typeof(DateTime))
            {
                if ((DateTime)obj == DateTime.MinValue) return "NULL";
                return "'" + obj+ "'";
            }
            else if (p.GetCustomAttribute<DatabaseFieldAttribute>().DefaultValue != null && (p.GetCustomAttribute<DetailViewItemAttribute>() == null || p.GetCustomAttribute<DetailViewItemAttribute>().IsEnabled == false))
            {
                string ObjVal = p.GetCustomAttribute<DatabaseFieldAttribute>().DefaultValue;
                return ObjVal.ToString();
            }
            else if (p.GetCustomAttribute<DatabaseFieldAttribute>().IsProperCase == true)
            {
                return "dbo.ProperCase('" + getValue(p) + "')";
            }
            else
            {
                return "'" + getValue(p) + "'";
            }
        }
    }
}