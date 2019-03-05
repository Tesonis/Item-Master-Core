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
            Item item = new Models.Item()
            {
                ItemID = "58187",
                ItemDescEng = "KIKKOMAN ORGANIC SOY SAUCE",
                ItemDescFr = "KIKKOMAN - SAUCE SOYA BIOLOGIQUE",
                Imgsrc = "https://via.placeholder.com/150",
                Status = "Active",
                Date = DateTime.Parse("09/26/2005")
            };
            return View(item);
        }
    }
}