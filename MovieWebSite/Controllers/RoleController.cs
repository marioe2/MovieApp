using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionWebSite.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                return View(ctx.GetRoles(0, 100));
            }
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                RoleBLL r = ctx.FindRoleByID(id);
                if (r == null)
                {
                    return View("ItemNotFound");
                }
                else
                {
                    return View(r);
                }

            }
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(RoleBLL r)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.CreateRole(r.Role);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                RoleBLL r = ctx.FindRoleByID(id);
                if (r == null)
                {
                    return View("ItemNotFound");
                }
                else
                {
                    return View(r);
                }

            }
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RoleBLL r)
        {


            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    // TODO: Add update logic here
                    ctx.JustUpdateRole(id, r.Role);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                RoleBLL r = ctx.FindRoleByID(id);
                if (r == null)
                {
                    return View("ItemNotFound");
                }
                else
                {
                    return View(r);
                }

            }
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RoleBLL o)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    // TODO: Add delete logic here
                    ctx.DeleteRole(id);

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
