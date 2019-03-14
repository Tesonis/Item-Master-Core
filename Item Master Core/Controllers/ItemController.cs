using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Item_Master_Core.Models;

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

        public ActionResult Inquiry()
        {
            //Call GET method to obtain Item
            //Use URL itemID as parameter


            Item item = new Item()
            {
                ItemID = "58187",
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
    }
}