using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using MvcShopping.Controllers;
using MvcShopping.Models;

namespace MvcShopping.Controllers
{
    public class HomeController : Controller
    {
        MvcShoppingMall db = new MvcShoppingMall();

        // GET: Home
        //首页
        public ActionResult Index()
        {
            var data = db.ProductCategories.ToList();

            if(data.Count == 0)
            {
                db.ProductCategories.Add(new ProductCategory() { Id = 1, Name = "文具" });
                db.ProductCategories.Add(new ProductCategory() { Id = 2, Name = "书籍" });
                db.ProductCategories.Add(new ProductCategory() { Id = 3, Name = "食品" });
                db.SaveChanges();
                data = db.ProductCategories.ToList();
            }
            
            return View(data);
        }

        //商品列表
        public ActionResult ProductList(int Id)
        {
            var productCategory = db.ProductCategories.Find(Id);
            if (productCategory != null)
            {
                var data = productCategory.Products.ToList();

                if (data.Count == 0)
                {
                    productCategory.Products.Add(new Product(){ Name = productCategory.Name + "类别下商品1", Color = Color.Red, Description = "N/A", Price = 99, PublishOn = DateTime.Now, ProductCategory = productCategory });
                    productCategory.Products.Add(new Product(){ Name = productCategory.Name + "类别下商品2", Color = Color.Blue, Description = "N/A", Price = 149, PublishOn = DateTime.Now, ProductCategory = productCategory });
                    db.SaveChanges();
                    data = productCategory.Products.ToList();
                }
                return View(data);
            }
            else
            {
                return HttpNotFound();
            }
        }

        //商品明细
        public ActionResult ProductDetail(int Id)
        {
            var data = db.Products.Find(Id);
            return View(data);
        }
    }
}