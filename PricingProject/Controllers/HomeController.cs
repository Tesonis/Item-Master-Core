using IBM.Data.DB2.iSeries;
using PricingProject.Models.ItemViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOLC.ERP.Application;

namespace PricingProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult PCEPNL()
        {
            SearchViewModel vm = new SearchViewModel();
            ViewBag.Brands = GetBrands();
            ViewBag.Vendors = GetVendors();
            return View(vm);
        }

        public ActionResult PCEDisplay()
        {
            return View();
        }
        public ActionResult PCEMain()
        {
            ViewBag.name = Request.Cookies["SecToken"]["FullName"];
            return View();
        }
        public ActionResult PCEAdd()
        {
            return View();
        }
        private IEnumerable<SelectListItem> GetBrands()
        {
            List<SelectListItem> brandlist = new List<SelectListItem>();
            Brand Brands = new Brand();
            iDB2DataReader readerPRN = null;
            //Brands.List(HttpContext.Session["SecurityKey"].ToString(), ref readerPRN);
            Brands.List(Request.Cookies["SecToken"]["SecurityKey"], ref readerPRN);

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
            Vendors.List(Request.Cookies["SecToken"]["SecurityKey"], ref readerVEN);

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
    }
}