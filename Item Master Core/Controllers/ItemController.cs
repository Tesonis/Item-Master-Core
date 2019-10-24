using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBM.Data.DB2.iSeries;
using Item_Master_Core.Models;
using Item_Master_Core.Models.ItemViewModels;
using TOLC.ERP.Application;

namespace Item_Master_Core.Controllers
{
    public class ItemController : Controller
    {

        // GET: Item
        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Create()
        {
            if (HttpContext.Session == null || HttpContext.Session["SecurityKey"] == null)
            {
                RedirectToAction("Login", "Account", new { area = "" }); ;
            }
            string date = String.Format("{0:D}", DateTime.Now);
            ViewBag.currentDate = date;
            

            return View();
        }

        public ActionResult Inquiry(int ItemID)
        {
            //Call GET method to obtain Item
            //Use URL itemID as parameter
            if (HttpContext.Session == null || HttpContext.Session["SecurityKey"] == null)
            {
                RedirectToAction("Login", "Account", new { area = "" }); ;
            }
            Models.Item item = GetItemsbyID(ItemID.ToString());
            
            return View(item);
        }
        public ActionResult SalesReport(int ItemID)
        {
            if (HttpContext.Session == null || HttpContext.Session["SecurityKey"] == null)
            {
                RedirectToAction("Login", "Account", new { area = "" }); ;
            }
            //Call GET method to obtain Item
            //Use URL itemID as parameter
            ViewBag.ItemID = ItemID;
            return View();
        }
        private Models.Item GetItemsbyID(string ItemID)
        {
            iDB2DataReader readerITM = null;
            TOLC.ERP.Application.Item item = new TOLC.ERP.Application.Item();
            Models.Item newitem = new Models.Item();
            item.ListbyItemNumber(HttpContext.Session["SecurityKey"].ToString(), ItemID, ref readerITM);
            if (readerITM != null)
            {
                newitem = MapItem(readerITM);
            }
            return newitem;
        }
        public Models.Item MapItem(iDB2DataReader readerITM)
        {
            Models.Item item = new Models.Item();
            while (readerITM.Read())
            {
                item.ItemID = readerITM["ITMITM"].ToString();
                if(readerITM["ITMADL"].ToString() == "1")
                    { item.Status = "Active"; }
                else if(readerITM["ITMADL"].ToString() == "0")
                    { item.Status = "Inactive"; }
                if (readerITM["ITMDT1"].ToString().Length == 5)
                    {item.Date = DateTime.ParseExact("0" + readerITM["ITMDT1"].ToString(), "yyMMdd", CultureInfo.InvariantCulture);}
                else
                 {item.Date = DateTime.ParseExact(readerITM["ITMDT1"].ToString(), "yyMMdd", CultureInfo.InvariantCulture);}
                item.ItemDescEng = readerITM["ITMEED"].ToString();
                item.ItemDescFr = readerITM["ITMEFD"].ToString();
                item.Vendor = readerITM["ITMVEN"].ToString();
                item.BrandManager = readerITM["ITMRMC"].ToString();
                item.UnitUPC = readerITM["ITMUUP"].ToString();
                item.Size = readerITM["ITME#B"].ToString() + " / " + readerITM["ITMB#U"].ToString() + " / " + readerITM["ITMDSS"].ToString();
                item.Brand = readerITM["ITMPG3"].ToString();
                item.Purchaser = readerITM["ITMRMC"].ToString();
                item.CaseUPC = readerITM["ITMCUP"].ToString();
                item.Perishable = readerITM["ITMSEA"].ToString();
            }
            return item;
        }
    }
}