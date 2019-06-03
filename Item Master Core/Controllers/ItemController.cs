using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Item_Master_Core.Models;
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
            string date = String.Format("{0:D}", DateTime.Now);
            ViewBag.currentDate = date;
            

            return View();
        }

        public ActionResult Inquiry(int ItemID)
        {
            //Call GET method to obtain Item
            //Use URL itemID as parameter
            
            ViewBag.ItemID = ItemID;
            Item item = new Item()
            {
                ItemID = "57187",
                ItemDescEng = "KIKKOMAN ORGANIC SOY SAUCE",
                ItemDescFr = "KIKKOMAN - SAUCE SOYA BIOLOGIQUE",
                Imgsrc = "https://via.placeholder.com/150",
                Status = "Active",
                Date = DateTime.Parse("09/26/2005"),
                //Optional
                Vendor = "Kikkoman",
                BrandManager = "Keira Hall",
                UnitUPC = "00041390001901",
                CaseUPC = "10041390001908",
                Size = "1 Carton / 6 Case / 296ML",
                Brand = "Kikkoman",
                Purchaser = "Bianca Ceoca",
                Perishable = false

            };
            return View(item);
        }
        public ActionResult SalesReport(int ItemID)
        {
            //Call GET method to obtain Item
            //Use URL itemID as parameter
            ViewBag.ItemID = ItemID;
            return View();
        }
    }
}