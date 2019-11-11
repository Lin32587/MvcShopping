using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShopping.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        //显示当前购物车的项目
        public ActionResult Index()
        {
            return View();
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