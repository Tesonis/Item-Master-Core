using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Item_Master_Core.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string FullName {get;set;}
        public string Email { get; set; }
    }
}