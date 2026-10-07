using WCORE.Utility;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace WCORE.Controllers
{
    // o--------------------------------------------------------------------------------------------------o
    // |                   Source Code Documentation
    // o--------------------------------------------------------------------------------------------------o
    // | 
    // o--------------------------------------------------------------------------------------------------o

    public class BaseController : Controller
    {
        protected Type GetModelType(String mName) { return Common.GetModelType(mName); }


        protected PropertyInfo[] GetTypePropertiesList(String mName)
        {
            return GetTypePropertiesList(GetModelType(mName));
        }

        protected PropertyInfo[] GetTypePropertiesList(Type ModelType)
        {
            return ModelType.GetProperties().Where(pr => pr.IsDefined(typeof(DatabaseFieldAttribute), true)).ToArray()
                    .OrderBy(p => (p.GetCustomAttribute<SeqNoAttribute>() == null ? 0 : p.GetCustomAttribute<SeqNoAttribute>().Index)).ToArray();
        }

        protected PropertyInfo[] GetTypeProperties(String mName)
        {
            return GetTypeProperties(GetModelType(mName));
        }

        protected PropertyInfo[] GetTypeProperties(Type ModelType)
        {
            return ModelType.GetProperties().Where(pr => pr.IsDefined(typeof(DatabaseFieldAttribute), true)).Where(p => p.GetCustomAttribute<DatabaseFieldAttribute>().NotInTable == false).ToArray()
            .OrderBy(p => (p.GetCustomAttribute<SeqNoAttribute>() == null ? 0 : p.GetCustomAttribute<SeqNoAttribute>().Index)).ToArray();
        }

        protected BaseObject ConvertJSONToBaseOBject( string mName, dynamic dynamicObject ) {
            Type ModelType = GetModelType( mName );
            PropertyInfo[] pInfos;
            if ((ModelType.GetCustomAttribute<MenuDescriptionAttribute>() != null ? ModelType.GetCustomAttribute<MenuDescriptionAttribute>().WOOthers : false)) { pInfos = GetTypeProperties(Common.GetModelType(mName)).Where(p => p.Name != "CreatedBy" && p.Name != "CreatedDate" && p.Name != "ModifiedBy" && p.Name != "ModifiedDate" && p.Name != "IsActive").ToArray(); }
            else { pInfos = GetTypeProperties(Common.GetModelType(mName)); }

            BaseObject newObject = (BaseObject) Activator.CreateInstance( ModelType );
            foreach ( PropertyInfo pinfo in pInfos ) {
                string DbFieldAttrRefDesc = null;
                string DbModelTable = null;
                Type DbModel = null;
                object objectValue = null;
                var DbFieldAttr = pinfo.GetCustomAttribute<DatabaseFieldAttribute>();
                string FieldName = DbFieldAttr.Name != null && DbFieldAttr.RefModel == null ? DbFieldAttr.Name : pinfo.Name;

                string DbFieldAttrRefModel = pinfo.GetCustomAttribute<DatabaseFieldAttribute>().RefModel != null && pinfo.GetCustomAttribute<DatabaseFieldAttribute>().IsTable == true  ? pinfo.GetCustomAttribute<DatabaseFieldAttribute>().RefModel.Name.ToString() : null;
                if (dynamicObject[FieldName] == null && DbFieldAttrRefModel != null)
                {
                    DbFieldAttrRefDesc = pinfo.GetCustomAttribute<DatabaseFieldAttribute>().RefField;
                    DbModel = GetModelType(DbFieldAttrRefModel);
                    DbModelTable = DbModel.GetCustomAttribute<DatabaseTableAttribute>().Name;
                    int objIDKey = Common.GetObjID(DbModelTable, FieldName, DbFieldAttrRefDesc + "='" + dynamicObject[pinfo.GetCustomAttribute<DisplayAttribute>().Name] + "'");
                    objectValue = dynamicObject[FieldName] != null && DbFieldAttrRefModel == null ? dynamicObject[FieldName].Value : objIDKey;
                }
                else if (dynamicObject[FieldName] != null)
                {
                    if (FieldName != "Password") { objectValue = dynamicObject[FieldName].Value; }
                }
                switch ( pinfo.PropertyType.Name ) {
                    case "Int32":
                        pinfo.SetValue(newObject, objectValue != null ? Convert.ToInt32(objectValue) : 0); 
                        break;
                    case "DateTime":
                        pinfo.SetValue(newObject, objectValue != null ? DateTime.Parse(objectValue.ToString()) : (DateTime?)null);
                        break;
                    case "Decimal":
                        pinfo.SetValue( newObject, objectValue != null ? Convert.ToDecimal( objectValue ) : 0 );
                        break;
                    case "String":
                        pinfo.SetValue(newObject, objectValue != null && objectValue.ToString() != "" && objectValue.ToString().ToLower() != "null" ? objectValue.ToString().Replace("'", "`") : null);
                        break;
                    case "Boolean":
                        pinfo.SetValue(newObject, objectValue != null  ? (Convert.ToInt32(objectValue) == 1 ? true : false) : false);
                        break;
                    default:
                        pinfo.SetValue( newObject, objectValue );
                        break;
                }
            }
            return newObject;
        }

        protected string[] getControlProperties(PropertyInfo pInfo, string pmName)
        {
            var dbItemAttr = pInfo.GetCustomAttribute<DatabaseFieldAttribute>();
            DetailViewItemAttribute displayAttr = pInfo.GetCustomAttribute<DetailViewItemAttribute>();
            string propertyType = pInfo.PropertyType.Name;
            string caption = displayAttr != null ? (displayAttr.Name != null ? displayAttr.Name : pInfo.Name) : pInfo.Name;
            if (pInfo.GetCustomAttribute<DisplayAttribute>() != null)
            {
                caption = pInfo.GetCustomAttribute<DisplayAttribute>().Name;
            }
            string controlType = null, controlModel = null, ColumnValue = null, DisplayColumnValue = null, LookupURL = null, ColumnNo = null, TbName = null, ControlID = null, strFormat = null, IsJson = null;
            if (pInfo.PropertyType.IsEnum)
            {
                controlType = "dropdownlist";
            }
            else
            {
                switch (propertyType)
                {
                    case "String":
                    case "Double":
                    case "Decimal":
                        if (displayAttr != null)
                        {
                            if (displayAttr.IsTextArea) { controlType = "textarea"; }
                            else if (displayAttr.IsTextEditor) { controlType = "texteditor"; }
                            else if (displayAttr.IsDateRange) { controlType = "daterange"; }
                        }
                        break;
                    case "Int32":
                        propertyType = "Int";
                        if (pInfo.IsDefined(typeof(DataLookUpAttribute), true))
                        {
                            DataLookUpAttribute lookupAttr = pInfo.GetCustomAttributes<DataLookUpAttribute>().Single();
                            if (lookupAttr != null)
                            {
                                IsJson = "IsJson:" + lookupAttr.IsJson.ToString().ToLower();
                                if (lookupAttr.WithAdd == true) { controlType = "comboboxPlus"; }
                                else { controlType = "combobox"; }

                                //controlModel = dbItemAttr.RefModel != null ? dbItemAttr.RefModel.Name : null;
                                ColumnValue = "ColumnValue:'" + lookupAttr.ColumnValue + "'";
                                DisplayColumnValue = "DisplayColumnValue:'" + lookupAttr.DisplayColumnValue + "'";
                            }
                        }
                        break;
                    case "DateTime":
                        controlType = "datepicker";
                        break;
                    case "Boolean":
                        controlType = "checkbox";
                        break;
                }
            }
            string Name = dbItemAttr.RefModel == null ? dbItemAttr.Name : pInfo.Name;
            string IsEnabled = "IsEnabled:true";
            string IsRequired = dbItemAttr.IsRequired ? "IsRequired:true" : null;
            string IsUnique = dbItemAttr.IsUnique ? "IsUnique:true" : null;
            if (displayAttr != null)
            {
                IsEnabled = displayAttr.IsEnabled ? null : "IsEnabled:" + displayAttr.IsEnabled.ToString().ToLower();
            }
            Name = "Name:'" + (Name != null ? Name : pInfo.Name) + "'";
            propertyType = "Type:'" + propertyType + "'";
            caption = pInfo.Name != caption ? "Caption:'" + caption + "'" : null;
            controlModel = dbItemAttr.RefModel == null ? ("ControlModel:'" + pmName + "'") : ("ControlModel:'" + dbItemAttr.RefModel.Name + "'");
            controlType = controlType != null ? "ControlType:'" + controlType + "'" : null;
            ColumnNo = "ColumnNo:" + (displayAttr.Column != 0 ? displayAttr.Column : 0);
            TbName = displayAttr.TabName != null ? ("TbName:'" + displayAttr.TabName + "'") : null;
            ControlID = pInfo.Name != null ? ("ControlID:'" + pInfo.Name + "'") : null;
            strFormat = displayAttr.strFormat != null ? ("strFormat:'" + displayAttr.strFormat + "'") : null;
            string refColumn = null;
            if (dbItemAttr.RefModel != null)
            {
                refColumn = "RefColumn:'" + (dbItemAttr.RefAlias == null ? "ref_" + pInfo.Name : dbItemAttr.RefAlias) + "'";
            }
            string[] strArrays = { Name, caption, propertyType, controlType, IsEnabled, refColumn, controlModel, ColumnValue, DisplayColumnValue, LookupURL, IsRequired, ColumnNo, TbName, ControlID, IsUnique, strFormat, IsJson };
            return strArrays;
        }
    }
}
