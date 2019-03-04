using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Item_Master_Core.Models.ItemPartialModels
{
    public class SalesOrderModel
    {
        [Key]
        public string OrderNum { get; set; }
        [Required]
        public string InvoiceNum { get; set; }
        [Required]
        public string Shipto { get; set; }
        [Required]
        public string CustName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float CasePrice { get; set; }
        [Required]
        public float Revenue { get; set; }
        [Required]
        public float Profit { get; set; }
    }
}