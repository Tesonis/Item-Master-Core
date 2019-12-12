using System;

namespace PricingProject.Models
{
    public class CostingModel
    {
        public string modelname { get; set; }
        public string brand { get; set; }
        public string status { get; set; }
        public DateTime lastviewed { get; set; }
        public DateTime datecreated { get; set; }
        public string vendor { get; set; }
        public User manager { get; set; }
        public CostingModelData.CostingModelData data { get; set; }
    }
}