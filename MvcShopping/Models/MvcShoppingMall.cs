namespace MvcShopping.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MvcShoppingMall : DbContext
    {
        public MvcShoppingMall()
            : base("name=MvcShoppingMall")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<OrderHeader> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetailItems { get; set; }
    }
}
