using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
    }
}