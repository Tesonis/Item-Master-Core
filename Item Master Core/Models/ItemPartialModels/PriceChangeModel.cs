using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Item_Master_Core.Models.ItemPartialModels
{
    public class PriceChangeModel
    {
        [Key]
        public string ChangedBy { get; set; }
        [Key]
        public DateTime ChangedOn { get; set; }
        [Required]
        public float NewZ1 { get; set; }
        [Required]
        public float NewZ3 { get; set; }
        [Required]
        public DateTime DateEffective { get; set; }
        public float Z1Prog { get; set; }
        public float Z3Prog { get; set; }

    }
}