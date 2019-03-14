using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Item_Master_Core.Models.ItemPartialModels
{
    public class ProductDetailsModel
    {
        public string NatProdManager { get; set; }
        public string RegProdManager { get; set; }
        public string ItemType { get; set; }
        public string MaterialType { get; set; }
        public string[] ProductGroups { get; set; }
        public string WeightCase { get; set; }
        public string BottleSize { get; set; }
        public float MAC { get; set; }
        public float LastMAC { get; set; }
        public bool SoldByWeight { get; set; }
        public bool Splitable { get; set; }
        public bool ChargeForSplit { get; set; }
        public bool AllowDiscount { get; set; }
        public string RabateCode { get; set; }
        public bool SlowMoving { get; set; }
        public bool Hold { get; set; }
        public bool PrintPriceList { get; set; }
        public int GST { get; set; }
        public int PSTHST { get; set; }
        public string CatalogCode { get; set; }
        public char CommissionCode { get; set; }
    }
}