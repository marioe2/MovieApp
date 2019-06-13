using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieWebSite.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                return View(ctx.GetCategories(0, 100));
            }
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                CategoryBLL c = ctx.FindCategoryByID(id);
                if (null == c)
                {
                    return View("ItemNotFound");
                }
                else
                {
                    return View(c);
                }

            }
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryBLL c)
        {
            try
            {
                // TODO: Add insert logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.CreateCategory(c.Category);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                CategoryBLL c = ctx.FindCategoryByID(id);
                if (null == c)
                {
                    return View("ItemNotFound");
                }
                else
                {
                    return View(c);
                }

            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryBLL c)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    // TODO: Add update logic here
                    ctx.JustUpdateCategory(id, c.Category);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                CategoryBLL c = ctx.FindCategoryByID(id);
                if (null == c)
                {

                    return View("ItemNotFound");
                }
                else
                {
                    return View(c);
                }

            }
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.DeleteCategory(id);
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
