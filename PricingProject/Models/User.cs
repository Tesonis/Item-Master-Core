using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PricingProject.Models
{
    public class User
    {
        public string fullname { get;}
        public string role { get;}
        public List<User> relatedusers { get; }
        public List<CostingModel> costingmodels { get; set; }
        public List<PriceChange> pricechanges { get; set; }
        public DateTime lastlogin { get; set; }

    }
}