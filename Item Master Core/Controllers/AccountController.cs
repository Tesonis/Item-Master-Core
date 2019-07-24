using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IBM.Data.DB2.iSeries;
using Item_Master_Core.Models;
using Item_Master_Core.Models.AccountViewModels;
using TOLC.ERP.Application;

namespace Item_Master_Core.Controllers
{
    [Route("")]
    public class AccountController : Controller
    {
        public object Formathentication { get; private set; }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {

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
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                ReturnValue rv = new ReturnValue();
                Session session = null;
                rv = new Security().Logon(model.Username, model.Password, ref session);
                if (session.securityIdentifier == null)
                {
                    return RedirectToAction("Login", "Account", new { area = "" });
                }
                else
                {
                    //User user = new User();
                    //user.Username = session.Username;
                    //user.FullName = session.FullName;
                    //user.Email = session.EmailAddress;
                    //HttpCookie userCookie = new HttpCookie("SecToken");
                    //userCookie["FullName"] = session.FullName;
                    //userCookie["Email"] = session.EmailAddress;
                    //userCookie["Username"] = session.Username;
                    //userCookie["SecurityKey"] = session.securityIdentifier;
                    //HttpContext.Response.Cookies.Add(userCookie);
                    //FormsAuthentication.SetAuthCookie(userCookie["SecurityKey"], true);
                    Session["FullName"] = session.FullName;
                    Session["Email"] = session.EmailAddress;
                    Session["Username"] = session.Username;
                    Session["SecurityKey"] = session.securityIdentifier;
                    return RedirectToAction("Search", "Home", new { area = "" }); ;
                }
            }
            catch(InvalidCastException e)
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            
            


            
        }
    }
}