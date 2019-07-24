using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Item_Master_Core.Models.ItemViewModels;
using Item_Master_Core.Models.AccountViewModels;
using TOLC.ERP.Application;
using IBM.Data.DB2.iSeries;
using System.Globalization;

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
        private IEnumerable<Models.Item> GetItems(ItemSearch newsearch)
        {
            iDB2DataReader readerITM = null;
            Item item = new Item();
            List<Models.Item> itemlist = new List<Models.Item>();
            
            item.List(HttpContext.Session["SecurityKey"].ToString(), newsearch, ref readerITM);
            if (readerITM != null)
            {
                while (readerITM.Read())
                {
                    var newitem = new Models.Item();
                    string formatYMD;
                    newitem.ItemID = readerITM["ITMITM"].ToString();
                    newitem.Brand = readerITM["ITMPG3"].ToString();
                    newitem.Size = readerITM["ITMPG4"].ToString();
                    newitem.ItemDescEng = readerITM["ITMDSE"].ToString();
                    
                    if (readerITM["ITMDT1"].ToString().Length == 5)
                    {
                        formatYMD = "0" + readerITM["ITMDT1"].ToString();
                    }
                    else
                    {
                        formatYMD = readerITM["ITMDT1"].ToString();
                    }
                    newitem.Date = DateTime.ParseExact(formatYMD, "yyMMdd", CultureInfo.InvariantCulture);
                    itemlist.Add(newitem);
                }

            }
            return itemlist;
        }
        private Models.Item GetItemsbyID(string ItemID)
        {
            iDB2DataReader readerITM = null;
            Item item = new Item();
            Models.Item newitem = new Models.Item();
            item.ListbyItemNumber(HttpContext.Session["SecurityKey"].ToString(), ItemID, ref readerITM);
            if (readerITM != null)
            {
                while (readerITM.Read())
                {
                    string id = readerITM["ITMITM"].ToString();
                    newitem.ItemID = id;
                }
            }
            return newitem;
        }
        [HttpGet]
        public ActionResult Search()
        {
            if (HttpContext.Session == null || HttpContext.Session["SecurityKey"] == null)
            {
                RedirectToAction("Login", "Account", new { area = "" }); 
            }

            SearchViewModel vm = new SearchViewModel();
            ViewBag.Brands = GetBrands();
            ViewBag.Vendors = GetVendors();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Search(SearchViewModel searchVM)
        {
            ViewBag.Brands = GetBrands();
            ViewBag.Vendors = GetVendors();
            if (searchVM.ItemID != null)
            {
                Models.Item inquiryitem = GetItemsbyID(searchVM.ItemID);
                if (inquiryitem.ItemID != null)
                {
                    return RedirectToAction("Inquiry", "Item", new { itemID = inquiryitem.ItemID });
                }
                return View(searchVM);
            }
            else
            {
                ViewBag.SearchResultslist = GetItems(parseQuery(searchVM));
                return View(searchVM);
            }
            
        }

        private ItemSearch parseQuery(SearchViewModel vm)
        {
            ItemSearch searchquery = new ItemSearch();
            List<string> keywords = new List<string>(vm.SearchString.Split(' '));
            List<string> descKeywords = new List<string>();
            string UPC = "----";
            foreach(string str in keywords)
            {
                if (str.Length>UPC.Length && Int32.TryParse(str, out int num)){
                    UPC = str;
                }
                else
                {
                    descKeywords.Add(str);
                }
            }
            if(UPC == "----") { UPC = ""; }
            searchquery.Description = descKeywords;
            searchquery.UPC = UPC;
            return searchquery;
        }
    }
}