using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeraFood.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public string ReviewPost { get; set; }
        public string ReviewUserName { get; set; }
        public string ReviewUserEmail { get; set; }
    }
}