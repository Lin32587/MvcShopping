using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShopping.Models;

namespace MvcShopping.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        //显示当前购物车的项目
        public ActionResult Index()
        {
            var productCate = new ProductCategory() { Id = 1, Name = "文具" };
            var a = new Product() { Id = 3, Price = 6, Name = "铅笔", ProductCategory = productCate, Color = System.Drawing.Color.White, Description = "", PublishOn = DateTime.Now };
            var data = new List<Cart>
            {
                new Cart(){ Product=a,Amount=10}
            };
            return View(data);
        }

        //添加产品项目到购物车,如果没有传入Amount参数则默认购买数量为1
        [HttpPost]
        public ActionResult AddToCart(int ProductId,int Amount = 1)
        {
            return View();
        }

        //移除购物车项目
        [HttpPost]
        public ActionResult Remove(int ProductId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAmount(int ProductId,int NewAmount)
        {
            return View();
        }
    }
}