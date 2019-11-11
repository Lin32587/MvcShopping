﻿using System;
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
        // GET: Home
        //首页
        public ActionResult Index()
        {
            var data = new List<ProductCategory>()
            {
                new ProductCategory(){Id=1,Name="文具"},
                new ProductCategory(){Id=2,Name="书籍"},
                new ProductCategory(){Id=3,Name="食品"},
            };
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
            return View();
        }
    }
}