using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeraFood.Models
{
    public class Job
    {
        [Key]
        public int? JobId { get; set; }
        public string JobeName { get; set; }
        public string JobDescription { get; set; }
        public string JobQualifications { get; set; }
        public string JobResponsibilities { get; set; }
        public bool Available { get; set; }
        public string Category { get; set; }
    }
}