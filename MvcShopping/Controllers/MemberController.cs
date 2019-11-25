using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShopping.Models;
using System.Web.Security;

namespace MvcShopping.Controllers
{
    public class MemberController : Controller
    {
        MvcShoppingMall db = new MvcShoppingMall();

        // GET: Member
        //会员注册页面
        public ActionResult Register()
        {
            return View();
        }

        private string pwSalt = "AlrySqloPe2Mh784QQwG6jRAfkdPpDa90J0i";

        //写入会员信息
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "RegisterOn,AuthCode")]Members member)
        {
            var chk_member = db.Members.Where(p => p.Email == member.Email).FirstOrDefault();
            if(chk_member != null)
            {
                ModelState.AddModelError("Email", "您输入的Email已经被注册过了");
            }

            if (ModelState.IsValid)
            {
                member.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + member.Password, "SHA1");
                member.RegisterOn = DateTime.Now;
                member.AuthCode = Guid.NewGuid().ToString();

                db.Members.Add(member);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        //显示会员登录页面
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //运行会员登录
        [HttpPost]
        public ActionResult Login(string email,string password,string returnUrl)
        {
            if (ValidateUser(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, false);

                if (String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            ModelState.AddModelError("", "您输入的账号或密码错误");
            return View();
        }

        public bool ValidateUser(string email,string password)
        {
            var hash_pw = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + password, "SHA1");

            var member = (from p in db.Members
                          where p.Email == email && p.Password == hash_pw
                          select p).FirstOrDefault();

            return (member != null);
        }

        public ActionResult Logout()
        {
            //清除Cookies
            FormsAuthentication.SignOut();

            //清除Session
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}