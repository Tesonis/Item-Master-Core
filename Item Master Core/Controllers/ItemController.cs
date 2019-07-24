using System;
using System.Collections.Generic;
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

                string id = readerITM["ITMITM"].ToString();
                item.ItemID = id;
            }
            return item;
        }
    }
}