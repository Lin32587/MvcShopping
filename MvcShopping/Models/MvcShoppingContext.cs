using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcShopping.Models
{
    public class MvcShoppingContext:DbContext
    {
        public MvcShoppingContext()
            :base("name=MvcShoppingDb")
        {
            
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Members> Members  { get; set; }
        public DbSet<OrderHeader> Orders   { get; set; }
        public DbSet<OrderDetail> OrderDetailItems    { get; set; }
    }
}