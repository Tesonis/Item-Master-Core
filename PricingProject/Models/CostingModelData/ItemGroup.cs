using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PricingProject.Models.CostingModelData
{
    public class ItemGroup
    {
        public string groupname { get; set; }
        public int numofitems { get; set; }
        public List<Item> itemlist { get; set; }
    }
}