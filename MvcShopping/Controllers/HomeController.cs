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
        // GET: Home
        //首页
        public ActionResult Index()
        {
            return View();
        }

        //商品列表
        public ActionResult ProductList(int Id)
        {
            return View();
        }

        //商品明细
        public ActionResult ProductDetail(int Id)
        {
            return View();
        }
    }
}