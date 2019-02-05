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
            return View();
        }

        public ActionResult Inquiry()
        {
            return View();
        }
    }
}