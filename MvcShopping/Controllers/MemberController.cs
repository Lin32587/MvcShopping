using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcShopping.Models;
using System.Web.Security;
using System.Net.Mail;

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

                SendAuthCodeToMember(member);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        private void SendAuthCodeToMember(Members member)
        {
            string mailBody =
                System.IO.File.ReadAllText(Server.MapPath("~/App_Data/MemberRegisterEMailTemplate.html"));

            mailBody = mailBody.Replace("{{Name}}", member.Name);
            mailBody = mailBody.Replace("{{RegisterOn}}", member.RegisterOn.ToString("F"));
            var auth_url = new UriBuilder(Request.Url)
            {
                Path = Url.Action("VaildateRegister", new { id = member.AuthCode }),
                Query = ""
            };
            mailBody = mailBody.Replace("{{AUTH_URL}}", auth_url.ToString());
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("Salty lin", "aizj11");
                SmtpServer.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("lin3258714569@gmail.com");
                mail.To.Add(member.Email);
                mail.Subject = "MvcShopping会员确认信";
                mail.IsBodyHtml = true;

                SmtpServer.Send(mail);
            }
            catch(Exception ex)
            {
                //throw ex;
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
            //ModelState.AddModelError("", "您输入的账号或密码错误");
            return View();
        }

        public bool ValidateUser(string email,string password)
        {
            var hash_pw = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + password, "SHA1");

            var member = (from p in db.Members
                          where p.Email == email && p.Password == hash_pw
                          select p).FirstOrDefault();
            
            if(member != null)
            {
                member.AuthCode = null;
                db.SaveChanges();
                Session["user"] = member;
                return true;
            }
            else
            {
                ModelState.AddModelError("", "账号或密码错误");
                return false;
            }
            
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