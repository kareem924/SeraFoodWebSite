using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SeraFood.Models
{
    public class ApplicationUser : IdentityUser
    {
    }
    public class SeraFoodCtx : IdentityDbContext<ApplicationUser>
    {
        public SeraFoodCtx() : base("Data Source=.;Trusted_Connection=yes;  Initial Catalog=SeraFood;") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

        }
    }

}