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
        private IEnumerable<SelectListItem> GetBrands()
        {
            List<SelectListItem> brandlist = new List<SelectListItem>();
            Brand Brands = new Brand();
            iDB2DataReader readerPRN = null;
            Brands.List(HttpContext.Session["SecurityKey"].ToString(), ref readerPRN);

            if (readerPRN != null)
            {
                while (readerPRN.Read())
                {
                    var brand = new SelectListItem
                    {
                        Value = readerPRN["PRNNAM"].ToString(),
                        Text = readerPRN["PRNNAM"].ToString()
                    };
                    brandlist.Add(brand);
                }
                
            }
            return brandlist;
        }
        private IEnumerable<SelectListItem> GetVendors()
        {
            List<SelectListItem> vendorlist = new List<SelectListItem>();
            Supplier Vendors = new Supplier();
            iDB2DataReader readerVEN = null;
            Vendors.List(HttpContext.Session["SecurityKey"].ToString(), ref readerVEN);

            if (readerVEN != null)
            {
                while (readerVEN.Read())
                {
                    var vendor = new SelectListItem
                    {
                        Value = readerVEN["VENNAM"].ToString(),
                        Text = readerVEN["VENNAM"].ToString()
                    };
                    vendorlist.Add(vendor);
                }
                
            }
            return vendorlist;
        }
        [HttpGet]
        public ActionResult Search()
        {

            if (HttpContext.Session == null || HttpContext.Session["SecurityKey"] == null)
            {
                RedirectToAction("Login", "Account", new { area = "" }); ;
            }

            SearchViewModel vm = new SearchViewModel();
            vm.Brands = GetBrands();
            vm.Vendors = GetVendors();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Search(SearchViewModel searchViewModel)
        {
            return View();
        }


    }
}