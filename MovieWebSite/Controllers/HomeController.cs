using BusinessLogicLayer;
using MovieWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ContextBLL ctx = new ContextBLL();
            var x = ctx.GetUsers(0, 100);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            // displays empty login screen with predefined returnURL
            LoginModel m = new LoginModel();
            m.Message = TempData["Message"]?.ToString() ?? "";
            m.ReturnURL = TempData["ReturnURL"]?.ToString() ?? @"~/Home";
            m.Email = "Type Email Here";
            m.Password = "Type Password Here";

            return View(m);
        }
        [HttpPost]
        public ActionResult Login(LoginModel info)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                UserBLL user = ctx.FindUserByEmail(info.Email);
                if (user == null)
                {
                    info.Message = $"The EmailAddress '{info.Email}' does not exist in the database";
                    return View(info);
                }
                string actual = user.Password;
                bool validateduser = user.Password == info.Password;

                if (validateduser)
                {
                    Session["AUTHEmail"] = user.Email;
                    Session["AUTHRoles"] = user.Role;
                    return Redirect(info.ReturnURL);
                }
                info.Message = "The password was incorrect";
                return View(info);
            }


        }
        public ActionResult LogOff()
        {
            Session.Remove("AUTHEmail");
            Session.Remove("AUTHRoles");
            return RedirectToAction("Index");
        }

    }
}