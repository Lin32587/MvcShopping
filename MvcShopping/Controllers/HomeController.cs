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
        public ActionResult ProductList(int Id,string Name)
        {
            var productCategory = new ProductCategory() { Id = Id, Name = Name };
            var data = new List<Product>()
            {
                new Product(){Id=1,ProductCategory=productCategory,Name="中性笔",Description="N/A",Price=30,PublishOn=DateTime.Now,Color=Color.Blue},
                new Product(){Id=1,ProductCategory=productCategory,Name="铅笔",Description="N/A",Price=5,PublishOn=DateTime.Now,Color=Color.Black},
            };
            return View(data);
        }

        //商品明细
        public ActionResult ProductDetail(int Id)
        {
            var productCategory = new ProductCategory() { Id = Id, Name = "文具" };
            var data = new Product()
            {
                Id = Id,
                ProductCategory = productCategory,
                Name = "商品" + Id,
                Description = "N/A",
                Price = 40,
                PublishOn = DateTime.Now,
                Color = Color.Transparent
            };
            return View(data);
        }
    }
}