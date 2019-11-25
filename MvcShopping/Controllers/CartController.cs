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
        MvcShoppingMall db = new MvcShoppingMall();

        List<Cart> Carts
        {
            get
            {
                if(Session["Carts"] == null)
                {
                    Session["Carts"] = new List<Cart>();
                }
                return (Session["Carts"] as List<Cart>);
            }
            set { Session["Carts"] = value; }
        }

        // GET: Cart
        //显示当前购物车的项目
        public ActionResult Index()
        {
            return View(this.Carts);
        }

        //添加产品项目到购物车,如果没有传入Amount参数则默认购买数量为1
        [HttpPost]
        public ActionResult AddToCart(int ProductId,int Amount = 1)
        {
            var product = db.Products.Find(ProductId);
            if(product == null)
            {
                return HttpNotFound();

            }

            var existingCart = this.Carts.FirstOrDefault(p => p.Product.Id == ProductId);
            if(existingCart != null)
            {
                existingCart.Amount += 1;
            }
            else
            {
                this.Carts.Add(new Cart()
                {
                    Product = product,
                    Amount = Amount
                });
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.Created);
        }

        //移除购物车项目
        [HttpPost]
        public ActionResult Remove(int ProductId)
        {
            var existingCart = this.Carts.FirstOrDefault(p => p.Product.Id == ProductId);
            if(existingCart != null)
            {
                this.Carts.Remove(existingCart);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult UpdateAmount(int ProductId,int NewAmount)
        {
            return View();
        }
    }
}