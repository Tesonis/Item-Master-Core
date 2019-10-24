using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PricingProject.Models.ItemViewModels
{
    public class SearchViewModel
    {
        public IEnumerable<SelectListItem> Brands;

        public IEnumerable<SelectListItem> Vendors;


    }
}