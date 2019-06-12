using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Item_Master_Core.Models.ItemViewModels;
using Item_Master_Core.Models.AccountViewModels;
using TOLC.ERP.Application;
using IBM.Data.DB2.iSeries;

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
            if (HttpContext.Session == null || HttpContext.Session["SecurityKey"] == null)
            {
                RedirectToAction("Login", "Account", new { area = "" }); ;
            }
            SearchViewModel vm = new SearchViewModel();
            List<string> brandlist = new List<string>();
            Brand Brands = new Brand();
            iDB2DataReader reader = null;
            Brands.List(HttpContext.Session["SecurityKey"].ToString(), ref reader);

            if (reader == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                string test;
                while (reader.Read()) {
                    test = reader["PRNNAM"].ToString();
                    brandlist.Add(test);
                }
                vm.Brands = brandlist;
            }
            return View(vm);
        }
        [HttpPost]
        public ActionResult Search(SearchViewModel searchViewModel)
        {
            return View();
        }


    }
}