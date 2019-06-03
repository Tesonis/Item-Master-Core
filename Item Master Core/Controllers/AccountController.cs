using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Item_Master_Core.Models;
using Item_Master_Core.Models.AccountViewModels;
using TOLC.ERP.Application;

namespace Item_Master_Core.Controllers
{
    [Route("")]
    public class AccountController : Controller
    {
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            //DB2ConnectionStringBuilder cnstr = new DB2ConnectionStringBuilder();
            //cnstr.UserID = "TXHUANG";
            //cnstr.Password = "485657";
            //cnstr.Server = "TOLC400:446";
            //cnstr.Database = "CANADA";
            //iDB2ConnectionStringBuilder cnstr = new iDB2ConnectionStringBuilder();
            //cnstr.UserID = "TXHUANG";
            //cnstr.DataSource = "TOLC400";
            //cnstr.Password = "485657";
            //iDB2Connection conn = new iDB2Connection();
            //conn.ConnectionString = cnstr.ConnectionString;
            //conn.Open();
            //DB2Connection conn = new DB2Connection();
            //conn.ConnectionString = cnstr.ConnectionString;
            //conn.Open();
            //Security security = new Security();
            //Session session = security.Logon("txhuang", "485657");
            //Session session = security.Logon(model.Username, model.Password);

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            Session session = new Security().Logon("txhuang", "485657");
            if (session.securityIdentifier == null)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            else
            {
                User user = new User();
                user.Username = session.Username;
                user.FullName = session.FullName;
                user.Email = session.EmailAddress;
                HttpCookie userCookie = new HttpCookie("SecToken");
                userCookie.Value = session.securityIdentifier;
                HttpContext.Response.Cookies.Add(userCookie);
                return RedirectToAction("Search", "Home", new { area = "" }); ;
            }


            
        }
    }
}