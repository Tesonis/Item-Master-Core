﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Item_Master_Core.Models.ItemViewModels;
using Item_Master_Core.Models.AccountViewModels;
using TOLC.ERP.Application;

namespace Item_Master_Core.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(SearchViewModel searchViewModel)
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            Security sec = new Security();
            Session session = sec.Logon("txhuang", "485657");
            //Session session = sec.Logon(model.Username, model.Password);
            if (session == null)
            {
                RedirectToAction("Login", "Account");
            }

            HttpCookie usercookie = new HttpCookie("userinfo");
            usercookie.Value = session.FullName;
            usercookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(usercookie);
            return View();
        }
    }
}