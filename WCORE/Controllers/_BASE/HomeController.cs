using Google.Authenticator;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WCORE.Models;
using WCORE.Utility;

namespace WCORE.Controllers
{
    // o------------------------------------------------------------------------------------------o
    // |                   Source Code Documentation
    // o------------------------------------------------------------------------------------------o
    // | Used to manipulate views, tasks and data to the Login,Reset Password,Forgot Password,
    // | Change Password and Dashboard
    // o------------------------------------------------------------------------------------------o
    public class HomeController : BaseController
    {
        Common cmn = new Common();
        DBHelper dbh = new DBHelper();

        // conversion of secret key to base 32 of google auth key 
        private static byte[] ConvertSecretToBytes(string secret, bool secretIsBase32) =>
          secretIsBase32 ? Base32Encoding.ToBytes(secret) : Encoding.UTF8.GetBytes(secret);


        // AES-256 encryption for google auth key 
        private static readonly string EncryptionKey = "!nf0rm@t!0nPr0f3ss!0n@l$S3cr3t**"; // 32 chars for AES-256

        public static string Encrypt(string plainText)
        {
            byte[] iv;
            byte[] encrypted;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aes.GenerateIV();
                iv = aes.IV;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(iv, 0, iv.Length);

                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }

                    encrypted = ms.ToArray();
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string cipherText)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);

                byte[] iv = new byte[16];
                Array.Copy(fullCipher, iv, iv.Length);

                aes.IV = iv;

                using (MemoryStream ms = new MemoryStream(fullCipher, 16, fullCipher.Length - 16))
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        // Start System Login
        public ActionResult Index() {
            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, max-age=0");
            Response.AddHeader("Pragma", "no-cache");
            return View("Index");
        }

        public string getLoginInfo(User user)
        {
            user = doLogin(user);
            if (user.Status == "Success")
            {
                Session["FullName"] = user.Description;
                Session["UserRoles"] = user.UserRoles;
                Session["UserRefNo"] = user.ID;
                Session["UserRolesRefno"] = user.UserPrivilegesRefNo;
                Session["IsOpenSurvey"] = user.IsOpenSurvey;
                Session["IsReset"] = user.IsReset;
                Session["CompanyRefNo"] = user.CompanyRefNo;
                Session["IsLogged"] = true;
            }
            var json = new JavaScriptSerializer().Serialize(user);
            return json;
        }

        public User doLogin(User user)
        {
            string[] strparam = { "@UserID", "@Password" };
            string[] strparamval = { user.Username, user.Password };
            try
            {
                using (DataTable dtUserInfo = dbh.ExecuteQuery("dbo.spSysDoLogin", CommandType.StoredProcedure, strparam, strparamval))
                {
                    //if (int.Parse(dtUserInfo.Rows[0][0].ToString()) > 0)
                    //{
                    //    user.Description = dtUserInfo.Rows[0]["Description"].ToString();
                    //    user.UserRoles = dtUserInfo.Rows[0]["UserRoles"].ToString();
                    //    user.ID = int.Parse(dtUserInfo.Rows[0]["ID"].ToString());
                    //    user.UserPrivilegesRefNo = int.Parse(dtUserInfo.Rows[0]["UserRolesRefno"].ToString());
                    //    user.IsOpenSurvey = bool.Parse(dtUserInfo.Rows[0]["IsOpenSurvey"].ToString());
                    //    user.CompanyRefNo = int.Parse(dtUserInfo.Rows[0]["CompanyRefNo"].ToString());
                    //    user.IsReset = bool.Parse(dtUserInfo.Rows[0]["IsReset"].ToString());
                    //    user.mguid = dtUserInfo.Rows[0]["mguid"].ToString();
                    //    cmn.DeleteSession(int.Parse(dtUserInfo.Rows[0]["ID"].ToString()));
                    //    cmn.InsertSession(int.Parse(dtUserInfo.Rows[0]["ID"].ToString()), int.Parse(dtUserInfo.Rows[0]["UserRolesRefno"].ToString()));
                    //    user.Status = "Success";
                    //    user.Message = "Success";
                    //}
                    //else { user.Message = dtUserInfo.Rows[0][1].ToString(); user.Status = "Failed"; }


                    if (int.Parse(dtUserInfo.Rows[0][0].ToString()) > 0 && dtUserInfo.Rows[0]["GoogleAuthKey"].ToString() == "ByPass")
                    {
                        user.Description = dtUserInfo.Rows[0]["Description"].ToString();
                        user.UserRoles = dtUserInfo.Rows[0]["UserRoles"].ToString();
                        user.ID = int.Parse(dtUserInfo.Rows[0]["ID"].ToString());
                        user.UserPrivilegesRefNo = int.Parse(dtUserInfo.Rows[0]["UserRolesRefno"].ToString());
                        user.IsOpenSurvey = bool.Parse(dtUserInfo.Rows[0]["IsOpenSurvey"].ToString());
                        user.CompanyRefNo = int.Parse(dtUserInfo.Rows[0]["CompanyRefNo"].ToString());
                        user.IsReset = bool.Parse(dtUserInfo.Rows[0]["IsReset"].ToString());
                        user.mguid = dtUserInfo.Rows[0]["mguid"].ToString();
                        cmn.DeleteSession(int.Parse(dtUserInfo.Rows[0]["ID"].ToString()));
                        cmn.InsertSession(int.Parse(dtUserInfo.Rows[0]["ID"].ToString()), int.Parse(dtUserInfo.Rows[0]["UserRolesRefno"].ToString()));
                        user.Status = "Success";
                        user.Message = "Success";

                        user.GoogleAuthKey = "ByPass";
                    }
                    else if (int.Parse(dtUserInfo.Rows[0][0].ToString()) > 0 && dtUserInfo.Rows[0]["GoogleAuthKey"] != DBNull.Value)
                    {
                        Session["UserID"] = int.Parse(dtUserInfo.Rows[0]["ID"].ToString());
                        user.Description = dtUserInfo.Rows[0]["Description"].ToString();
                        user.UserRoles = dtUserInfo.Rows[0]["UserRoles"].ToString();
                        user.ID = int.Parse(dtUserInfo.Rows[0]["ID"].ToString());
                        user.UserPrivilegesRefNo = int.Parse(dtUserInfo.Rows[0]["UserRolesRefno"].ToString());
                        user.IsOpenSurvey = bool.Parse(dtUserInfo.Rows[0]["IsOpenSurvey"].ToString());
                        user.CompanyRefNo = int.Parse(dtUserInfo.Rows[0]["CompanyRefNo"].ToString());
                        user.IsReset = bool.Parse(dtUserInfo.Rows[0]["IsReset"].ToString());
                        user.mguid = dtUserInfo.Rows[0]["mguid"].ToString();
                        cmn.DeleteSession(int.Parse(dtUserInfo.Rows[0]["ID"].ToString()));
                        cmn.InsertSession(int.Parse(dtUserInfo.Rows[0]["ID"].ToString()), int.Parse(dtUserInfo.Rows[0]["UserRolesRefno"].ToString()));
                        user.Status = "Success";
                        user.Message = "Success";
                        user.GoogleAuthKey = "Yes";

                        Session["UserGoogleAuthKey"] = 1;


                        // Goole Authentication Key
                        string googleAuthKey = WebConfigurationManager.AppSettings["GoogleAuthKey"];
                        string UserUniqueKey = (user.Username + googleAuthKey);
                        string encrypted_useruniquekey = Encrypt(UserUniqueKey);

                        TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();
                        var setupInfo = TwoFacAuth.GenerateSetupCode("ipiphil.com", user.Username, ConvertSecretToBytes(UserUniqueKey, false), 300);
                        Session["UserUniqueKey"] = UserUniqueKey;
                        Session["BarcodeImageUrl"] = setupInfo.QrCodeSetupImageUrl;
                        Session["SetupCode"] = setupInfo.ManualEntryKey;

                        string[] strparam2 = { "@UserID", "@GoogleAuthKey" };
                        string[] strparamval2 = { user.Username, encrypted_useruniquekey };

                        dbh.ExecuteNonQuery("UPDATE dbo.SYS_WebUser SET GoogleAuthKey = @GoogleAuthKey WHERE Username = @UserID", CommandType.Text, strparam2, strparamval2);

                    }
                    else if (int.Parse(dtUserInfo.Rows[0][0].ToString()) > 0 && dtUserInfo.Rows[0].IsNull("GoogleAuthKey"))
                    {
                        Session["UserID"] = int.Parse(dtUserInfo.Rows[0]["ID"].ToString());
                        user.Description = dtUserInfo.Rows[0]["Description"].ToString();
                        user.UserRoles = dtUserInfo.Rows[0]["UserRoles"].ToString();
                        user.ID = int.Parse(dtUserInfo.Rows[0]["ID"].ToString());
                        user.UserPrivilegesRefNo = int.Parse(dtUserInfo.Rows[0]["UserRolesRefno"].ToString());
                        user.IsOpenSurvey = bool.Parse(dtUserInfo.Rows[0]["IsOpenSurvey"].ToString());
                        user.CompanyRefNo = int.Parse(dtUserInfo.Rows[0]["CompanyRefNo"].ToString());
                        user.IsReset = bool.Parse(dtUserInfo.Rows[0]["IsReset"].ToString());
                        user.mguid = dtUserInfo.Rows[0]["mguid"].ToString();
                        cmn.DeleteSession(int.Parse(dtUserInfo.Rows[0]["ID"].ToString()));
                        cmn.InsertSession(int.Parse(dtUserInfo.Rows[0]["ID"].ToString()), int.Parse(dtUserInfo.Rows[0]["UserRolesRefno"].ToString()));
                        user.Status = "Success";
                        user.GoogleAuthKey = "No";
                        //ViewBag.UserGoogleAuthKey = null;
                        Session["UserGoogleAuthKey"] = 0;

                        // Goole Authentication Key
                        string googleAuthKey = WebConfigurationManager.AppSettings["GoogleAuthKey"];
                        string UserUniqueKey = (user.Username + googleAuthKey);
                        string encrypted_useruniquekey = Encrypt(UserUniqueKey);

                        TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();
                        var setupInfo = TwoFacAuth.GenerateSetupCode("pitsph.com", user.Username, ConvertSecretToBytes(UserUniqueKey, false), 300);
                        Session["UserUniqueKey"] = UserUniqueKey;
                        Session["BarcodeImageUrl"] = setupInfo.QrCodeSetupImageUrl;
                        Session["SetupCode"] = setupInfo.ManualEntryKey;

                        //ViewBag.BarcodeImageUrl = setupInfo.QrCodeSetupImageUrl;
                        //ViewBag.SetupCode = setupInfo.ManualEntryKey;

                        string[] strparam2 = { "@UserID", "@GoogleAuthKey" };
                        string[] strparamval2 = { user.Username, encrypted_useruniquekey };

                        dbh.ExecuteNonQuery("UPDATE dbo.SYS_WebUser SET GoogleAuthKey = @GoogleAuthKey WHERE Username = @UserID", CommandType.Text, strparam2, strparamval2);
                    }

                    else { user.Message = dtUserInfo.Rows[0][1].ToString(); user.Status = "Failed"; }
                }
            }
            catch { user.Message = "Please contact system administrator."; user.Status = "Failed"; }
            return user;
        }
        // End System Login

        // Password Management
        public ActionResult ResetPassword() { return View(); }
        public ActionResult ForgotPassword() { return View(); }

        public ActionResult GoogleAuthKey() { return View(); }

        public ActionResult Cronus()
        {
            return View("~/Views/Home/Cronus.cshtml");
        }

        // sending reset password link to user
        public string doResetPassword(User user)
        {
            string[] strparam = { "@Email" };
            string[] strparamval = { user.Email };
            SqlDataReader dr = dbh.ExecuteReader("dbo.spSysDoRetrievePassword", CommandType.StoredProcedure, strparam, strparamval);
            if (dr.Read())
            {
                if (int.Parse(dr[0].ToString()) == 0) { user.Status = "Failed"; user.Message = dr[1].ToString(); }
                else { user.Status = "Success"; }
            }
            else { user.Status = "Failed"; user.Message = "Please contact system administrator."; }
            dr.Close();
            return new JavaScriptSerializer().Serialize(user);
        }

        // validate gooogle auth key 
        public string AuthenticateGoogleAuthKey(User user)
        {

            string[] strparam1 = { "@UserID" };
            string[] strparamval1 = { Session["UserID"].ToString() };

            using (DataTable dtUserInfo = dbh.ExecuteQuery("SELECT GoogleAuthKey FROM SYS_WebUser WHERE ID = @UserID", CommandType.Text, strparam1, strparamval1))
            {
                //var token = Request["CodeDigit"];
                var token = user.GoogleAuthKey;
                TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();
                string UserUniqueKey = Decrypt(dtUserInfo.Rows[0]["GoogleAuthKey"].ToString());
                bool isValid = TwoFacAuth.ValidateTwoFactorPIN(UserUniqueKey, token, false);


                if (isValid)
                {
                    user.Status = "Success";
                    user.Message = "dito dumaan";
                }
                else
                {
                    user.Status = "Failed";
                    user.Message = "Not Success";
                }

            }
            //if (dr.Read())
            //{
            //    if (int.Parse(dr[0].ToString()) == 0) { user.Status = "Failed"; user.Message = dr[1].ToString(); }
            //    else { user.Status = "Success"; }
            //}
            //else { user.Status = "Failed"; user.Message = "Please contact system administrator."; }
            //dr.Close();

            return new JavaScriptSerializer().Serialize(user);
        }


        // validate if the link used by the user is not expired
        public string checkResetExpiry(string mguid, User user)
        {
            SystemMessage sm = new SystemMessage();
            string[] strparam = { "@mguid" };
            string[] strparamval = { mguid };
            SqlDataReader dr = dbh.ExecuteReader("dbo.spSysCheckResetPassword", CommandType.StoredProcedure, strparam, strparamval);
            if (dr.Read()) {
                if (int.Parse(dr[0].ToString()) == 0) { user.Status = "Failed"; user.Message = dr[1].ToString(); }
                else { user.Status = "Success"; user.rpExpiry = int.Parse(dr[1].ToString()); }
            }
            else { user.Status = "Failed"; user.Message = "Please contact system administrator."; }
            dr.Close();
            return new JavaScriptSerializer().Serialize(user);
        }
        // perform the change password
        public string doChangePassword(string mguid, User user)
        {
            string[] strparam = { "@mguid", "@Password" };
            string[] strparamval = { mguid, user.Password };
            SqlDataReader dr = dbh.ExecuteReader("dbo.spSysDoChangePassword", CommandType.StoredProcedure, strparam, strparamval);
            if (dr.Read())
            {
                if (int.Parse(dr[0].ToString()) == 0) { user.Status = "Failed"; user.Message = dr[1].ToString(); }
                else { user.Status = "Success"; user.Message = dr[1].ToString(); }
            }
            else { user.Status = "Failed"; user.Message = "Please contact system administrator."; }
            dr.Close();
            return new JavaScriptSerializer().Serialize(user);
        }
        // End Password Management

        public ActionResult Main()
        {
            if (cmn.SessionUserRefNo() > 0)
            {
                ViewBag.IsOpenSurvey = Session["IsOpenSurvey"];
                ViewBag.IsReset = Session["IsReset"];
                string[] strparam = { "@UserRefNo", "@UserRoles" };
                string[] strparamval = { cmn.SessionUserRefNo().ToString(), cmn.SessionUserRolesRefNo().ToString() };
                var SQLmenu = "SELECT * FROM dbo.fSysMenuUserRoles(@UserRefNo,@UserRoles)";
                using (DataTable dtmenu = dbh.ExecuteQuery(SQLmenu, CommandType.Text, strparam, strparamval))
                {
                    ViewBag.NavigationList = cmn.CreateTreeView(dtmenu).ToString();
                }

                return View();
            }
            else { return View(@"~\Views\Home\Index.cshtml"); }
        }

        public bool doSubmitSurvey(int rating, string comment, int stype)
        {
            string[] strparam = { "@UserRefNo", "@Ratings", "@Remarks", "@SurveyType" };
            string[] strparamval = { cmn.SessionUserRefNo().ToString(), rating.ToString(), comment, stype.ToString() };
            int isSubmit = dbh.ExecuteNonQuery("dbo.spSysSurveyHRIS", CommandType.StoredProcedure, strparam, strparamval);
            Session["IsOpenSurvey"] = isSubmit > 0 ? true : false;
            return isSubmit > 0 ? true : false;
        }

        ///  Start Dashboard
        public ActionResult PlainDashboard() { return View(); }
        public ActionResult Dashboard()
        {
            string[] strparam = { "@UserRefNo" };
            string[] strparamval = { cmn.SessionUserRefNo().ToString() };
            using (SqlDataReader dr = dbh.ExecuteReader("dbo.spSysDashboard", CommandType.StoredProcedure, strparam, strparamval))
            {
                while (dr.Read()) { ViewBag.LineChartData = dr[0].ToString(); } // used to display information in dashboard chart per employee status per employee group
                dr.NextResult();
                while (dr.Read()) { ViewBag.PieData = dr[0].ToString(); } // used to display information in dashboard line chart per gender per employee group
                dr.NextResult();
                while (dr.Read()) { ViewBag.ChartData = dr[0].ToString(); } //  used to display information in dashboard pie chart per employment status per employee group
            }
            ViewBag.mCode = "Dashboard";
            return View();
        }

        // Used to display list of expiring contract with active status 
        // based on the selected no of days remaining
        [HttpPost]
        public virtual JsonResult getListEOC(int days)
        {
            string[] strparam = { "@NoofDays", "@UserRefNo" };
            string[] strparamval = { days.ToString(), cmn.SessionUserRefNo().ToString() };
            var JsonData = dbh.GetJSONData("SELECT * FROM dbo.fGetExpiringContract(@NoofDays,@UserRefNo)", CommandType.Text, true, strparam, strparamval);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }
        // Used to display list of due for kpi 
        // based on the selected no of months
        [HttpPost]
        public virtual JsonResult getDueForKPI(int month)
        {
            string[] strparam = { "@Month", "@UserRefNo" };
            string[] strparamval = { month.ToString(), cmn.SessionUserRefNo().ToString() };
            var JsonData = dbh.GetJSONData("SELECT * FROM dbo.fGetDueForKPI(@Month,@UserRefNo)", CommandType.Text, true, strparam, strparamval);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }
        // Used to display list of expiring floating status
        // based on the selected no of days remaining
        [HttpPost]
        public virtual JsonResult getListFEOC(int days)
        {
            string[] strparam = { "@NoofDays", "@UserRefNo" };
            string[] strparamval = { days.ToString(), cmn.SessionUserRefNo().ToString() };
            var JsonData = dbh.GetJSONData("SELECT * FROM dbo.fGetExpiringFloatingContract(@NoofDays,@UserRefNo)", CommandType.Text, true, strparam, strparamval);
            return Json(JsonData ?? "[]", JsonRequestBehavior.AllowGet);
        }
        // End dashboard

        public ActionResult ExpiringContract()
        {
            ViewBag.Description = "Expiring Contract";
            ViewBag.cuserPriv = Convert.ToString(cmn.SessionUserRolesRefNo());
            return View("~/Views/RV/ExpiringContract.cshtml");
        }

    }
}