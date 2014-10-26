using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeraFood.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageName { get; set; }
    }
}