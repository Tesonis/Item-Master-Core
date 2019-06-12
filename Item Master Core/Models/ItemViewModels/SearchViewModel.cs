﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Item_Master_Core.Models.ItemViewModels
{
    public class SearchViewModel
    {
        public List<string> Brands;

        public string SearchString { get; set; }
        public string Status { get; set; }
        public string SalesRep { get; set; }
        public string Pillar { get; set; }
        public string BrandPrincipal { get; set; }

    }
}