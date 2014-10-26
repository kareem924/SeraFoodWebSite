using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeraFood.Models
{
    public class Product
    {
    
        [Key]
        public int? ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string FullDescription { get; set; }
        public string ProductPrice { get; set; }
        public string ProductImage { get; set; }
    }
}