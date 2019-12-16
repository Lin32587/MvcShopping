using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using MvcShopping.Controllers;
using MvcShopping.Models;
using PagedList;

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
                db.ProductCategories.Add(new ProductCategory() { Id = 1 });
                db.ProductCategories.Add(new ProductCategory() { Id = 2 });
                db.ProductCategories.Add(new ProductCategory() { Id = 3 });
                db.SaveChanges();
                data = db.ProductCategories.ToList();
            }
            
            return View(data);
        }

        //商品列表
        public ActionResult ProductList(int Id,int p = 1)
        {
            var productCategory = db.ProductCategories.Find(Id);
            if (productCategory != null)
            {
                var data = productCategory.Products.ToList();

                var pagedData = data.ToPagedList(pageNumber: p, pageSize: 4);

                return View(pagedData);
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