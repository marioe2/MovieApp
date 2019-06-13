using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace MovieWebSite.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                return View(ctx.GetUsers(0, 100));
            }
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                UserBLL U = ctx.FindUserByID(id);
                if (U == null)
                {
                    return View("ItemNotFound");
                }
                else
                {
                    return View(U);
                }

            }
        }

        

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserBLL u)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.CreateUser(u.Email, u.UserName, u.Password,u.RoleID);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                UserBLL U = ctx.FindUserByID(id);
                if (U == null)
                {
                    return View("ItemNotFound");
                }
                else
                {
                    return View(U);
                }

            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserBLL u)
        {
            try
            {
                // TODO: Add update logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.JustUpdateUser(id, u.Email, u.UserName, u.Password,u.RoleID);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                UserBLL U = ctx.FindUserByID(id);
                if (U == null)
                {
                    return View("ItemNotFound");
                }
                else
                {
                    return View(U);
                }

            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.DeleteUser(id);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}
