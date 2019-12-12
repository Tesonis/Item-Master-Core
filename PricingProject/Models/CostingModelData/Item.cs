using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PricingProject.Models.CostingModelData
{
    public class Item
    {
        public string description { get; set; }
        public int size { get; set; }
        public string sizeunit { get; set; }
        public int unitpercase { get; set; }
        public double purchasepricecase { get; set; }
        public double wholesaleprice { get; set; }
        public double suggestedprice { get; set; }

    }
}