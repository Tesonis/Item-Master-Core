using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Item_Master_Core.Models.ItemPartialModels;

namespace Item_Master_Core.Models
{
    public class Item
    {
        [Key]
        public string ItemID { get; set; }
        [Required]
        public string Imgsrc { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string ItemDescEng { get; set; }
        public string ItemDescEngShort { get; set; }
        [Required]
        public string ItemDescFr { get; set; }
        public string ItemDescFrShort { get; set; }
        public string Vendor { get; set; }
        public string BrandManager { get; set; }
        public string UnitUPC { get; set; }
        public string Size { get; set; }
        //Tentative
        public string Brand { get; set; }
        //Tentative
        public string Purchaser { get; set; }
        public string CaseUPC { get; set; }
        public bool Perishable { get; set; }

        //Seperated all sections into their own view model to reduce clutter
        public ProductDetailsModel ProductDetails { get; set; }
        public SupplyDetailsModel SupplyDetails { get; set; }
        public WarehouseStockModel WarehouseStockDetails { get; set; }
        public DimensionsModel Dimentions { get; set; }
        public SalesDetailsModel SalesDetails { get; set; }
        public PricingDetailsModel PricingDetails { get; set; }
        public PODetailsModel PODetails { get; set; }
    }
}